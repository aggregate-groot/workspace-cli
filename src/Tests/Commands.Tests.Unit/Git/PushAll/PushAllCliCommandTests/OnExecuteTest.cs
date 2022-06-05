using System.Collections.Generic;
using System.Threading.Tasks;

using Moq;
using Xunit;

using AggregateGroot.CliTools.Commands.Git;
using AggregateGroot.CliTools.Commands.Git.PushAll;

namespace AggregateGroot.Workspace.Cli.Commands.Tests.Unit.Git.PushAll.PushAllCliCommandTests
{
    /// <summary>
    /// Unit tests for the OnExecute method of the <see cref="PushAllCliCommand" /> class.
    /// </summary>
    public class OnExecuteTest
    {
        /// <summary>
        /// Tests that the command sends a push command for each remote returned
        /// by the git provider.
        /// </summary>
        [Fact]
        public async Task Should_Send_Push_Command_To_Each_Remote()
        {
            List<string> remotes = new()
            {
                "origin",
                "azure",
                "gitlab"
            };

            _gitProviderMock
                .Setup(git => git.ListRemotesAsync())
                .ReturnsAsync(remotes);

            PushAllCliCommand command = CreateCommand();

            int result = await command.OnExecute();

            Assert.Equal(1, result);

            foreach (string remote in remotes)
            {
                _gitProviderMock.Verify(git => git.PushAsync(remote), Times.Once);
            }
        }

        /// <summary>
        /// Creates a new instance of the <see cref="PushAllCliCommand"/> configured
        /// for testing.
        /// </summary>
        private PushAllCliCommand CreateCommand()
        {
            return new PushAllCliCommand(_gitProviderMock.Object);
        }

        private readonly Mock<IGitProvider> _gitProviderMock = new();
    }
}