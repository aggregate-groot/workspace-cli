namespace AggregateGroot.Workspace.Cli.Commands.Workspaces
{
    /// <summary> 
    /// Represents a workspace setting definition.
    /// </summary>
    public record WorkspaceSettingDefinition
    {
        /// <summary>
        /// Gets or initializes the name of the workspace setting.
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// Gets or initializes the default value for the setting.
        /// </summary>
        public string Default { get; init; }

        /// <summary>
        /// Gets or initializes the text used to prompt the user for the
        /// workspace setting value.
        /// </summary>
        public string Prompt { get; init; }

        /// <summary>
        /// Gets or initializes the type of workspace setting.
        /// </summary>
        public WorkspaceSettingType Type { get; init; }
    }
}