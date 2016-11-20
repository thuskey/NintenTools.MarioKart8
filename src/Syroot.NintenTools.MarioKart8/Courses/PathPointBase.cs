using System.Collections.Generic;
using Syroot.NintenTools.Byaml.Serialization;
using Syroot.Maths;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a point of a path of type <typeparamref name="TPath"/>.
    /// </summary>
    /// <typeparam name="TPath">The type of the path this point belongs to.</typeparam>
    /// <typeparam name="TPoint">The type of the point itself.</typeparam>
    [ByamlObject]
    public abstract class PathPointBase<TPath, TPoint> : ICourseReferencable
        where TPath : PathBase<TPath, TPoint>
        where TPoint : PathPointBase<TPath, TPoint>, ICourseReferencable, new()
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the path without any following logic.
        /// </summary>
        internal TPath PathInternal;

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets the parent path holding this point.
        /// </summary>
        public TPath Path
        {
            get
            {
                return PathInternal;
            }
            set
            {
                // Remove from a possible current parent.
                if (PathInternal != null)
                {
                    PathInternal.Points.Remove((TPoint)this);
                }

                // Set the new parent.
                PathInternal = value;
                // Add to the new parent's points.
                if (PathInternal != null)
                {
                    PathInternal.Points.Add((TPoint)this);
                }
            }
        }

        /// <summary>
        /// Gets the index of this point in the parent path or -1 if there is no parent.
        /// </summary>
        public int Index
        {
            get
            {
                if (PathInternal == null)
                {
                    return -1;
                }
                return PathInternal.Points.IndexOf((TPoint)this);
            }
        }

        /// <summary>
        /// Gets or sets the rotation of the object in radian.
        /// </summary>
        [ByamlMember]
        public Vector3F Rotate { get; set; }

        /// <summary>
        /// Gets or sets the scale of the object. Might be optional for specific path types.
        /// </summary>
        [ByamlMember(Optional = true)]
        public Vector3F? Scale { get; set; }

        /// <summary>
        /// Gets or sets the position at which the object is placed.
        /// </summary>
        [ByamlMember]
        public Vector3F Translate { get; set; }

        /// <summary>
        /// Gets or sets the list of point instances preceeding this one.
        /// </summary>
        public List<TPoint> PreviousPoints { get; set; }

        /// <summary>
        /// Gets or sets the list of point instances following this one.
        /// </summary>
        public List<TPoint> NextPoints { get; set; }

        /// <summary>
        /// Gets or sets the list of <see cref="PathPointReference"/> instances for preceeding points.
        /// </summary>
        [ByamlMember("PrevPt", Optional = true)]
        protected List<PathPointReference> PreviousPointIndices;

        /// <summary>
        /// Gets or sets the list of <see cref="PathPointReference"/> instances for succeeding points.
        /// </summary>
        [ByamlMember("NextPt", Optional = true)]
        protected List<PathPointReference> NextPointIndices;

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------
        
        /// <summary>
        /// Allows references of course data objects to be resolved to provide real instances instead of the raw values
        /// in the BYAML.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> providing the objects.</param>
        public virtual void DeserializeReferences(CourseDefinition courseDefinition)
        {
            // Solve the previous and next point references.
            IList<TPath> paths = GetPathReferenceList(courseDefinition);

            if (PreviousPointIndices != null)
            {
                PreviousPoints = new List<TPoint>();
                foreach (PathPointReference index in PreviousPointIndices)
                {
                    TPath referencedPath = paths[index.PathIndex];
                    PreviousPoints.Add(referencedPath.Points[index.PointIndex]);
                }
            }

            if (NextPointIndices != null)
            {
                NextPoints = new List<TPoint>();
                foreach (PathPointReference index in NextPointIndices)
                {
                    TPath referencedPath = paths[index.PathIndex];
                    NextPoints.Add(referencedPath.Points[index.PointIndex]);
                }
            }
        }

        /// <summary>
        /// Allows references between course objects to be serialized into raw values stored in the BYAML.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> providing the objects.</param>
        public virtual void SerializeReferences(CourseDefinition courseDefinition)
        {
            // Solve the previous and next point references.
            IList<TPath> paths = GetPathReferenceList(courseDefinition);

            if (PreviousPoints == null)
            {
                PreviousPointIndices = null;
            }
            else
            {
                PreviousPointIndices = new List<PathPointReference>();
                foreach (TPoint previousPoint in PreviousPoints)
                {
                    int pathIndex = paths.IndexOf(previousPoint.Path);
                    int pointIndex = previousPoint.Index;
                    PreviousPointIndices.Add(new PathPointReference(pathIndex, pointIndex));
                }
            }

            if (NextPoints == null)
            {
                NextPointIndices = null;
            }
            else
            {
                NextPointIndices = new List<PathPointReference>();
                foreach (TPoint nextPoint in NextPoints)
                {
                    int pathIndex = paths.IndexOf(nextPoint.Path);
                    int pointIndex = nextPoint.Index;
                    NextPointIndices.Add(new PathPointReference(pathIndex, pointIndex));
                }
            }
        }

        // ---- METHODS (PROTECTED) ------------------------------------------------------------------------------------

        /// <summary>
        /// Returns the array of paths in the <see cref="CourseDefinition"/> which can be referenced by previous and
        /// next points.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> to get the paths from.</param>
        /// <returns>The array of paths which can be referenced.</returns>
        protected abstract IList<TPath> GetPathReferenceList(CourseDefinition courseDefinition);
    }
}