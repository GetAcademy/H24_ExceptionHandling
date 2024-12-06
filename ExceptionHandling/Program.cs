using ExceptionHandling;

var fileApplication = new FileApplication();
try
{
    fileApplication.Run();
}
catch (Exception e)
{
    Console.WriteLine(e);
}


// var downloader = new WebsiteDownloader();
// Console.Write("Enter url: ");
// var url = Console.ReadLine();
// Console.WriteLine(downloader.Download(url));



