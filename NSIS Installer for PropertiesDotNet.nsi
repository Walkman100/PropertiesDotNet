; PropertiesDotNet Installer NSIS Script
; get NSIS at http://nsis.sourceforge.net/Download

!define ProgramName "PropertiesDotNet"
!define ProgramVersion 1.11.0.0
Icon "My Project\document-properties.ico"

Name "${ProgramName}"
Caption "${ProgramName} Installer"
XPStyle on
Unicode true
ShowInstDetails show
AutoCloseWindow true

VIProductVersion ${ProgramVersion}
VIAddVersionKey "ProductVersion" "${ProgramVersion}"
VIAddVersionKey "ProductName" "${ProgramName}"
VIAddVersionKey "FileVersion" "${ProgramVersion}"
VIAddVersionKey "LegalCopyright" "FOSS Walkman"
VIAddVersionKey "FileDescription" "${ProgramName} Installer"

LicenseBkColor /windows
LicenseData "LICENSE.md"
LicenseForceSelection checkbox "I have read and understand this notice"
LicenseText "Please read the notice below before installing ${ProgramName}. If you understand the notice, click the checkbox below and click Next."

InstallDir $PROGRAMFILES\WalkmanOSS
InstallDirRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${ProgramName}" "InstallLocation"
OutFile "bin\Release\${ProgramName}-Installer.exe"

; Pages

Page license
Page components
Page directory
Page instfiles
Page custom postInstallShow postInstallFinish ": Install Complete"
UninstPage uninstConfirm
UninstPage instfiles

; Sections

Section "Executable, Uninstaller & Ookii.Dialogs"
  SectionIn RO
  SetOutPath $INSTDIR
  File "bin\Release\${ProgramName}.exe"
  File "bin\Release\${ProgramName}.exe.config"
  File "bin\Release\${ProgramName}-Ookii.Dialogs.dll"
  WriteUninstaller "${ProgramName}-Uninst.exe"
SectionEnd

Section "Add to Windows Programs & Features"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${ProgramName}" "DisplayName" "${ProgramName}"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${ProgramName}" "Publisher" "WalkmanOSS"
  
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${ProgramName}" "DisplayIcon" "$INSTDIR\${ProgramName}.exe"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${ProgramName}" "InstallLocation" "$INSTDIR\"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${ProgramName}" "UninstallString" "$INSTDIR\${ProgramName}-Uninst.exe"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${ProgramName}" "DisplayVersion" "${ProgramVersion}"
  
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${ProgramName}" "NoModify" 1
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${ProgramName}" "NoRepair" 1
  
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${ProgramName}" "HelpLink" "https://github.com/Walkman100/${ProgramName}/issues/new"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${ProgramName}" "URLInfoAbout" "https://github.com/Walkman100/${ProgramName}" ; Support Link
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${ProgramName}" "URLUpdateInfo" "https://github.com/Walkman100/${ProgramName}/releases" ; Update Info Link
SectionEnd

Section "Start Menu Shortcuts"
  CreateDirectory "$SMPROGRAMS\WalkmanOSS"
  CreateShortCut "$SMPROGRAMS\WalkmanOSS\${ProgramName}.lnk" "$INSTDIR\${ProgramName}.exe" "" "$INSTDIR\${ProgramName}.exe" "" "" "" "${ProgramName}"
  CreateShortCut "$SMPROGRAMS\WalkmanOSS\Uninstall ${ProgramName}.lnk" "$INSTDIR\${ProgramName}-Uninst.exe" "" "" "" "" "" "Uninstall ${ProgramName}"
  ;Syntax for CreateShortCut: link.lnk target.file [parameters [icon.file [icon_index_number [start_options [keyboard_shortcut [description]]]]]]
SectionEnd

Section "Desktop Shortcut"
  CreateShortCut "$DESKTOP\${ProgramName}.lnk" "$INSTDIR\${ProgramName}.exe" "" "$INSTDIR\${ProgramName}.exe" "" "" "" "${ProgramName}"
SectionEnd

Section "Quick Launch Shortcut"
  CreateShortCut "$QUICKLAUNCH\${ProgramName}.lnk" "$INSTDIR\${ProgramName}.exe" "" "$INSTDIR\${ProgramName}.exe" "" "" "" "${ProgramName}"
SectionEnd

SubSection "Context menu entry"
  Section "Add to context menu for all files"
    WriteRegStr HKCR "*\shell\${ProgramName}" "" "P&roperties..."
    WriteRegStr HKCR "*\shell\${ProgramName}" "Icon" "$INSTDIR\${ProgramName}.exe"
      WriteRegStr HKCR "*\shell\${ProgramName}\command" "" "$\"$INSTDIR\${ProgramName}.exe$\" $\"%1$\""
  SectionEnd
  Section "Add to context menu for .url files"
    WriteRegStr HKCR "IE.AssocFile.URL\shell\${ProgramName}" "" "P&roperties..."
    WriteRegStr HKCR "IE.AssocFile.URL\shell\${ProgramName}" "Icon" "$INSTDIR\${ProgramName}.exe"
      WriteRegStr HKCR "IE.AssocFile.URL\shell\${ProgramName}\command" "" "$\"$INSTDIR\${ProgramName}.exe$\" $\"%1$\""
    WriteRegStr HKCR "InternetShortcut\shell\${ProgramName}" "" "P&roperties..."
    WriteRegStr HKCR "InternetShortcut\shell\${ProgramName}" "Icon" "$INSTDIR\${ProgramName}.exe"
      WriteRegStr HKCR "InternetShortcut\shell\${ProgramName}\command" "" "$\"$INSTDIR\${ProgramName}.exe$\" $\"%1$\""
  SectionEnd
  Section "Add to context menu for .lnk files"
    WriteRegStr HKCR "lnkfile\shell\${ProgramName}Shortcut" "" "Shortcut Properties..."
    WriteRegStr HKCR "lnkfile\shell\${ProgramName}Shortcut" "Icon" "$INSTDIR\${ProgramName}.exe"
      WriteRegStr HKCR "lnkfile\shell\${ProgramName}Shortcut\command" "" "$\"$INSTDIR\${ProgramName}.exe$\" $\"%1$\""
  SectionEnd
  Section "Add to context menu for folders"
    DeleteRegKey HKCR "Directory\shell\${ProgramName}" ; Remove old context menu item, 'Folder' also covers drives
    WriteRegStr HKCR "Folder\shell\${ProgramName}" "" "P&roperties..."
    WriteRegStr HKCR "Folder\shell\${ProgramName}" "Icon" "$INSTDIR\${ProgramName}.exe"
      WriteRegStr HKCR "Folder\shell\${ProgramName}\command" "" "$\"$INSTDIR\${ProgramName}.exe$\" $\"%1$\""
  SectionEnd
SubSectionEnd

; Functions

Function .onInit
  SetShellVarContext all
  SetAutoClose true
FunctionEnd

; Custom Install Complete page

!include nsDialogs.nsh
!include LogicLib.nsh ; For ${IF} logic
Var Dialog
Var Label
Var CheckboxReadme
Var CheckboxReadme_State
Var CheckboxRunProgram
Var CheckboxRunProgram_State

Function postInstallShow
  nsDialogs::Create 1018
  Pop $Dialog
  ${If} $Dialog == error
    Abort
  ${EndIf}
  
  ${NSD_CreateLabel} 0 0 100% 12u "Setup will launch these tasks when you click close:"
  Pop $Label
  
  ${NSD_CreateCheckbox} 10u 30u 100% 10u "&Open Readme"
  Pop $CheckboxReadme
  ${If} $CheckboxReadme_State == ${BST_CHECKED}
    ${NSD_Check} $CheckboxReadme
  ${EndIf}
  
  ${NSD_CreateCheckbox} 10u 50u 100% 10u "&Launch ${ProgramName}"
  Pop $CheckboxRunProgram
  ${If} $CheckboxRunProgram_State == ${BST_CHECKED}
    ${NSD_Check} $CheckboxRunProgram
  ${EndIf}
  
  # alternative for the above ${If}:
  #${NSD_SetState} $Checkbox_State
  nsDialogs::Show
FunctionEnd

Function postInstallFinish
  ${NSD_GetState} $CheckboxReadme $CheckboxReadme_State
  ${NSD_GetState} $CheckboxRunProgram $CheckboxRunProgram_State
  
  ${If} $CheckboxReadme_State == ${BST_CHECKED}
    ExecShell "open" "https://github.com/Walkman100/${ProgramName}/blob/master/README.md#propertiesdotnet-"
  ${EndIf}
  ${If} $CheckboxRunProgram_State == ${BST_CHECKED}
    ExecShell "open" "$INSTDIR\${ProgramName}.exe"
  ${EndIf}
FunctionEnd

; Uninstaller

Section "Uninstall"
  Delete "$INSTDIR\${ProgramName}-Uninst.exe" ; Remove Application Files
  Delete "$INSTDIR\${ProgramName}.exe"
  Delete "$INSTDIR\${ProgramName}.exe.config"
  Delete "$INSTDIR\${ProgramName}-Ookii.Dialogs.dll"
  RMDir "$INSTDIR"
  
  DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${ProgramName}" ; Remove Windows Programs & Features integration (uninstall info)
  
  Delete "$SMPROGRAMS\WalkmanOSS\${ProgramName}.lnk" ; Remove Start Menu Shortcuts & Folder
  Delete "$SMPROGRAMS\WalkmanOSS\Uninstall ${ProgramName}.lnk"
  RMDir "$SMPROGRAMS\WalkmanOSS"
  
  Delete "$DESKTOP\${ProgramName}.lnk"     ; Remove Desktop      Shortcut
  Delete "$QUICKLAUNCH\${ProgramName}.lnk" ; Remove Quick Launch Shortcut
  
  DeleteRegKey HKCR "*\shell\${ProgramName}"         ; Remove files  context menu item
  DeleteRegKey HKCR "IE.AssocFile.URL\shell\${ProgramName}"
  DeleteRegKey HKCR "InternetShortcut\shell\${ProgramName}"
  DeleteRegKey HKCR "lnkfile\shell\${ProgramName}Shortcut"
  DeleteRegKey HKCR "Directory\shell\${ProgramName}" ; Remove old folder context menu item
  DeleteRegKey HKCR "Folder\shell\${ProgramName}"    ; Remove current folder context menu item
SectionEnd

; Uninstaller Functions

Function un.onInit
  SetShellVarContext all
  SetAutoClose true
FunctionEnd

Function un.onUninstFailed
  MessageBox MB_OK "Uninstall Cancelled"
FunctionEnd

Function un.onUninstSuccess
  MessageBox MB_OK "Uninstall Completed"
FunctionEnd
