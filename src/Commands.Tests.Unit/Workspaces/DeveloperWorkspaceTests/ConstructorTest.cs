using Xunit;

using AggregateGroot.Workspace.Cli.Commands.Workspaces;

namespace AggregateGroot.Workspace.Cli.Commands.Tests.Unit.Workspaces.DeveloperWorkspaceTests
{
    /// <summary>
    /// Unit tests for the constructors of the <see cref="Workspace" /> class.
    /// </summary>
    public class ConstructorTest
    {
        /// <summary>
        /// Tests that a new instance of the <see cref="Workspace"/> class has
        /// the expected state.
        /// </summary>
        [Fact]
        public void New_Instance_Should_Have_Expected_State()
        {
            DeveloperWorkspace workspace = new("/home");

            Assert.Equal(0, workspace.DefaultSettings.Count);
        }
    }
}