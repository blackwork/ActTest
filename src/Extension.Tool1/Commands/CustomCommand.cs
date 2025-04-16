using Contracts;

namespace Extension.Tool1.Commands;

public class CustomCommand : IBuildCommand
{
    public BuildCommands Command => BuildCommands.Custom;

    public Task Execute(string[] args)
    {
        Console.WriteLine("Custom command not implemented.");
        // TODO

        return Task.CompletedTask;
    }

    public Dictionary<string, string> Env { get; } = new Dictionary<string, string>(Constants.DefaultEnv);
}
