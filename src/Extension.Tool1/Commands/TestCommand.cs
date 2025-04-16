using Contracts;

namespace Extension.Tool1.Commands;

public class TestCommand : IBuildCommand
{
    public BuildCommands Command => BuildCommands.Test;

    public Task Execute(string[] args)
    {
        Console.WriteLine("Test command not implemented.");

        return Task.CompletedTask;
    }

    public Dictionary<string, string> Env { get; } = new Dictionary<string, string>(Constants.DefaultEnv);
}
