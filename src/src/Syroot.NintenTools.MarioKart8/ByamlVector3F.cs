using Syroot.Maths;
using Syroot.NintenTools.Byaml.Serialization;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a <see cref="Vector3"/> serializable as BYAML data.
    /// </summary>
    [ByamlObject]
    public struct ByamlVector3F
    {

        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        /// <summary>
        /// The X float component.
        /// </summary>
        [ByamlMember]
        public float X;

        /// <summary>
        /// The Y float component.
        /// </summary>
        [ByamlMember]
        public float Y;

        /// <summary>
        /// The Z float component.
        /// </summary>
        [ByamlMember]
        public float Z;

        // ---- CONSTRUCTORS -------------------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="ByamlVector3F"/> struct with the given values for the X, Y and
        /// Z components.
        /// </summary>
        /// <param name="x">The value of the X component.</param>
        /// <param name="y">The value of the Y component.</param>
        /// <param name="z">The value of the Z component.</param>
        public ByamlVector3F(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        // ---- OPERATORS ----------------------------------------------------------------------------------------------

        /// <summary>
        /// Implicit conversion from <see cref="Vector3F"/>.
        /// </summary>
        /// <param name="vector">The <see cref="Vector3F"/> to convert from.</param>
        /// <returns>The retrieved <see cref="ByamlVector3F"/>.</returns>
        public static implicit operator ByamlVector3F(Vector3F vector)
        {
            return new ByamlVector3F(vector.X, vector.Y, vector.Z);
        }
    }
}