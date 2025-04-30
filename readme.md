# LiveSplit.RustAlarm

## Environment Setup

When you clone the repository, be sure to use the `--recurse-submodules` option. This will init the LiveSplit submodule (and all of its nested submodules) in addition to the main repository.

## Building

Building this component requires the .NET 9 SDK to be installed: `winget install Microsoft.DotNet.SDK.9`.  

* Run `dotnet build -c <Debug|Release>` to build
* Copy the resulting `.dll` (`artifacts/bin/LiveSplit.RustAlarm/<debug|release>`) to your `LiveSplit/Components` directory to test
