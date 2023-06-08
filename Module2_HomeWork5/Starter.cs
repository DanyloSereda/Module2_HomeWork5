using static Logger;

public class Starter
{
    public void Run()
    {
        ConfigurationService configurationService = new ConfigurationService();
        ConfigurationData configData = configurationService.LoadConfiguration();

        FileService fileService = new FileService(configData.LogDirectory);
        Logger logger = new Logger(fileService);
        Actions actions = new Actions(logger);

        Random random = new Random();
        for (int i = 0; i < 100; i++)
        {
            int action = random.Next(1, 4);
            switch (action)
            {
                case 1:
                    actions.StartMethod();
                    break;
                case 2:
                    try
                    {
                        actions.SkippedLogicInMethod();
                    }
                    catch (BusinessException ex)
                    {
                        logger.Log($"Action got this custom Exception: {ex.Message}", LogType.Warning);
                    }
                    break;
                case 3:
                     try
                    {
                        actions.Error();
                    }
                    catch (Exception ex)
                    {
                        logger.Log($"Action failed by reason: {ex.Message}", LogType.Error);
                    }
                    break;
            }
        }
    }
}