# PropertiesDotNet [![Build status](https://ci.appveyor.com/api/projects/status/7iooy0iqejw297i0)](https://ci.appveyor.com/project/Walkman100/propertiesdotnet)
A properties window made in VB.Net

[![Gitter](https://badges.gitter.im/Join Chat.svg)](https://gitter.im/Walkman100/Walkman?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

## Screenshots


## Credits/Acknowledgements
### Icons
- Program Icon:
  - https://www.iconfinder.com/icons/28343/document_properties_icon
  - License: [GPL](http://www.gnu.org/copyleft/gpl.html)
- Compress form icon:
  - https://www.iconfinder.com/icons/35891/compress_icon
  - License: [Creative Commons (Attribution 3.0 United States)](http://creativecommons.org/licenses/by/3.0/us)
- Hashing form icon:
  - https://www.iconfinder.com/icons/118664/hash_icon
  - License: [Attribution-Non-Commercial 3.0 Netherlands](http://creativecommons.org/licenses/by-nc/3.0/nl/deed.en_GB)

### Getting open with program
- Find at: [PropertiesDotNet.vb#L6](PropertiesDotNet.vb#L6)
- And: [PropertiesDotNet.vb#L44](PropertiesDotNet.vb#L44)
- http://www.vb-helper.com/howto_get_associated_program.html
- The page above is in VB6 however, so I needed to convert it (manually) to VB.Net. Also, the most importand line, the `Function FindExecutable Lib "shell32.dll"`, is chopped off the sample you see on the page, so you have to download the `zip` to get that.

### NTFS Compression
- Find at: [PropertiesDotNet.vb#L6](PropertiesDotNet.vb#L6)
- And: [PropertiesDotNet.vb#L122](PropertiesDotNet.vb#L122)
- http://www.thescarms.com/dotnet/NTFSCompress.aspx
- Original code from above link has been copied, un-modified, to [here](NTFSCompressOriginalCode.cs)
- I have edited it so it can be compiled [here](NTFSCompressConvertable.cs)
- Then converted it to VB.Net [here](NTFSCompressConverted.vb)
- MSDN Info (for decompression value): https://msdn.microsoft.com/en-us/library/windows/desktop/aa364592(v=vs.85).aspx

### Hash Generating
- Find at: [Hashes.vb#L392](Hashes.vb#L392)
- Basic Hashing: http://us.informatiweb.net/programmation/36--generate-hashes-md5-sha-1-and-sha-256-of-a-file.html
- Hashing with progress reporting: http://www.infinitec.de/post/2007/06/09/Displaying-progress-updates-when-hashing-large-files.aspx

## Compile requirements
See [CompileInstructions.md](https://github.com/Walkman100/WinCompile/blob/master/CompileInstructions.md)
