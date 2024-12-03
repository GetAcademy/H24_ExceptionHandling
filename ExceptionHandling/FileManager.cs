namespace ExceptionHandling;

public class FileManager
{
    public string Path { get; }

    public FileManager(string path)
    {
        Path = path;
    }
    
    public string ReadFileContent()
    {
        return File.ReadAllText(Path);
    }

    public void WriteFileContent(string content)
    {
        File.WriteAllText(Path, content);
    }

    public void CreateFile()
    {
        File.Create(Path).Close();
    }

    public void DeleteFile()
    {
        File.Delete(Path);
    }

    public void MoveFile(string newPath)
    {
        File.Move(Path, newPath);
    }
}