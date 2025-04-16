namespace mybuildtool.CiCd;

public class NullSupport : ICiCdSupport
{
    public string EnvironmentType => "Null"; 

    public string GetEnv(string key)
    {
        return Environment.GetEnvironmentVariable(key);
    }

    public void SetEnv(string key, string value)
    {
        Environment.SetEnvironmentVariable(key, value);       
    }
}