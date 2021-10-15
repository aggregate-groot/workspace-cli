using System.Collections.Generic;
using System.Threading.Tasks;

namespace AggregateGroot.Workspace.Cli.Commands.Workspaces.ConfigurationTargets
{
    /// <summary>
    /// Interface for types that provide persistent storage of application configuration.
    /// </summary>
    internal interface IConfigurationTarget
    {
        /// <summary>
        /// Saves the provided settings to the configuration target.
        /// </summary>
        /// <param name="settings">
        /// Required list of settings to save.
        /// </param>
        Task SaveAsync(IEnumerable<WorkspaceSetting> settings);
    }
}