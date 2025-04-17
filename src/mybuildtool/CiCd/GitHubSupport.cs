namespace mybuildtool.CiCd;

public class GitHubSupport : ICiCdSupport
{
    private readonly string _gitHubEnvPath;

    public string EnvironmentType => "GitHub"; 

    public GitHubSupport()
    {
        _gitHubEnvPath = Environment.GetEnvironmentVariable("GITHUB_ENV");
    }

    public string GetEnv(string key)
    {
        return Environment.GetEnvironmentVariable(key);
    }

    public void SetEnv(string key, string value)
    {
        if (!string.IsNullOrEmpty(_gitHubEnvPath))
        {
            try
            {
                // Write the variable to the GITHUB_ENV file (to handover to next tool call.
                using (var writer = new StreamWriter(_gitHubEnvPath, true))
                {
                    writer.WriteLine($"{key}={value}");
                }


                // update environment variable (for commands in a row)
                Environment.SetEnvironmentVariable(key, value);

                //Console.WriteLine($"Environment variable successfully set! Value={value}");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"An error occurred while writing to GITHUB_ENV: {ex.Message}", ex);
            }
        }
        else
        {
            throw new InvalidOperationException("GITHUB_ENV environment variable not found.");
        }
    }
}