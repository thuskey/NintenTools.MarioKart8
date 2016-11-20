using System.Collections.Generic;
using Syroot.NintenTools.Byaml.Serialization;
using Syroot.NintenTools.MarioKart8.Courses;

namespace Syroot.NintenTools.MarioKart8.Objs
{
    /// <summary>
    /// Represents an entry of the objflow.byaml file, describing how an Obj is loaded and behaves in-game.
    /// </summary>
    [ByamlObject]
    public class ObjDefinition
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the way the AI interacts with this Obj.
        /// </summary>
        [ByamlMember]
        public AiReact AiReact { get; set; }

        /// <summary>
        /// Gets or sets a value possibly indicating if the AI should check this Obj when trying to take a cut.
        /// </summary>
        [ByamlMember]
        public bool CalcCut { get; set; }

        /// <summary>
        /// Gets or sets a value possibly indicating whether this object can be clipped from view.
        /// </summary>
        [ByamlMember]
        public bool Clip { get; set; }

        /// <summary>
        /// Gets or sets a distance possibly indicating when the object should be clipped from view.
        /// </summary>
        [ByamlMember]
        public float ClipRadius { get; set; }

        /// <summary>
        /// Gets or sets a height offset of a generic collision box.
        /// </summary>
        [ByamlMember]
        public float ColOffsetY { get; set; }

        /// <summary>
        /// Gets or sets the shape of a generic collision box.
        /// </summary>
        [ByamlMember]
        public int ColShape { get; set; }

        /// <summary>
        /// Gets or sets the size of a generic collision box.
        /// </summary>
        [ByamlMember]
        public ByamlVector3F ColSize { get; set; }

        /// <summary>
        /// Gets or sets an unknown value.
        /// </summary>
        [ByamlMember]
        public bool DemoCameraCheck { get; set; }

        /// <summary>
        /// Gets or sets a list of unknown values.
        /// </summary>
        [ByamlMember("Item")]
        public List<int> Items { get; set; }

        /// <summary>
        /// Gets or sets a list of unknown values.
        /// </summary>
        [ByamlMember("ItemObj")]
        public List<int> ItemObjs { get; set; }

        /// <summary>
        /// Gets or sets a list of unknown values.
        /// </summary>
        [ByamlMember("Kart")]
        public List<int> Karts { get; set; }

        /// <summary>
        /// Gets or sets a list of unknown values.
        /// </summary>
        [ByamlMember("KartObj")]
        public List<int> KartObjs { get; set; }

        /// <summary>
        /// Gets or sets the name of the Obj.
        /// </summary>
        [ByamlMember]
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets an unknown light setting.
        /// </summary>
        [ByamlMember]
        public int LightSetting { get; set; }

        /// <summary>
        /// Gets or sets a distance possibly indicating when the object should be rendered with full detail.
        /// </summary>
        [ByamlMember]
        public float Lod1 { get; set; }

        /// <summary>
        /// Gets or sets a distance possibly indicating when the object should be rendered with a lower detail second
        /// LoD model.
        /// </summary>
        [ByamlMember]
        public float Lod2 { get; set; }

        /// <summary>
        /// Gets or sets a distance possibly indicating when the object should not be drawn at all anymore.
        /// </summary>
        [ByamlMember]
        public float Lod_NoDisp { get; set; }

        /// <summary>
        /// Gets or sets an object manager ID.
        /// </summary>
        [ByamlMember]
        public int MgrId { get; set; }

        /// <summary>
        /// Gets or sets a possible type determining how the object is rendered.
        /// </summary>
        [ByamlMember]
        public int ModelDraw { get; set; }

        /// <summary>
        /// Gets or sets an unknown model effect number.
        /// </summary>
        [ByamlMember]
        public int ModelEffNo { get; set; }

        /// <summary>
        /// Gets or sets an optional model name.
        /// </summary>
        [ByamlMember(Optional = true)]
        public string ModelName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this object already moves before the online sync is done.
        /// </summary>
        [ByamlMember]
        public bool MoveBeforeSync { get; set; }

        /// <summary>
        /// Gets or sets an unknown value.
        /// </summary>
        [ByamlMember]
        public bool NotCreate { get; set; }

        /// <summary>
        /// Gets or sets the ID of the Obj with which it is reference in <see cref="CourseDefinition"/> files.
        /// </summary>
        [ByamlMember]
        public int ObjId { get; set; }

        /// <summary>
        /// Gets or sets an offset.
        /// </summary>
        [ByamlMember]
        public float Offset { get; set; }

        /// <summary>
        /// Gets or sets the origin type of the model.
        /// </summary>
        [ByamlMember]
        public int Origin { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the piranha plant item targets and tries to eat this item.
        /// </summary>
        [ByamlMember]
        public bool PackunEat { get; set; }

        /// <summary>
        /// Gets or sets the path type this Obj possibly requires.
        /// </summary>
        [ByamlMember]
        public int PathType { get; set; }

        /// <summary>
        /// Gets or sets a value possibly indicating how pylons Objs react to this object (a pylon can destroy an item
        /// box upon touching for example).
        /// </summary>
        [ByamlMember]
        public int PylonReact { get; set; }

        /// <summary>
        /// Gets or sets the list of resource names.
        /// </summary>
        [ByamlMember("ResName")]
        public List<string> ResNames { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this object should be handled as a skydome or not.
        /// </summary>
        [ByamlMember]
        public bool VR { get; set; }
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