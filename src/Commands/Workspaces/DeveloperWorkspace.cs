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
        /// Creates a new instance of the <see cref="DeveloperWorkspace"/> class.
        /// </summary>
        /// <param name="configurationFilePath">
        /// Required path to save the workspace configuration file to.
        /// </param>
        public DeveloperWorkspace(string configurationFilePath)
        {
            
        }

        /// <summary>
        /// Gets the default settings for the workspace.
        /// </summary>
        public IReadOnlyCollection<WorkspaceSetting> DefaultSettings 
            => _workspaceSettings.AsReadOnly();

        /// <summary>
        /// Initializes the developer's workspace.
        /// </summary>
        /// <param name="workspaceSettings">
        /// Required workspace settings used to initialize the developer's workspace.
        /// </param>
        public void Initialize(IEnumerable<WorkspaceSetting> workspaceSettings)
        {
            if (workspaceSettings is null)
            {
                throw new ArgumentNullException(nameof(workspaceSettings));
            }

            foreach (WorkspaceSetting setting in workspaceSettings)
            {
                _workspaceSettings.Add(setting);
            }
        }

        private readonly List<WorkspaceSetting> _workspaceSettings = new();
    }
}