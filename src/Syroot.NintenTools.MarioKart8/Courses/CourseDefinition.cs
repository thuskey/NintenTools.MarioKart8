using System.Collections.Generic;
using System.IO;
using Syroot.NintenTools.Byaml.Serialization;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents the contents of a *_muunt*.byaml file, holding information about the properties, paths and objects on
    /// a course.
    /// </summary>
    [ByamlObject]
    public class CourseDefinition : IByamlSerializable
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
        [ByamlMember(Optional = true)]
        public int? EffectSW { get; set; }

        /// <summary>
        /// Gets or sets a value indicating how headlights are turned on or off on this course.
        /// </summary>
        [ByamlMember(Optional = true)]
        public CourseHeadLight? HeadLight { get; set; }

        /// <summary>
        /// Gets or sets a value which indicates whether the first curve is a left turn. Has to be in sync with
        /// <see cref="FirstCurve"/>.
        /// </summary>
        [ByamlMember(Optional = true)]
        public bool? IsFirstLeft { get; set; }

        /// <summary>
        /// Gets or sets a value which indicates whether the first curve is a &quot;left&quot; or &quot;right&quot;
        /// turn. Has to be in sync with <see cref="IsFirstLeft"/>.
        /// </summary>
        [ByamlMember(Optional = true)]
        public string FirstCurve { get; set; }

        /// <summary>
        /// Gets or sets an unknown value.
        /// </summary>
        [ByamlMember(Optional = true)]
        public bool? IsJugemAbove { get; set; }

        /// <summary>
        /// Gets or sets an unknown value.
        /// </summary>
        [ByamlMember(Optional = true)]
        public int? JugemAbove { get; set; }

        /// <summary>
        /// Gets or sets an unknown value.
        /// </summary>
        [ByamlMember(Optional = true)]
        public int? LapJugemPos { get; set; }

        /// <summary>
        /// Gets or sets the number of laps which have to be driven to finish the track.
        /// </summary>
        [ByamlMember("LapNumber", Optional = true)]
        public int? LapCount { get; set; }

        /// <summary>
        /// Gets or sets a list of Obj parameters which are applied globally.
        /// </summary>
        public List<int> ObjParams { get; set; }

        /// <summary>
        /// Gets or sets the number of pattern sets out of which one is picked randomly at start.
        /// </summary>
        [ByamlMember("PatternNum", Optional = true)]
        public int? PatternCount { get; set; }

        // ---- Areas ----

        /// <summary>
        /// Gets or sets the list of <see cref="Area"/> instances.
        /// </summary>
        [ByamlMember("Area", Optional = true)]
        public List<Area> Areas { get; set; }

        /// <summary>
        /// Gets or sets the list of <see cref="EffectArea"/> instances.
        /// </summary>
        [ByamlMember("EffectArea", Optional = true)]
        public List<EffectArea> EffectAreas { get; set; }

        // ---- Clipping ----

        /// <summary>
        /// Gets or sets the list of <see cref="Clip"/> instances.
        /// </summary>
        [ByamlMember("Clip", Optional = true)]
        public List<Clip> Clips { get; set; }

        /// <summary>
        /// Gets or sets the list of <see cref="ClipArea"/> instances.
        /// </summary>
        [ByamlMember("ClipArea", Optional = true)]
        public List<ClipArea> ClipAreas { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ClipPattern"/> instance.
        /// </summary>
        [ByamlMember(Optional = true)]
        public ClipPattern ClipPattern { get; set; }

        // ---- Paths ----

        /// <summary>
        /// Gets or sets the list of <see cref="Path"/> instances.
        /// </summary>
        [ByamlMember("Path", Optional = true)]
        public List<Path> Paths { get; set; }

        /// <summary>
        /// Gets or sets the list of <see cref="EnemyPath"/> instances.
        /// </summary>
        [ByamlMember("EnemyPath", Optional = true)]
        public List<EnemyPath> EnemyPaths { get; set; }

        /// <summary>
        /// Gets or sets the list of <see cref="GCameraPath"/> instances.
        /// </summary>
        [ByamlMember("GCameraPath", Optional = true)]
        public List<GCameraPath> GCameraPaths { get; set; }

        /// <summary>
        /// Gets or sets the list of <see cref="GlidePath"/> instances.
        /// </summary>
        [ByamlMember("GlidePath", Optional = true)]
        public List<GlidePath> GlidePaths { get; set; }

        /// <summary>
        /// Gets or sets the list of <see cref="GravityPath"/> instances.
        /// </summary>
        [ByamlMember("GravityPath", Optional = true)]
        public List<GravityPath> GravityPaths { get; set; }

        /// <summary>
        /// Gets or sets the list of <see cref="ItemPath"/> instances.
        /// </summary>
        [ByamlMember("ItemPath", Optional = true)]
        public List<ItemPath> ItemPaths { get; set; }

        /// <summary>
        /// Gets or sets the list of <see cref="JugemPath"/> instances.
        /// </summary>
        [ByamlMember("JugemPath", Optional = true)]
        public List<JugemPath> JugemPaths { get; set; }

        /// <summary>
        /// Gets or sets the list of <see cref="LapPath"/> instances.
        /// </summary>
        [ByamlMember("LapPath", Optional = true)]
        public List<LapPath> LapPaths { get; set; }

        /// <summary>
        /// Gets or sets the list of <see cref="ObjPath"/> instances.
        /// </summary>
        [ByamlMember("ObjPath", Optional = true)]
        public List<ObjPath> ObjPaths { get; set; }

        /// <summary>
        /// Gets or sets the list of <see cref="PullPath"/> instances.
        /// </summary>
        [ByamlMember("PullPath", Optional = true)]
        public List<PullPath> PullPaths { get; set; }

        // ---- Objects ----

        /// <summary>
        /// Gets or sets the list of ObjId's of objects to load for the track.
        /// </summary>
        [ByamlMember]
        public List<int> MapObjIdList { get; set; }

        /// <summary>
        /// Gets or sets the list of ResName's of objects to load for the track.
        /// </summary>
        [ByamlMember]
        public List<string> MapObjResList { get; set; }

        /// <summary>
        /// Gets or sets the list of <see cref="Obj"/> instances.
        /// </summary>
        [ByamlMember("Obj")]
        public List<Obj> Objs { get; set; }

        /// <summary>
        /// Gets or sets the list of <see cref="SoundObj"/> instances.
        /// </summary>
        [ByamlMember("SoundObj", Optional = true)]
        public List<SoundObj> SoundObjs { get; set; }

        // ---- Cameras ----

        /// <summary>
        /// Gets or sets the list of <see cref="IntroCamera"/> instances.
        /// </summary>
        [ByamlMember("IntroCamera", Optional = true)]
        public List<IntroCamera> IntroCameras { get; set; }

        /// <summary>
        /// Gets or sets the list of <see cref="ReplayCamera"/> instances.
        /// </summary>
        [ByamlMember("ReplayCamera", Optional = true)]
        public List<ReplayCamera> ReplayCameras { get; set; }

        // ---- METHODS(PUBLIC) ---------------------------------------------------------------------------------------

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
            // Before saving all the instances, allow references to be resolved.
            Areas?.ForEach(x => x.SerializeReferences(this));

            EnemyPaths?.ForEach(x => x.SerializeReferences(this));
            GCameraPaths?.ForEach(x => x.SerializeReferences(this));
            GlidePaths?.ForEach(x => x.SerializeReferences(this));
            GravityPaths?.ForEach(x => x.SerializeReferences(this));
            ItemPaths?.ForEach(x => x.SerializeReferences(this));
            JugemPaths?.ForEach(x => x.SerializeReferences(this));
            LapPaths?.ForEach(x => x.SerializeReferences(this));
            PullPaths?.ForEach(x => x.SerializeReferences(this));

            Objs.ForEach(x => x.SerializeReferences(this));

            ReplayCameras?.ForEach(x => x.SerializeReferences(this));

            // Save the serialized values.
            ByamlSerializer serializer = new ByamlSerializer(new ByamlSerializerSettings()
            {
                SupportPaths = true,
                Version = ByamlVersion.Version1
            });
            serializer.Serialize(stream, this);
        }

        /// <summary>
        /// Reads data from the given <paramref name="dictionary"/> to satisfy members.
        /// </summary>
        /// <param name="dictionary">The <see cref="IDictionary{String, Object}"/> to read the data from.</param>
        public void DeserializeByaml(IDictionary<string, object> dictionary)
        {
            // ObjParams
            ObjParams = new List<int>();
            for (int i = 1; i <= 8; i++)
            {
                object objParam;
                if (dictionary.TryGetValue("OBJPrm" + i.ToString(), out objParam))
                {
                    ObjParams.Add((int)objParam);
                }
            }
        }

        /// <summary>
        /// Writes instance members into the given <paramref name="dictionary"/> to store them as BYAML data.
        /// </summary>
        /// <param name="dictionary">The <see cref="Dictionary{String, Object}"/> to store the data in.</param>
        public void SerializeByaml(IDictionary<string, object> dictionary)
        {
            // ObjParams
            for (int i = 1; i <= ObjParams.Count; i++)
            {
                dictionary["OBJPrm" + i.ToString()] = ObjParams[i - 1];
            }
        }

        // ---- METHODS (PRIVATE) --------------------------------------------------------------------------------------

        private void Load(Stream stream)
        {
            // Load all the values from the stream.
            ByamlSerializer serializer = new ByamlSerializer(new ByamlSerializerSettings()
            {
                SupportPaths = true,
                Version = ByamlVersion.Version1
            });
            serializer.Deserialize(stream, this);

            // After loading all the instances, allow references to be resolved.
            Areas?.ForEach(x => x.DeserializeReferences(this));

            EnemyPaths?.ForEach(x => x.DeserializeReferences(this));
            GCameraPaths?.ForEach(x => x.DeserializeReferences(this));
            GlidePaths?.ForEach(x => x.DeserializeReferences(this));
            GravityPaths?.ForEach(x => x.DeserializeReferences(this));
            ItemPaths?.ForEach(x => x.DeserializeReferences(this));
            JugemPaths?.ForEach(x => x.DeserializeReferences(this));
            LapPaths?.ForEach(x => x.DeserializeReferences(this));
            ObjPaths?.ForEach(x => x.DeserializeReferences(this));
            Paths?.ForEach(x => x.DeserializeReferences(this));
            PullPaths?.ForEach(x => x.DeserializeReferences(this));

            Objs.ForEach(x => x.DeserializeReferences(this));

            ReplayCameras?.ForEach(x => x.DeserializeReferences(this));
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
