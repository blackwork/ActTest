using Contracts;
using Microsoft.VisualBasic;

namespace Extension.Tool1.Commands;

public class InitializeCommand : IBuildCommand
{
    public BuildCommands Command => BuildCommands.Initialize;

    public Task Execute(string[] args)
    {
        // TODO

        var value = "Hello World";
        Env[Constants.TestVar1] = value;

        return Task.CompletedTask;
    }

    public Dictionary<string, string> Env { get; } = new Dictionary<string, string>(Constants.DefaultEnv);
}
