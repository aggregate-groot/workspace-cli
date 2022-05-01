using McMaster.Extensions.CommandLineUtils;

using AggregateGroot.CliTools.Commands.Project.AssemblyVersion;

namespace AggregateGroot.CliTools.Commands.Project
{
    /// <summary>
    /// Represents the CLI command for working with .NET projects.
    /// </summary>
    [Command("project", Description = "Root command for working with projects.")]
    [Subcommand(typeof(AssemblyVersionCliCommand))]
    public class ProjectCliCommand : CliCommand
    {
    }
}