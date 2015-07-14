; PropertiesDotNet Installer NSIS Script
; get NSIS at http://nsis.sourceforge.net/Download
; As a program that all Power PC users should have, Notepad++ is recommended to edit this file

Icon "My Project\document-properties.ico"
Caption "PropertiesDotNet Installer"
Name "PropertiesDotNet"
AutoCloseWindow true
ShowInstDetails show

LicenseBkColor /windows
LicenseData "LICENSE.md"
LicenseForceSelection checkbox "I have read and understand this notice"
LicenseText "Please read the notice below before installing PropertiesDotNet. If you understand the notice, click the checkbox below and click Next."

InstallDir $PROGRAMFILES\WalkmanOSS

OutFile "bin\Release\PropertiesDotNet-Installer.exe"

; Pages

Page license
Page components
Page directory
Page instfiles
UninstPage uninstConfirm
UninstPage instfiles

; Sections

Section "Executable & Uninstaller"
  SectionIn RO
  SetOutPath $INSTDIR
  File "bin\Release\PropertiesDotNet.exe"
  WriteUninstaller "PropertiesDotNet-Uninst.exe"
SectionEnd

Section "Start Menu Shortcuts"
  CreateDirectory "$SMPROGRAMS\WalkmanOSS"
  CreateShortCut "$SMPROGRAMS\WalkmanOSS\PropertiesDotNet.lnk" "$INSTDIR\PropertiesDotNet.exe" "" "$INSTDIR\PropertiesDotNet.exe" "" "" "" "PropertiesDotNet"
  CreateShortCut "$SMPROGRAMS\WalkmanOSS\Uninstall PropertiesDotNet.lnk" "$INSTDIR\PropertiesDotNet-Uninst.exe" "" "" "" "" "" "Uninstall PropertiesDotNet"
  ;Syntax for CreateShortCut: link.lnk target.file [parameters [icon.file [icon_index_number [start_options [keyboard_shortcut [description]]]]]]
SectionEnd

Section "Desktop Shortcut"
  CreateShortCut "$DESKTOP\PropertiesDotNet.lnk" "$INSTDIR\PropertiesDotNet.exe" "" "$INSTDIR\PropertiesDotNet.exe" "" "" "" "PropertiesDotNet"
SectionEnd

Section "Quick Launch Shortcut"
  CreateShortCut "$QUICKLAUNCH\PropertiesDotNet.lnk" "$INSTDIR\PropertiesDotNet.exe" "" "$INSTDIR\PropertiesDotNet.exe" "" "" "" "PropertiesDotNet"
SectionEnd

Section "Add PropertiesDotNet to context menu"
  ; File item
  WriteRegStr HKCR "*\shell\PropertiesDotNet" "" "Properties..."
  WriteRegStr HKCR "*\shell\PropertiesDotNet" "Icon" "$INSTDIR\PropertiesDotNet.exe"
  WriteRegStr HKCR "*\shell\PropertiesDotNet\command" "" "$\"$INSTDIR\PropertiesDotNet.exe$\" $\"%1$\""
  
  ; Folder item
  WriteRegStr HKCR "Directory\shell\PropertiesDotNet" "" "Properties..."
  WriteRegStr HKCR "Directory\shell\PropertiesDotNet" "Icon" "$INSTDIR\PropertiesDotNet.exe"
  WriteRegStr HKCR "Directory\shell\PropertiesDotNet\command" "" "$\"$INSTDIR\PropertiesDotNet.exe$\" $\"%1$\""
SectionEnd

; Functions

Function .onInit
  MessageBox MB_YESNO "This will install PropertiesDotNet. Do you wish to continue?" IDYES gogogo
    Abort
  gogogo:
  SetShellVarContext all
  SetAutoClose true
FunctionEnd

Function .onInstSuccess
    MessageBox MB_YESNO "Install Succeeded! Open ReadMe?" IDNO NoReadme
      ExecShell "open" "https://github.com/Walkman100/PropertiesDotNet/blob/master/README.md#propertiesdotnet-"
    NoReadme:
FunctionEnd

; Uninstaller

Section "Uninstall"
  Delete "$INSTDIR\PropertiesDotNet-Uninst.exe" ; Remove Application Files
  Delete "$INSTDIR\PropertiesDotNet.exe"
  RMDir "$INSTDIR"
  
  Delete "$SMPROGRAMS\WalkmanOSS\PropertiesDotNet.lnk" ; Remove Start Menu Shortcuts & Folder
  Delete "$SMPROGRAMS\WalkmanOSS\Uninstall PropertiesDotNet.lnk"
  RMDir "$SMPROGRAMS\WalkmanOSS"
  
  Delete "$DESKTOP\PropertiesDotNet.lnk"     ; Remove Desktop      Shortcut
  Delete "$QUICKLAUNCH\PropertiesDotNet.lnk" ; Remove Quick Launch Shortcut
  
  DeleteRegKey HKCR "*\shell\PropertiesDotNet"         ; Remove files  context menu item
  DeleteRegKey HKCR "Directory\shell\PropertiesDotNet" ; Remove folder context menu item
SectionEnd

; Uninstaller Functions

Function un.onInit
    MessageBox MB_YESNO "This will uninstall PropertiesDotNet. Continue?" IDYES NoAbort
      Abort ; causes uninstaller to quit.
    NoAbort:
    SetShellVarContext all
    SetAutoClose true
FunctionEnd

Function un.onUninstFailed
    MessageBox MB_OK "Uninstall Cancelled"
FunctionEnd

Function un.onUninstSuccess
    MessageBox MB_OK "Uninstall Completed"
FunctionEnd
