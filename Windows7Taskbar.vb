Imports System.ComponentModel

'Windows7ProgressBar v1.0, created by Wyatt O'Day
'Visit: http://wyday.com/windows-7-progress-bar/

Namespace wyDay.Controls
    ''' <summary>
    ''' A Windows progress bar control with Windows Vista & 7 functionality.
    ''' </summary>
    <ToolboxBitmap(GetType(ProgressBar))> _
    Public Class Windows7ProgressBar
        Inherits ProgressBar
        Private m_showInTaskbar As Boolean
        Private m_State As ProgressBarState = ProgressBarState.Normal
        Private ownerForm As ContainerControl

        Public Sub New()
        End Sub

        Public Sub New(parentControl As ContainerControl)
            ContainerControl = parentControl
        End Sub
        Public Property ContainerControl() As ContainerControl
            Get
                Return ownerForm
            End Get
            Set
                ownerForm = value

                If Not ownerForm.Visible Then
                    AddHandler DirectCast(ownerForm, Form).Shown, AddressOf Windows7ProgressBar_Shown
                End If
            End Set
        End Property
        Public Overrides WriteOnly Property Site() As ISite
            Set
                ' Runs at design time, ensures designer initializes ContainerControl
                MyBase.Site = value
                If value Is Nothing Then
                    Return
                End If
                Dim service As Design.IDesignerHost = TryCast(value.GetService(GetType(Design.IDesignerHost)), Design.IDesignerHost)
                If service Is Nothing Then
                    Return
                End If
                Dim rootComponent As IComponent = service.RootComponent

                ContainerControl = TryCast(rootComponent, ContainerControl)
            End Set
        End Property

        Private Sub Windows7ProgressBar_Shown(sender As Object, e As System.EventArgs)
            If ShowInTaskbar Then
                If Style <> ProgressBarStyle.Marquee Then
                    SetValueInTB()
                End If

                SetStateInTB()
            End If

            RemoveHandler DirectCast(ownerForm, Form).Shown, AddressOf Windows7ProgressBar_Shown
        End Sub



        ''' <summary>
        ''' Show progress in taskbar
        ''' </summary>
        <DefaultValue(False)> _
        Public Property ShowInTaskbar() As Boolean
            Get
                Return m_showInTaskbar
            End Get
            Set
                If m_showInTaskbar <> value Then
                    m_showInTaskbar = value

                    ' send signal to the taskbar.
                    If ownerForm IsNot Nothing Then
                        If Style <> ProgressBarStyle.Marquee Then
                            SetValueInTB()
                        End If

                        SetStateInTB()
                    End If
                End If
            End Set
        End Property


        ''' <summary>
        ''' Gets or sets the current position of the progress bar.
        ''' </summary>
        ''' <returns>The position within the range of the progress bar. The default is 0.</returns>
        Public Shadows Property Value() As Integer
            Get
                Return MyBase.Value
            End Get
            Set
                MyBase.Value = value

                ' send signal to the taskbar.
                SetValueInTB()
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the manner in which progress should be indicated on the progress bar.
        ''' </summary>
        ''' <returns>One of the ProgressBarStyle values. The default is ProgressBarStyle.Blocks</returns>
        Public Shadows Property Style() As ProgressBarStyle
            Get
                Return MyBase.Style
            End Get
            Set
                MyBase.Style = value

                ' set the style of the progress bar
                If m_showInTaskbar AndAlso ownerForm IsNot Nothing Then
                    SetStateInTB()
                End If
            End Set
        End Property


        ''' <summary>
        ''' The progress bar state for Windows Vista & 7
        ''' </summary>
        <DefaultValue(ProgressBarState.Normal)> _
        Public Property State() As ProgressBarState
            Get
                Return m_State
            End Get
            Set
                m_State = value

                Dim wasMarquee As Boolean = Style = ProgressBarStyle.Marquee

                If wasMarquee Then
                    ' sets the state to normal (and implicity calls SetStateInTB() )
                    Style = ProgressBarStyle.Blocks
                End If

                ' set the progress bar state (Normal, Error, Paused)
                Windows7Taskbar.SendMessage(Handle, &H410, CInt(value), 0)


                If wasMarquee Then
                    ' the Taskbar PB value needs to be reset
                    SetValueInTB()
                Else
                    ' there wasn't a marquee, thus we need to update the taskbar
                    SetStateInTB()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Advances the current position of the progress bar by the specified amount.
        ''' </summary>
        ''' <param name="value">The amount by which to increment the progress bar's current position.</param>
        Public Shadows Sub Increment(value As Integer)
            MyBase.Increment(value)

            ' send signal to the taskbar.
            SetValueInTB()
        End Sub

        ''' <summary>
        ''' Advances the current position of the progress bar by the amount of the System.Windows.Forms.ProgressBar.Step property.
        ''' </summary>
        Public Shadows Sub PerformStep()
            MyBase.PerformStep()

            ' send signal to the taskbar.
            SetValueInTB()
        End Sub

        Private Sub SetValueInTB()
            If m_showInTaskbar Then
                Dim maximum__1 As ULong = CULng(Maximum - Minimum)
                Dim progress As ULong = CULng(Value - Minimum)

                Windows7Taskbar.SetProgressValue(ownerForm.Handle, progress, maximum__1)
            End If
        End Sub

        Private Sub SetStateInTB()
            If ownerForm Is Nothing Then
                Return
            End If

            Dim thmState As ThumbnailProgressState = ThumbnailProgressState.Normal

            If Not m_showInTaskbar Then
                thmState = ThumbnailProgressState.NoProgress
            ElseIf Style = ProgressBarStyle.Marquee Then
                thmState = ThumbnailProgressState.Indeterminate
            ElseIf m_State = ProgressBarState.[Error] Then
                thmState = ThumbnailProgressState.[Error]
            ElseIf m_State = ProgressBarState.Pause Then
                thmState = ThumbnailProgressState.Paused
            End If

            Windows7Taskbar.SetProgressState(ownerForm.Handle, thmState)
        End Sub
    End Class

    ''' <summary>
    ''' The progress bar state for Windows Vista & 7
    ''' </summary>
    Public Enum ProgressBarState
        ''' <summary>
        ''' Indicates normal progress
        ''' </summary>
        Normal = 1

        ''' <summary>
        ''' Indicates an error in the progress
        ''' </summary>
        [Error] = 2

        ''' <summary>
        ''' Indicates paused progress
        ''' </summary>
        Pause = 3
    End Enum
End Namespace
