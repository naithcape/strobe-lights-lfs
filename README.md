# LFS Strobe Lights Controller

A Windows Forms application for controlling strobe lights in Live for Speed (LFS) racing simulator. This tool allows you to create custom strobe light sequences and effects that can be triggered during gameplay.

## Features

- **Custom Strobe Sequences**: Create and edit custom light patterns using a data grid interface
- **Random Strobe Mode**: Generate random strobe effects with configurable patterns
- **Brake Light Integration**: Automatic brake light activation when enabled
- **File Management**: Save and load strobe patterns from text files
- **Smart Chat Detection**: Automatically pauses when LFS chat is opened to prevent interference
- **Real-time Control**: Use the '+' key in-game to start/stop strobe effects
- **Timing Control**: Precise timing intervals for each light command in your sequences

## Requirements

- **Operating System**: Windows (Windows Forms application)
- **Framework**: .NET 8.0 or higher
- **Game**: Live for Speed (LFS) racing simulator
- **Permissions**: The application requires permission to send keyboard input to other applications

## Installation

1. Download the latest release or clone this repository
2. Ensure you have .NET 8.0 Runtime installed on your system
3. Run the executable file `LFS Strobe TK by Anton.exe`

## Usage

### Basic Operation

1. **Launch the application** while Live for Speed is running
2. **Configure your strobe pattern** using one of these methods:
   - **Manual Entry**: Use the data grid to enter light commands and timing intervals
   - **Load Pattern**: Click "Load" to import a previously saved pattern file
   - **Random Mode**: Enable the random checkbox for automatic random strobing

3. **Start strobing**: Press the '+' key while in LFS to activate the strobe effects
4. **Stop strobing**: Release the '+' key or let the application detect when chat is opened

### Creating Custom Patterns

- **Column 1**: Enter the light command (usually numbers 0-9, or other keys like 7, 8)
- **Column 2**: Enter the timing interval in milliseconds
- The sequence will loop automatically when it reaches the end

### Controls

- **Random Mode Checkbox**: Enables random strobe pattern generation
- **Brake Light Checkbox**: Enables automatic brake light (B key) activation
- **Load Button**: Import strobe patterns from text files
- **Save Button**: Export current patterns to text files
- **Status Labels**: Show current position in sequence and running status

### File Format

Pattern files use a simple text format:
```
[number_of_entries]
[light_command_1]
[timing_1]
[light_command_2]
[timing_2]
...
```

## Technical Details

- **Target Framework**: .NET 8.0-windows
- **UI Framework**: Windows Forms
- **Input Simulation**: Uses Windows API (user32.dll) for keyboard input simulation
- **Supported Keys**: Numbers 0-9, letters A-Z, and special function keys

## Troubleshooting

- **Application not responding to '+' key**: Ensure LFS is the active window and the application has proper permissions
- **Strobe not working**: Check that your pattern data is valid (no empty cells, valid timing values)
- **Chat interference**: The application automatically stops when chat is opened in LFS to prevent unwanted input

## Credits

**Original Source Code**: Anton provided the original source code that was created by somebody else. This version represents an updated implementation to work with the new version of LFS and modern .NET framework.

**Current Version**: Updated and modernized by Nenad Petrovic to work with .NET 8.0 and current LFS versions.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Disclaimer

This tool is designed for enhancing the Live for Speed gaming experience. Use responsibly and in accordance with LFS terms of service. The software is provided "as is" without warranty of any kind.