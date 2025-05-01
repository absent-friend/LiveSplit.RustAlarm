# LiveSplit.RustAlarm

## Environment Setup

When you clone the repository, be sure to use the `--recurse-submodules` option. This will init the LiveSplit submodule (and all of its nested submodules) in addition to the main repository.

## Building

Building this component requires the .NET 9 SDK to be installed: `winget install Microsoft.DotNet.SDK.9`.  

* Run `dotnet build -c <Debug|Release>` to build
* Copy the resulting `.dll` (`artifacts/bin/LiveSplit.RustAlarm/<debug|release>`) to your `LiveSplit/Components` directory to test

## IDE

I don't have experience with Rider or any non-Visual Studio IDE. If you need to do something special to open this project in your IDE of choice, you're welcome to add instructions to this section of the readme and submit a pull request.

If you want to use Visual Studio, you need to opt into a preview feature to open solutions in the .slnx format. Here are the steps:

* Open up a Visual Studio window. It can be an empty window or another solution.
* In the menu bar at the top of the window, click Tools → Options...
* Search "persistence" and you should see a "Use Solution File Persistence Model" checkbox. Check it.
* Hit enter or click the "OK" button.
* Now it will let you see and select .slnx files in the Open Project/Solution dialog.

Building won't work in Visual Studio because it has different (and more cumbersome) requirements for project-to-project dependencies. Just use the dotnet CLI.
