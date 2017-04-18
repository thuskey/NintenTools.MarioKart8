using System.Diagnostics;
using Syroot.NintenTools.Byaml.Serialization;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a path used for different aspects in the game.
    /// </summary>
    [ByamlObject]
    public abstract class PathBase<TPath, TPoint> : UnitObject, ICourseReferencable
        where TPath : PathBase<TPath, TPoint>
        where TPoint : PathPointBase<TPath, TPoint>, ICourseReferencable, new()
    {
        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the list of point instances making up this path.
        /// </summary>
        [ByamlMember("PathPt")]
        public PathPointCollection<TPath, TPoint> Points { get; set; }

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Allows references of course data objects to be resolved to provide real instances instead of the raw values
        /// in the BYAML.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> providing the objects.</param>
        public virtual void DeserializeReferences(CourseDefinition courseDefinition)
        {
            // Resolve the linked point list and set the path as the parent.
            Debug.WriteLine(this);
            TPath thisTPath = (TPath)this;
            foreach (TPoint point in Points)
            {
                point.PathInternal = thisTPath;
                point.DeserializeReferences(courseDefinition);
            }
        }

        /// <summary>
        /// Allows references between course objects to be serialized into raw values stored in the BYAML.
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
