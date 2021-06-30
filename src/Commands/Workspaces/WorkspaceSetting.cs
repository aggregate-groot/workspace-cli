namespace AggregateGroot.Workspace.Cli.Commands.Workspaces
{
    /// <summary>
    /// Represents a workspace setting.
    /// </summary>
    public record WorkspaceSetting
    {
        /// <summary>
        /// Gets or initializes the name of the setting.
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// Gets or initializes the type of workspace setting.
        /// </summary>
        public WorkspaceSettingType Type { get; init; }

        /// <summary>
        /// Gets or initializes the default value for the setting.
        /// </summary>
        public string Default { get; init; }

        /// <summary>
        /// Gets or initializes the value for the setting.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or initializes the text used to prompt the user for the value.
        /// </summary>
        public string Prompt { get; init; }
    }
}