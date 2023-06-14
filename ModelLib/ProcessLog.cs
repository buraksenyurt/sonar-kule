namespace ModelLib;

public class ProcessLog
{
    public string Summary { get; set; } = string.Empty;
    public DateTime LogDate { get; set; } = DateTime.Now;
    public LogLevel Level { get; set; }

    public override string ToString()
    {
        return this.LogDate.ToLongTimeString() + " " + this.Level.ToString() + " " + Summary;
    }
}

public enum LogLevel
{
    Info,
    Debug,
    Error,
    Warn
}
