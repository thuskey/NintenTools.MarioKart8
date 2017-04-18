using System.Collections.Generic;
using Syroot.NintenTools.Byaml.Serialization;

namespace Syroot.NintenTools.MarioKart8.Courses
{
    /// <summary>
    /// Represents a path the AI drives.
    /// </summary>
    [ByamlObject]
    public class EnemyPath : PathBase<EnemyPath, EnemyPathPoint>
    {
        /// <summary>
        /// Gets or sets the list of <see cref="ReturnPointEnemy"/> instances.
        /// </summary>
        [ByamlMember(Optional = true)]
        public List<ReturnPointEnemy> ReturnPoints { get; set; }
    }
}
