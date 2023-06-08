using Newtonsoft.Json;

public class ConfigurationService
{
    private const string ConfigFilePath = "E:\\Visual Studio\\Code\\Module2_HomeWork5\\config.json";

    public ConfigurationData LoadConfiguration()
    {
        string jsonContent = File.ReadAllText(ConfigFilePath);
        ConfigurationData configData = JsonConvert.DeserializeObject<ConfigurationData>(jsonContent);
        return configData;
    }
}