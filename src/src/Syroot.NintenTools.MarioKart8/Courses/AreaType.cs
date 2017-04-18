namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents the action taken for objects inside of an area or clip area.
    /// </summary>
    public enum AreaType
    {
        /// <summary>
        /// No special action will be taken.
        /// </summary>
        None = 0,

        /// <summary>
        /// Unknown area type. Appears in Mario Circuit and Twisted Mansion.
        /// </summary>
        Unknown1 = 1,

        /// <summary>
        /// Unknown area type. Appears almost everywhere.
        /// </summary>
        Unknown2 = 2,

        /// <summary>
        /// Objects are moved along a specified path.
        /// </summary>
        Pull = 3,

        /// <summary>
        /// Objects will roam randomly inside of this area.
        /// </summary>
        Roam = 4,

        /// <summary>
        /// Specifies that this is a clip area. Not valid for areas.
        /// </summary>
        Clip = 5
    }
}
