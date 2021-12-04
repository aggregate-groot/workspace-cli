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
        /// <param name="settingDefinitions">
        /// Required workspace setting definitions.
        /// </param>
        public DeveloperWorkspace(
            string configurationPath,
            IEnumerable<WorkspaceSettingDefinition> settingDefinitions)
        {
            _configurationPath = configurationPath 
                ?? throw new ArgumentNullException(nameof(configurationPath));

            _settingDefinitions = settingDefinitions.ToList();
        }

        /// <summary>
        /// Gets the default settings for the workspace.
        /// </summary>
        public IReadOnlyCollection<WorkspaceSetting> Settings
            => null;//_settingDefinitions.AsReadOnly();

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

            string configurationDirectory = Path.GetDirectoryName(_configurationPath);
            Directory.CreateDirectory(configurationDirectory);

            Console.WriteLine($"Saving workspace configuration to {_configurationPath}.");

            await File.WriteAllTextAsync(_configurationPath, json);
        }

        private readonly string _configurationPath;
        private readonly List<WorkspaceSettingDefinition> _settingDefinitions = new();
    }
}