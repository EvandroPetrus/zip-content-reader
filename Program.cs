using System.IO.Compression;

class Program
{
    static void Main()
    {
        string archive = "novaera_65_05.419.268-4";
        string folderPath = @"C:\Infis\data\Exporta_Nomes\input\" + archive;
        string outputFilePath = @"C:\Infis\data\Exporta_Nomes\output\output - " + archive + ".txt";

        List<string> fileNames = new List<string>();

        string[] zipFiles = Directory.GetFiles(folderPath, "*.zip");

        foreach (string zipFile in zipFiles)
        {
            List<string> extractedFileNames = ExtractFileNamesFromZip(zipFile);
            fileNames.AddRange(extractedFileNames);
        }

        WriteFileNamesToTxt(fileNames, outputFilePath);

        Console.WriteLine("Extraction completed.");
    }

    static List<string> ExtractFileNamesFromZip(string zipFilePath)
    {
        List<string> fileNames = new List<string>();

        using (ZipArchive archive = ZipFile.OpenRead(zipFilePath))
        {
            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                fileNames.Add(entry.FullName);
                Console.WriteLine($"Adding entry: {entry.FullName}");
            }
        }

        return fileNames;
    }

    static void WriteFileNamesToTxt(List<string> fileNames, string outputFilePath)
    {
        Console.WriteLine($"Writing file on: '{outputFilePath}'");
        File.WriteAllLines(outputFilePath, fileNames);
    }
}
