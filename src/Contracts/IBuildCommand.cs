namespace Contracts;

public interface IBuildCommand
{
    BuildCommands Command { get; }

    Task Execute(string[] args);

    Dictionary<string, string> Env { get; }
}
