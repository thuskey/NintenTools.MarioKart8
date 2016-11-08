using System;
using System.Collections.Generic;
using Syroot.NintenTools.Byaml;
using Syroot.NintenTools.MarioKart8.Objs;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents an Obj placed on the course.
    /// </summary>
    public class Obj : SpatialObject, IByamlReferencable
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        // References to path unit objects.
        private int? _pathIndex;
        private int? _pathPointIndex;
        private int? _lapPathIndex;
        private int? _lapPathPointIndex;
        private int? _objPathIndex;
        private int? _objPathPointIndex;
        private int? _enemyPath1Index;
        private int? _enemyPath2Index;
        private int? _itemPath1Index;
        private int? _itemPath2Index;
        
        // References to other unit objects.
        private int? _areaIndex;
        private int? _objIndex;

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the ID determining the type of this object (as defined in the <see cref="ObjDefinitionDb"/>).
        /// </summary>
        public int ObjId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether collision detection with this Obj will be skipped.
        /// </summary>
        public bool? NoCol { get; set; }

        /// <summary>
        /// Gets or sets an unknown setting which has never been used in the original courses.
        /// </summary>
        public bool TopView { get; set; }

        /// <summary>
        /// Gets or sets the speed in which a path is followed.
        /// </summary>
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
        /// Gets or sets another <see cref="Courses.Path"/> this Obj is attached to.
        /// </summary>
        public Path ObjPath { get; set; }

        /// <summary>
        /// Gets or sets the point in the <see cref="ObjPath"/> this Obj is attached to.
        /// </summary>
        public PathPoint ObjPathPoint { get; set; }

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
        public List<float> Params { get; set; }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Reads the data from the given dynamic BYAML node into the instance.
        /// </summary>
        /// <param name="node">The dynamic BYAML node to deserialize.</param>
        public override void DeserializeByaml(dynamic node)
        {
            base.DeserializeByaml((IDictionary<string, dynamic>)node);

            ObjId = node["ObjId"];
            NoCol = ByamlFile.GetValue(node, "NoCol");
            TopView = node["TopView"];
            Params = ByamlFile.GetList<float>(node["Params"]);

            // Paths.
            Speed = node["Speed"];
            _pathIndex = ByamlFile.GetValue(node, "Obj_Path");
            _pathPointIndex = ByamlFile.GetValue(node, "Obj_PathPoint");
            _lapPathIndex = ByamlFile.GetValue(node, "Obj_LapPath");
            _lapPathPointIndex = ByamlFile.GetValue(node, "Obj_LapPoint");
            _objPathIndex = ByamlFile.GetValue(node, "Obj_ObjPath");
            _objPathPointIndex = ByamlFile.GetValue(node, "Obj_ObjPoint");
            _enemyPath1Index = ByamlFile.GetValue(node, "Obj_EnemyPath1");
            _enemyPath2Index = ByamlFile.GetValue(node, "Obj_EnemyPath2");
            _itemPath1Index = ByamlFile.GetValue(node, "Obj_ItemPath1");
            _itemPath2Index = ByamlFile.GetValue(node, "Obj_ItemPath2");

            // References.
            _areaIndex = ByamlFile.GetValue(node, "Area_Obj");
            _objIndex = ByamlFile.GetValue(node, "Obj_Obj");

            // Exclusions.
            ModeInclusion = ModeInclusionExtensions.GetFromByaml(node);
        }

        /// <summary>
        /// Creates a dynamic BYAML node from the instance's data.
        /// </summary>
        /// <returns>The dynamic BYAML node.</returns>
        public override dynamic SerializeByaml()
        {
            IDictionary<string, dynamic> node = base.SerializeByaml();

            node["ObjId"] = ObjId;
            ByamlFile.SetValue(node, "NoCol", NoCol);
            node["TopView"] = TopView;
            node["Params"] = Params;

            // Paths.
            node["Speed"] = Speed;
            ByamlFile.SetValue(node, "Obj_Path", _pathIndex);
            ByamlFile.SetValue(node, "Obj_PathPoint", _pathPointIndex);
            ByamlFile.SetValue(node, "Obj_LapPath", _lapPathIndex);
            ByamlFile.SetValue(node, "Obj_LapPoint", _lapPathPointIndex);
            ByamlFile.SetValue(node, "Obj_ObjPath", _objPathIndex);
            ByamlFile.SetValue(node, "Obj_ObjPoint", _objPathPointIndex);
            ByamlFile.SetValue(node, "Obj_EnemyPath1", _enemyPath1Index);
            ByamlFile.SetValue(node, "Obj_EnemyPath2", _enemyPath2Index);
            ByamlFile.SetValue(node, "Obj_ItemPath1", _itemPath1Index);
            ByamlFile.SetValue(node, "Obj_ItemPath2", _itemPath2Index);

            // References.
            ByamlFile.SetValue(node, "Area_Obj", _areaIndex);
            ByamlFile.SetValue(node, "Obj_Obj", _objIndex);

            // Exclusions.
            ModeInclusion.SetForByaml(node);

            return node;
        }
        
        /// <summary>
        /// Allows references between BYAML instances to be resolved to provide real instances
        /// instead of the raw values in the BYAML.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> providing the objects.</param>
        public void DeserializeReferences(CourseDefinition courseDefinition)
        {
            // References to paths and points.
            Path = _pathIndex == null ? null : courseDefinition.Paths[_pathIndex.Value];
            PathPoint = _pathPointIndex == null ? null : Path.Points[_pathPointIndex.Value];
            LapPath = _lapPathIndex == null ? null : courseDefinition.LapPaths[_lapPathIndex.Value];
            LapPathPoint = _lapPathPointIndex == null ? null : LapPath.Points[_lapPathPointIndex.Value];
            ObjPath = _objPathIndex == null ? null : courseDefinition.Paths[_objPathIndex.Value];
            ObjPathPoint = _objPathPointIndex == null ? null : Path.Points[_objPathPointIndex.Value];
            EnemyPath1 = _enemyPath1Index == null ? null : courseDefinition.EnemyPaths[_enemyPath1Index.Value];
            EnemyPath2 = _enemyPath2Index == null ? null : courseDefinition.EnemyPaths[_enemyPath2Index.Value];
            ItemPath1 = _itemPath1Index == null ? null : courseDefinition.ItemPaths[_itemPath1Index.Value];
            ItemPath2 = _itemPath2Index == null ? null : courseDefinition.ItemPaths[_itemPath2Index.Value];

            // References to other unit objects.
            ParentArea = _areaIndex == null ? null : courseDefinition.Areas[_areaIndex.Value];
            ParentObj = _objIndex == null ? null : courseDefinition.Objs[_objIndex.Value];
        }

        /// <summary>
        /// Allows references between BYAML instances to be serialized into raw values stored in the
        /// BYAML.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> providing the objects.</param>
        public void SerializeReferences(CourseDefinition courseDefinition)
        {
            // References to paths and points.
            _pathIndex = Path == null ? null : (int?)courseDefinition.Paths.IndexOf(Path);
            _pathPointIndex = PathPoint?.Index;
            _lapPathIndex = LapPath == null ? null : (int?)courseDefinition.LapPaths.IndexOf(LapPath);
            _lapPathPointIndex = LapPathPoint?.Index;
            _objPathIndex = ObjPath == null ? null : (int?)courseDefinition.Paths.IndexOf(ObjPath);
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
