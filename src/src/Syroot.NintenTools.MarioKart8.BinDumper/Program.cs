using System;
using System.IO;
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
                Write(writer, 0, "Identifier", binFile.Identifier);
                Write(writer, 0, "Section count", binFile.Sections.Count);
                Write(writer, 0, "Unknown", binFile.Unknown);
                Write(writer, 0, "Version", binFile.Version);
                writer.WriteLine();

                // Write info about the sections.
                for (int sectionIndex = 0; sectionIndex < binFile.Sections.Count; sectionIndex++)
                {
                    Section section = binFile.Sections[sectionIndex];
                    Write(writer, 0, $"Section {sectionIndex + 1}");
                    Write(writer, 1, "Identifier", section.Name);
                    Write(writer, 1, "Group count", section.Groups.Count);
                    Write(writer, 1, "Type", section.SectionType.ToString("X"));
                    writer.WriteLine();

                    // Dump the groups.
                    int i = 0;
                    foreach (GroupBase group in section.Groups)
                    {
                        Write(writer, 1, $"Group {i + 1}");
                        switch (section.SectionType)
                        {
                            case SectionType.ByteArrays:
                                foreach (byte[] element in ((ByteArraysGroup)group).Elements)
                                {
                                    Write(writer, 1, String.Join(_csvSeparator.ToString(), element));
                                }
                                writer.WriteLine();
                                i++;
                                break;
                            case SectionType.Strings:
                                foreach (string element in ((StringsGroup)group).Elements)
                                {
                                    Write(writer, 1, element);
                                }
                                break;
                            default:
                                Write(writer, 1, "Unknown section type.");
                                break;
                        }
                    }
                }
            }

            return 0;
        }

        private static void Write(StreamWriter writer, int indent, params object[] values)
        {
            writer.WriteLine(new string(_csvSeparator, indent) + String.Join(_csvSeparator.ToString(), values));
        }
    }
}
