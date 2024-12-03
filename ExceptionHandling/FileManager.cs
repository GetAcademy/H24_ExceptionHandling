namespace ExceptionHandling;

public class FileManager
{
    public string FilePath { get; }

    public FileManager(string filePath)
    {
        FilePath = filePath;
    }
    
    public string ReadFileContent()
    {
        return File.ReadAllText(FilePath);
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