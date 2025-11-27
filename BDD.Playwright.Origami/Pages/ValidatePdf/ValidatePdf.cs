using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Text.RegularExpressions;

public static class ValidatePdf
{
    public static async Task ValidatePdfContainsTextAsync(string folderPath, string filePattern, string expectedText = null, string regexPattern = null)
    {
        // Find the latest PDF file matching the filePattern
        var latestPdf = Directory.GetFiles(folderPath, filePattern)
            .OrderByDescending(File.GetLastWriteTime)
            .FirstOrDefault();
        Console.WriteLine(latestPdf);

        if (latestPdf == null)
        {
            throw new FileNotFoundException($"No PDF file found matching pattern '{filePattern}' in {folderPath}");
        }

        var fullText = string.Empty;
        // PDF reading - same logic as before
        await Task.Run(() =>
        {
            using (var reader = new PdfReader(latestPdf))
            {
                for (var i = 1; i <= reader.NumberOfPages; i++)
                {
                    fullText += PdfTextExtractor.GetTextFromPage(reader, i);
                }
            }
        });

        // Normalize whitespace
        fullText = Regex.Replace(fullText, @"\s+", " ");

        if (!string.IsNullOrEmpty(regexPattern))
        {
            var regex = new Regex(regexPattern);
            if (!regex.IsMatch(fullText))
            {
                throw new Exception($"Regex pattern '{regexPattern}' not found in PDF content.");
            }
        }
        else if (!string.IsNullOrEmpty(expectedText))
        {
            if (!fullText.Contains(expectedText))
            {
                throw new Exception($"Expected text '{expectedText}' not found in PDF content.");
            }
        }
        else
        {
            throw new ArgumentException("Expected text or regex pattern must be provided.");
        }

        Console.WriteLine("PDF validation passed.");
    }
}