namespace ExceptionHandling;

public class SafeFileManager
{
    public string FilePath { get; private set; }

    public SafeFileManager(string filePath)
    {
        var directoryExists = Directory.Exists(Path.GetDirectoryName(filePath));
        if (!directoryExists)
        {
            throw new DirectoryNotFoundException("Directory not found. Please specify an existing directory");
        }

        FilePath = filePath;
    }

    public FileOperationResult ReadFileContent()
    {
        try
        {
            if (!File.Exists(FilePath))
            {
                return FileOperationResult.Failure("Fila finnes ikke. Hva med å kjøre 'create' først?");
            }

            return FileOperationResult.Success(File.ReadAllText(FilePath));
        }
        catch (Exception e)
        {
            return FileOperationResult.Failure("Feil ved å lese fil: " + e.Message);
        }
    }

    public FileOperationResult WriteFileContent(string content)
    {
        try
        {
            File.WriteAllText(FilePath, content);
            return FileOperationResult.Success();
        }
        catch (Exception e)
        {
            return FileOperationResult.Failure("Feil ved å lese fil: " + e.Message);
        }
    }

    public FileOperationResult CreateFile()
    {
        try
        {
            if (File.Exists(FilePath))
            {
                return FileOperationResult.Success("Fila fantes fra før");
            }

            File.Create(FilePath).Close();
            return FileOperationResult.Success();
        }
        catch (Exception e)
        {
            return FileOperationResult.Failure("Feil ved å lage fil: " + e.Message);
        }
    }

    public FileOperationResult DeleteFile()
    {
        File.Delete(FilePath);
        return FileOperationResult.Success();
    }

    public FileOperationResult MoveFile(string newPath)
    {
        try
        {
            if (!File.Exists(FilePath))
            {
                return FileOperationResult.Failure("Fila finnes ikke. Hva med å kjøre 'create' først?");
            }

            File.Move(FilePath, newPath);
            FilePath = newPath;
            return FileOperationResult.Success($"Sti er oppdatert til {FilePath}");
        }
        catch (Exception e)
        {
            return FileOperationResult.Failure("Feil ved å flytte fil: " + e.Message);
        }
    }
}