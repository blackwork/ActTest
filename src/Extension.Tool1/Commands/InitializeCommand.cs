using Contracts;
using Microsoft.VisualBasic;

namespace Extension.Tool1.Commands;

public class InitializeCommand : IBuildCommand
{
    public BuildCommands Command => BuildCommands.Initialize;

    public Task Execute(string[] args)
    {
        var value = "Hello World";
        Env[Constants.TestVar1] = value;
        Console.WriteLine($"Update value to: {value}");

        Console.WriteLine("Initialize command not implemented.");

        return Task.CompletedTask;
    }

    public Dictionary<string, string> Env { get; } = new Dictionary<string, string>(Constants.DefaultEnv);
}
