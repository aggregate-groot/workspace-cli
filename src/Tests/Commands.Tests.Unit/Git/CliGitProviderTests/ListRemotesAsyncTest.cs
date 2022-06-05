using System.Linq;
using System.Threading.Tasks;

using Moq;
using Xunit;

using AggregateGroot.CliTools.Commands.Git;

namespace AggregateGroot.Workspace.Cli.Commands.Tests.Unit.Git.CliGitProviderTests
{
    /// <summary>
    /// Unit tests for the ListRemotesAsync method of the <see cref="CliGitProvider" /> class.
    /// </summary>
    public class ListRemotesAsyncTest : CliGitProviderTest
    {
        /// <summary>
        /// Tests that the expected list of remotes is returned after parsing
        /// git CLI command.
        /// </summary>
        [Fact]
        public async Task Should_Return_List_Of_Remotes_From_Git_CLI()
        {
            CliProviderMock
                .Setup(cli => cli.ExecuteAsync("git", "remote"))
                .ReturnsAsync("origin\nazure");

            CliGitProvider gitProvider = CreateGitProvider();

            string[] remotes = (await gitProvider.ListRemotesAsync()).ToArray();

            Assert.Equal(2, remotes.Length);
            Assert.Equal("origin", remotes[0]);
            Assert.Equal("azure", remotes[1]);
        }
    }
}