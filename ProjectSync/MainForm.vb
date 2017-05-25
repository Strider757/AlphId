Imports System.Net
Imports System.Net.NetworkInformation
Imports System.IO

Public Class MainForm
    Public fileCollect As New ArrayList
    Public xdoc As XDocument
    Public SyncFileName As String = CurDir() & "\Config.xml"
    Public bool_configFileExist As Boolean
    Dim bool_connection As Boolean = False
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FilesForm.Visible = True
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bool_configFileExist = File.Exists(SyncFileName)
        ToolStripStatusLabel1.Text = " "
        With DataGridView1
            .Columns.Add("name", "Имя")
            .Columns.Add("local", "Местный")
            .Columns.Add("remote", "Удалённый")
            .Columns.Add("directory", "Расположение")
            .Columns(0).Width = 153
            .Columns(1).Width = 110
            .Columns(2).Width = 110
            .Columns(3).Width = 318
        End With

        RadioButton1.Checked = True



        If bool_configFileExist Then
            xdoc = XDocument.Load(SyncFileName)         'грузим в память хмл
            Call FilesForm.xmlLoad()         'запихиваем список файлов из хмл в колекцию
        Else
            ToolStripStatusLabel1.Text = "Внимание! Конфигурационный файл не найден!"
            ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Red
        End If
        TextBox1.Text = xdoc.Element("Root").Element("IP").Value
    End Sub
    Public Function FullFileName(ByVal path As String, ByVal name As String) As String
        FullFileName = path & "\" & name
    End Function

    Public Function convertFilePathToRemote(ByVal path As String) As String
        '\\172.16.18.161\d$\Development\Work\ProjectSync\TestFiles\path 1
        'd:\Development\Work\ProjectSync\TestFiles\path 1
        convertFilePathToRemote = "\\" & TextBox1.Text & "\" & Replace(path, ":", "$")
    End Function

    Sub anal()
        On Error GoTo err1
        Dim i = 0

        DataGridView1.Rows.Clear()
        If My.Computer.Network.Ping(TextBox1.Text) Then
            TextBox1.BackColor = System.Drawing.Color.Green

            bool_connection = True
        Else
            TextBox1.BackColor = System.Drawing.Color.Red
            ToolStripStatusLabel1.Text = "Нет связи"
        End If



        For Each fObj In fileCollect
            DataGridView1.Rows.Add()
            DataGridView1.Rows.Item(i).Cells(0).Value = fObj.Name
            DataGridView1.Rows.Item(i).Cells(3).Value = fObj.Location
            DataGridView1.Rows.Item(i).Cells(1).Value = Replace(IO.File.GetLastWriteTime(FullFileName(fObj.location, fObj.name)), "01.01.1601 3:00:00", " ")
            If bool_connection = True Then DataGridView1.Rows.Item(i).Cells(2).Value = Replace(IO.File.GetLastWriteTime(FullFileName(convertFilePathToRemote(fObj.location), fObj.name)), "01.01.1601 3:00:00", " ")

            If DataGridView1.Rows.Item(i).Cells(1).Value > DataGridView1.Rows.Item(i).Cells(2).Value Or bool_connection = False Then
                DataGridView1.Rows.Item(i).Cells(1).Style.ForeColor = System.Drawing.Color.Green
                DataGridView1.Rows.Item(i).Cells(2).Style.ForeColor = System.Drawing.Color.Red
            ElseIf DataGridView1.Rows.Item(i).Cells(1).Value = DataGridView1.Rows.Item(i).Cells(2).Value Then
                DataGridView1.Rows.Item(i).Cells(1).Style.ForeColor = System.Drawing.Color.Black
                DataGridView1.Rows.Item(i).Cells(2).Style.ForeColor = System.Drawing.Color.Black
            Else
                DataGridView1.Rows.Item(i).Cells(2).Style.ForeColor = System.Drawing.Color.Green
                DataGridView1.Rows.Item(i).Cells(1).Style.ForeColor = System.Drawing.Color.Red
            End If
            i = i + 1
        Next
        'xdoc.Element("Root").Elements("IP").Value = TextBox1.Text
        'xdoc.Save(SyncFileName)
        Exit Sub
err1:
        If Err.Number = 5 Then
            MsgBox("Err.Number: " & Err.Number & ". " & Err.Description, vbCritical, "Ошибка")
            bool_connection = False
        ElseIf Err.Number = 57 And bool_connection = False Then
            MsgBox("Кажись удаленный узел не доступен. Err.Number: " & Err.Number & ". " & Err.Description, vbCritical, "Ошибка")
        ElseIf Err.Number = 57 And bool_connection = True Then
            MsgBox("Связь есть, но надо залогинится. Для этого зайди на удаленную машину Err.Number: " & Err.Number & ". " & Err.Description, vbCritical, "Ошибка")
            bool_connection = False
            ToolStripStatusLabel1.Text = "Не выполенен вход"
            Resume Next
        Else
            MsgBox("Err.Number: " & Err.Number & ". " & Err.Description, vbCritical, "Ошибка")
        End If
    End Sub

    Private Sub but_Anal_Click(sender As Object, e As EventArgs) Handles but_Anal.Click
        anal()
        If bool_connection = True Then but_sync.Enabled = True
    End Sub


    Private Sub but_sync_Click(sender As Object, e As EventArgs) Handles but_sync.Click
        If MsgBox("Выполнить синхронизацию?", vbOKCancel Or vbQuestion, "Вопрос") = MsgBoxResult.Cancel Then Exit Sub
        For Each dataElem As DataGridViewRow In DataGridView1.Rows 'dataElem.Cells(0).Value

            If RadioButton1.Checked Then ' туда
                If dataElem.Cells(2).Value > dataElem.Cells(3).Value Then
                    IO.File.Copy(FullFileName(dataElem.Cells(1).Value, dataElem.Cells(0).Value), FullFileName(convertFilePathToRemote(dataElem.Cells(1).Value), dataElem.Cells(0).Value), True)
                End If
            ElseIf RadioButton2.Checked Then ' cюда
                If dataElem.Cells(3).Value > dataElem.Cells(2).Value Then
                    IO.File.Copy(FullFileName(convertFilePathToRemote(dataElem.Cells(1).Value), dataElem.Cells(0).Value), FullFileName(dataElem.Cells(1).Value, dataElem.Cells(0).Value), True)
                End If
            ElseIf RadioButton3.Checked Then ' туда - сюда
                If dataElem.Cells(2).Value > dataElem.Cells(3).Value Then
                    IO.File.Copy(FullFileName(dataElem.Cells(1).Value, dataElem.Cells(0).Value), FullFileName(convertFilePathToRemote(dataElem.Cells(1).Value), dataElem.Cells(0).Value), True)
                End If
                If dataElem.Cells(3).Value > dataElem.Cells(2).Value Then
                    IO.File.Copy(FullFileName(convertFilePathToRemote(dataElem.Cells(1).Value), dataElem.Cells(0).Value), FullFileName(dataElem.Cells(1).Value, dataElem.Cells(0).Value), True)
                End If
            End If
        Next
        anal()

        MsgBox("Синхронизация выполнена!", vbOKOnly)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim bool_connection As Boolean = False
        but_sync.Enabled = False
    End Sub

End Class
