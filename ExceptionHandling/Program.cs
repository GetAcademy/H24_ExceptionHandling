using ExceptionHandling;

var fileManager = new FileManager(@"C:\Dev\test.txt");

Console.WriteLine("Available commands: create, write, read, delete, move");
while (true)
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
            Console.WriteLine($"File {fileManager.Path} created");
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




