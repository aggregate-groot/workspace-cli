namespace AggregateGroot.CliTools.Commands.Project.AssemblyVersion
{
    /// <summary>
    /// Represents the possible response codes for the assembly version command.
    /// </summary>
    public enum AssemblyVersionResponseCode
    {
        /// <summary>
        /// Indicates that the command was successful.
        /// </summary>
        Success = 0,

        /// <summary>
        /// Indicates that the path to the assembly was not provided.
        /// </summary>
        PathNotProvided = 2,

        /// <summary>
        /// Indicates that the requested assembly does not exist for the path
        /// provided.
        /// </summary>
        AssemblyNotFound = 3
    }
}