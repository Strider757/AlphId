Imports System.Net
Imports System.Net.NetworkInformation
Imports System.IO

Public Class MainForm
    Public fileCollect As New ArrayList
    Public xdoc As XDocument
    Public SyncFileName As String = CurDir() & "\Config.xml"
    Public bool_configFileExist As Boolean
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FilesForm.Visible = True
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bool_configFileExist = File.Exists(SyncFileName)
        With DataGridView1
            .Columns.Add("name", "name")
            .Columns.Add("directory", "directory")
            .Columns.Add("local", "local")
            .Columns.Add("remote", "remote")
        End With

        With ComboBox1
            ComboBox1.Items.Add("Туда")
            ComboBox1.Items.Add("Сюда")
            ComboBox1.Items.Add("Туда - Сюда")
            ComboBox1.SelectedIndex = 0
        End With
        TextBox1.Text = "172.16.17.48"

        If bool_configFileExist Then
            xdoc = XDocument.Load(SyncFileName)         'грузим в память хмл
            Call FilesForm.xmlLoad()         'запихиваем список файлов из хмл в колекцию
        Else
            ToolStripStatusLabel1.Text = "Внимание! Конфигурационный файл не найден!"
            ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Red
        End If

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
        Dim bool_connection As Boolean = False
        DataGridView1.Rows.Clear()
        If My.Computer.Network.Ping(TextBox1.Text) Then
            Label2.Text = "ЕСТЬ СВЯЗЬ"
            Label2.ForeColor = System.Drawing.Color.Green
            bool_connection = True
        End If

        For Each fObj In fileCollect
            DataGridView1.Rows.Add()
            DataGridView1.Rows.Item(i).Cells(0).Value = fObj.Name
            DataGridView1.Rows.Item(i).Cells(1).Value = fObj.Location
            DataGridView1.Rows.Item(i).Cells(2).Value = Replace(IO.File.GetLastWriteTime(FullFileName(fObj.location, fObj.name)), "01.01.1601 3:00:00", " ")
            If bool_connection = True Then DataGridView1.Rows.Item(i).Cells(3).Value = Replace(IO.File.GetLastWriteTime(FullFileName(convertFilePathToRemote(fObj.location), fObj.name)), "01.01.1601 3:00:00", " ")

            If DataGridView1.Rows.Item(i).Cells(2).Value > DataGridView1.Rows.Item(i).Cells(3).Value Or bool_connection = False Then
                DataGridView1.Rows.Item(i).Cells(2).Style.ForeColor = System.Drawing.Color.Green
                DataGridView1.Rows.Item(i).Cells(3).Style.ForeColor = System.Drawing.Color.Red
            ElseIf DataGridView1.Rows.Item(i).Cells(2).Value = DataGridView1.Rows.Item(i).Cells(3).Value Then
                DataGridView1.Rows.Item(i).Cells(2).Style.ForeColor = System.Drawing.Color.Black
                DataGridView1.Rows.Item(i).Cells(3).Style.ForeColor = System.Drawing.Color.Black
            Else
                DataGridView1.Rows.Item(i).Cells(3).Style.ForeColor = System.Drawing.Color.Green
                DataGridView1.Rows.Item(i).Cells(2).Style.ForeColor = System.Drawing.Color.Red
            End If
            i = i + 1
        Next


        Exit Sub
err1:
        If Err.Number = 57 Then MsgBox("Кажись удаленный узел не доступен. Err.Number: " & Err.Number & ". " & Err.Description, vbCritical, "Ошибка")
        If Err.Number = 57 And bool_connection = True Then MsgBox("Связь есть, но надо залогинится. Для этого зайди на удаленную машину Err.Number: " & Err.Number & ". " & Err.Description, vbCritical, "Ошибка")
        If Err.Number = 5 Then MsgBox("Кажись кривой айпишник. Err.Number: " & Err.Number & ". " & Err.Description, vbCritical, "Ошибка")
    End Sub

    Private Sub but_Anal_Click(sender As Object, e As EventArgs) Handles but_Anal.Click
        anal()
    End Sub


    Private Sub but_sync_Click(sender As Object, e As EventArgs) Handles but_sync.Click
        For Each dataElem As DataGridViewRow In DataGridView1.Rows 'dataElem.Cells(0).Value
            If ComboBox1.SelectedIndex = 0 Then ' туда
                If dataElem.Cells(2).Value > dataElem.Cells(3).Value Then
                    IO.File.Copy(FullFileName(dataElem.Cells(1).Value, dataElem.Cells(0).Value), FullFileName(convertFilePathToRemote(dataElem.Cells(1).Value), dataElem.Cells(0).Value), True)
                End If
            ElseIf ComboBox1.SelectedIndex = 1 Then ' cюда
                If dataElem.Cells(3).Value > dataElem.Cells(2).Value Then
                    IO.File.Copy(FullFileName(convertFilePathToRemote(dataElem.Cells(1).Value), dataElem.Cells(0).Value), FullFileName(dataElem.Cells(1).Value, dataElem.Cells(0).Value), True)
                End If
            ElseIf ComboBox1.SelectedIndex = 2 Then ' туда - сюда
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



End Class
