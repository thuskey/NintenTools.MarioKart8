using System;
using System.IO;
using Syroot.NintenTools.MarioKart8.Courses;

using Path = System.IO.Path;

namespace Syroot.NintenTools.MarioKart8.NoLakitu
{
    /// <summary>
    /// Represents the main class of the application containing the program entry point.
    /// </summary>
    internal static class Program
    {
        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        private static string _fileName;

        // ---- METHODS (PRIVATE) --------------------------------------------------------------------------------------

        private static int Main(string[] args)
        {
            // Parse the parameters and validate them.
            if (!ParseParameters(args))
            {
                PrintHelp();
                return -1;
            }
            if (!File.Exists(_fileName))
            {
                Console.Error.WriteLine($"File '{_fileName}' does not exist.");
                return -1;
            }

            // Load the BYAML file.
            Console.WriteLine("Loading course...");
            CourseDefinition course = new CourseDefinition(_fileName);

            // Remove all EnemyPath and LapPath instances.
            Console.WriteLine("Removing Lakitu...");
            course.EnemyPaths = null;
            course.LapPaths = null;

            // Remove all Objs which required an EnemyPath or LapPath (they might crash the game without them).
            for (int i = course.Objs.Count - 1; i >= 0; i--)
            {
                Obj obj = course.Objs[i];
                if (obj.EnemyPath1 != null || obj.EnemyPath2 != null || obj.LapPath != null)
                {
                    course.Objs.RemoveAt(i);
                }
            }

            // Make a backup of the original BYAML file.
            string backupFileName = Path.ChangeExtension(_fileName, "orig.byaml");
            if (!File.Exists(backupFileName))
            {
                Console.WriteLine("No backup found, creating '" + backupFileName + "'...");
                File.Copy(_fileName, backupFileName);
            }

            //// Overwrite the provided file.
            Console.Write("Storing new BYAML...");
            course.Save(_fileName);
            Console.WriteLine(" done.");

            return 0;
        }

        private static bool ParseParameters(string[] args)
        {
            // Check the correct number of parameters.
            if (args.Length != 1)
            {
                return false;
            }

            // Get the file name.
            _fileName = args[0];

            return true;
        }

        private static void PrintHelp()
        {
            Console.WriteLine("Removes EnemyPath and LapPath instances (including Objs which referenced them)");
            Console.WriteLine("in a track file, effectively preventing Lakitu from resetting the player when");
            Console.WriteLine("driving out of bounds.");
            Console.WriteLine();
            Console.WriteLine("NOLAKITU file.byaml");
            Console.WriteLine();
            Console.WriteLine("         file.byaml  The name of the BYAML file which will be modified.");
            Console.WriteLine("                     A backup is stored automatically as '*.orig.byaml' if it");
            Console.WriteLine("                     does not exist yet.");
        }
    }
}
