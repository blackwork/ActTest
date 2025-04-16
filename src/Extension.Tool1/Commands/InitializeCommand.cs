using Contracts;
using Microsoft.VisualBasic;

namespace Extension.Tool1.Commands;

public class InitializeCommand : IBuildCommand
{
    public BuildCommands Command => BuildCommands.Initialie;

    public Task Execute(string[] args)
    {
        // TODO

        return Task.CompletedTask;
    }

    public Dictionary<string, string> Env { get; } = new Dictionary<string, string>(Constants.DefaultEnv);
}
