using System.Collections.Generic;

namespace AggregateGroot.Workspace.Cli.Commands.Workspaces
{
    /// <summary>
    /// Represents the configuration of a developer's workspace.
    /// </summary>
    public record WorkspaceConfiguration
    {
        /// <summary>
        /// Gets or initializes the root path for the workspace.
        /// </summary>
        public string RootPath { get; init; }

        /// <summary>
        /// Gets or initializes the settings for the workspace.
        /// </summary>
        public IEnumerable<WorkspaceSetting> Settings { get; init; }
    }
}