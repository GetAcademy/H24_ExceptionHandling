namespace ExceptionHandling;

public class FileManager
{
    public string FilePath { get; }

    public FileManager(string filePath)
    {
        var directoryExists = Directory.Exists(Path.GetDirectoryName(filePath));
        if (!directoryExists)
        {
            throw new DirectoryNotFoundException("Directory not found. Please specify an existing directory");
        }
        FilePath = filePath;
    }

    public string ReadFileContent()
    {
        if (!File.Exists(FilePath))
        {
            Console.WriteLine("Fila finnes ikke. Hva med å kjøre 'create' først?");
            return string.Empty;
        }

        try
        {
            return File.ReadAllText(FilePath);
        }
        catch (Exception e)
        {
            Console.WriteLine("Feil ved å lese fil: " + e.Message);
            return string.Empty;
        }
    }

    public void WriteFileContent(string content)
    {
        File.WriteAllText(FilePath, content);
    }

    public void CreateFile()
    {
        File.Create(FilePath).Close();
    }

    public void DeleteFile()
    {
        File.Delete(FilePath);
    }

    public void MoveFile(string newPath)
    {
        File.Move(FilePath, newPath);
    }
}