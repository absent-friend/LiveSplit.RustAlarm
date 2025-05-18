# LiveSplit.RustAlarm
![livesplit-rustalarm-demo](https://github.com/user-attachments/assets/727696ee-bf7e-4eb1-83cc-f8bc17ac7bcc)

Rust Alarm is an informational component that warns you when a segment is likely getting rusty. When you have a bad split or a reset in a segment multiple times in a row, it will flag that segment in a special area of your LiveSplit window. You can use this as a signal to stop and practice, or just to focus harder on the next attempt.

## Downloads

Downloads can be found on the [Releases page](https://github.com/absent-friend/LiveSplit.RustAlarm/releases).

## Installation

Place the component DLL in the "Components" folder of your LiveSplit installation. After the initial installation, future updates can be obtained through LiveSplit's update mechanism.

## Setup

Add the Rust Alarm component to your layout:

![image](https://github.com/user-attachments/assets/94536cfe-315e-4bad-a91f-8c4e8a9c0ab9)

Rust Alarm can be used as-is, but I recommend reading the [settings guide](https://github.com/absent-friend/LiveSplit.RustAlarm/wiki/2.-Settings-Guide) to get the most out of it. Each segment can be configured separately to suit your needs as a runner.

You should also be aware of these [warnings and caveats](https://github.com/absent-friend/LiveSplit.RustAlarm/wiki/3.-Warnings-and-Caveats).

If you have LiveSplit in your recording layout, you might not want to show Rust Alarm in the recording. I've written up some [recommendations for recording LiveSplit](https://github.com/absent-friend/LiveSplit.RustAlarm/wiki/4.-Excluding-Rust-Alarm-from-a-LiveSplit-Capture) with this in mind.

## Development

While I don't envision much in the way of new features, contributions are welcome. Below are some tips for setting up the project.

### Environment Setup

When you clone the repository, be sure to use the `--recurse-submodules` option. This will init the LiveSplit submodule (and all of its nested submodules) in addition to the main repository.

### Building

Building this component requires the .NET 9 SDK to be installed: `winget install Microsoft.DotNet.SDK.9`.  

* Run `dotnet build -c <Debug|Release>` to build
* Copy the resulting `.dll` (`artifacts/bin/LiveSplit.RustAlarm/<debug|release>`) to your `LiveSplit/Components` directory to test

### IDE

I don't have experience with Rider or any non-Visual Studio IDE. If you need to do something special to open this project in your IDE of choice, you're welcome to add instructions to this section of the readme and submit a pull request.

If you want to use Visual Studio, you need to opt into a preview feature to open solutions in the .slnx format. Here are the steps:

* Open up a Visual Studio window. It can be an empty window or another solution.
* In the menu bar at the top of the window, click Tools → Options...
* Search "persistence" and you should see a "Use Solution File Persistence Model" checkbox. Check it.
* Hit enter or click the "OK" button.
* Now it will let you see and select .slnx files in the Open Project/Solution dialog.

Building won't work in Visual Studio because it has different (and more cumbersome) requirements for project-to-project dependencies. Just use the dotnet CLI.
