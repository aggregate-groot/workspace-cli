using System;

using McMaster.Extensions.CommandLineUtils;

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
        public InitCommand()
        {
            this.Name = "init";
            this.Description = "Initializes the developer's workspace";
            this.HelpOption("-h|--help");
            this.OnExecute(() =>
            {
                Console.WriteLine("Init...");
            });
        }
    }
}