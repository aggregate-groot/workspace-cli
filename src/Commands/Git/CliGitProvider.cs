using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AggregateGroot.CliTools.Commands.Git
{
    /// <summary>
    /// Provides git functionality using the git command line tool.
    /// </summary>
    public class CliGitProvider : IGitProvider
    {
        /// <summary>
        /// Creates a new instance of the <see cref="CliGitProvider"/> class.
        /// </summary>
        public CliGitProvider(ICliProvider cliProvider)
        {
            _cliProvider = cliProvider 
                ?? throw new ArgumentNullException(nameof(cliProvider));
        }

        /// <inheritdoc />
        public async Task<IEnumerable<string>> ListRemotesAsync()
        {
            string result = await _cliProvider.ExecuteAsync("git", "remote");

            string[] remotes
                = result.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            return remotes;
        }

        /// <inheritdoc />
        public Task PushAsync(string remote)
        {
            if (string.IsNullOrWhiteSpace(remote))
            {
                throw new ArgumentException(
                    "Value cannot be null or whitespace.", nameof(remote));
            }

            return _cliProvider.ExecuteAsync("git", $"push {remote}");
        }

        private readonly ICliProvider _cliProvider;
    }
}
