using System.Collections.Generic;
using Syroot.NintenTools.Byaml;
using Syroot.NintenTools.Maths;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a point of a path of type <typeparamref name="TPath"/>.
    /// </summary>
    /// <typeparam name="TPath">The type of the path this point belongs to.</typeparam>
    /// <typeparam name="TPoint">The type of the point itself.</typeparam>
    public abstract class PathPointBase<TPath, TPoint> : IByamlSerializable, IByamlReferencable
        where TPath : PathBase<TPath, TPoint>
        where TPoint : PathPointBase<TPath, TPoint>, IByamlReferencable, new()
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        private TPath _path;

        // ---- PROPERTIES ---------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets the parent path holding this point.
        /// </summary>
        public TPath Path
        {
            get
            {
                return _path;
            }
            set
            {
                // Remove from a possible current parent.
                if (_path != null)
                {
                    _path.Points.Remove((TPoint)this);
                }

                // Set the new parent.
                _path = value;
                // Add to the new parent's points.
                if (_path != null)
                {
                    _path.Points.Add((TPoint)this);
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
                if (_path == null)
                {
                    return -1;
                }
                return _path.Points.IndexOf((TPoint)this);
            }
        }

        /// <summary>
        /// Gets or sets the rotation of the object in radian.
        /// </summary>
        public Vector3F Rotate { get; set; }

        /// <summary>
        /// Gets or sets the scale of the object. Might be optional for specific path types.
        /// </summary>
        public Vector3F? Scale { get; set; }

        /// <summary>
        /// Gets or sets the position at which the object is placed.
        /// </summary>
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
        protected List<PathPointReference> PreviousPointIndices;

        /// <summary>
        /// Gets or sets the list of <see cref="PathPointReference"/> instances for succeeding points.
        /// </summary>
        protected List<PathPointReference> NextPointIndices;

        // ---- METHODS (PUBLIC) ---------------------------------------------------------------------------------------

        /// <summary>
        /// Reads the data from the given dynamic BYAML node into the instance.
        /// </summary>
        /// <param name="node">The dynamic BYAML node to deserialize.</param>
        /// <returns>The instance itself.</returns>
        public virtual dynamic DeserializeByaml(dynamic node)
        {
            // Spatial.
            Rotate = new Vector3F(node["Rotate"]);
            dynamic scale = ByamlFile.GetValue(node, "Scale");
            if (scale != null) Scale = new Vector3F(scale);
            Translate = new Vector3F(node["Translate"]);

            // Predecessor and successor points.
            PreviousPointIndices = ByamlFile.DeserializeList<PathPointReference>(ByamlFile.GetValue(node, "PrevPt"));
            NextPointIndices = ByamlFile.DeserializeList<PathPointReference>(ByamlFile.GetValue(node, "NextPt"));

            return this;
        }

        /// <summary>
        /// Creates a dynamic BYAML node from the instance's data.
        /// </summary>
        /// <returns>The dynamic BYAML node.</returns>
        public virtual dynamic SerializeByaml()
        {
            Dictionary<string, dynamic> node = new Dictionary<string, dynamic>()
            {
                ["Rotate"] = Rotate.SerializeByaml(),
                ["Translate"] = Translate.SerializeByaml(),
            };
            ByamlFile.SetValue(node, "Scale", Scale);
            ByamlFile.SetValue(node, "PrevPt", PreviousPointIndices);
            ByamlFile.SetValue(node, "NextPt", NextPointIndices);
            return node;
        }

        /// <summary>
        /// Allows references between BYAML instances to be resolved to provide real instances instead of the raw values
        /// in the BYAML.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> providing the objects.</param>
        public virtual void DeserializeReferences(CourseDefinition courseDefinition)
        {
            // Solve the previous and next point references.
            IList<TPath> paths = GetPathReferenceList(courseDefinition);

            PreviousPoints = new List<TPoint>();
            foreach (PathPointReference index in PreviousPointIndices)
            {
                TPath referencedPath = paths[index.PathIndex];
                PreviousPoints.Add(referencedPath.Points[index.PointIndex]);
            }

            NextPoints = new List<TPoint>();
            foreach (PathPointReference index in NextPointIndices)
            {
                TPath referencedPath = paths[index.PathIndex];
                NextPoints.Add(referencedPath.Points[index.PointIndex]);
            }
        }

        /// <summary>
        /// Allows references between BYAML instances to be serialized into raw values stored in the BYAML.
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