' Copyright (c) Microsoft Corporation.  All rights reserved.

Namespace wyDay.Controls
    ''' <summary>
    ''' Represents the thumbnail progress bar state.
    ''' </summary>
    Public Enum ThumbnailProgressState
        ''' <summary>
        ''' No progress is displayed.
        ''' </summary>
        NoProgress = 0
        ''' <summary>
        ''' The progress is indeterminate (marquee).
        ''' </summary>
        Indeterminate = &H1
        ''' <summary>
        ''' Normal progress is displayed.
        ''' </summary>
        Normal = &H2
        ''' <summary>
        ''' An error occurred (red).
        ''' </summary>
        [Error] = &H4
        ''' <summary>
        ''' The operation is paused (yellow).
        ''' </summary>
        Paused = &H8
    End Enum

    'Based on Rob Jarett's wrappers for the desktop integration PDC demos.
    <ComImportAttribute> _
    <GuidAttribute("ea1afb91-9e28-4b86-90e9-9e9f8a5eefaf")> _
    <InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)> _
    Friend Interface ITaskbarList3
        ' ITaskbarList
        <PreserveSig> _
        Sub HrInit()
        <PreserveSig> _
        Sub AddTab(hwnd As IntPtr)
        <PreserveSig> _
        Sub DeleteTab(hwnd As IntPtr)
        <PreserveSig> _
        Sub ActivateTab(hwnd As IntPtr)
        <PreserveSig> _
        Sub SetActiveAlt(hwnd As IntPtr)

        ' ITaskbarList2
        <PreserveSig> _
        Sub MarkFullscreenWindow(hwnd As IntPtr, <MarshalAs(UnmanagedType.Bool)> fFullscreen As Boolean)

        ' ITaskbarList3
        Sub SetProgressValue(hwnd As IntPtr, ullCompleted As UInt64, ullTotal As UInt64)
        Sub SetProgressState(hwnd As IntPtr, tbpFlags As ThumbnailProgressState)

        ' yadda, yadda - there's more to the interface, but we don't need it.
    End Interface

    <GuidAttribute("56FDF344-FD6D-11d0-958A-006097C9A090")> _
    <ClassInterfaceAttribute(ClassInterfaceType.None)> _
    <ComImportAttribute> _
    Friend Class CTaskbarList
    End Class
End Namespace
