using System;

using McMaster.Extensions.CommandLineUtils;

using AggregateGroot.Workspace.Cli.Commands.Workspaces;

namespace AggregateGroot.Workspace.Cli.Commands.Init
{
    /// <summary>
    /// Represents the "init" command.
    /// </summary>
    public class InitCommand : CommandLineApplication
    {
        /// <summary>
        /// Creates a new instance of the <see cref="InitCommand"/> class.
        /// </summary>
        /// <param name="workspace">
        /// Required developer workspace to initialize.
        /// </param>
        public InitCommand(DeveloperWorkspace workspace)
        {
            _workspace = workspace 
                ?? throw new ArgumentNullException(nameof(workspace));

            Name = "init";
            Description = "Initializes the developer's workspace";

            this.HelpOption("-h|--help");
            this.OnExecute(() =>
            {
                Console.WriteLine("Init...");
            });
        }

        private readonly DeveloperWorkspace _workspace;
    }
}