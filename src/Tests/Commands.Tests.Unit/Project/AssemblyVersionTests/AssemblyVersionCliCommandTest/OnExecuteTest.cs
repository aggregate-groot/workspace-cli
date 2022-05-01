using System;
using System.IO;
using McMaster.Extensions.CommandLineUtils;
using Moq;
using Xunit;

using AggregateGroot.CliTools.Commands;
using AggregateGroot.CliTools.Commands.Project.AssemblyVersion;

namespace AggregateGroot.Workspace.Cli.Commands.Tests.Unit.Project.AssemblyVersionTests.AssemblyVersionCliCommandTest
{
    /// <summary>
    /// Unit tests for the OnExecute method of the <see cref="AssemblyVersionCliCommand" /> class.
    /// </summary>
    public class OnExecuteTest
    {
        /// <summary>
        /// Tests that an error is printed when the path to the assembly is not
        /// provided.
        /// </summary>
        /// <param name="path">
        /// Value to test.
        /// </param>
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Should_Print_Error_When_Path_Not_Set(string path)
        {
            AssemblyVersionCliCommand command = CreateCommand(path);

            AssemblyVersionResponseCode result = command.OnExecute();

            Assert.Equal(AssemblyVersionResponseCode.PathNotProvided, result);

            _errorWriterMock.Verify(error 
                    => error.Write("Please provide the path of the assembly to get the version for."),
                Times.Once);
        }

        private readonly Mock<IConsole> _consoleMock = new();
        private readonly Mock<IPrompt> _promptMock = new();
        private readonly Mock<TextWriter> _textWriterMock = new();
        private readonly Mock<TextWriter> _errorWriterMock = new();

        /// <summary>
        /// Creates a new instance of the <see cref="AssemblyVersionCliCommand"/>
        /// configured for testing.
        /// </summary>
        /// <param name="path">
        /// Value to use for the path argument of the CLI command.
        /// </param>
        private AssemblyVersionCliCommand CreateCommand(string path)
        {
            _consoleMock
                .SetupGet(console => console.Out)
                .Returns(_textWriterMock.Object);
            _consoleMock
                .SetupGet(console => console.Error)
                .Returns(_errorWriterMock.Object);
            return new AssemblyVersionCliCommand(
                _consoleMock.Object,
                _promptMock.Object)
            {
                Path = path
            };
        }
    }
}