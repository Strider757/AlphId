Imports System.Net
Imports System.Net.NetworkInformation
Imports System.IO
Imports System.Text

Public Class MainForm
    Public fileCollect As New ArrayList
    Public xdoc As XDocument
    Public SyncFileName As String = CurDir() & "\Config.xml"
    Public bool_configFileExist As Boolean
    Dim bool_connection As Boolean = False
    Public xElem_IP As XElement
    Public xElem_SynType As XElement
    Dim prjName As String = "OSA"
    Dim prjDir As String = "C:\Dynamics\"
    Dim wweDir As String
    Dim opergenDir As String
    Dim excelName As String

    Dim sr As StreamReader

    Dim cn_chk As Integer = 0
    Dim cn_nm As Integer = 1
    Dim cn_loc As Integer = 2
    Dim cn_rem As Integer = 3
    Dim cn_der As Integer = 4

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SyncSetForm.Visible = True
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bool_configFileExist = File.Exists(SyncFileName)
        ToolStripStatusLabel1.Text = " "
        Dim chk As New DataGridViewCheckBoxColumn()

        With DataGridView1
            .Columns.Add(chk)
            .Columns.Add("name", "Имя")
            .Columns.Add("local", "Местный")
            .Columns.Add("remote", "Удалённый")
            .Columns.Add("directory", "Расположение")
            .Columns(0).Width = 21
            .Columns(0).ReadOnly = False
            .Columns(1).Width = 150
            .Columns(1).ReadOnly = True
            .Columns(2).Width = 110
            .Columns(2).ReadOnly = True
            .Columns(3).Width = 110
            .Columns(3).ReadOnly = True
            .Columns(4).Width = 300
            .Columns(4).ReadOnly = True
        End With

        RadioButton1.Checked = True
        ToolStripProgressBar1.Visible = False
        If bool_configFileExist Then
            xdoc = XDocument.Load(SyncFileName)         'грузим в память хмл
            Call SyncSetForm.xmlLoad()         'запихиваем список файлов из хмл в колекцию
            xElem_IP = xdoc.Element("Root").Element("Settings").Element("IP")
            xElem_SynType = xdoc.Element("Root").Element("Settings").Element("TypeSync")
        Else
            ToolStripStatusLabel1.Text = "Внимание! Конфигурационный файл не найден!"
            ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Red
        End If
        TextBox1.Text = xElem_IP.Value
        findePO()
        excelSearch()

    End Sub
    Public Function FullFileName(ByVal path As String, ByVal name As String) As String
        FullFileName = path & "\" & name
    End Function

    Public Function convertFilePathToRemote(ByVal path As String) As String
        '\\172.16.18.161\d$\Development\Work\ProjectSync\TestFiles\path 1
        'd:\Development\Work\ProjectSync\TestFiles\path 1
        convertFilePathToRemote = "\\" & TextBox1.Text & "\" & Replace(path, ":", "$")
    End Function
    Sub findePO()
        Dim q() As String
        Dim wweDate As String = "01.01.1601 3:00:00"
        Dim opergenDate As String = "01.01.1601 3:00:00"
        For Each d In Directory.EnumerateDirectories(prjDir & prjName & "\APL", "*.*", SearchOption.TopDirectoryOnly)
            q = Split(d, "\")
            If q(q.Length - 1) Like "work with excel*" Then
                If IO.Directory.GetLastWriteTime(d) > wweDate Then
                    wweDate = IO.Directory.GetLastWriteTime(d)
                    wweDir = d
                End If
            End If
            If q(q.Length - 1) Like "Opergen*" Then
                If IO.Directory.GetLastWriteTime(d) > wweDate Then
                    opergenDate = IO.Directory.GetLastWriteTime(d)
                    opergenDir = d
                End If
            End If
        Next
    End Sub
    Sub excelSearch()
        Dim s As String
        Dim q() As String
        Dim h() As String
        s = IO.File.ReadAllText(wweDir & "\param.ini", System.Text.Encoding.GetEncoding(1251))
        q = Split(s, vbCrLf)
        For k = 0 To q.Length - 1
            If q(k) = "[XLSName]" Then
                h = Split(q(k + 1), Chr(34))
                excelName = h(1)
            End If
        Next
        lb_excelName.Text = excelName
        lb_excelDate.Text = IO.File.GetLastWriteTime(prjDir & prjName & "\" & excelName)
    End Sub
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
            DataGridView1.Rows.Item(i).Cells(cn_nm).Value = fObj.Name
            DataGridView1.Rows.Item(i).Cells(cn_der).Value = fObj.Location
            DataGridView1.Rows.Item(i).Cells(cn_loc).Value = Replace(IO.File.GetLastWriteTime(FullFileName(fObj.location, fObj.name)), "01.01.1601 3:00:00", " ")
            If bool_connection = True Then DataGridView1.Rows.Item(i).Cells(cn_rem).Value = Replace(IO.File.GetLastWriteTime(FullFileName(convertFilePathToRemote(fObj.location), fObj.name)), "01.01.1601 3:00:00", " ")

            If DataGridView1.Rows.Item(i).Cells(cn_loc).Value > DataGridView1.Rows.Item(i).Cells(cn_rem).Value Or bool_connection = False Then 'если новый файл на локальном компе
                DataGridView1.Rows.Item(i).Cells(cn_loc).Style.ForeColor = System.Drawing.Color.Green
                DataGridView1.Rows.Item(i).Cells(cn_rem).Style.ForeColor = System.Drawing.Color.Red
            ElseIf DataGridView1.Rows.Item(i).Cells(cn_loc).Value = DataGridView1.Rows.Item(i).Cells(cn_rem).Value Then 'если новый файлы одинаковые
                DataGridView1.Rows.Item(i).Cells(cn_loc).Style.ForeColor = System.Drawing.Color.Black
                DataGridView1.Rows.Item(i).Cells(cn_loc).Style.ForeColor = System.Drawing.Color.Black
            Else 'если новый файл на удаленном компе
                DataGridView1.Rows.Item(i).Cells(cn_rem).Style.ForeColor = System.Drawing.Color.Green
                DataGridView1.Rows.Item(i).Cells(cn_loc).Style.ForeColor = System.Drawing.Color.Red
            End If
            DataGridView1.Rows.Item(i).Cells(cn_chk).Value = True
            i = i + 1
        Next

        If TextBox1.Text <> xElem_IP.Value Then ' перезаписываем ip
            xElem_IP.Value = TextBox1.Text
            xdoc.Save(SyncFileName)
        End If

        Exit Sub
err1:
        If Err.Number = 5 Then
            MsgBox("Err.Number: " & Err.Number & ". " & Err.Description, vbCritical, "Ошибка")
            bool_connection = False
            ToolStripStatusLabel1.Text = "Нет доступа"
            Resume Next
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
        Dim err_check As Boolean = False
        On Error GoTo err1
        If MsgBox("Выполнить синхронизацию?", vbOKCancel Or vbQuestion, "Вопрос") = MsgBoxResult.Cancel Then Exit Sub
        ToolStripProgressBar1.Maximum = DataGridView1.Rows.Count
        ToolStripProgressBar1.Visible = True
        For Each dataElem As DataGridViewRow In DataGridView1.Rows 'dataElem.Cells(0).Value

            If RadioButton1.Checked And dataElem.Cells(cn_chk).Value = True Then ' туда
                If dataElem.Cells(cn_loc).Value > dataElem.Cells(cn_rem).Value Then
                    IO.File.Copy(FullFileName(dataElem.Cells(cn_der).Value, dataElem.Cells(cn_nm).Value), FullFileName(convertFilePathToRemote(dataElem.Cells(cn_der).Value), dataElem.Cells(cn_nm).Value), True)
                End If
            ElseIf RadioButton2.Checked And dataElem.Cells(cn_chk).Value = True Then ' cюда
                If dataElem.Cells(cn_rem).Value > dataElem.Cells(cn_loc).Value Then
                    IO.File.Copy(FullFileName(convertFilePathToRemote(dataElem.Cells(cn_der).Value), dataElem.Cells(cn_nm).Value), FullFileName(dataElem.Cells(cn_der).Value, dataElem.Cells(cn_nm).Value), True)
                End If
            ElseIf RadioButton3.Checked And dataElem.Cells(cn_chk).Value = True Then ' туда - сюда
                If dataElem.Cells(cn_loc).Value > dataElem.Cells(cn_rem).Value Then
                    IO.File.Copy(FullFileName(dataElem.Cells(cn_der).Value, dataElem.Cells(cn_nm).Value), FullFileName(convertFilePathToRemote(dataElem.Cells(cn_der).Value), dataElem.Cells(cn_nm).Value), True)
                End If
                If dataElem.Cells(cn_rem).Value > dataElem.Cells(cn_loc).Value Then
                    IO.File.Copy(FullFileName(convertFilePathToRemote(dataElem.Cells(cn_der).Value), dataElem.Cells(cn_nm).Value), FullFileName(dataElem.Cells(cn_der).Value, dataElem.Cells(cn_nm).Value), True)
                End If
            End If
            ToolStripProgressBar1.Value = ToolStripProgressBar1.Value + 1
        Next
        anal()

        MsgBox("Синхронизация выполнена!", vbOKOnly)
        ToolStripProgressBar1.Visible = False
        ToolStripProgressBar1.Value = 0
        ToolStripProgressBar1.Maximum = 0
err1:
        If Err.Number = 76 And err_check = False Then
            MsgBox("Err.Number: " & Err.Number & ". " & Err.Description, vbCritical, "Ошибка")
            err_check = True
            ToolStripStatusLabel1.Text = "Не удалось найти часть пути"
        End If
        Resume Next

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim bool_connection As Boolean = False
        but_sync.Enabled = False
    End Sub

    Private Sub But_selAll_Click(sender As Object, e As EventArgs) Handles But_selAll.Click
        For Each dataElem As DataGridViewRow In DataGridView1.Rows
            dataElem.Cells(cn_chk).Value = True
        Next
    End Sub

    Private Sub But_UnSel_Click(sender As Object, e As EventArgs) Handles But_UnSel.Click
        For Each dataElem As DataGridViewRow In DataGridView1.Rows
            dataElem.Cells(cn_chk).Value = False
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Shell(wweDir & "\Excel_Export.exe", AppWinStyle.NormalFocus)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Shell(opergenDir & "\opergen.exe", AppWinStyle.NormalFocus)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox(prjDir & prjName & "\" & excelName)
        Shell(prjDir & prjName & "\" & excelName)
    End Sub
End Class
