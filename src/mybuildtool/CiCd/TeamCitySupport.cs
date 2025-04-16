namespace mybuildtool.CiCd;

public class TeamCitySupport : ICiCdSupport
{
    public string GetEnv(string key)
    {
        return Environment.GetEnvironmentVariable(key);
    }

    public void SetEnv(string key, string value)
    {
        Console.WriteLine($"##teamcity[setParameter name='env.MY_VARIABLE' value='{value}']"); //NOSONAR
    }
}