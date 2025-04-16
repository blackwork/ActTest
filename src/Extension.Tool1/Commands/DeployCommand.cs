using Contracts;

namespace Extension.Tool1.Commands;

public class DeployCommand : IBuildCommand
{
    public BuildCommands Command => BuildCommands.Deploy;

    public Task Execute(string[] args)
    {
        Console.WriteLine("Deploy command not implemented.");

        return Task.CompletedTask;
    }

    public Dictionary<string, string> Env { get; } = new Dictionary<string, string>(Constants.DefaultEnv);
}
