namespace mybuildtool.CiCd;

public class TeamCitySupport : ICiCdSupport
{
    public string EnvironmentType => "TeamCity"; 

    public string GetEnv(string key)
    {
        return Environment.GetEnvironmentVariable(key);
    }

    public void SetEnv(string key, string value)
    {
        // Write the variable to the TeamCity environment (via console)
        Console.WriteLine($"##teamcity[setParameter name='env.{key}' value='{value}']"); //NOSONAR

        // update environment variable (for commands in a row)
        Environment.SetEnvironmentVariable(key, value);
    }
}