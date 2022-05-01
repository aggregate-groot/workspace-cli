using System;

using McMaster.Extensions.CommandLineUtils;

namespace AggregateGroot.CliTools.Commands.Project.AssemblyVersion
{
    /// <summary>
    /// Represents the CLI command for getting the version of a .NET assembly.
    /// </summary>
    [Command("assembly-version", Description = "Get the version of an assembly in a project.")]
    public class AssemblyVersionCliCommand
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

        /// <summary>
        /// Gets or initializes the path of the assembly.
        /// </summary>
        [Argument(0, Description = "The path to the assembly to get the version for.")]
        public string Path { get; init; }

        /// <summary>
        /// Executes the command.
        /// </summary>
        public AssemblyVersionResponseCode OnExecute()
        {
            if (string.IsNullOrWhiteSpace(Path))
            {
                _console.Error.Write(
                    "Please provide the path of the assembly to get the version for.");

                return AssemblyVersionResponseCode.PathNotProvided;
            }
            
            return AssemblyVersionResponseCode.Success;
        }

        private readonly IConsole _console;
        private readonly IPrompt _prompt;
    }
}