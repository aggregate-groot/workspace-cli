using System;
using System.IO;
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

        /// <summary>
        /// Gets or initializes the path of the assembly.
        /// </summary>
        [Argument(0, Name = "path", Description = "The path to the assembly to get the version for.")]
        public string Path { get; init; }

        /// <inheritdoc />
        public override int OnExecute(CommandLineApplication app)
        {
            if (string.IsNullOrWhiteSpace(Path))
            {
                _console.Error.Write(
                    "Please provide the path of the assembly to get the version for.");

                app.ShowHelp();

                return (int)AssemblyVersionResponseCode.PathNotProvided;
            }

            if (!File.Exists(Path))
            {
                string message = BuildAssemblyNotFoundMessage(Path);
                _console.Error.Write(
                    BuildAssemblyNotFoundMessage(Path));

                app.ShowHelp();

                return (int)AssemblyVersionResponseCode.AssemblyNotFound;
            }
            
            return (int)AssemblyVersionResponseCode.Success;
        }

        private readonly IConsole _console;
        private readonly IPrompt _prompt;

        private static string BuildAssemblyNotFoundMessage(string path)
        {
            string fileName = System.IO.Path.GetFileName(path);
            string directory = System.IO.Path.GetDirectoryName(path);

            return $"Could not find assembly '{fileName}' in directory '{directory}'.";
        }
    }
}