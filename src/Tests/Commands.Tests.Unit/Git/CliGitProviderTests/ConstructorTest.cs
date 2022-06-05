using System;
using System.Diagnostics.CodeAnalysis;

using Xunit;

using AggregateGroot.CliTools.Commands.Git;

namespace AggregateGroot.Workspace.Cli.Commands.Tests.Unit.Git.CliGitProviderTests
{
    /// <summary>
    /// Unit tests for the constructors of the <see cref="CliGitProvider" /> class.
    /// </summary>
    public class ConstructorTest
    {
        /// <summary>
        /// Tests that passing a null cliProvider argument will result
        /// in an <see cref="ArgumentNullException" /> being thrown.
        /// </summary>
        [Fact]
        [ExcludeFromCodeCoverage]
        public void Null_CliProvider_Should_Throw_Exception()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
                () => new CliGitProvider(null!));

            Assert.Equal("cliProvider", exception.ParamName);
        }
    }
}