using Contracts;

namespace Extension.Tool1.Commands;

public class BuildCommand : IBuildCommand
{
    public BuildCommands Command => BuildCommands.Build;

    public Task Execute(string[] args)
    {
        Console.WriteLine("Build command not implemented.");

        return Task.CompletedTask;
    }

    public Dictionary<string, string> Env { get; } = new Dictionary<string, string>(Constants.DefaultEnv);
}
