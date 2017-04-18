using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Syroot.NintenTools.MarioKart8.Courses;

using Path = System.IO.Path;

namespace Syroot.NintenTools.MarioKart8.NoLakitu
{
    /// <summary>
    /// Represents the main class of the application containing the program entry point.
    /// </summary>
    internal static class Program
    {
        // ---- CONSTANTS ----------------------------------------------------------------------------------------------

        private const int _adjusterID = 8029;
        private const string _adjusterName = "Adjuster200cc";

        // ---- MEMBERS ------------------------------------------------------------------------------------------------

        private static string _fileName;
        private static string _fileName200;

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
            if (!File.Exists(_fileName200))
            {
                Console.Error.WriteLine($"File '{_fileName200}' does not exist.");
                return -1;
            }

            // Load the BYAML files.
            Console.WriteLine($"Loading {Path.GetFileName(_fileName)}...");
            CourseDefinition course = new CourseDefinition(_fileName);

            Console.WriteLine($"Loading {Path.GetFileName(_fileName200)}...");
            CourseDefinition course200 = new CourseDefinition(_fileName200);

            // Check if the 200 BYAML has any Adjuster200cc objects at all.
            List<Obj> adjusters = course200.Objs.Where(x => x.ObjId == _adjusterID).ToList();
            if (adjusters.Count == 0)
            {
                Console.WriteLine("No Adjuster200cc objects found in 200cc BYAML, nothing to do.");
                return 0;
            }

            // Add the adjusters to the normal BYAML and the Name and ID lists.
            course.Objs.AddRange(adjusters);
            course.MapObjIdList.Add(_adjusterID);
            course.MapObjResList.Add(_adjusterName);

            // Overwrite the 200cc BYAML.
            Console.WriteLine($"Creating new {_fileName200}...");
            course.Save(_fileName200);
            return 0;
        }

        private static bool ParseParameters(string[] args)
        {
            // Check the correct number of parameters.
            if (args.Length != 1)
            {
                return false;
            }

            // Get the file names.
            _fileName = args[0];
            _fileName200 = Path.Combine(Path.GetDirectoryName(_fileName),
                Path.GetFileNameWithoutExtension(_fileName) + "_200" + Path.GetExtension(_fileName));

            return true;
        }

        private static void PrintHelp()
        {
            Console.WriteLine("Takes a course_muunt.byaml and searches for the corresponding");
            Console.WriteLine("course_muunt_200.byaml in the same directory. It then adds the Adjuster200cc");
            Console.WriteLine("Objs from the 200cc BYAML to the normal BYAML and overwrites the 200 BYAML.");
            Console.WriteLine();
            Console.WriteLine("ADJUST200 course_muunt.byaml");
            Console.WriteLine();
            Console.WriteLine("         course_muunt.byaml  The name of the BYAML file which will be combined");
            Console.WriteLine("                             with the 200cc BYAML.");
        }
    }
}
