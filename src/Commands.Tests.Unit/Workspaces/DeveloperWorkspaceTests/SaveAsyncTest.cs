using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

using Xunit;

using AggregateGroot.Workspace.Cli.Commands.Workspaces;

namespace AggregateGroot.Workspace.Cli.Commands.Tests.Unit.Workspaces.DeveloperWorkspaceTests
{
    /// <summary>
    /// Unit tests for the SaveAsync method of the
    /// <see cref="DeveloperWorkspaceTests" /> class.
    /// </summary>
    public class SaveAsyncTest
    {
        /// <summary>
        /// Tests that the workspace settings are saved to the expected configuration
        /// path.
        /// </summary>
        [Fact]
        public async Task Should_Save_To_Configuration_Path()
        {
            string configurationFilePath = GetConfigurationFilePath();

            DeveloperWorkspace workspace = new(configurationFilePath, new List<WorkspaceSetting>());
            await workspace.SaveAsync();

            bool configurationSaved = File.Exists(configurationFilePath);

            Assert.True(configurationSaved);

            File.Delete(configurationFilePath);
        }

        /// <summary>
        /// Gets the path to use for testing the SaveAsync method.
        /// </summary>
        private static string GetConfigurationFilePath()
        {
            string assemblyPath = Assembly.GetExecutingAssembly().Location;
            string configurationFolder = Path.GetDirectoryName(assemblyPath);
            return Path.Combine(
                configurationFolder,
                "SaveTest",
                "workspace-settings.json");
        }
    }
}