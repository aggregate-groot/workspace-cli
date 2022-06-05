using Moq;

using AggregateGroot.CliTools.Commands;
using AggregateGroot.CliTools.Commands.Git;

namespace AggregateGroot.Workspace.Cli.Commands.Tests.Unit.Git.CliGitProviderTests
{
    /// <summary>
    /// Base class for testing the <see cref="CliGitProvider"/> class.
    /// </summary>
    public abstract class CliGitProviderTest
    {
        /// <summary>
        /// Creates a new instance of the <see cref="CliGitProviderTest"/> class.
        /// </summary>
        protected CliGitProviderTest()
        {
            CliProviderMock = new Mock<ICliProvider>();
        }
        
        /// <summary>
        /// Gets mock cli provider instance.
        /// </summary>
        protected Mock<ICliProvider> CliProviderMock { get; private set; }

        /// <summary>
        /// Creates a new instance of the <see cref="CliGitProvider"/> configured
        /// for testing.
        /// </summary>
        protected CliGitProvider CreateGitProvider()
        {
            return new CliGitProvider(CliProviderMock.Object);
        }
    }
}