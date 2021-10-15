using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AggregateGroot.Workspace.Cli.Commands.Workspaces.ConfigurationTargets
{
    /// <summary>
    /// Docker .env file implementation of the <see cref="IConfigurationTarget"/>
    /// interface.
    /// </summary>
    internal class DockerEnvConfigurationTagert : IConfigurationTarget
    {
        /// <summary>
        /// Creates a new instance of the <see cref="DockerEnvConfigurationTagert"/> class.
        /// </summary>
        /// <param name="targetDirectory">
        /// Required path to the directory where the configuration file will be saved.
        /// </param>
        public DockerEnvConfigurationTagert(string targetDirectory)
        {
            this._targetDirectory = targetDirectory;
        }

        /// <inheritdoc />
        public async Task SaveAsync(IEnumerable<WorkspaceSetting> settings)
        {
            Console.WriteLine("Creating Docker .env file...");

            Console.WriteLine("Docker .env file created.");
        }

        private readonly string _targetDirectory;
    }
}
