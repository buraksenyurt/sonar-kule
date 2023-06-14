using ModelLib;

namespace CommonLib;

public class FileLogger
{
    private string fileName = Path.Combine(Environment.CurrentDirectory, "application.logs");
    public async void InfoAsync(String content, String source)
    {
        String logMessage = "INFO: Source" + source + ", " + content;
        ProcessLog log=new ProcessLog{
            Level=LogLevel.Info,
            Summary=logMessage,            
        };
        
        System.IO.File.AppendAllText(fileName, log.ToString());
    }
    public async void WarnAsync(String content, String source)
    {
        String logMessage = "WARN: Source" + source + ", " + content;
        ProcessLog log=new ProcessLog{
            Level=LogLevel.Warn,
            Summary=logMessage,            
        };
        System.IO.File.AppendAllText(fileName, logMessage);
    }

    public async void ErrorAsync(String source, String exceptionMessage)
    {
        String logMessage = "ERROR: Source" + source + ":" + exceptionMessage;
        ProcessLog log=new ProcessLog{
            Level=LogLevel.Error,
            Summary=logMessage,            
        };
        System.IO.File.AppendAllText(fileName, logMessage);
    }
}