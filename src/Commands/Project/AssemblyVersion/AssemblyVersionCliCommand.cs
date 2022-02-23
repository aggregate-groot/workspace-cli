using McMaster.Extensions.CommandLineUtils;

namespace AggregateGroot.CliTools.Commands.Project.AssemblyVersion
{
    /// <summary>
    /// Represents the CLI command for getting the version of a .NET assembly.
    /// </summary>
    [Command("assembly-version", Description = "Get the version of an assembly in a project.")]
    public class AssemblyVersionCliCommand : CliCommand
    {
    }
}