using System;
using System.Reflection;

using McMaster.Extensions.CommandLineUtils;

using AggregateGroot.Workspace.Cli.Commands.Init;
using AggregateGroot.Workspace.Cli.Commands.Workspaces;

namespace AggregateGroot.Workspace.Cli
{
    /// <summary>
    /// Represents the main command line application.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">
        /// Optional command line arguments.
        /// </param>
        private static void Main(string[] args)
        {
            string versionNumber = Assembly
                .GetExecutingAssembly()
                .GetName()
                .Version
                .ToString();

            var application = new CommandLineApplication();
            application.HelpOption("-h|--help");

            application.AddInitCommand(new DeveloperWorkspace("", new List<WorkspaceSetting>()));

            application.OnExecute(() =>
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("CLI.");
                Console.WriteLine("Use -h for more help.");
                Console.WriteLine("Version: " + versionNumber);
                Console.WriteLine("---------------------------");
                return 0;
            });

            application.Execute(args);
        }
    }
}