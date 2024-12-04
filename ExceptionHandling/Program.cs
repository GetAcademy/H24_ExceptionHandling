using ExceptionHandling;


var fileManager = new FileManager(@"C:\Dev\test.txt");

Console.WriteLine("Available commands: create, write, read, delete, move");
while (true)
{
    try
    {
        Console.Write("File command: ");
        var command = Console.ReadLine();
        switch (command)
        {
            case "read":
                Console.WriteLine(fileManager.ReadFileContent());
                break;
            case "create":
                fileManager.CreateFile();
                Console.WriteLine($"File {fileManager.FilePath} created");
                break;
            case "write":
                Console.Write("Content: ");
                var content = Console.ReadLine();
                fileManager.WriteFileContent(content);
                break;
            case "delete":
                fileManager.DeleteFile();
                break;
            case "move":
                Console.Write("New path: ");
                var newPath = Console.ReadLine();
                fileManager.MoveFile(newPath);
                break;
            case "exit":
                Environment.Exit(0);
                break;
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("Unhandled exception. Try again. Exception: " + e.Message);
    }
}

// var downloader = new WebsiteDownloader();
// Console.Write("Enter url: ");
// var url = Console.ReadLine();
// Console.WriteLine(downloader.Download(url));



