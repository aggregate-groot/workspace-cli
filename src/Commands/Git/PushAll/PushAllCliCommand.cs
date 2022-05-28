using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using McMaster.Extensions.CommandLineUtils;

namespace AggregateGroot.CliTools.Commands.Git.PushAll
{
    /// <summary>
    /// CLI command to push changes in the current branch to all remotes.
    /// </summary>
    [Command("push-all", Description = "PushAsync changes in the current branch to all remotes.")]
    public class PushAllCliCommand
    {
        /// <summary>
        /// Creates a new instance of the <see cref="PushAllCliCommand"/> class.
        /// </summary>
        /// <param name="gitProvider">
        /// Required type used for interacting with git.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="gitProvider"/> is <c>null</c>.
        /// </exception>
        public PushAllCliCommand(IGitProvider gitProvider)
        {
            _gitProvider = gitProvider 
                ?? throw new ArgumentNullException(nameof(gitProvider));
        }
        
        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <returns>
        /// Execution status code.
        /// </returns>
        public async Task<int> OnExecute()
        {
            IEnumerable<string> remotes = await _gitProvider.ListRemotesAsync();

            foreach (string remote in remotes)
            {
                await _gitProvider.PushAsync(remote);
            }

            return 1;
        }

        private readonly IGitProvider _gitProvider;
    }
}