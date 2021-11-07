Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Windows.Forms
Imports System.Xml

Public Class Settings
    Private _settingsPath As String

    Public ReadOnly Property Loaded As Boolean = False
    Public Sub Init()

        Dim configFileName As String = "PropertiesDotNet.xml"

        If Environment.GetEnvironmentVariable("OS") = "Windows_NT" Then
            If Not       Directory.Exists(Path.Combine(Environment.GetEnvironmentVariable("AppData"), "WalkmanOSS")) Then
                Directory.CreateDirectory(Path.Combine(Environment.GetEnvironmentVariable("AppData"), "WalkmanOSS"))
            End If
            _settingsPath =               Path.Combine(Environment.GetEnvironmentVariable("AppData"), "WalkmanOSS", configFileName)
        Else
            If Not       Directory.Exists(Path.Combine(Environment.GetEnvironmentVariable("HOME"), ".config", "WalkmanOSS")) Then
                Directory.CreateDirectory(Path.Combine(Environment.GetEnvironmentVariable("HOME"), ".config", "WalkmanOSS"))
            End If
            _settingsPath =               Path.Combine(Environment.GetEnvironmentVariable("HOME"), ".config", "WalkmanOSS", configFileName)
        End If

        If      File.Exists(Path.Combine(Application.StartupPath, configFileName)) Then
            _settingsPath = Path.Combine(Application.StartupPath, configFileName)
        ElseIf               File.Exists(configFileName) Then
            _settingsPath = New FileInfo(configFileName).FullName
        End If

        cbxTheme.Items.AddRange([Enum].GetNames(GetType(ThemeNames)))

        _Loaded = True
        If File.Exists(_settingsPath) Then
            LoadSettings()
        Else
            ' set initial settings
            chkUseSystemDefault.Checked = True
            chkShowOpenWithWarning.Checked = True
            chkEnableAutoResize.Checked = True
            chkEnableUpdateCheck.Checked = True
            cbxDriveInfo.SelectedIndex = 2 ' Show on Drives
            cbxDefaultSize.SelectedIndex = 11 ' Auto (Decimal)
            cbxTheme.SelectedIndex = 0
        End If
    End Sub

    Private Sub MeVisibleChanged() Handles Me.VisibleChanged
        If Me.Visible Then Me.CenterToParent()
    End Sub

    Public Enum DriveInfoVisibility
        AlwaysVisible
        AlwaysHidden
        AutoVisibility
    End Enum

    Public Enum ThemeNames
        [Default]
        Inverted
        SystemDark
        Dark
        Test
    End Enum

#Region "Properties"
    Public ReadOnly Property DefaultUseSystemState As Boolean
    Public ReadOnly Property ShowOpenWithWarning As Boolean
    Public ReadOnly Property AutoResize As Boolean
    Public ReadOnly Property UpdateCheck As Boolean
    Public ReadOnly Property ShowDriveInfo As DriveInfoVisibility
    Public ReadOnly Property DefaultSizeSelection As Integer
    Public ReadOnly Property Theme As ThemeNames
#End Region

#Region "GUI Methods"
    Private Sub chkUseSystemDefault_CheckedChanged() Handles chkUseSystemDefault.CheckedChanged
        _DefaultUseSystemState = chkUseSystemDefault.Checked
        SaveSettings()
    End Sub
    Private Sub chkShowOpenWithWarning_CheckedChanged() Handles chkShowOpenWithWarning.CheckedChanged
        _ShowOpenWithWarning = chkShowOpenWithWarning.Checked
        SaveSettings()
    End Sub
    Private Sub chkEnableAutoResize_CheckedChanged() Handles chkEnableAutoResize.CheckedChanged
        _AutoResize = chkEnableAutoResize.Checked
        SaveSettings()
    End Sub
    Private Sub chkEnableUpdateCheck_CheckedChanged() Handles chkEnableUpdateCheck.CheckedChanged
        _UpdateCheck = chkEnableUpdateCheck.Checked
        SaveSettings()
    End Sub
    Private Sub cbxDriveInfo_SelectedIndexChanged() Handles cbxDriveInfo.SelectedIndexChanged
        _ShowDriveInfo = DirectCast(cbxDriveInfo.SelectedIndex, DriveInfoVisibility)
        SaveSettings()
    End Sub
    Private Sub cbxDefaltSize_SelectedIndexChanged() Handles cbxDefaultSize.SelectedIndexChanged
        _DefaultSizeSelection = cbxDefaultSize.SelectedIndex
        SaveSettings()
    End Sub
    Private Sub cbxTheme_SelectedIndexChanged() Handles cbxTheme.SelectedIndexChanged
        _Theme = DirectCast(cbxTheme.SelectedIndex, ThemeNames)
        SaveSettings()
    End Sub

    Private Sub btnClose_Click() Handles btnClose.Click
        Me.Hide()
    End Sub
    Private Sub btnShowSettingsFile_Click() Handles btnShowSettingsFile.Click
        Process.Start("explorer.exe", "/select, " & _settingsPath)
    End Sub
#End Region

#Region "Settings Saving & Loading"
    Private Sub LoadSettings() Handles btnReload.Click
        If Not Loaded Then Return
        _loading = True
        Try
            Using reader As XmlReader = XmlReader.Create(_settingsPath)
                Try
                    reader.Read()
                Catch ex As XmlException
                    Return
                End Try

                If reader.IsStartElement() AndAlso reader.Name = "PropertiesDotNet" Then
                    If reader.Read() AndAlso reader.IsStartElement() AndAlso reader.Name = "Settings" AndAlso reader.Read() Then
                        While reader.IsStartElement
                            Select Case reader.Name
                                Case "DefaultUseSystemState"
                                    reader.Read()
                                    Boolean.TryParse(reader.Value, chkUseSystemDefault.Checked)
                                Case "ShowOpenWithWarning"
                                    reader.Read()
                                    Boolean.TryParse(reader.Value, chkShowOpenWithWarning.Checked)
                                Case "EnableAutoResize"
                                    reader.Read()
                                    Boolean.TryParse(reader.Value, chkEnableAutoResize.Checked)
                                Case "EnableUpdateCheck"
                                    reader.Read()
                                    Boolean.TryParse(reader.Value, chkEnableUpdateCheck.Checked)
                                Case "ShowDriveInfo"
                                    reader.Read()
                                    Dim selected As DriveInfoVisibility
                                    [Enum].TryParse(reader.Value, selected)
                                    cbxDriveInfo.SelectedIndex = selected
                                Case "DefaultSizeSelection"
                                    reader.Read()
                                    Integer.TryParse(reader.Value, cbxDefaultSize.SelectedIndex)
                                Case "Theme"
                                    reader.Read()
                                    Dim out As ThemeNames
                                    [Enum].TryParse(reader.Value, out)
                                    cbxTheme.SelectedIndex = out
                                Case Else
                                    reader.Read() ' skip unknown values
                            End Select
                            reader.Read() : reader.Read()
                        End While
                    End If
                End If
            End Using
        Finally
            _loading = False
        End Try
    End Sub

    Private _loading As Boolean = False ' so that we don't save while loading settings

    Friend Sub SaveSettings() Handles btnSave.Click
        If Not Loaded OrElse _loading Then Return
        Using writer As XmlWriter = XmlWriter.Create(_settingsPath, New XmlWriterSettings With {.Indent = True})
            writer.WriteStartDocument()
            writer.WriteStartElement("PropertiesDotNet")

            writer.WriteStartElement("Settings")
            writer.WriteElementString("DefaultUseSystemState", DefaultUseSystemState.ToString())
            writer.WriteElementString("ShowOpenWithWarning", ShowOpenWithWarning.ToString())
            writer.WriteElementString("EnableAutoResize", AutoResize.ToString())
            writer.WriteElementString("EnableUpdateCheck", UpdateCheck.ToString())
            writer.WriteElementString("ShowDriveInfo", ShowDriveInfo.ToString())
            writer.WriteElementString("DefaultSizeSelection", DefaultSizeSelection.ToString())
            writer.WriteElementString("Theme", Theme.ToString())
            writer.WriteEndElement() ' Settings

            writer.WriteEndElement()
            writer.WriteEndDocument()
        End Using
    End Sub
#End Region
End Class
