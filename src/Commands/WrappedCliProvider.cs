using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;

using CliWrap;

namespace AggregateGroot.CliTools.Commands
{
    /// <summary>
    /// CliWrap implementation of the <see cref="ICliProvider"/> interface.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class WrappedCliProvider : ICliProvider
    {
        /// <inheritdoc />
        public async Task<string> ExecuteAsync(string command, string arguments)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(command));
            }

            if (arguments == null)
            {
                throw new ArgumentNullException(nameof(arguments));
            }

            StringBuilder outputBuffer = new StringBuilder();

            await CliWrap.Cli
                .Wrap(command)
                .WithArguments(arguments)
                .WithStandardOutputPipe(PipeTarget.ToStringBuilder(outputBuffer))
                .WithStandardErrorPipe(PipeTarget.ToStringBuilder(outputBuffer))
                .WithValidation(CommandResultValidation.None)
                .ExecuteAsync();

            return outputBuffer.ToString();
        }
    }
}