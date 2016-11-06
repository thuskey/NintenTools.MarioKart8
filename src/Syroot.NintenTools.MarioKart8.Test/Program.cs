using System;
using Syroot.NintenTools.MarioKart8.Courses;

namespace Syroot.NintenTools.MarioKart8.Test
{
    /// <summary>
    /// Represents the main class of the program containing the program entry point.
    /// </summary>
    internal class Program
    {
        // ---- METHODS (PRIVATE) --------------------------------------------------------------------------------------

        private static void Main(string[] args)
        {
            CourseDefinition course = new CourseDefinition(
                @"D:\Archive\Games\Emulators\Wii U\Roms\Mario Kart 8 EUR 4.1 with DLC1+2\content\course\D3ds_NeoBowserCity\course_muunt_200.byaml");
        }
    }
}
