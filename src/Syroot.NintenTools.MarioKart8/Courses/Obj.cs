using System.Collections.Generic;
using Syroot.NintenTools.Byaml.Serialization;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents an Obj placed on the course.
    /// </summary>
    public class Obj : SpatialObject, IByamlSerializable, ICourseReferencable
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        // References to paths and their points.
        [ByamlMember("Obj_Path", Optional = true)]
        private int? _pathIndex;
        [ByamlMember("Obj_PathPoint", Optional = true)]
        private int? _pathPointIndex;
        [ByamlMember("Obj_LapPath", Optional = true)]
        private int? _lapPathIndex;
        [ByamlMember("Obj_LapPoint", Optional = true)]
        private int? _lapPathPointIndex;
        [ByamlMember("Obj_ObjPath", Optional = true)]
        private int? _objPathIndex;
        [ByamlMember("Obj_ObjPoint", Optional = true)]
        private int? _objPathPointIndex;
        [ByamlMember("Obj_EnemyPath1", Optional = true)]
        private int? _enemyPath1Index;
        [ByamlMember("Obj_EnemyPath2", Optional = true)]
        private int? _enemyPath2Index;
        [ByamlMember("Obj_ItemPath1", Optional = true)]
        private int? _itemPath1Index;
        [ByamlMember("Obj_ItemPath2", Optional = true)]
        private int? _itemPath2Index;

        // References to other unit objects.
        [ByamlMember("Area_Obj", Optional = true)]
        private int? _areaIndex;
        [ByamlMember("Obj_Obj", Optional = true)]
        private int? _objIndex;

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the ID determining the type of this object.
        /// </summary>
        [ByamlMember]
        public int ObjId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether collision detection with this Obj will be skipped.
        /// </summary>
        [ByamlMember(Optional = true)]
        public bool? NoCol { get; set; }

        /// <summary>
        /// Gets or sets an unknown setting which has never been used in the original courses.
        /// </summary>
        [ByamlMember]
        public bool TopView { get; set; }

        /// <summary>
        /// Gets or sets an unknown setting.
        /// </summary>
        [ByamlMember(Optional = true)]
        public bool? Single { get; set; }

        /// <summary>
        /// Gets or sets the speed in which a path is followed.
        /// </summary>
        [ByamlMember]
        public float Speed { get; set; }
        
        /// <summary>
        /// Gets or sets the <see cref="Courses.Path"/> this Obj is attached to.
        /// </summary>
        public Path Path { get; set; }

        /// <summary>
        /// Gets or sets the point in the <see cref="Path"/> this Obj is attached to.
        /// </summary>
        public PathPoint PathPoint { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Courses.LapPath"/> this Obj is attached to.
        /// </summary>
        public LapPath LapPath { get; set; }

        /// <summary>
        /// Gets or sets the point in the <see cref="LapPath"/> this Obj is attached to.
        /// </summary>
        public LapPathPoint LapPathPoint { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Courses.ObjPath"/> this Obj is attached to.
        /// </summary>
        public ObjPath ObjPath { get; set; }

        /// <summary>
        /// Gets or sets the point in the <see cref="Courses.ObjPath"/> this Obj is attached to.
        /// </summary>
        public ObjPathPoint ObjPathPoint { get; set; }

        /// <summary>
        /// Gets or sets the first <see cref="EnemyPath"/> this Obj is attached to.
        /// </summary>
        public EnemyPath EnemyPath1 { get; set; }

        /// <summary>
        /// Gets or sets the second <see cref="EnemyPath"/> this Obj is attached to.
        /// </summary>
        public EnemyPath EnemyPath2 { get; set; }

        /// <summary>
        /// Gets or sets the first <see cref="ItemPath"/> this Obj is attached to.
        /// </summary>
        public ItemPath ItemPath1 { get; set; }

        /// <summary>
        /// Gets or sets the second <see cref="ItemPath"/> this Obj is attached to.
        /// </summary>
        public ItemPath ItemPath2 { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Area"/> this Obj is attached to.
        /// </summary>
        public Area ParentArea { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Obj"/> this Obj is attached to.
        /// </summary>
        public Obj ParentObj { get; set; }

        /// <summary>
        /// Gets or sets the game modes in which this Obj will appear.
        /// </summary>
        public ModeInclusion ModeInclusion { get; set; }

        /// <summary>
        /// Gets or sets an array of 8 float values further controlling object behavior.
        /// </summary>
        [ByamlMember]
        public List<float> Params { get; set; }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Reads data from the given <paramref name="dictionary"/> to satisfy members.
        /// </summary>
        /// <param name="dictionary">The <see cref="IDictionary{String, Object}"/> to read the data from.</param>
        public void DeserializeByaml(IDictionary<string, object> dictionary)
        {
            ModeInclusion = ModeInclusion.FromDictionary(dictionary);
        }

        /// <summary>
        /// Writes instance members into the given <paramref name="dictionary"/> to store them as BYAML data.
        /// </summary>
        /// <param name="dictionary">The <see cref="Dictionary{String, Object}"/> to store the data in.</param>
        public void SerializeByaml(IDictionary<string, object> dictionary)
        {
            ModeInclusion.ToDictionary(dictionary);
        }

        /// <summary>
        /// Allows references of course data objects to be resolved to provide real instances instead of the raw values
        /// in the BYAML.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> providing the objects.</param>
        public void DeserializeReferences(CourseDefinition courseDefinition)
        {
            // References to paths and their points.
            Path = _pathIndex == null ? null : courseDefinition.Paths[_pathIndex.Value];
            PathPoint = _pathPointIndex == null ? null : Path.Points[_pathPointIndex.Value];
            LapPath = _lapPathIndex == null ? null : courseDefinition.LapPaths[_lapPathIndex.Value];
            LapPathPoint = _lapPathPointIndex == null ? null : LapPath.Points[_lapPathPointIndex.Value];
            ObjPath = _objPathIndex == null ? null : courseDefinition.ObjPaths[_objPathIndex.Value];
            ObjPathPoint = _objPathPointIndex == null ? null : ObjPath.Points[_objPathPointIndex.Value];
            EnemyPath1 = _enemyPath1Index == null ? null : courseDefinition.EnemyPaths[_enemyPath1Index.Value];
            EnemyPath2 = _enemyPath2Index == null ? null : courseDefinition.EnemyPaths[_enemyPath2Index.Value];
            ItemPath1 = _itemPath1Index == null ? null : courseDefinition.ItemPaths[_itemPath1Index.Value];
            ItemPath2 = _itemPath2Index == null ? null : courseDefinition.ItemPaths[_itemPath2Index.Value];

            // References to other unit objects.
            ParentArea = _areaIndex == null ? null : courseDefinition.Areas[_areaIndex.Value];
            ParentObj = _objIndex == null ? null : courseDefinition.Objs[_objIndex.Value];
        }

        /// <summary>
        /// Allows references between course objects to be serialized into raw values stored in the BYAML.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> providing the objects.</param>
        public void SerializeReferences(CourseDefinition courseDefinition)
        {
            // References to paths and their points.
            _pathIndex = Path == null ? null : (int?)courseDefinition.Paths.IndexOf(Path);
            _pathPointIndex = PathPoint?.Index;
            _lapPathIndex = LapPath == null ? null : (int?)courseDefinition.LapPaths.IndexOf(LapPath);
            _lapPathPointIndex = LapPathPoint?.Index;
            _objPathIndex = ObjPath == null ? null : (int?)courseDefinition.ObjPaths.IndexOf(ObjPath);
            _objPathPointIndex = ObjPathPoint?.Index;
            _enemyPath1Index = EnemyPath1 == null ? null : (int?)courseDefinition.EnemyPaths.IndexOf(EnemyPath1);
            _enemyPath2Index = EnemyPath2 == null ? null : (int?)courseDefinition.EnemyPaths.IndexOf(EnemyPath2);
            _itemPath1Index = ItemPath1 == null ? null : (int?)courseDefinition.ItemPaths.IndexOf(ItemPath1);
            _itemPath2Index = ItemPath2 == null ? null : (int?)courseDefinition.ItemPaths.IndexOf(ItemPath2);

            // References to other unit objects.
            _areaIndex = ParentArea == null ? null : (int?)courseDefinition.Areas.IndexOf(ParentArea);
            _objIndex = ParentObj == null ? null : (int?)courseDefinition.Objs.IndexOf(ParentObj);
        }
    }
}
