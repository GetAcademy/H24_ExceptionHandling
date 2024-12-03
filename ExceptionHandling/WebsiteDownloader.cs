namespace ExceptionHandling;

public class WebsiteDownloader
{
    public string Download(string url)
    {
        using var client = new HttpClient();
        var response = client.GetAsync(url).Result;
        response.EnsureSuccessStatusCode();
        var responseBody = response.Content.ReadAsStringAsync().Result;

        return responseBody;
    }
}