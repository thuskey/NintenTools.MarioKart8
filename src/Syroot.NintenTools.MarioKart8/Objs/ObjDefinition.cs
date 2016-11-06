using System.Collections.Generic;
using Syroot.NintenTools.Byaml;
using Syroot.NintenTools.MarioKart8.Courses;
using Syroot.NintenTools.Maths;

namespace Syroot.NintenTools.MarioKart8.Objs
{
    /// <summary>
    /// Represents an entry of the objflow.byaml file, describing how an Obj is loaded and behaves in-game.
    /// </summary>
    public class ObjDefinition : IByamlSerializable
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the way the AI interacts with this Obj.
        /// </summary>
        public AiReact AiReact { get; set; }

        /// <summary>
        /// Gets or sets a value possibly indicating if the AI should check this Obj when trying to take a cut.
        /// </summary>
        public bool CalcCut { get; set; }

        /// <summary>
        /// Gets or sets a value possibly indicating whether this object can be clipped from view.
        /// </summary>
        public bool Clip { get; set; }

        /// <summary>
        /// Gets or sets a distance possibly indicating when the object should be clipped from view.
        /// </summary>
        public float ClipRadius { get; set; }

        /// <summary>
        /// Gets or sets a height offset of a generic collision box.
        /// </summary>
        public float ColOffsetY { get; set; }

        /// <summary>
        /// Gets or sets the shape of a generic collision box.
        /// </summary>
        public int ColShape { get; set; }

        /// <summary>
        /// Gets or sets the size of a generic collision box.
        /// </summary>
        public Vector3F ColSize { get; set; }

        /// <summary>
        /// Gets or sets an unknown value.
        /// </summary>
        public bool DemoCameraCheck { get; set; }

        /// <summary>
        /// Gets or sets a list of unknown values.
        /// </summary>
        public List<int> Item { get; set; }

        /// <summary>
        /// Gets or sets a list of unknown values.
        /// </summary>
        public List<int> ItemObj { get; set; }

        /// <summary>
        /// Gets or sets a list of unknown values.
        /// </summary>
        public List<int> Kart { get; set; }

        /// <summary>
        /// Gets or sets a list of unknown values.
        /// </summary>
        public List<int> KartObj { get; set; }

        /// <summary>
        /// Gets or sets the name of the Obj.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets an unknown light setting.
        /// </summary>
        public int LightSetting { get; set; }

        /// <summary>
        /// Gets or sets a distance possibly indicating when the object should be rendered with full detail.
        /// </summary>
        public float Lod1 { get; set; }

        /// <summary>
        /// Gets or sets a distance possibly indicating when the object should be rendered with a lower detail second
        /// LoD model.
        /// </summary>
        public float Lod2 { get; set; }

        /// <summary>
        /// Gets or sets a distance possibly indicating when the object should not be drawn at all anymore.
        /// </summary>
        public float Lod_NoDisp { get; set; }

        /// <summary>
        /// Gets or sets an object manager ID.
        /// </summary>
        public int MgrId { get; set; }

        /// <summary>
        /// Gets or sets a possible type determining how the object is rendered.
        /// </summary>
        public int ModelDraw { get; set; }

        /// <summary>
        /// Gets or sets an unknown model effect number.
        /// </summary>
        public int ModelEffNo { get; set; }

        /// <summary>
        /// Gets or sets an optional model name.
        /// </summary>
        public string ModelName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this object already moves before the online sync is done.
        /// </summary>
        public bool MoveBeforeSync { get; set; }

        /// <summary>
        /// Gets or sets an unknown value.
        /// </summary>
        public bool NotCreate { get; set; }

        /// <summary>
        /// Gets or sets the ID of the Obj with which it is reference in <see cref="CourseDefinition"/> files.
        /// </summary>
        public int ObjId { get; set; }

        /// <summary>
        /// Gets or sets an offset.
        /// </summary>
        public float Offset { get; set; }

        /// <summary>
        /// Gets or sets the origin type of the model.
        /// </summary>
        public int Origin { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the piranha plant item targets and tries to eat this item.
        /// </summary>
        public bool PackunEat { get; set; }

        /// <summary>
        /// Gets or sets the path type this Obj possibly requires.
        /// </summary>
        public int PathType { get; set; }

        /// <summary>
        /// Gets or sets a value possibly indicating how pylons Objs react to this object (a pylon can destroy an item
        /// box upon touching for example).
        /// </summary>
        public int PylonReact { get; set; }

        /// <summary>
        /// Gets or sets the list of resource names.
        /// </summary>
        public List<string> ResName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this object should be handled as a skydome or not.
        /// </summary>
        public bool VR { get; set; }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Reads the data from the given dynamic BYAML node into the instance.
        /// </summary>
        /// <param name="node">The dynamic BYAML node to deserialize.</param>
        public void DeserializeByaml(dynamic node)
        {
            AiReact = (AiReact)node["AiReact"];
            CalcCut = node["CalcCut"];
            Clip = node["Clip"];
            ClipRadius = node["ClipRadius"];
            ColOffsetY = node["ColOffsetY"];
            ColShape = node["ColShape"];
            ColSize = new Vector3F(node["ColSize"]);
            DemoCameraCheck = node["DemoCameraCheck"];
            Item = ByamlFile.GetList<int>(node["Item"]);
            ItemObj = ByamlFile.GetList<int>(node["ItemObj"]);
            Kart = ByamlFile.GetList<int>(node["Kart"]);
            KartObj = ByamlFile.GetList<int>(node["KartObj"]);
            Label = node["Label"];
            LightSetting = node["LightSetting"];
            Lod1 = node["Lod1"];
            Lod2 = node["Lod2"];
            Lod_NoDisp = node["Lod_NoDisp"];
            MgrId = node["MgrId"];
            ModelDraw = node["ModelDraw"];
            ModelEffNo = node["ModelEffNo"];
            ModelName = ByamlFile.GetValue(node, "ModelName");
            MoveBeforeSync = node["MoveBeforeSync"];
            NotCreate = node["NotCreate"];
            ObjId = node["ObjId"];
            Offset = node["Offset"];
            Origin = node["Origin"];
            PackunEat = node["PackunEat"];
            PathType = node["PathType"];
            PylonReact = node["PylonReact"];
            ResName = ByamlFile.GetList<string>(node["ResName"]);
            VR = node["VR"];
        }

        /// <summary>
        /// Creates a dynamic BYAML node from the instance's data.
        /// </summary>
        /// <returns>The dynamic BYAML node.</returns>
        public dynamic SerializeByaml()
        {
            Dictionary<string, dynamic> node = new Dictionary<string, dynamic>
            {
                ["AiReact"] = (int)AiReact,
                ["CalcCut"] = CalcCut,
                ["Clip"] = Clip,
                ["ClipRadius"] = ClipRadius,
                ["ColOffsetY"] = ColOffsetY,
                ["ColShape"] = ColShape,
                ["ColSize"] = ColSize.SerializeByaml(),
                ["DemoCameraCheck"] = DemoCameraCheck,
                ["Item"] = Item,
                ["ItemObj"] = ItemObj,
                ["Kart"] = Kart,
                ["KartObj"] = KartObj,
                ["Label"] = Label,
                ["LightSetting"] = LightSetting,
                ["Lod1"] = Lod1,
                ["Lod2"] = Lod2,
                ["Lod_NoDisp"] = Lod_NoDisp,
                ["MgrId"] = MgrId,
                ["ModelDraw"] = ModelDraw,
                ["ModelEffNo"] = ModelEffNo,
                ["MoveBeforeSync"] = MoveBeforeSync,
                ["NotCreate"] = NotCreate,
                ["ObjId"] = ObjId,
                ["Offset"] = Offset,
                ["Origin"] = Origin,
                ["PackunEat"] = PackunEat,
                ["PathType"] = PathType,
                ["PylonReact"] = PylonReact,
                ["ResName"] = ResName,
                ["VR"] = VR
            };
            ByamlFile.SetValue(node, "ModelName", ModelName);
            return node;
        }
    }

    // ---- ENUMERATIONS -------------------------------------------------------------------------------------------

    /// <summary>
    /// Represents the possibly AI reactions to an <see cref="ObjDefinition"/>.
    /// </summary>
    public enum AiReact
    {
        /// <summary>
        /// The AI takes no action.
        /// </summary>
        None = 0,

        /// <summary>
        /// The AI tries to circumvent this Obj.
        /// </summary>
        Repel = 1,

        /// <summary>
        /// The AI tries to collide with this Obj.
        /// </summary>
        Attract = 2,

        /// <summary>
        /// An unknown AI reaction.
        /// </summary>
        Unknown3 = 3
    }
}
