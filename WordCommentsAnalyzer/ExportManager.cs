using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace WordCommentsAnalyzer
{
    public partial class Main : Form
    {

        public static string GetTimestampedExportPath(string baseFolder = "Exports", string filePrefix = "export")
        {
            // Create Exports folder if it doesn't exist
            string exportsFolder = Path.Combine(WorkingDirectory, baseFolder);
            Directory.CreateDirectory(exportsFolder);

            // Generate timestamp (Year-Month-Day_Hour-Minute-Second)
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");

            // Combine to create full file path
            string fileName = $"{filePrefix}_{timestamp}.txt";
            string outputFilePath = Path.Combine(exportsFolder, fileName);

            return outputFilePath;
        }


        public void ExportCodesToMarkdown(string outputFilePath)
        {
            if (Models.CodesDictionary == null || Models.CodesDictionary.Count == 0)
            {
                Log("Models.CodesDictionary is empty or null.");
                return;
            }

            // Build and sort by frequency only (most frequent first)
            var sortedCodes = Models.CodesDictionary
                .Select(kvp => kvp.Value)
                .OrderByDescending(code => code.DataExtractsCount)
                .ToList();

            using (StreamWriter writer = new StreamWriter(outputFilePath, false, Encoding.UTF8))
            {
                // Write header
                writer.WriteLine("# Code Export");
                writer.WriteLine($"Generated on: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                writer.WriteLine();
                writer.WriteLine($"Total Codes: {Models.CodesDictionary.Count}");
                writer.WriteLine();
                writer.WriteLine("---");
                writer.WriteLine();

                // Iterate through sorted codes
                foreach (var code in sortedCodes)
                {
                    // Write code as heading with frequency
                    writer.WriteLine($"## {code.Value} (Frequency: {code.DataExtractsCount})");
                    writer.WriteLine();

                    // Check if there are data extracts
                    if (code.DataExtracts != null && code.DataExtracts.Any())
                    {
                        writer.WriteLine("### Data Extracts:");
                        writer.WriteLine();

                        foreach (var dataExtract in code.DataExtracts)
                        {
                            string fileName = dataExtract.File?.Info?.Name ?? "Unknown";
                            string referenceText = string.IsNullOrEmpty(dataExtract.ReferenceText)
                                ? "[No reference text available]"
                                : dataExtract.ReferenceText;

                            string cleanText = referenceText.Replace("\r\n", " ").Replace("\n", " ");
                            writer.WriteLine($"{cleanText} ({fileName})");
                            writer.WriteLine();
                        }
                    }
                    else
                    {
                        writer.WriteLine("*No data extracts available for this code*");
                        writer.WriteLine();
                    }

                    writer.WriteLine("---");
                    writer.WriteLine();
                }

                writer.WriteLine("# End of Export");
            }

            Log($"Export completed successfully to: {outputFilePath}");
        }

    }
}
