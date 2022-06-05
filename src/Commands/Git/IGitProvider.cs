using System.Collections.Generic;
using System.Threading.Tasks;

namespace AggregateGroot.CliTools.Commands.Git
{
    /// <summary>
    /// Interface for types that provide git capabilities.
    /// </summary>
    public interface IGitProvider
    {
        /// <summary>
        /// Lists all of the configured remotes for the current git repository.
        /// </summary>
        Task<IEnumerable<string>> ListRemotesAsync();

        /// <summary>
        /// Pushes the current branch to the specified <paramref name="remote"/>.
        /// </summary>
        /// <param name="remote">
        /// Required name of the remote to push the branch to.
        /// </param>
        Task PushAsync(string remote);
    }
}