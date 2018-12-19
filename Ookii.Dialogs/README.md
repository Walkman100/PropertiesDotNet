# Ookii.Dialogs.dll

As PropertiesDotNet installs to the same folder as other programs of mine, it doesn't work to keep [`Ookii.Dialogs.dll`](https://github.com/Walkman100/Ookii.Dialogs) as the filename, unless I make some sort of system to keep track of which programs are using it, and delete it on the last program uninstall, and that doesn't even take into account if a new version is released...

The only solution I have found, is to compile Ookii.Dialogs as a different assembly name. Renaming the file and referencing it allows the project to build, but on runtime PropertiesDotNet still looks for `Ookii.Dialogs.dll` for some reason...

### Compiling `PropertiesDotNet-Ookii.Dialogs.dll`

I have included this file in this repo for ease of use, but to get the exact same binary from source, follow these instructions from within the folder this README is in:

#### Linux/WSL:
- `rm PropertiesDotNet-Ookii.Dialogs.dll`
- `git clone https://github.com/Walkman100/Ookii.Dialogs`
- `cd Ookii.Dialogs`
- `cp ../Ookii.Dialogs_Rename_Patch.patch .`
- `git apply Ookii.Dialogs_Rename_Patch.patch`
- Compile the solution:
  - Linux: `msbuild`
  - WSL: `/mnt/c/Windows/Microsoft.NET/Framework/v4.0.30319/MSBuild.exe`
- `cp bin/Debug/PropertiesDotNet-Ookii.Dialogs.dll ..`
- `cd ..`
- Optionally `rm -rf Ookii.Dialogs/`

#### Windows CMD:
- `del PropertiesDotNet-Ookii.Dialogs.dll`
- `git clone https://github.com/Walkman100/Ookii.Dialogs`
- `cd Ookii.Dialogs`
- `copy ..\Ookii.Dialogs_Rename_Patch.patch .`
- `git apply Ookii.Dialogs_Rename_Patch.patch`
- Compile the solution: `C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe`
- `copy bin\Debug\PropertiesDotNet-Ookii.Dialogs.dll ..`
- `cd ..`
- Optionally `rmdir /S /Q Ookii.Dialogs`
