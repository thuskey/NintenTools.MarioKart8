using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Syroot.NintenTools.MarioKart8.BinData;

namespace Syroot.NintenTools.MarioKart8.BinDumper
{
    /// <summary>
    /// The main class of the program containing the application entry point.
    /// </summary>
    internal class Program
    {
        // ---- CONSTANTS ----------------------------------------------------------------------------------------------

        private const char _csvSeparator = '\t';

        // ---- METHODS (PRIVATE) --------------------------------------------------------------------------------------

        private static int Main(string[] args)
        {
            // Read the parameters.
            if (args.Length > 2)
            {
                return -1;
            }
            string binPath = args[0];
            string csvPath;
            if (args.Length == 2)
            {
                csvPath = args[1];
            }
            else
            {
                csvPath = Path.ChangeExtension(binPath, "csv");
            }

            // Load the BIN file.
            BinFile binFile = new BinFile(binPath);

            // Dump the BIN file to CSV.
            using (FileStream stream = new FileStream(csvPath, FileMode.Create, FileAccess.Write, FileShare.None))
            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8, 1024, true))
            {
                // Write file header information.
                Write(writer, 0, $"BIN File Report for", binPath);
                Write(writer, 0, "Identifier          ", binFile.Identifier);
                Write(writer, 0, "Reported file size  ", binFile.FileSize);
                Write(writer, 0, "Actual file size    ", new FileInfo(binPath).Length);
                Write(writer, 0, "Section count       ", binFile.Sections.Length);
                Write(writer, 0, "Unknown             ", binFile.Unknown);
                Write(writer, 0, "Version             ", binFile.Version);
                writer.WriteLine();

                // Write info about the sections.
                for (int sectionIndex = 0; sectionIndex < binFile.Sections.Length; sectionIndex++)
                {
                    SectionBase section = binFile.Sections[sectionIndex];
                    Write(writer, 0, $"Section {sectionIndex + 1}");
                    Write(writer, 1, "Identifier   ", section.Header.Identifier);
                    Write(writer, 1, "Element count", section.Header.ElementCount);
                    Write(writer, 1, "Group count  ", section.Header.GroupCount);
                    Write(writer, 1, "Type ID      ", section.Header.TypeID);
                    writer.WriteLine();

                    // Dump the groups.
                    IntArraySection intArray = section as IntArraySection;
                    if (intArray != null)
                    {
                        for (int groupIndex = 0; groupIndex < section.Header.GroupCount; groupIndex++)
                        {
                            List<int[]> group = intArray.Groups[groupIndex];
                            Write(writer, 1, $"Group {groupIndex + 1}");
                            for (int elementIndex = 0; elementIndex < section.Header.ElementCount; elementIndex++)
                            {
                                int[] element = group[elementIndex];
                                Write(writer, 1, String.Join(" ", element.Select(x => x.ToString().PadLeft(5))));
                            }
                            writer.WriteLine();
                        }
                    }
                    // TODO: Dump other group types.
                }
                writer.Flush();
            }

            return 0;
        }

        private static void Write(StreamWriter writer, int indent, params object[] values)
        {
            writer.WriteLine(new string(_csvSeparator, indent) + String.Join(_csvSeparator.ToString(), values));
        }
    }
}
