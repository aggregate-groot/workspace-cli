using System;

using McMaster.Extensions.CommandLineUtils;

namespace AggregateGroot.CliTools.Commands.Project.AssemblyVersion
{
    /// <summary>
    /// Represents the CLI command for getting the version of a .NET assembly.
    /// </summary>
    [Command("assembly-version", Description = "Get the version of an assembly in a project.")]
    public class AssemblyVersionCliCommand : CliCommand
    {
        /// <summary>
        /// Creates a new instance of the <see cref="AssemblyVersionCliCommand"/> class.
        /// </summary>
        public AssemblyVersionCliCommand(IConsole console, IPrompt prompt)
        {
            _console = console 
                ?? throw new ArgumentNullException(nameof(console));
            _prompt = prompt
                ?? throw new ArgumentNullException(nameof(prompt));
        }

        /// <inheritdoc />
        public override int OnExecute(CommandLineApplication app)
        {
            app.ShowHelp();
            return 1;
        }

        private readonly IConsole _console;
        private readonly IPrompt _prompt;
    }
}