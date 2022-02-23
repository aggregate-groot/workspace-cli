using System.Reflection;

using McMaster.Extensions.CommandLineUtils;

using AggregateGroot.CliTools.Commands.Project;

namespace AggregateGroot.Workspace.Cli
{
    /// <summary>
    /// Represents the root command for the application.
    /// </summary>
    [Subcommand(typeof(ProjectCliCommand))]
    public class RootCommand
    {
        /// <summary>
        /// Runs when this command is executed.
        /// </summary>
        /// <param name="application">
        /// Required command line application.
        /// </param>
        /// <param name="console">
        /// Required console.
        /// </param>
        private int OnExecute(CommandLineApplication application, IConsole console)
        {
            string versionNumber = Assembly
                .GetExecutingAssembly()
                .GetName()
                .Version?
                .ToString();

            console.WriteLine("-----------------------------------");
            console.WriteLine("CLI.");
            console.WriteLine("Use -h for more help.");
            console.WriteLine("Version: " + versionNumber);
            console.WriteLine("-----------------------------------");

            application.ShowHelp();
            return 1;
        }
    }
}