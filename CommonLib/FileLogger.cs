namespace CommonLib;

public class FileLogger
{
    private string fileName = Path.Combine(Environment.CurrentDirectory, "application.logs");
    public async void InfoAsync(String content, String source)
    {
        String logMessage = "INFO: Source" + source + ", " + DateTime.Now.ToLongTimeString() + ":" + content;
        System.IO.File.AppendAllText(fileName, logMessage);
    }
    public async void WarnAsync(String content, String source)
    {
        String logMessage = "WARN: Source" + source + ", " + DateTime.Now.ToLongTimeString() + ":" + content;
        System.IO.File.AppendAllText(fileName, logMessage);
    }

    public async void ErrorAsync(String source, String exceptionMessage)
    {
        String logMessage = "ERROR: Source" + source + ", " + DateTime.Now.ToLongTimeString() + ":" + exceptionMessage;
        System.IO.File.AppendAllText(fileName, logMessage);
    }
}