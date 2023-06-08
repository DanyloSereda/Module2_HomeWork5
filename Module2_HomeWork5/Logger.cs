public class Logger
{
    public enum LogType
    {
        Info, Warning, Error
    }

    private readonly FileService fileLog;

    public Logger(FileService fileService)
    {
        this.fileLog = fileService;
    }

    public void Log(string message, LogType logType)
    {
        string logTime = DateTime.Now.ToString("HH:mm:ss");
        string logEntry = $"{logTime}: {logType.ToString()}: {message}";

        Console.WriteLine(logEntry);
        fileLog.WriteLog(logEntry);
    }
}