using System;
using System.Diagnostics.CodeAnalysis;

using Xunit;

using AggregateGroot.Workspace.Cli.Commands.Init;

namespace AggregateGroot.Workspace.Cli.Commands.Tests.Unit.InitTests
{
    /// <summary>
    /// Unit tests for the constructors of the <see cref="InitCommand" /> class.
    /// </summary>
    public class ConstructorTest
    {
        /// <summary>
        /// Tests that passing a null workspace argument will result
        /// in an <see cref="ArgumentNullException" /> being thrown.
        /// </summary>
        [Fact]
        [ExcludeFromCodeCoverage]
        public void Null_Workspace_Should_Throw_Exception()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
                () => new InitCommand(null));

            Assert.Equal("workspace", exception.ParamName);
        }
    }
}