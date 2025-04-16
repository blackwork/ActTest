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
                throw new NotImplementedException($"Requested build command '{command}' not implemented");
            case BuildCommands.Restore:
                throw new NotImplementedException($"Requested build command '{command}' not implemented");
            case BuildCommands.Build:
                return new BuildCommand();
            case BuildCommands.Test:
                throw new NotImplementedException($"Requested build command '{command}' not implemented");
            case BuildCommands.Deploy:
                throw new NotImplementedException($"Requested build command '{command}' not implemented");
            case BuildCommands.Finalize:
                throw new NotImplementedException($"Requested build command '{command}' not implemented");
            default:
                throw new NotImplementedException($"Requested build command '{command}' not implemented");
        }
    }
}
