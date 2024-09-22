# Operating System Info Retrieval using WMI in C#

## Overview
This project demonstrates how to use Windows Management Instrumentation (WMI) in C# to retrieve system information, specifically the operating system's last boot-up time. The code connects to a local or remote machine using credentials and queries the `Win32_OperatingSystem` WMI class.

## Features
- Retrieve OS information from local or remote machines.
- Use of `ManagementScope` and `ConnectionOptions` for remote connections.
- Query WMI for `LastBootUpTime` using `ObjectQuery`.
- Easy-to-use method with customizable machine names and credentials.

## Requirements
- .NET Framework
- Visual Studio
- `System.Management` reference

## Usage
1. Clone the repository or copy the code into your project.
2. Add a reference to `System.Management`.
3. Call the `GetOperatingSystemInfo` method, passing the machine name and optional credentials.

```csharp
GetOperatingSystemInfo("localhost", null, null);  // Local system usage
```

For remote systems, provide the appropriate credentials:

```csharp
GetOperatingSystemInfo("RemoteMachine", "username", "password");
```

## Output Example
```bash
Last Boot Up Time: 2024-09-22 08:30:15
```

## License
This project is licensed under the MIT License
