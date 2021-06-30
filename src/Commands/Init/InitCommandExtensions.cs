using McMaster.Extensions.CommandLineUtils;

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
        public static CommandLineApplication AddInitCommand(
            this CommandLineApplication application)
        {
            InitCommand command = new();

            application.AddSubcommand(command);
            return application;
        }
    }
}