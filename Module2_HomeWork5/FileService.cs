public class FileService
{
    private const int MaxLogFileCount = 3;
    private readonly string logDirectory;
    private bool isFirstLog = true;

    public FileService(string logDirectory)
    {
        this.logDirectory = logDirectory;
    }

    public void WriteLog(string logMessage)
    {
        string solutionDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\"));

        string logDirectoryPath = Path.Combine(solutionDirectory, logDirectory);

        if (!Directory.Exists(logDirectoryPath))
        {
            Directory.CreateDirectory(logDirectoryPath);
        }

        if (isFirstLog)
        {
            string logFileName = $"{DateTime.Now:HH.mm.ss dd.MM.yyyy}.txt";
            string logFilePath = Path.Combine(logDirectoryPath, logFileName);

            File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
            isFirstLog = false;
        }
        else
        {
            string[] logFiles = Directory.GetFiles(logDirectoryPath, "*.txt");
            if (logFiles.Length > MaxLogFileCount)
            {
                Array.Sort(logFiles, (f1, f2) => File.GetCreationTime(f1).CompareTo(File.GetCreationTime(f2)));

                File.Delete(logFiles[0]);
            }
        }
    }
}