#!/usr/bin/env bash

LOCATION=$(dirname "${BASH_SOURCE[0]}")

dotnet build $LOCATION/../src/Cli/Cli.csproj -c Release
dotnet tool update --global --add-source $LOCATION/../src/Cli/bin/Release/ AggregateGroot.Workspace.Cli