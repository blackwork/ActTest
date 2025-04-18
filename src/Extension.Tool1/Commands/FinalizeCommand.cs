using Contracts;
using Microsoft.VisualBasic;

namespace Extension.Tool1.Commands;

public class FinalizeCommand : IBuildCommand
{
    public BuildCommands Command => BuildCommands.Finalize;

    public Task Execute(string[] args)
    {
        Console.WriteLine("Finalize command not implemented.");

        return Task.CompletedTask;
    }

    public Dictionary<string, string> Env { get; } = new Dictionary<string, string>(Constants.DefaultEnv);
}
