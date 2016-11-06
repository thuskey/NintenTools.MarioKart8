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
        private int? _lapPathIndex;
        private int? _objPathIndex;
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
        
        // TODO: Paths

        /// <summary>
        /// Gets or sets the index of the point in the <see cref="Path"/> this Obj is attached to.
        /// </summary>
        public int? PathPoint { get; set; }

        /// <summary>
        /// Gets or sets the index of the point in the <see cref="LapPath"/> this Obj is attached to.
        /// </summary>
        public int? LapPathPoint { get; set; }

        /// <summary>
        /// Gets or sets the index of the point in the <see cref="ObjPath"/> this Obj is attached to.
        /// </summary>
        public int? ObjPathPoint { get; set; }

        /// <summary>
        /// Gets or sets the first <see cref="EnemyPath"/> this object is attached to.
        /// </summary>
        public EnemyPath EnemyPath1 { get; set; }

        /// <summary>
        /// Gets or sets the second <see cref="EnemyPath"/> this object is attached to.
        /// </summary>
        public EnemyPath EnemyPath2 { get; set; }

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
            PathPoint = ByamlFile.GetValue(node, "Obj_PathPoint");
            _lapPathIndex = ByamlFile.GetValue(node, "Obj_LapPath");
            LapPathPoint = ByamlFile.GetValue(node, "Obj_LapPoint");
            _objPathIndex = ByamlFile.GetValue(node, "Obj_ObjPath");
            ObjPathPoint = ByamlFile.GetValue(node, "Obj_ObjPoint");
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
            ByamlFile.SetValue(node, "Obj_PathPoint", PathPoint);
            ByamlFile.SetValue(node, "Obj_LapPath", _lapPathIndex);
            ByamlFile.SetValue(node, "Obj_LapPoint", LapPathPoint);
            ByamlFile.SetValue(node, "Obj_ObjPath", _objPathIndex);
            ByamlFile.SetValue(node, "Obj_ObjPoint", ObjPathPoint);
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
            // TODO: References to path unit objects.
            EnemyPath1 = _enemyPath1Index == null ? null : courseDefinition.EnemyPaths[_enemyPath1Index.Value];
            EnemyPath2 = _enemyPath2Index == null ? null : courseDefinition.EnemyPaths[_enemyPath2Index.Value];

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
            // TODO: References to path unit objects.
            _enemyPath1Index = courseDefinition.EnemyPaths.IndexOf(EnemyPath1);
            _enemyPath2Index = courseDefinition.EnemyPaths.IndexOf(EnemyPath2);

            // References to other unit objects.
            _areaIndex = ParentArea == null ? null : (int?)courseDefinition.Areas.IndexOf(ParentArea);
            _objIndex = ParentObj == null ? null : (int?)courseDefinition.Objs.IndexOf(ParentObj);
        }
    }
}
