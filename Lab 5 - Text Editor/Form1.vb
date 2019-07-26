Option Strict On
Public Class frmTextEditor

    Dim fileOpened As String

    Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        Application.Exit()
    End Sub

    Private Sub mnuOpen_Click(sender As Object, e As EventArgs) Handles mnuOpen.Click
        Dim openFileDialog1 As OpenFileDialog = New OpenFileDialog
        openFileDialog1.Title = "Please select a text file"
        openFileDialog1.InitialDirectory = "C:\"
        openFileDialog1.Filter = "All files|*.*|Text files|*.txt"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog = DialogResult.OK Then
            fileOpened = openFileDialog1.FileName
            Me.Text = "Text Editor - " & fileOpened
            tbInput.Text = My.Computer.FileSystem.ReadAllText(openFileDialog1.FileName)
        End If

    End Sub

    Private Sub SaveWindow()
        If Not tbInput.Text = "" Then
            Dim saveFileDialog1 As SaveFileDialog = New SaveFileDialog
            saveFileDialog1.Title = "Save the text file"
            saveFileDialog1.InitialDirectory = "C:\"
            saveFileDialog1.Filter = "All files|*.*|Text files|*.txt"
            saveFileDialog1.FilterIndex = 2
            saveFileDialog1.RestoreDirectory = True

            If saveFileDialog1.ShowDialog = DialogResult.OK Then
                fileOpened = saveFileDialog1.FileName
                Me.Text = "Text Editor - " & saveFileDialog1.FileName

                Dim saveWriter As New System.IO.StreamWriter(fileOpened)
                saveWriter.Write(tbInput.Text)
                saveWriter.Close()
            End If
        End If
    End Sub

    Private Sub mnuSave_Click(sender As Object, e As EventArgs) Handles mnuSave.Click
        If fileOpened = "" Or Not System.IO.File.Exists(fileOpened) Then
            SaveWindow()
        Else
            Dim saveWriter As New System.IO.StreamWriter(fileOpened)
            saveWriter.Write(tbInput.Text)
            saveWriter.Close()
        End If
    End Sub

    Private Sub mnuSaveAs_Click(sender As Object, e As EventArgs) Handles mnuSaveAs.Click
        SaveWindow()
    End Sub

    Private Sub mnuClose_Click(sender As Object, e As EventArgs) Handles mnuClose.Click
        ResetText()
    End Sub

    Private Sub mnuCopy_Click(sender As Object, e As EventArgs) Handles mnuCopy.Click
        tbInput.Copy()
    End Sub

    Private Sub mnuCut_Click(sender As Object, e As EventArgs) Handles mnuCut.Click
        tbInput.Cut()
    End Sub

    Private Sub mnuPaste_Click(sender As Object, e As EventArgs) Handles mnuPaste.Click
        tbInput.Paste()
    End Sub

    Private Sub frmTextEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResetText()
    End Sub

    Private Sub ResetText()
        Me.Text = "Text Editor"
        tbInput.Text = ""
        fileOpened = ""
    End Sub

    Private Sub mnuAbout_Click(sender As Object, e As EventArgs) Handles mnuAbout.Click
        MessageBox.Show("Made by March Roldan (100702892)", "About")
    End Sub
End Class
