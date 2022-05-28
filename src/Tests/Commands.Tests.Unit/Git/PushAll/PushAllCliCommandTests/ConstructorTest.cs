using System;
using System.Diagnostics.CodeAnalysis;

using Xunit;

using AggregateGroot.CliTools.Commands.Git.PushAll;

namespace AggregateGroot.Workspace.Cli.Commands.Tests.Unit.Git.PushAll.PushAllCliCommandTests
{
    /// <summary>
    /// Unit tests for the constructors of the <see cref="PushAllCliCommand" /> class.
    /// </summary>
    public class ConstructorTest
    {
        /// <summary>
        /// Tests that passing a null gitProvider argument will result
        /// in an <see cref="ArgumentNullException" /> being thrown.
        /// </summary>
        [Fact]
        [ExcludeFromCodeCoverage]
        public void Null_GitProvider_Should_Throw_Exception()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
                () => new PushAllCliCommand(null!));

            Assert.Equal("gitProvider", exception.ParamName);
        }
    }
}