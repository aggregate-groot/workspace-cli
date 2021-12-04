using Xunit;

using AggregateGroot.Workspace.Cli.Commands.Workspaces;

namespace AggregateGroot.Workspace.Cli.Commands.Tests.Unit.Workspaces.WorkspaceSettingTests
{
    /// <summary>
    /// Unit tests for the constructors of the <see cref="WorkspaceSetting"/>
    /// class.
    /// </summary>
    public class ConstructorTest
    {
        /// <summary>
        /// Tests that a new instance of the <see cref="WorkspaceSetting"/>
        /// class has the expected state.
        /// </summary>
        [Fact]
        public void New_Instance_Should_Have_Expected_State()
        {
            WorkspaceSetting setting = new();

            Assert.Null(setting.Name);
            Assert.Null(setting.Value);
        }
    }
}