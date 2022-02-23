using McMaster.Extensions.CommandLineUtils;

namespace AggregateGroot.CliTools.Commands
{
    /// <summary>
    /// Base class for CLI commands.
    /// </summary>
    public abstract class CliCommand
    {
        /// <summary>
        /// Runs when this command is executed.
        /// </summary>
        /// <param name="application">
        /// Required command line application.
        /// </param>
        public virtual int OnExecute(CommandLineApplication application)
        {
            application.ShowHelp();
            return 1;
        }
    }
}