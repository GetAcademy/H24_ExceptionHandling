namespace ExceptionHandling;

public class FileApplication
{
    private readonly SafeFileManager _fileManager;

    public FileApplication()
    {
        _fileManager = new SafeFileManager(@"C:\Dev\test.txt");
    }
    public void Run()
    {
        Console.WriteLine("Available commands: create, write, read, delete, move");
        while (true)
        {
            try
            {
                Console.Write("File command: ");
                var command = Console.ReadLine();
                var result = RunCommand(command);
                if (result is null)
                {
                    return;
                }
                
                PrintResult(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Operasjonsfeil. Prøv igjen. Exception: " + e.Message);
            }
        }
    }

    private static void PrintResult(FileOperationResult result)
    {
        if (result.Successful)
        {
            if (!string.IsNullOrEmpty(result.Message))
            {
                Console.WriteLine(result.Message);    
            }
        }
        else
        {
            Console.WriteLine($"Operasjonen var ikke vellykket. Melding: {result.Message}");
        }
    }

    private FileOperationResult RunCommand(string command)
    {
        FileOperationResult result = null;
        switch (command)
        {
            case "read":
                result = _fileManager.ReadFileContent();
                break;
            case "create":
                result = _fileManager.CreateFile();
                break;
            case "write":
                Console.Write("Content: ");
                var content = Console.ReadLine();
                result = _fileManager.WriteFileContent(content);
                break;
            case "delete":
                result = _fileManager.DeleteFile();
                break;
            case "move":
                Console.Write("New path: ");
                var newPath = Console.ReadLine();
                result = _fileManager.MoveFile(newPath);
                break;
            case "exit":
                return null;
        }

        return result;
    }
}