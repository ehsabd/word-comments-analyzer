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

        private static string GetTimestampedExportPath(DateTime timestamp, string baseFolder, string filePrefix)
        {
            // Create Exports folder if it doesn't exist
            string exportsFolder = Path.Combine(WorkingDirectory, baseFolder);
            Directory.CreateDirectory(exportsFolder);

            // Generate timestamp (Year-Month-Day_Hour-Minute-Second)
            string timestampText = timestamp.ToString("yyyy-MM-dd_HH-mm-ss");

            // Combine to create full file path
            string fileName = $"{filePrefix}_{timestampText}.txt";
            string outputFilePath = Path.Combine(exportsFolder, fileName);

            return outputFilePath;
        }

        public void ExportCodesToMarkdownFiles(IEnumerable<string> codesInHierarchy)
        {
            if (Models.CodesDictionary == null || Models.CodesDictionary.Count == 0)
            {
                Log("Models.CodesDictionary is empty or null.");
                return;
            }

            var exportTime = DateTime.Now;
            ExportCodesToMarkdown(
                GetTimestampedExportPath(exportTime, "Exports", "export"),
                Models.CodesDictionary.Values,
                "Code Export",
                exportTime);

            var hierarchyCodeValues = new HashSet<string>(
                codesInHierarchy ?? Enumerable.Empty<string>(),
                StringComparer.OrdinalIgnoreCase);
            var hierarchyCodes = Models.CodesDictionary
                .Where(kvp => hierarchyCodeValues.Contains(kvp.Key))
                .Select(kvp => kvp.Value);

            // NOTE: I used V2 in order to intentionally avoid to include the word "hierarchy" in exported file name. Because when the two files of export output and code hierarchy are fed into an LLM I want it not to get confused which one presents the code hierarchy
            ExportCodesToMarkdown(
                GetTimestampedExportPath(exportTime, "Exports", "export_V2"),
                hierarchyCodes,
                "Code Export (Only Codes in Code Hierarchy)",
                exportTime);
        }

        public void ExportCodesToMarkdown(string outputFilePath)
        {
            if (Models.CodesDictionary == null || Models.CodesDictionary.Count == 0)
            {
                Log("Models.CodesDictionary is empty or null.");
                return;
            }

            ExportCodesToMarkdown(
                outputFilePath,
                Models.CodesDictionary.Values,
                "Code Export",
                DateTime.Now);
        }

        private void ExportCodesToMarkdown(
            string outputFilePath,
            IEnumerable<Models.Code> codes,
            string exportTitle,
            DateTime generatedAt)
        {
            // Build and sort by frequency only (most frequent first)
            var sortedCodes = codes
                .OrderByDescending(code => code.DataExtractsCount)
                .ToList();

            using (StreamWriter writer = new StreamWriter(outputFilePath, false, Encoding.UTF8))
            {
                // Write header
                writer.WriteLine($"Generated on: {generatedAt:yyyy-MM-dd HH:mm:ss}");
                writer.WriteLine();
                writer.WriteLine($"Total Codes: {sortedCodes.Count}");
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

            Log($"{exportTitle} completed successfully to: {outputFilePath}");
        }

    }
}
