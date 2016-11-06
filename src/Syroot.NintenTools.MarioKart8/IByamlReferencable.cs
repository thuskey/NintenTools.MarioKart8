using Syroot.NintenTools.MarioKart8.Courses;

namespace Syroot.NintenTools.MarioKart8
{
    /// <summary>
    /// Represents a BYAML element which references others and thus must resolve and build the dependencies.
    /// </summary>
    public interface IByamlReferencable
    {
        // ---- METHODS ------------------------------------------------------------------------------------------------

        /// <summary>
        /// Allows references between BYAML instances to be resolved to provide real instances instead of the raw values
        /// in the BYAML.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> providing the objects.</param>
        void DeserializeReferences(CourseDefinition courseDefinition);

        /// <summary>
        /// Allows references between BYAML instances to be serialized into raw values stored in the BYAML.
        /// </summary>
        /// <param name="courseDefinition">The <see cref="CourseDefinition"/> providing the objects.</param>
        void SerializeReferences(CourseDefinition courseDefinition);
    }
}