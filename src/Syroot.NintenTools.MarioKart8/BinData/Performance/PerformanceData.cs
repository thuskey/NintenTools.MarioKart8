using System;
using System.IO;

namespace Syroot.NintenTools.MarioKart8.BinData.Performance
{
    /// <summary>
    /// Represents the contents of the &quot;Performance.bin&quot; file as it appears in 4.1 versions of the game.
    /// </summary>
    public class PerformanceData
    {
        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="PerformanceData"/> class from the file with the given name.
        /// </summary>
        /// <param name="fileName">The name of the file from which the instance will be loaded.</param>
        public PerformanceData(string fileName)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                Load(stream);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PerformanceData"/> class from the given stream.
        /// </summary>
        /// <param name="stream">The stream from which the instance will be loaded.</param>
        public PerformanceData(Stream stream)
        {
            Load(stream);
        }

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the 21 <see cref="WeightStat"/> instances.
        /// </summary>
        public WeightStat[] WeightStats { get; set; }

        /// <summary>
        /// Gets or sets the 21 <see cref="AccelerationStat"/> instances.
        /// </summary>
        public AccelerationStat[] AccelerationStats { get; set; }

        /// <summary>
        /// Gets or sets the 21 <see cref="OuterslipStat"/> instances.
        /// </summary>
        public OuterslipStat[] OuterslipStats { get; set; }

        /// <summary>
        /// Gets or sets the 21 <see cref="OffroadStat"/> instances.
        /// </summary>
        public OffroadStat[] OffroadStats { get; set; }

        /// <summary>
        /// Gets or sets the 21 <see cref="TurboStat"/> instances.
        /// </summary>
        public TurboStat[] TurboStats { get; set; }

        /// <summary>
        /// Gets or sets the 21 <see cref="SpeedStat"/> instances for speed while on normal ground.
        /// </summary>
        public SpeedStat[] SpeedGroundStats { get; set; }

        /// <summary>
        /// Gets or sets the 21 <see cref="SpeedStat"/> instances for speed when underwater.
        /// </summary>
        public SpeedStat[] SpeedWaterStats { get; set; }

        /// <summary>
        /// Gets or sets the 21 <see cref="SpeedStat"/> instances for speed in antigravity sections.
        /// </summary>
        public SpeedStat[] SpeedAntigravityStats { get; set; }

        /// <summary>
        /// Gets or sets the 21 <see cref="SpeedAirStat"/> instances for speed while gliding.
        /// </summary>
        public SpeedAirStat[] SpeedAirStats { get; set; }

        /// <summary>
        /// Gets or sets the 21 <see cref="HandlingStat"/> instances for turn rates when on normal ground.
        /// </summary>
        public HandlingStat[] HandlingGroundStats { get; set; }

        /// <summary>
        /// Gets or sets the 21 <see cref="HandlingStat"/> instances for turn rates while underwater.
        /// </summary>
        public HandlingStat[] HandlingWaterStats { get; set; }

        /// <summary>
        /// Gets or sets the 21 <see cref="HandlingStat"/> instances for turn rates in antigravity sections.
        /// </summary>
        public HandlingStat[] HandlingAntigravityStats { get; set; }

        /// <summary>
        /// Gets or sets the 21 <see cref="HandlingAirStat"/> instances for turn rates while gliding.
        /// </summary>
        public HandlingAirStat[] HandlingAirStats { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="KartPoints"/>.
        /// </summary>
        public KartPoints KartPoints { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DriverPoints"/>.
        /// </summary>
        public DriverPoints DriverPoints { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="TirePoints"/>.
        /// </summary>
        public TirePoints TirePoints { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="GliderPoints"/>.
        /// </summary>
        public GliderPoints GliderPoints { get; set; }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Saves the data into the file with the given name.
        /// </summary>
        /// <param name="fileName">The name of the file in which the data will be stored.</param>
        public void Save(string fileName)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                Save(stream);
            }
        }

        /// <summary>
        /// Saves the data into the the given stream.
        /// </summary>
        /// <param name="stream">The stream in which the data will be stored.</param>
        public void Save(Stream stream)
        {
            BinFile binFile = new BinFile("PERF", 84, 1000);
            binFile.Sections.Add(CreateSection("PRWG", WeightStats));
            binFile.Sections.Add(CreateSection("PRAC", AccelerationStats));
            binFile.Sections.Add(CreateSection("PRON", OuterslipStats));
            binFile.Sections.Add(CreateSection("PROF", OffroadStats));
            binFile.Sections.Add(CreateSection("PRMT", TurboStats));
            binFile.Sections.Add(CreateSection("PRSL", SpeedGroundStats));
            binFile.Sections.Add(CreateSection("PRSW", SpeedWaterStats));
            binFile.Sections.Add(CreateSection("PRSA", SpeedAntigravityStats));
            binFile.Sections.Add(CreateSection("PRSG", SpeedAirStats));
            binFile.Sections.Add(CreateSection("PRTL", HandlingGroundStats));
            binFile.Sections.Add(CreateSection("PRTW", HandlingWaterStats));
            binFile.Sections.Add(CreateSection("PRTA", HandlingAntigravityStats));
            binFile.Sections.Add(CreateSection("PRTG", HandlingAirStats));
            binFile.Sections.Add(CreateSection("PTBD", KartPoints.ToPointSetArray()));
            binFile.Sections.Add(CreateSection("PTDV", DriverPoints.ToPointSetArray()));
            binFile.Sections.Add(CreateSection("PTTR", TirePoints.ToPointSetArray()));
            binFile.Sections.Add(CreateSection("PTWG", GliderPoints.ToPointSetArray()));
            binFile.Save(stream);
        }

        // ---- METHODS (PRIVATE) --------------------------------------------------------------------------------------

        private void Load(Stream stream)
        {
            BinFile binFile = new BinFile(stream);
            WeightStats = ((ByteArraysGroup)binFile.Sections["PRWG"].Groups[0]).ToStructArray<WeightStat>();
            AccelerationStats = ((ByteArraysGroup)binFile.Sections["PRAC"].Groups[0]).ToStructArray<AccelerationStat>();
            OuterslipStats = ((ByteArraysGroup)binFile.Sections["PRON"].Groups[0]).ToStructArray<OuterslipStat>();
            OffroadStats = ((ByteArraysGroup)binFile.Sections["PROF"].Groups[0]).ToStructArray<OffroadStat>();
            TurboStats = ((ByteArraysGroup)binFile.Sections["PRMT"].Groups[0]).ToStructArray<TurboStat>();
            SpeedGroundStats = ((ByteArraysGroup)binFile.Sections["PRSL"].Groups[0]).ToStructArray<SpeedStat>();
            SpeedWaterStats = ((ByteArraysGroup)binFile.Sections["PRSW"].Groups[0]).ToStructArray<SpeedStat>();
            SpeedAntigravityStats = ((ByteArraysGroup)binFile.Sections["PRSA"].Groups[0]).ToStructArray<SpeedStat>();
            SpeedAirStats = ((ByteArraysGroup)binFile.Sections["PRSG"].Groups[0]).ToStructArray<SpeedAirStat>();
            HandlingGroundStats = ((ByteArraysGroup)binFile.Sections["PRTL"].Groups[0]).ToStructArray<HandlingStat>();
            HandlingWaterStats = ((ByteArraysGroup)binFile.Sections["PRTW"].Groups[0]).ToStructArray<HandlingStat>();
            HandlingAntigravityStats = ((ByteArraysGroup)binFile.Sections["PRTA"].Groups[0]).ToStructArray<HandlingStat>();
            HandlingAirStats = ((ByteArraysGroup)binFile.Sections["PRTG"].Groups[0]).ToStructArray<HandlingAirStat>();
            KartPoints = new KartPoints((ByteArraysGroup)binFile.Sections["PTBD"].Groups[0]);
            DriverPoints = new DriverPoints((ByteArraysGroup)binFile.Sections["PTDV"].Groups[0]);
            TirePoints = new TirePoints((ByteArraysGroup)binFile.Sections["PTTR"].Groups[0]);
            GliderPoints = new GliderPoints((ByteArraysGroup)binFile.Sections["PTWG"].Groups[0]);
        }

        private Section CreateSection<T>(string name, T[] instances)
        {
            Section section = new Section(name, SectionType.ByteArrays);
            ByteArraysGroup group = new ByteArraysGroup();
            group.FromStructArray(instances);
            section.Groups.Add(group);
            return section;
        }
    }
}
