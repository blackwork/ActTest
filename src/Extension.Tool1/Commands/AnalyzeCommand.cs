using Contracts;

namespace Extension.Tool1.Commands;

public class AnalyzeCommand : IBuildCommand
{
    public BuildCommands Command => BuildCommands.Analyze;

    public Task Execute(string[] args)
    {
        Console.WriteLine("Analyze command not implemented.");

        return Task.CompletedTask;
    }

    public Dictionary<string, string> Env { get; } = new Dictionary<string, string>(Constants.DefaultEnv);
}
