using Contracts;

namespace Extension.Tool1;

public class BuildCommand : IBuildCommand
{
    public BuildCommands Command => BuildCommands.Build;

    public Task Execute(string[] args)
    {
        // TODO

        return Task.CompletedTask;
    }

    public Dictionary<string, string> Env { get; } = new Dictionary<string, string> 
    {
        { "MY_VAR_1", null }
    };
}
