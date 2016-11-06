using System.Collections.Generic;
using System.IO;
using Syroot.NintenTools.Byaml;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents the contents of a *_muunt*.byaml file, holding information about the properties, paths and Objs
    /// on a course.
    /// </summary>
    public class CourseDefinition
    {
        // ---- CONSTRUCTORS & DESTRUCTOR ------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="CourseDefinition"/> class from the file with the given name.
        /// </summary>
        /// <param name="fileName">The name of the file from which the instance will be loaded.</param>
        public CourseDefinition(string fileName)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                Load(stream);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CourseDefinition"/> class from the given stream.
        /// </summary>
        /// <param name="stream">The stream from which the instance will be loaded.</param>
        public CourseDefinition(Stream stream)
        {
            Load(stream);
        }

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets a globally applied effect index.
        /// </summary>
        public int? EffectSW { get; set; }

        /// <summary>
        /// Gets or sets a value indicating how headlights are turned on or off on this course.
        /// </summary>
        public CourseHeadLight? HeadLight { get; set; }

        /// <summary>
        /// Gets or sets a value which indicates whether the first curve is a left turn. Has to be in sync with
        /// <see cref="FirstCurve"/>.
        /// </summary>
        public bool? IsFirstLeft { get; set; }

        /// <summary>
        /// Gets or sets a value which indicates whether the first curve is a &quot;left&quot; or &quot;right&quot;
        /// turn. Has to be in sync with <see cref="IsFirstLeft"/>.
        /// </summary>
        public string FirstCurve { get; set; }

        /// <summary>
        /// Gets or sets an unknown value.
        /// </summary>
        public bool? IsJugemAbove { get; set; }

        /// <summary>
        /// Gets or sets an unknown value.
        /// </summary>
        public int? JugemAbove { get; set; }

        /// <summary>
        /// Gets or sets an unknown value.
        /// </summary>
        public int? LapJugemPos { get; set; }

        /// <summary>
        /// Gets or sets the number of laps which have to be driven to finish the track.
        /// </summary>
        public int? LapCount { get; set; }

        /// <summary>
        /// Gets or sets a list of Obj parameters which are applied globally.
        /// </summary>
        public int[] ObjParams { get; set; }

        /// <summary>
        /// Gets or sets the number of pattern sets out of which one is picked randomly at start.
        /// </summary>
        public int? PatternCount { get; set; }

        /// <summary>
        /// Gets or sets the list of <see cref="Area"/> instances.
        /// </summary>
        public List<Area> Areas { get; set; }

        /// <summary>
        /// Gets or sets the list of <see cref="Clip"/> instances.
        /// </summary>
        public List<Clip> Clips { get; set; }

        /// <summary>
        /// Gets or sets the list of <see cref="ClipArea"/> instances.
        /// </summary>
        public List<ClipArea> ClipAreas { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ClipPattern"/> instance.
        /// </summary>
        public ClipPattern ClipPattern { get; set; }

        /// <summary>
        /// Gets or sets the list of <see cref="EffectArea"/> instances.
        /// </summary>
        public List<EffectArea> EffectAreas { get; set; }

        /// <summary>
        /// Gets or sets the list of <see cref="EnemyPath"/> instances.
        /// </summary>
        public List<EnemyPath> EnemyPaths { get; set; }

        /// <summary>
        /// Gets or sets the list of <see cref="GlidePath"/> instances.
        /// </summary>
        public List<GlidePath> GlidePaths { get; set; }

        /// <summary>
        /// Gets or sets the list of ObjId's of objects to load for the track.
        /// </summary>
        public List<int> MapObjIdList { get; set; }

        /// <summary>
        /// Gets or sets the list of ResName's of objects to load for the track.
        /// </summary>
        public List<string> MapObjResList { get; set; }

        /// <summary>
        /// Gets or sets the list of <see cref="Obj"/> instances.
        /// </summary>
        public List<Obj> Objs { get; set; }

        /// <summary>
        /// Gets or sets the list of <see cref="SoundObj"/> instances.
        /// </summary>
        public List<SoundObj> SoundObjs { get; set; }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Saves the definition into the file with the given name.
        /// </summary>
        /// <param name="fileName">The name of the file in which the definitions will be stored.</param>
        public void Save(string fileName)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                Save(stream);
            }
        }

        /// <summary>
        /// Saves the definition into the the given stream.
        /// </summary>
        /// <param name="stream">The stream in which the definitions will be stored.</param>
        public void Save(Stream stream)
        {
            IDictionary<string, dynamic> node = new Dictionary<string, dynamic>();

            ByamlFile.SetValue(node, "EffectSW", EffectSW);
            ByamlFile.SetValue(node, "HeadLight", (int?)HeadLight);
            ByamlFile.SetValue(node, "IsFirstLeft", IsFirstLeft);
            ByamlFile.SetValue(node, "FirstCurve", FirstCurve);
            ByamlFile.SetValue(node, "IsJugemAbove", IsJugemAbove);
            ByamlFile.SetValue(node, "JugemAbove", JugemAbove);
            ByamlFile.SetValue(node, "LapJugemPos", LapJugemPos);
            ByamlFile.SetValue(node, "LapNumber", LapCount);
            ByamlFile.SetValue(node, "PatternNum", PatternCount);
            for (int i = 0; i < ObjParams.Length; i++)
            {
                ByamlFile.SetValue(node, "OBJPrm" + i.ToString(), ObjParams[i]);
            }
            ByamlFile.SetValue(node, "Area", ByamlFile.SerializeList(Areas));
            ByamlFile.SetValue(node, "Clip", ByamlFile.SerializeList(Clips));
            ByamlFile.SetValue(node, "ClipArea", ByamlFile.SerializeList(ClipAreas));
            ByamlFile.SetValue(node, "EffectArea", ByamlFile.SerializeList(EffectAreas));
            ByamlFile.SetValue(node, "EnemyPaths", ByamlFile.SerializeList(EnemyPaths));
            ByamlFile.SetValue(node, "GlidePaths", ByamlFile.SerializeList(GlidePaths));
            ByamlFile.SetValue(node, "MapObjIdList", MapObjIdList);
            ByamlFile.SetValue(node, "MapObjResList", MapObjResList);
            ByamlFile.SetValue(node, "Obj", ByamlFile.SerializeList(Objs));
            ByamlFile.SetValue(node, "SoundObj", ByamlFile.SerializeList(SoundObjs));

            ByamlFile.Save(stream, node);
        }

        // ---- METHODS (PRIVATE) --------------------------------------------------------------------------------------

        private void Load(Stream stream)
        {
            dynamic node = ByamlFile.Load(stream);

            EffectSW = ByamlFile.GetValue(node, "EffectSW");
            HeadLight = (CourseHeadLight?)ByamlFile.GetValue(node, "HeadLight");
            IsFirstLeft = ByamlFile.GetValue(node, "IsFirstLeft");
            FirstCurve = ByamlFile.GetValue(node, "FirstCurve");
            IsJugemAbove = ByamlFile.GetValue(node, "IsJugemAbove");
            JugemAbove = ByamlFile.GetValue(node, "JugemAbove");
            LapJugemPos = ByamlFile.GetValue(node, "LapJugemPos");
            LapCount = ByamlFile.GetValue(node, "LapNumber");
            PatternCount = ByamlFile.GetValue(node, "PatternNum");
            ObjParams = new int[8];
            for (int i = 0; i < ObjParams.Length; i++)
            {
                ObjParams[i] = ByamlFile.GetValue(node, "OBJPrm" + i.ToString()) ?? 0;
            }

            Areas = ByamlFile.DeserializeList<Area>(ByamlFile.GetValue(node, "Area"));
            Clips = ByamlFile.DeserializeList<Clip>(ByamlFile.GetValue(node, "Clip"));
            ClipAreas = ByamlFile.DeserializeList<ClipArea>(ByamlFile.GetValue(node, "ClipArea"));
            ClipPattern = ByamlFile.Deserialize<ClipPattern>(ByamlFile.GetValue(node, "ClipPattern"));
            EffectAreas = ByamlFile.DeserializeList<EffectArea>(ByamlFile.GetValue(node, "EffectArea"));
            EnemyPaths = ByamlFile.DeserializeList<EnemyPath>(ByamlFile.GetValue(node, "EnemyPath"));
            GlidePaths = ByamlFile.DeserializeList<GlidePath>(ByamlFile.GetValue(node, "GlidePath"));
            MapObjIdList = ByamlFile.GetList<int>(node["MapObjIdList"]);
            MapObjResList = ByamlFile.GetList<string>(node["MapObjResList"]);
            Objs = ByamlFile.DeserializeList<Obj>(node["Obj"]);
            SoundObjs = ByamlFile.DeserializeList<SoundObj>(ByamlFile.GetValue(node, "SoundObj"));

            // After loading all the instances, allow references to be resolved.
            Areas?.ForEach(x => x.DeserializeReferences(this));
            EnemyPaths?.ForEach(x => x.DeserializeReferences(this));
            GlidePaths?.ForEach(x => x.DeserializeReferences(this));
            Objs.ForEach(x => x.DeserializeReferences(this));
        }
    }

    // ---- ENUMERATIONS -----------------------------------------------------------------------------------------------

    /// <summary>
    /// Specifies how headlights are displayed on a course.
    /// </summary>
    public enum CourseHeadLight
    {
        /// <summary>
        /// Headlights are globally turned off.
        /// </summary>
        Off = 0,

        /// <summary>
        /// Headlights are globally turned on.
        /// </summary>
        On = 1,

        /// <summary>
        /// The lap path decides when headlights are turned on.
        /// </summary>
        ByLapPath = 2
    }
}
