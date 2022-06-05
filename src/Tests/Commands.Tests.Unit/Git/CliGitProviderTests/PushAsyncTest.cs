using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

using Moq;
using Xunit;

using AggregateGroot.CliTools.Commands.Git;

namespace AggregateGroot.Workspace.Cli.Commands.Tests.Unit.Git.CliGitProviderTests
{
    /// <summary>
    /// Unit tests for the PushAsync method of the <see cref="CliGitProvider" /> class.
    /// </summary>
    public class PushAsyncTest : CliGitProviderTest
    {
        /// <summary>
        /// Tests that passing a null or whitespace remote argument will result
        /// in an <see cref="ArgumentException" /> being thrown.
        /// </summary>
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [ExcludeFromCodeCoverage]
        public async Task Missing_Remote_Should_Throw_Exception(string remote)
        {
            CliGitProvider provider = CreateGitProvider();
            
            ArgumentException exception = await Assert.ThrowsAsync<ArgumentException>(
                () => provider.PushAsync(remote));

            Assert.Equal("remote", exception.ParamName);
        }

        /// <summary>
        /// Tests that the specified remote is sent to the git CLI.
        /// </summary>
        [Fact]
        public async Task Should_Provide_Remote_To_Git()
        {
            CliGitProvider provider = CreateGitProvider();

            await provider.PushAsync("origin");
            
            CliProviderMock
                .Verify(cli => cli.ExecuteAsync("git", "push origin"), Times.Once);
        }
    }
}