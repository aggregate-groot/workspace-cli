using System;
using System.Threading.Tasks;

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
            this.OnExecute(async () =>
            {
                Console.WriteLine("Initializing the workspace...");
                await CreateUserConfigurationAsync();

            });
        }

        private async Task CreateUserConfigurationAsync()
        {
            foreach (WorkspaceSetting setting in _workspace.Settings)
            {
                string currentValue = setting.Value;
                setting.Value = Prompt.GetString(setting.Prompt, currentValue);
            }

            await _workspace.SaveAsync();
        }

        private readonly DeveloperWorkspace _workspace;
    }
}