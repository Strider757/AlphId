Imports System.Net
Imports System.Net.NetworkInformation
Imports System.IO

Public Class MainForm
    Public fileCollect As New ArrayList
    Public xdoc As XDocument
    Public SyncFileName As String = "D:\Development\Work\ProjectSync\Config.xml"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FilesForm.Visible = True
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With DataGridView1
            .Columns.Add("name", "name")
            .Columns.Add("directory", "directory")
            .Columns.Add("local", "local")
            .Columns.Add("remote", "remote")
        End With

        TextBox1.Text = "172.16.18.161"
        'Call but_Anal_Click()
        xdoc = XDocument.Load(SyncFileName) 'грузим в память хмл
        Call FilesForm.xmlLoad() 'запихиваем список файлов из хмл в колекцию
    End Sub
    Public Function FullFileName(ByVal path As String, ByVal name As String) As String
        FullFileName = path & "\" & name
    End Function

    Public Function convertFilePathToRemote(ByVal path As String) As String
        '\\172.16.18.161\d$\Development\Work\ProjectSync\TestFiles\path 1
        'd:\Development\Work\ProjectSync\TestFiles\path 1
        convertFilePathToRemote = "\\" & TextBox1.Text & "\" & Replace(path, ":", "$")
    End Function

    Private Sub but_Anal_Click(sender As Object, e As EventArgs) Handles but_Anal.Click
        On Error GoTo err1
        Dim i = 0
        DataGridView1.Rows.Clear()
        If My.Computer.Network.Ping(TextBox1.Text) Then
            Label2.Text = "ЕСТЬ СВЯЗЬ"
            Label2.ForeColor = System.Drawing.Color.Green
            'Else
            '    Label2.Text = "НЕТ СВЯЗИ"
            '    Label2.ForeColor = System.Drawing.Color.Red
        End If

        For Each fObj In fileCollect
            'If File.Exists(FullFileName(fObj.location, fObj.name)) Then
            DataGridView1.Rows.Add()
            DataGridView1.Rows.Item(i).Cells(0).Value = fObj.Name
            DataGridView1.Rows.Item(i).Cells(1).Value = fObj.Location
            DataGridView1.Rows.Item(i).Cells(2).Value = Replace(IO.File.GetLastWriteTime(FullFileName(fObj.location, fObj.name)), "01.01.1601 3:00:00", " ")
            DataGridView1.Rows.Item(i).Cells(3).Value = Replace(IO.File.GetLastWriteTime(FullFileName(convertFilePathToRemote(fObj.location), fObj.name)), "01.01.1601 3:00:00", " ")

            If DataGridView1.Rows.Item(i).Cells(2).Value > DataGridView1.Rows.Item(i).Cells(3).Value Then
                DataGridView1.Rows.Item(i).Cells(2).Style.ForeColor = System.Drawing.Color.Green
                DataGridView1.Rows.Item(i).Cells(3).Style.ForeColor = System.Drawing.Color.Red
            Else
                DataGridView1.Rows.Item(i).Cells(3).Style.ForeColor = System.Drawing.Color.Green
                DataGridView1.Rows.Item(i).Cells(2).Style.ForeColor = System.Drawing.Color.Red
            End If
            i = i + 1
            'End If
        Next

        Exit Sub
err1:
        If Err.Number = 5 Then MsgBox("Кажись кривой айпишник. Err.Number: " & Err.Number & ". " & Err.Description, vbCritical, "Ошибка")
    End Sub


End Class
