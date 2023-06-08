using static Logger;

public class Actions
{
    private readonly Logger logger;

    public Actions(Logger log)
    {
        logger = log;
    }

    public bool StartMethod()
    {
        string methodName = nameof(StartMethod);
        logger.Log($"Start method: {methodName}", LogType.Info);
        return true;
    }

    public bool SkippedLogicInMethod()
    {
        throw new BusinessException("Skipped logic in method");
    }

    public bool Error()
    {
        throw new Exception("I broke a logic");
    }
}