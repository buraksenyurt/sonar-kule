namespace CommonLib.Exceptions;

public class ReportException
    : Exception
{
    public ReportException()
        : base("Raporlamada bir sorun oluştu.")
    {
    }
}
