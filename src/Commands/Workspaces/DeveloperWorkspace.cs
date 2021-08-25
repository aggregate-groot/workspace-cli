using System;
using System.Collections.Generic;

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
        }

        /// <summary>
        /// Gets the default settings for the workspace.
        /// </summary>
        public IReadOnlyCollection<WorkspaceSetting> DefaultSettings 
            => _workspaceSettings.AsReadOnly();

        /// <summary>
        /// Saves the current workspace.
        /// </summary>
        public Task SaveAsync()
        {
            return Task.CompletedTask;
        }

        private readonly string _configurationPath;
        private readonly List<WorkspaceSetting> _workspaceSettings = new();
    }
}