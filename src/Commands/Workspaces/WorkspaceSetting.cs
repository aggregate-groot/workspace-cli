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
        /// Gets or initializes the value for the setting.
        /// </summary>
        public string Value { get; set; }
    }
}