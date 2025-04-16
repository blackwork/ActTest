// See https://aka.ms/new-console-template for more information

Console.WriteLine("My Build Tool!");

Console.WriteLine();
Console.WriteLine("Args");

foreach (var arg in args)
{
    Console.WriteLine($" - {arg}");
}


if (string.Equals(Environment.GetEnvironmentVariable("$GITHUB_ACTIONS"), "true", StringComparison.InvariantCultureIgnoreCase))
{
    Console.WriteLine("Running in a GitHub Actions environment!");
}
else
{
    Console.WriteLine("Not running in GitHub Actions.");
}


// Console.WriteLine();
// Console.WriteLine("Environment Vars (Current Process)");

// IDictionary dict = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Process);
// foreach (var key in dict.Keys)
// {
//     string val = dict[key].ToString();
//     Console.WriteLine($" {key} = {val}");
// }

// Get the path to the GITHUB_ENV file from the environment variable
var githubEnvPath = Environment.GetEnvironmentVariable("GITHUB_ENV");
var myVariable = Environment.GetEnvironmentVariable("MY_VARIABLE");

// Check if custom var exists
if (!string.IsNullOrEmpty(myVariable))
{
    Console.WriteLine($"Value: {myVariable}");
}
// Check if the path exists
else if (!string.IsNullOrEmpty(githubEnvPath))
{
    try
    {
        string value = $"Hello from C# ({DateTime.Now:U})";
        // Write the variable to the GITHUB_ENV file
        using (var writer = new StreamWriter(githubEnvPath, true))
        {
            writer.WriteLine($"MY_VARIABLE={value}");
        }

        Console.WriteLine($"Environment variable successfully set! Value={value}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while writing to GITHUB_ENV: {ex.Message}");
    }
}
else
{
    Console.WriteLine("GITHUB_ENV and MY_VARIABLE environment variable not found.");
}