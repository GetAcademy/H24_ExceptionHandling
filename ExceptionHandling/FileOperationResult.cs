namespace ExceptionHandling;

public class FileOperationResult
{
    public bool Successful { get; set; }
    public string Message { get; set; }

    public static FileOperationResult Success(string message = "")
    {
        return new FileOperationResult
        {
            Successful = true,
            Message = message
        };
    }
    
    public static FileOperationResult Failure(string message)
    {
        return new FileOperationResult
        {
            Successful = false,
            Message = message
        };
    }
}