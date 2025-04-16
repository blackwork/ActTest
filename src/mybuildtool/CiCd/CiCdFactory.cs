namespace mybuildtool.CiCd;

public static class CiCdFactory
{
    public static ICiCdSupport Create()
    {
        if (string.Equals(Environment.GetEnvironmentVariable("GITHUB_ACTIONS"), "true", StringComparison.InvariantCultureIgnoreCase))
        {
            return new GitHubSupport();
        }
        else if (string.Equals(Environment.GetEnvironmentVariable("CI"), "true", StringComparison.InvariantCultureIgnoreCase) &&
            Environment.GetEnvironmentVariable("GITLAB_CI") != null)
        {
            return new GitLabSupport();
        }
        else if (Environment.GetEnvironmentVariable("TEAMCITY_VERSION") != null)
        {
            return new TeamCitySupport();
        }

        // not executed via CI/CD
        return new NullSupport();
    }
}