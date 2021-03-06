using System.Diagnostics.CodeAnalysis;

using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;

using AggregateGroot.CliTools.Commands;
using AggregateGroot.CliTools.Commands.Git;

namespace AggregateGroot.Workspace.Cli
{
    /// <summary>
    /// Represents the main command line application.
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">
        /// Optional command line arguments.
        /// </param>
        private static void Main(string[] args)
        {
            ServiceProvider services = new ServiceCollection()
                .AddSingleton<ICliProvider, WrappedCliProvider>()
                .AddSingleton<IPrompt, WrappedPrompt>()
                .AddSingleton(PhysicalConsole.Singleton)
                .AddSingleton<IGitProvider, CliGitProvider>()
                .BuildServiceProvider();

            CommandLineApplication<RootCommand> application = new ();

            application.Conventions
                .UseDefaultConventions()
                .UseConstructorInjection(services);

            application.Execute(args);
        }
    }
}