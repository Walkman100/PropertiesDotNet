' Copyright (c) Microsoft Corporation.  All rights reserved.

Imports System
Imports System.Runtime.InteropServices

Namespace wyDay.Controls
    ''' <summary>
    ''' The primary coordinator of the Windows 7 taskbar-related activities.
    ''' </summary>
    Public NotInheritable Class Windows7Taskbar
        Private Sub New()
        End Sub
        Private Shared _taskbarList As ITaskbarList3
        Friend Shared ReadOnly Property TaskbarList() As ITaskbarList3
            Get
                If _taskbarList Is Nothing Then
                    SyncLock GetType(Windows7Taskbar)
                        If _taskbarList Is Nothing Then
                            _taskbarList = DirectCast(New CTaskbarList(), ITaskbarList3)
                            _taskbarList.HrInit()
                        End If
                    End SyncLock
                End If
                Return _taskbarList
            End Get
        End Property

        Shared ReadOnly osInfo As OperatingSystem = Environment.OSVersion

        Friend Shared ReadOnly Property Windows7OrGreater() As Boolean
            Get
                Return (osInfo.Version.Major = 6 AndAlso osInfo.Version.Minor >= 1) OrElse (osInfo.Version.Major > 6)
            End Get
        End Property

        ''' <summary>
        ''' Sets the progress state of the specified window's
        ''' taskbar button.
        ''' </summary>
        ''' <param name="hwnd">The window handle.</param>
        ''' <param name="state">The progress state.</param>
        Public Shared Sub SetProgressState(hwnd As IntPtr, state As ThumbnailProgressState)
            If Windows7OrGreater Then
                TaskbarList.SetProgressState(hwnd, state)
            End If
        End Sub
        ''' <summary>
        ''' Sets the progress value of the specified window's
        ''' taskbar button.
        ''' </summary>
        ''' <param name="hwnd">The window handle.</param>
        ''' <param name="current">The current value.</param>
        ''' <param name="maximum">The maximum value.</param>
        Public Shared Sub SetProgressValue(hwnd As IntPtr, current As ULong, maximum As ULong)
            If Windows7OrGreater Then
                TaskbarList.SetProgressValue(hwnd, current, maximum)
            End If
        End Sub


        <DllImport("user32.dll", CharSet := CharSet.Auto)> _
        Friend Shared Function SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer) As Integer
        End Function
    End Class
End Namespace
