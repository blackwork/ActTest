using Contracts;
using System.ComponentModel.Composition;

namespace Extension.Tool1;

[Export(typeof(IBuildToolExtension))]
public class Tool1Extension : IBuildToolExtension
{
    public string ToolType => "Tool1";

    public IBuildCommand GetCommand(BuildCommands command)
    {
        switch (command)
        {
            case BuildCommands.Initialie:
                return new Commands.InitializeCommand();
            case BuildCommands.Restore:
                return new Commands.RestoreCommand();
            case BuildCommands.Build:
                return new Commands.BuildCommand();
            case BuildCommands.Test:
                throw new NotImplementedException($"Requested build command '{command}' not implemented");
            case BuildCommands.Deploy:
                throw new NotImplementedException($"Requested build command '{command}' not implemented");
            case BuildCommands.Finalize:
                return new Commands.FinalizeCommand();
            default:
                throw new NotImplementedException($"Requested build command '{command}' not implemented");
        }
    }
}
