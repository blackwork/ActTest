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
            case BuildCommands.Initialize:
                return new Commands.InitializeCommand();
            case BuildCommands.Restore:
                return new Commands.RestoreCommand();
            case BuildCommands.Build:
                return new Commands.BuildCommand();
            case BuildCommands.Analyze:
                return new Commands.AnalyzeCommand();
            case BuildCommands.Test:
                return new Commands.TestCommand();
            case BuildCommands.Deploy:
                return new Commands.DeployCommand();
            case BuildCommands.Finalize:
                return new Commands.FinalizeCommand();
            default:
                return new Commands.CustomCommand();
        }
    }
}
