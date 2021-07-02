using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;

using Xunit;

using AggregateGroot.Workspace.Cli.Commands.Workspaces;

namespace AggregateGroot.Workspace.Cli.Commands.Tests.Unit.Workspaces.DeveloperWorkspaceTests
{
    /// <summary>
    /// Unit tests for the Initialize method of the <see cref="DeveloperWorkspace" /> class.
    /// </summary>
    public class InitializeTest
    {
        /// <summary>
        /// Tests that passing a null workspaceSettings argument will result
        /// in an <see cref="ArgumentNullException" /> being thrown.
        /// </summary>
        [Fact]
        [ExcludeFromCodeCoverage]
        public void Null_WorkspaceSettings_Should_Throw_Exception()
        {
            DeveloperWorkspace workspace = new();

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
                () => workspace.Initialize(null));

            Assert.Equal("workspaceSettings", exception.ParamName);
        }

        /// <summary>
        /// Tests that each setting is added to the default list.
        /// </summary>
        [Fact]
        public void Should_Add_Each_Setting_To_Defaults()
        {
            DeveloperWorkspace workspace = new();

            List<WorkspaceSetting> settings = new()
            {
                new WorkspaceSetting()
                {
                    Default = "Foo",
                    Name = "Bar",
                    Prompt = "Enter Bar",
                    Type = WorkspaceSettingType.String,
                    Value = "Foo 1"
                },
                new WorkspaceSetting()
                {
                    Default = "Dark",
                    Name = "Helmet",
                    Prompt = "Fooled You!",
                    Type = WorkspaceSettingType.String,
                    Value = "Mr Radar"
                }
            };

            workspace.Initialize(settings);

            Assert.Equal(settings.First(), workspace.DefaultSettings.First());
            Assert.Equal(settings.Last(), workspace.DefaultSettings.Last());
        }
    }
}