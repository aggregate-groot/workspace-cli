using System;
using System.Collections.Generic;
using System.IO;
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

            application.AddInitCommand(ConfigureWorkspace());

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

        /// <summary>
        /// Configures the workspace.
        /// </summary>
        private static DeveloperWorkspace ConfigureWorkspace()
        {
            string configurationPath = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData,
                    Environment.SpecialFolderOption.DoNotVerify), 
                "Workspace-Cli");

            List<WorkspaceSettingDefinition> settingDefinitions = new()
            {
                new WorkspaceSettingDefinition()
                {
                    Name = "SomeSetting",
                    Prompt = "Some Setting:",
                    Default = "some-value"
                }
            };

            return new DeveloperWorkspace(configurationPath, settingDefinitions);
        }
    }
}