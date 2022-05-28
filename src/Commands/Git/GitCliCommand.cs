using McMaster.Extensions.CommandLineUtils;

using AggregateGroot.CliTools.Commands.Git.PushAll;

namespace AggregateGroot.CliTools.Commands.Git
{
    /// <summary>
    /// Root command for git sub commands.
    /// </summary>
    [Command("git", Description = "Root command for git sub commands.")]
    [Subcommand(typeof(PushAllCliCommand))]
    public class GitCliCommand : CliCommand
    {
    
    }
}