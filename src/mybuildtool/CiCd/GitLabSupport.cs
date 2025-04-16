namespace mybuildtool.CiCd;

public class GitLabSupport : ICiCdSupport
{
    public string EnvironmentType => "GitLab"; 

    public string GetEnv(string key)
    {
        return Environment.GetEnvironmentVariable(key);
    }

    public void SetEnv(string key, string value)
    {
        try
        {
            // Write the variable to the .env file
            using (var writer = new StreamWriter(".env", true))
            {
                writer.WriteLine($"{key}={value}");
            }

            //Console.WriteLine($"Environment variable successfully set! Value={value}");
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"An error occurred while writing to .env: {ex.Message}", ex);
        }
    }
}