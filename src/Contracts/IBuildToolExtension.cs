namespace Contracts;

public interface IBuildToolExtension
{
    string ToolType { get; }
    IBuildCommand GetCommand(BuildCommands command);
}
