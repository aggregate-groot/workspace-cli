using McMaster.Extensions.CommandLineUtils;

using AggregateGroot.Workspace.Cli.Commands.Workspaces;

namespace AggregateGroot.Workspace.Cli.Commands.Init
{
    /// <summary>
    /// Extension methods for adding the "init" command to
    /// the CLI application.
    /// </summary>
    public static class InitCommandExtensions
    {
        /// <summary>
        /// Adds the "init" command to the supplied <paramref name="application"/>.
        /// </summary>
        /// <param name="application">
        /// Required instance of the <see cref="CommandLineApplication"/> to add
        /// the command to.
        /// </param>
        /// <param name="workspace">
        /// Required developer workspace to initialize.
        /// </param>
        public static CommandLineApplication AddInitCommand(
            this CommandLineApplication application,
            DeveloperWorkspace workspace)
        {
            InitCommand command = new(workspace);

            application.AddSubcommand(command);
            return application;
        }
    }
}