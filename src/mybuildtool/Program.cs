// See https://aka.ms/new-console-template for more information

using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using Contracts;
using mybuildtool.CiCd;

namespace mybuildtool;

public class Program
{
    [ImportMany]
    public IEnumerable<IBuildToolExtension> BuildToolExtensions { get; set; }
    
    private void ComposeParts()
    {
        string pluginFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);

        // Ensure the folder exists
        Directory.CreateDirectory(pluginFolder);

        // Create a catalog to discover DLLs in the folder
        var catalog = new DirectoryCatalog(pluginFolder, "Extension.*.dll");

        // Create a composition container
        var container = new CompositionContainer(catalog);

        // Compose the parts
        container.ComposeParts(this);
    }

    private IBuildToolExtension GetBuildToolExtension(string toolType)
    {
        return BuildToolExtensions.FirstOrDefault(l => l.ToolType == toolType);
    }
    
    private async Task RunBuildCommand(string[] args)
    {
        if (args.Length < 1)
        {
            throw new ArgumentException("No build command specified.");
        }
        if (!Enum.TryParse<BuildCommands>(args[0], true, out var commandName))
        {
            throw new InvalidOperationException($"Requested build command '{args[0]}' not found defined");
        }

        var ciCdSupport = CiCdFactory.Create();
        var toolType = "Tool1";

        Console.WriteLine($"Detected CI/CD environment type: {ciCdSupport.EnvironmentType}");
        Console.WriteLine($"Running tool type: {toolType}");

        var buildToolExtension = GetBuildToolExtension(toolType);

        if (buildToolExtension == null) 
        {
            throw new InvalidOperationException($"Requested build tool type extension '{toolType}' not installed");
        }

        var command = buildToolExtension.GetCommand(commandName);

        // recover registered command key values
        foreach (var key in command.Env.Keys.ToArray())
        {
            //Console.WriteLine($"Try to restore Environment variable {key}");
            string value = ciCdSupport.GetEnv(key);
            command.Env[key] = value;
        }

        await command.Execute(args.Skip(1).ToArray());

        // persist registered command key values
        foreach (var key in command.Env.Keys.ToArray())
        {
            var value = command.Env[key];
            if (value != null)
            {
                //Console.WriteLine($"Persisted value {key}={value}");
                ciCdSupport.SetEnv(key, command.Env[key]);
            }
        }
    }

    public static async Task<int> Main(string[] args)
    {
        var program = new Program();
        program.ComposeParts();

        try 
        {
            await program.RunBuildCommand(args);

            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while executing build command. {ex.Message}");
            return -1;
        }
        
        // result currently ignored to test envs.



        // // TODO


        // Console.WriteLine("My Build Tool!");

        // Console.WriteLine();
        // Console.WriteLine("Args");

        // foreach (var arg in args)
        // {
        //     Console.WriteLine($" - {arg}");
        // }

        // // Console.WriteLine();
        // // Console.WriteLine("Environment Vars (Current Process)");

        // // IDictionary dict = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Process);
        // // foreach (var key in dict.Keys)
        // // {
        // //     string val = dict[key].ToString();
        // //     Console.WriteLine($" {key} = {val}");
        // // }



        // if (string.Equals(Environment.GetEnvironmentVariable("GITHUB_ACTIONS"), "true", StringComparison.InvariantCultureIgnoreCase))
        // {
        //     // Get the path to the GITHUB_ENV file from the environment variable
        //     var githubEnvPath = Environment.GetEnvironmentVariable("GITHUB_ENV");
        //     var myVariable = Environment.GetEnvironmentVariable("MY_VARIABLE");

        //     // Check if custom var exists
        //     if (!string.IsNullOrEmpty(myVariable))
        //     {
        //         Console.WriteLine($"MY_VARIABLE Value: {myVariable}");
        //     }
        //     // Check if the path exists
        //     else if (!string.IsNullOrEmpty(githubEnvPath))
        //     {
        //         try
        //         {
        //             string value = $"Hello from C# ({DateTime.Now:U})";
        //             // Write the variable to the GITHUB_ENV file
        //             using (var writer = new StreamWriter(githubEnvPath, true))
        //             {
        //                 writer.WriteLine($"MY_VARIABLE={value}");
        //             }

        //             Console.WriteLine($"Environment variable successfully set! Value={value}");
        //         }
        //         catch (Exception ex)
        //         {
        //             Console.WriteLine($"An error occurred while writing to GITHUB_ENV: {ex.Message}");
        //         }
        //     }
        //     else
        //     {
        //         Console.WriteLine("GITHUB_ENV and MY_VARIABLE environment variable not found.");
        //     }

        //     return 0;
        // }
        // else if (string.Equals(Environment.GetEnvironmentVariable("CI"), "true", StringComparison.InvariantCultureIgnoreCase) &&
        //     Environment.GetEnvironmentVariable("GITLAB_CI") != null)
        // {
        //     var myVariable = Environment.GetEnvironmentVariable("MY_VARIABLE");

        //     // Check if custom var exists
        //     if (!string.IsNullOrEmpty(myVariable))
        //     {
        //         Console.WriteLine($"MY_VARIABLE Value: {myVariable}");
        //     }
        //     else
        //     {
        //         try
        //         {
        //             string value = $"Hello from C# ({DateTime.Now:U})";
        //             // Write the variable to the GITHUB_ENV file
        //             using (var writer = new StreamWriter(".env", true))
        //             {
        //                 writer.WriteLine($"MY_VARIABLE={value}");
        //             }

        //             Console.WriteLine($"Environment variable successfully set! Value={value}");
        //         }
        //         catch (Exception ex)
        //         {
        //             Console.WriteLine($"An error occurred while writing to GitLab .env: {ex.Message}");
        //         }
        //     }
        //     // else
        //     // {
        //     //     Console.WriteLine("GITHUB_ENV and MY_VARIABLE environment variable not found.");
        //     // }

        //     return 0;
        // }
        // else if (Environment.GetEnvironmentVariable("TEAMCITY_VERSION") != null)
        // {
        //     var myVariable = Environment.GetEnvironmentVariable("MY_VARIABLE");

        //     // Check if custom var exists
        //     if (!string.IsNullOrEmpty(myVariable))
        //     {
        //         Console.WriteLine($"MY_VARIABLE Value: {myVariable}");
        //     }
        //     else
        //     {
        //         string value = $"Hello from C# ({DateTime.Now:U})";
                
        //         Console.WriteLine($"##teamcity[setParameter name='env.MY_VARIABLE' value='{value}']");
        //         Console.WriteLine($"Environment variable successfully set! Value={value}");
        //     }

        //     return 0;
        // }
        // else
        // {
        //     Console.WriteLine("Not running in GitHub or GitLab Actions or TeamCity.");
        //     return -1;
        // }

    }
}

