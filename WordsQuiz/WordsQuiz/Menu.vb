Imports System.IO
Public Class Menu
    Private Sub Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Info.Show()
    End Sub

    Private Sub RecordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecordToolStripMenuItem.Click
        Record.Show()
    End Sub

    Private Sub EditorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditorToolStripMenuItem.Click
        Editor.Show()
    End Sub

    Private Sub QuitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitToolStripMenuItem.Click
        End
    End Sub

    Function ChkExist(tnc As TreeNodeCollection, str As String) As Boolean
        For Each n As TreeNode In tnc
            If n.Text = str Then Return True
        Next
        Return False
    End Function

    Private Sub NewQuizToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewQuizToolStripMenuItem.Click
        OpenFileDialog1.InitialDirectory = Application.StartupPath
        If OpenFileDialog1.ShowDialog() <> vbOK Then Return
        TreeView1.Nodes.Clear()

        Dim sr As StreamReader = New StreamReader(OpenFileDialog1.FileName)
        Dim str, c As String

        Do While sr.Peek > 0
            str = sr.ReadLine()
            Dim tnc As TreeNodeCollection

            tnc = TreeView1.Nodes
            For Each c In str.Split(":")(0).Split("/")
                If Not ChkExist(tnc, c) Then tnc.Add(c)
                For Each n As TreeNode In tnc
                    If n.Text = c Then tnc = n.Nodes
                Next
            Next

            str = str.Split(":")(1)
            Dim buf As String() = str.Split(";")
            For Each s As String In buf
                If s IsNot "" Then
                    If Not ChkExist(tnc, s) Then tnc.Add(s)
                End If
            Next
        Loop

        sr.Close()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        If ToolStripMenuItem2.Checked = False Then
            ToolStripMenuItem2.Checked = True
        Else
            ToolStripMenuItem2.Checked = False
        End If
        ToolStripButton1.Enabled = Not ToolStripMenuItem2.Checked
    End Sub
End Class
