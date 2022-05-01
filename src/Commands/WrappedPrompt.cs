using System;
using System.Diagnostics.CodeAnalysis;

using McMaster.Extensions.CommandLineUtils;

namespace AggregateGroot.CliTools.Commands
{
    /// <summary>
    /// Wraps the built in McMaster static prompt to allow for testing.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class WrappedPrompt : IPrompt
    {
        /// <inheritdoc />
        /// <exception cref="ArgumentException">
        /// Thrown when the prompt is not provided.
        /// </exception>
        public string GetString(string prompt, string defaultValue)
        {
            if (string.IsNullOrWhiteSpace(prompt))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(prompt));
            }

            return Prompt.GetString(prompt, defaultValue);
        }
    }
}