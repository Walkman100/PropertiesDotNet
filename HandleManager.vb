﻿Imports System.Threading.Tasks
Imports PropertiesDotNet.WalkmanLib

Public Partial Class HandleManager
    Public Sub New()
        Me.InitializeComponent()
    End Sub
    
    Sub LoadHandles() Handles Me.Shown
        Me.Text = "Processes using file: " & PropertiesDotNet.lblLocation.Text
        
        If Not bwHandleScan.IsBusy Then
            btnScan_Click()
        End If
    End Sub
    
    Private Sub lstHandles_ItemSelectionChanged() Handles lstHandles.ItemSelectionChanged
        If lstHandles.SelectedItems.Count = 0 Then
            btnKillProcess.Enabled = False
            btnCloseHandle.Enabled = False
        Else
            btnKillProcess.Enabled = True
            btnCloseHandle.Enabled = False
            For Each item As ListViewItem In lstHandles.SelectedItems
                If Not String.IsNullOrWhiteSpace(item.SubItems(0).Text) AndAlso Not String.IsNullOrWhiteSpace(item.SubItems(2).Text) Then
                    btnCloseHandle.Enabled = True
                End If
            Next
        End If
    End Sub
    
    Private Sub lstHandles_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lstHandles.ColumnClick
        If e.Column = 0 Then
            lstHandles.Sorting = IIf(lstHandles.Sorting = SortOrder.Ascending, SortOrder.Descending, SortOrder.Ascending)
        Else
            'lstHandles.Sort(e.Column)
        End If
    End Sub
    
    Sub btnScan_Click() Handles btnScan.Click
        btnScan.Enabled = False
        If bwHandleScan.IsBusy Then
            bwHandleScan.CancelAsync()
        Else
            bwHandleScan.RunWorkerAsync()
        End If
    End Sub
    
    Sub btnKillProcess_Click() Handles btnKillProcess.Click
        For Each item As ListViewItem In lstHandles.SelectedItems
            
        Next
    End Sub
    
    Sub btnCloseHandle_Click() Handles btnCloseHandle.Click
        For Each item As ListViewItem In lstHandles.SelectedItems
            If Not String.IsNullOrWhiteSpace(item.SubItems(0).Text) AndAlso Not String.IsNullOrWhiteSpace(item.SubItems(2).Text) Then
                SystemHandles.CloseSystemHandle(UInteger.Parse(item.SubItems(0).Text), UShort.Parse(item.SubItems(2).Text))
            End If
        Next
    End Sub
    
    Sub bwHandleScan_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bwHandleScan.ProgressChanged
        lblStatus.Text = DirectCast(e.UserState, String)
    End Sub
    
    Sub bwHandleScan_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwHandleScan.RunWorkerCompleted
        btnScan.Enabled = True
        btnScan.Text = "Start New Scan"
        
        lblStatus.Text = "Status: Idle."
        If e.Error IsNot Nothing Then
            PropertiesDotNet.ErrorParser(e.Error)
        ElseIf e.Cancelled Then
            MsgBox("The scan waiting was cancelled! Running handle checks are still running and can only be stopped by restarting PropertiesDotNet...",
                MsgBoxStyle.Exclamation, "Canceled Scan")
        End If
    End Sub
    
    Sub bwHandleScan_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwHandleScan.DoWork
        btnScan.Enabled = True
        btnScan.Text = "Cancel Waiting"
        
        Dim filePath As String = New FileInfo(PropertiesDotNet.lblLocation.Text).FullName
        MsgBox(filePath)
        Dim taskList As New List(Of Task)
        
        bwHandleScan.ReportProgress(0, "Status: Getting System Handles...")
        
        For Each systemHandle As SystemHandles.SYSTEM_HANDLE In SystemHandles.GetSystemHandles()
            taskList.Add(Task.Run(Sub()
                    Dim handleInfo As SystemHandles.HandleInfo = SystemHandles.GetHandleInfo(systemHandle, True, SystemHandles.SYSTEM_HANDLE_TYPE.FILE)
                    If handleInfo.Type = SystemHandles.SYSTEM_HANDLE_TYPE.FILE AndAlso handleInfo.Name IsNot Nothing Then
                        handleInfo.Name = SystemHandles.ConvertDevicePathToDosPath(handleInfo.Name)
                        If handleInfo.Name.Contains(filePath) Then
                            addHandle(handleInfo)
                        End If
                    End If
                End Sub
            ))
            
            If bwHandleScan.CancellationPending Then e.Cancel = True : Return
        Next
        
        ' while any tasks haven't finished
        While taskList.Any(Function(task As Task)
                               Return task.IsCompleted = False
                           End Function)
            
            ' report unfinished tasks count
            Dim taskCount = taskList.Where(Function(task As Task)
                                               Return task.IsCompleted = False
                                           End Function).Count()
            bwHandleScan.ReportProgress(0, "Status: Waiting for tasks: " & taskCount & " remaining...")
            
            If bwHandleScan.CancellationPending Then e.Cancel = True : Return
            ' wait for any tasks to complete
            Task.WaitAny(taskList.ToArray(), 200)
            If bwHandleScan.CancellationPending Then e.Cancel = True : Return
            
            ' remove completed tasks so they aren't waited
            taskList.RemoveAll(Function(task As Task)
                                   Return task.IsCompleted
                               End Function)
        End While
    End Sub
    
    Private Sub addHandle(handleInfo As SystemHandles.HandleInfo)
        Dim processName As String
        Try : processName = Diagnostics.Process.GetProcessById(handleInfo.ProcessID).ProcessName
        Catch ex As InvalidOperationException : processName = ""
        End Try
        
        Dim tmpListViewItem As ListViewItem = New ListViewItem({handleInfo.ProcessID, processName, handleInfo.HandleID, handleInfo.Name})
        lstHandles.Items.Add(tmpListViewItem)
        
        lstHandles.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        lstHandles_ItemSelectionChanged()
    End Sub
End Class