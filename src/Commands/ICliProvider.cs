using System.Threading.Tasks;

namespace AggregateGroot.CliTools.Commands
{
    /// <summary>
    /// Interface for types that provider command line execution.
    /// </summary>
    public interface ICliProvider
    {
        /// <summary>
        /// Executes the provided <paramref name="command"/>.
        /// </summary>
        /// <param name="command">
        /// Required command to execute.
        /// </param>
        /// <param name="arguments">
        /// Optional arguments for the command.
        /// </param>
        /// <returns>
        /// The standard output of the command.
        /// </returns>
        Task<string> ExecuteAsync(string command, string arguments);
    }
}