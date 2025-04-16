using Contracts;
using Microsoft.VisualBasic;

namespace Extension.Tool1.Commands;

public class RestoreCommand : IBuildCommand
{
    public BuildCommands Command => BuildCommands.Restore;

    public Task Execute(string[] args)
    {
        // TODO

        if (Env.TryGetValue(Constants.TestVar1, out string value))
        {
            Console.WriteLine($"Restored value: {value}");
        }

        return Task.CompletedTask;
    }

    public Dictionary<string, string> Env { get; } = new Dictionary<string, string>(Constants.DefaultEnv);
}
