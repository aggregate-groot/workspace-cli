using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace AggregateGroot.Workspace.Cli.Commands.Workspaces
{
    /// <summary>
    /// Represents the developer's workspace.
    /// </summary>
    public class DeveloperWorkspace
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeveloperWorkspace"/> class.
        /// </summary>
        /// <param name="configurationPath">
        /// Required path to save the workspace configuration to.
        /// </param>
        /// <param name="workspaceSettings">
        /// Required workspace settings.
        /// </param>
        public DeveloperWorkspace(
            string configurationPath,
            IEnumerable<WorkspaceSetting> workspaceSettings)
        {
            _configurationPath = configurationPath 
                ?? throw new ArgumentNullException(nameof(configurationPath));

            _workspaceSettings = workspaceSettings.ToList();
        }

        /// <summary>
        /// Gets the default settings for the workspace.
        /// </summary>
        public IReadOnlyCollection<WorkspaceSetting> Settings 
            => _workspaceSettings.AsReadOnly();

        /// <summary>
        /// Saves the current workspace.
        /// </summary>
        public async Task SaveAsync()
        {
            string json = JsonSerializer.Serialize(
                Settings,
                new JsonSerializerOptions()
                {
                    WriteIndented = true
                });

            //string configurationFilePath = Path.Combine(_configurationPath, "workspace-settings.json");
            string configurationDirectory = Path.GetDirectoryName(_configurationPath);
            Directory.CreateDirectory(configurationDirectory);

            Console.WriteLine($"Saving workspace configuration to {_configurationPath}.");

            await File.WriteAllTextAsync(_configurationPath, json);
        }

        /// <summary>
        /// Adds the settings required for the workspace to operate.
        /// </summary>
        public void AddRequiredSettings()
        {
            _workspaceSettings.Add(new WorkspaceSetting()
            {

            });
        }

        private readonly string _configurationPath;
        private readonly List<WorkspaceSetting> _workspaceSettings = new();
    }
}