using Contracts;
using Microsoft.VisualBasic;

namespace Extension.Tool1.Commands;

public class RestoreCommand : IBuildCommand
{
    public BuildCommands Command => BuildCommands.Restore;

    public Task Execute(string[] args)
    {
        if (Env.TryGetValue(Constants.TestVar1, out string value) && value != null)
        {
            Console.WriteLine($"Restored value: {value}");
        }
        else
        {
            Console.WriteLine($"Restore failed.");
        }

        Console.WriteLine("Restore command not implemented.");

        return Task.CompletedTask;
    }

    public Dictionary<string, string> Env { get; } = new Dictionary<string, string>(Constants.DefaultEnv);
}
