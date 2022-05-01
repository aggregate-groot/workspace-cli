using System;
using System.Diagnostics.CodeAnalysis;

using Moq;
using Xunit;

using AggregateGroot.CliTools.Commands;
using AggregateGroot.CliTools.Commands.Project.AssemblyVersion;
using McMaster.Extensions.CommandLineUtils;

namespace AggregateGroot.Workspace.Cli.Commands.Tests.Unit.Project.AssemblyVersionTests.AssemblyVersionCliCommandTest
{
    /// <summary>
    /// Unit tests for the constructors of the <see cref="AssemblyVersionCliCommand" /> class.
    /// </summary>
    public class ConstructorTest
    {
        /// <summary>
        /// Tests that passing a null console argument will result
        /// in an <see cref="ArgumentNullException" /> being thrown.
        /// </summary>
        [Fact]
        [ExcludeFromCodeCoverage]
        public void Null_Console_Should_Throw_Exception()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
                () => new AssemblyVersionCliCommand(null, new Mock<IPrompt>().Object));

            Assert.Equal("console", exception.ParamName);
        }

        /// <summary>
        /// Tests that passing a null prompt argument will result
        /// in an <see cref="ArgumentNullException" /> being thrown.
        /// </summary>
        [Fact]
        [ExcludeFromCodeCoverage]
        public void Null_Prompt_Should_Throw_Exception()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
                () => new AssemblyVersionCliCommand(NullConsole.Singleton, null));

            Assert.Equal("prompt", exception.ParamName);
        }
    }
}