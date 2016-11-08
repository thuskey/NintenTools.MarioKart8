using System.Collections.Generic;
using Syroot.NintenTools.Byaml;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a path used for different aspects in the game.
    /// </summary>
    public abstract class PathBase<TPath, TPoint> : UnitObject, IByamlReferencable
        where TPath : PathBase<TPath, TPoint>
        where TPoint : PathPointBase<TPath, TPoint>, IByamlReferencable, new()
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the list of point instances making up this path.
        /// </summary>
        public PathPointCollection<TPath, TPoint> Points { get; set; }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Reads the data from the given dynamic BYAML node into the instance.
        /// </summary>
        /// <param name="node">The dynamic BYAML node to deserialize.</param>
        /// <returns>The instance itself.</returns>
        public override dynamic DeserializeByaml(dynamic node)
        {
            base.DeserializeByaml((IDictionary<string, dynamic>)node);
            Points = new PathPointCollection<TPath, TPoint>((TPath)this);
            Points.AddRange(ByamlFile.DeserializeList<TPoint>(node["PathPt"]));
            return this;
        }

        /// <summary>
        /// Creates a dynamic BYAML node from the instance's data.
        /// </summary>
        /// <returns>The dynamic BYAML node.</returns>
        public override dynamic SerializeByaml()
        {
            dynamic node = base.SerializeByaml();
            node["PathPt"] = Points;
            return node;
        }
        
        /// <summary>
        /// Allows references between BYAML instances to be resolved to provide real instances instead of the raw values
        /// in the BYAML.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> providing the objects.</param>
        public virtual void DeserializeReferences(CourseDefinition courseDefinition)
        {
            // Resolve the linked point list.
            foreach (TPoint point in Points)
            {
                point.DeserializeReferences(courseDefinition);
            }
        }

        /// <summary>
        /// Allows references between BYAML instances to be serialized into raw values stored in the BYAML.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> providing the objects.</param>
        public virtual void SerializeReferences(CourseDefinition courseDefinition)
        {
            // Resolve the linked point list.
            foreach (TPoint point in Points)
            {
                point.SerializeReferences(courseDefinition);
            }
        }
    }
}
