Imports System.Net
Imports System.Net.NetworkInformation
Imports System.IO
Imports System.Text
Imports System.Xml

Public Class MainForm
    Public fileCollect As New ArrayList ' коллекция в которую запихиваются объекты с информацией о синхронизируемом файле при чтении конфигурации (не знаю зачем так сделал, можно обойтись без этого)
    Public catCollect As New Collection ' список синхронизируемых каталогов
    Public xdoc As XDocument ' переменная для хранения конфигурационного файла
    Public SyncFileName As String = CurDir() & "\Config.xml" ' расположение и имя конфигурационного файла
    Public bool_configFileExist As Boolean ' наличие конфигурационного файла
    Dim bool_connection As Boolean = False ' наличие связи и доступа к удалённым файлам

    Public xElem_IP As XElement 'IP адресс. обращатся xElem_IP.Value
    Public xElem_SynType As XElement 'Тип синхронизации По файлам или по Каталогам
    Public xElem_prjDirSet As XElement 'как будт вычислятся папка проекта. Автоматически из распложения файла или вручную
    Public xElem_prjDir As XElement 'Папка проекта в виде ХМЛ элемента

    Public prjDir As String 'строка с папкой проекта
    Dim prjName As String ' имя проекта

    Dim wweDir As String 'Путь workWithExcel 
    Dim opergenDir As String 'Путь opergen
    Dim excelName As String ' Имя и путь Excel

    Dim cn_chk As Integer = 0 'Номер столбца с чекбоксом
    Dim cn_nm As Integer = 1 'Номер столбца с именем файла
    Dim cn_loc As Integer = 2 'Номер столбца с датой местного файла
    Dim cn_rem As Integer = 3 'Номер столбца с датой удалённого файла
    Dim cn_der As Integer = 4 'Номер столбца с папкой файла

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SyncSetForm.Visible = True
    End Sub

    'грузим форму
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ToolStripStatusLabel1.Text = " "
        Dim chk As New DataGridViewCheckBoxColumn()

        ' задаём свойства 
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

        ' проверяем наличие конфиг файла
        initConfig()

    End Sub

    Sub initConfig()
        'проверка на наличие конфигурационного файла config.xml 
        bool_configFileExist = File.Exists(SyncFileName)
        If bool_configFileExist Then
            xdoc = XDocument.Load(SyncFileName)         'грузим в память хмл
            Call SyncSetForm.xmlLoad()         'запихиваем список файлов из хмл в колекцию
            xElem_IP = xdoc.Element("Root").Element("Settings").Element("IP")
            xElem_SynType = xdoc.Element("Root").Element("Settings").Element("TypeSync")
            xElem_prjDirSet = xdoc.Element("Root").Element("Settings").Element("prjDirSet")

            TextBox1.Text = xElem_IP.Value
            defineDir()
            'If findePO() = True Then excelSearch()
        Else
            ToolStripStatusLabel1.Text = "Внимание! Конфигурационный файл не найден!"
            ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Red
        End If
    End Sub

    'поиск папки проекта
    Sub defineDir()
        tbManualDir.Text = xdoc.Element("Root").Element("Settings").Element("prjDir").Value
        'авто режим (из расположения самой программы) ПОКА НЕ ДОДЕЛАН
        If xElem_prjDirSet.Value = "Auto" Then
            tbManualDir.Enabled = False
            rbAutoDir.Checked = True
            'Ручной (ПОКА ЧТО ТОЛЬКО БЕРЕТ ИЗ КОНФИГА)
        ElseIf xElem_prjDirSet.Value = "Manual" Then
            rbManualDir.Checked = True
            prjDir = xdoc.Element("Root").Element("Settings").Element("prjDir").Value ' хранится пока в виде строки
            xElem_prjDir = xdoc.Element("Root").Element("Settings").Element("prjDir") ' потом надо переделать везде что бы обращалось к ХМЛелементу
        End If
    End Sub

    Public Function FullFileName(ByVal path As String, ByVal name As String) As String
        FullFileName = path & "\" & name
    End Function

    Public Function convertFilePathToRemote(ByVal path As String) As String
        convertFilePathToRemote = "\\" & TextBox1.Text & "\" & Replace(path, ":", "$")
    End Function

    '    'ищем вспогоательное ПО
    '    Function findePO() As Boolean
    '        On Error GoTo err1
    '        findePO = False
    '        Dim q() As String
    '        Dim wweDate As String = "01.01.1601 3:00:00"
    '        Dim opergenDate As String = "01.01.1601 3:00:00"
    '        For Each d In Directory.EnumerateDirectories(prjDir & "\APL", "*.*", SearchOption.TopDirectoryOnly)
    '            q = Split(d, "\")
    '            If q(q.Length - 1) Like "work with excel*" Then
    '                If IO.Directory.GetLastWriteTime(d) > wweDate Then
    '                    wweDate = IO.Directory.GetLastWriteTime(d)
    '                    wweDir = d
    '                End If
    '            End If
    '            If q(q.Length - 1) Like "Opergen*" Then
    '                If IO.Directory.GetLastWriteTime(d) > opergenDate Then
    '                    opergenDate = IO.Directory.GetLastWriteTime(d)
    '                    opergenDir = d
    '                End If
    '            End If
    '        Next
    '        findePO = True
    '        Exit Function
    'err1:
    '        Button3.Enabled = False
    '        Button4.Enabled = False
    '        ToolStripStatusLabel1.Text = "Внимание! Вспомогательное ПО не найдено"
    '        ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Black
    '    End Function

    'ищем послденюю по дате эксельку
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
        lb_excelDate.Text = IO.File.GetLastWriteTime(prjDir & "\" & excelName)
    End Sub

    'сравнение дат изменения файлов
    '1 - если первый файл старше
    '2 - если второй файл старше
    '0 - если два файла одинаковые или нет доступа

    Function compareIzmDate(ByVal strFile1 As String, ByVal strFile2 As String) As Integer
        Dim f1_d As New DateTime
        Dim f2_d As New DateTime

        If strFile1 <> "" And strFile1 <> " " Then f1_d = CDate(strFile1)
        If strFile2 <> "" And strFile2 <> " " Then f2_d = CDate(strFile2)

        If f1_d > f2_d And (strFile1 <> "" And strFile2 <> "") Then
            compareIzmDate = 1
        ElseIf f2_d > f1_d And (strFile1 <> "" And strFile2 <> "") Then
            compareIzmDate = 2
        Else
            compareIzmDate = 0
        End If

    End Function

    Sub anal()
        On Error GoTo err1
        Dim i = 0
        Dim k = 0
        Dim ki = 0
        Dim strstr As String
        Dim Folder As Directory
        Dim Files() As String
        DataGridView1.Rows.Clear()
        If My.Computer.Network.Ping(TextBox1.Text) Then
            TextBox1.BackColor = System.Drawing.Color.Green
            bool_connection = True
        Else
            TextBox1.BackColor = System.Drawing.Color.Red
            ToolStripStatusLabel1.Text = "Нет связи"
        End If

        'If xElem_SynType.Value = "Files" Then
        For Each fObj In fileCollect
                DataGridView1.Rows.Add()
                DataGridView1.Rows.Item(i).Cells(cn_nm).Value = fObj.Name
                DataGridView1.Rows.Item(i).Cells(cn_der).Value = fObj.Location
                DataGridView1.Rows.Item(i).Cells(cn_loc).Value = Replace(IO.File.GetLastWriteTime(FullFileName(fObj.location, fObj.name)), "01.01.1601 3:00:00", " ")

                If bool_connection = True Then DataGridView1.Rows.Item(i).Cells(cn_rem).Value = Replace(IO.File.GetLastWriteTime(FullFileName(convertFilePathToRemote(fObj.location), fObj.name)), "01.01.1601 3:00:00", " ")

                If compareIzmDate(DataGridView1.Rows.Item(i).Cells(cn_loc).Value, DataGridView1.Rows.Item(i).Cells(cn_rem).Value) = 1 Then 'если новый файл на локальном компе
                    DataGridView1.Rows.Item(i).Cells(cn_loc).Style.ForeColor = System.Drawing.Color.Green
                    DataGridView1.Rows.Item(i).Cells(cn_rem).Style.ForeColor = System.Drawing.Color.Red
                ElseIf compareIzmDate(DataGridView1.Rows.Item(i).Cells(cn_loc).Value, DataGridView1.Rows.Item(i).Cells(cn_rem).Value) = 0 Or bool_connection = False Then 'если файлы одинаковые
                    DataGridView1.Rows.Item(i).Cells(cn_loc).Style.ForeColor = System.Drawing.Color.Black
                    DataGridView1.Rows.Item(i).Cells(cn_loc).Style.ForeColor = System.Drawing.Color.Black
                Else 'если новый файл на удаленном компе
                    DataGridView1.Rows.Item(i).Cells(cn_rem).Style.ForeColor = System.Drawing.Color.Green
                    DataGridView1.Rows.Item(i).Cells(cn_loc).Style.ForeColor = System.Drawing.Color.Red
                End If

                DataGridView1.Rows.Item(i).Cells(cn_chk).Value = True
                i = i + 1
            Next
        'Else
        k = i 'потому что это теперь общий стчетчик, но мне лень переделывать
        For Each xer As XElement In xdoc.Element("Root").Elements("Sync").Elements("Catalog")
            Files = IO.Directory.GetFiles(xer.Value)
            For ki = 0 To Files.Length - 1
                If xer.Attribute("allFiles").Value = True Then
                    DataGridView1.Rows.Add()
                    DataGridView1.Rows.Item(k).Cells(cn_nm).Value = SyncSetForm.getfName(Files(ki), 0)
                    DataGridView1.Rows.Item(k).Cells(cn_der).Value = xer.Value
                    DataGridView1.Rows.Item(k).Cells(cn_loc).Value = Replace(IO.File.GetLastWriteTime(Files(ki)), "01.01.1601 3:00:00", " ")
                    If bool_connection = True Then DataGridView1.Rows.Item(k).Cells(cn_rem).Value = Replace(IO.File.GetLastWriteTime(convertFilePathToRemote(Files(ki))), "01.01.1601 3:00:00", " ")

                    If compareIzmDate(DataGridView1.Rows.Item(k).Cells(cn_loc).Value, DataGridView1.Rows.Item(k).Cells(cn_rem).Value) = 1 Then 'если новый файл на локальном компе
                        DataGridView1.Rows.Item(k).Cells(cn_loc).Style.ForeColor = System.Drawing.Color.Green
                        DataGridView1.Rows.Item(k).Cells(cn_rem).Style.ForeColor = System.Drawing.Color.Red
                    ElseIf compareIzmDate(DataGridView1.Rows.Item(k).Cells(cn_loc).Value, DataGridView1.Rows.Item(k).Cells(cn_rem).Value) = 0 Or bool_connection = False Then 'если файлы одинаковые
                        DataGridView1.Rows.Item(k).Cells(cn_loc).Style.ForeColor = System.Drawing.Color.Black
                        DataGridView1.Rows.Item(k).Cells(cn_loc).Style.ForeColor = System.Drawing.Color.Black
                    Else 'если новый файл на удаленном компе
                        DataGridView1.Rows.Item(k).Cells(cn_rem).Style.ForeColor = System.Drawing.Color.Green
                        DataGridView1.Rows.Item(k).Cells(cn_loc).Style.ForeColor = System.Drawing.Color.Red
                    End If
                    DataGridView1.Rows.Item(k).Cells(cn_chk).Value = True
                    k = k + 1
                ElseIf xer.Attribute("allFiles").Value = False And checkFileRash(getfName(Files(ki), 0)) = True Then
                    DataGridView1.Rows.Add()
                    DataGridView1.Rows.Item(k).Cells(cn_nm).Value = SyncSetForm.getfName(Files(ki), 0)
                    DataGridView1.Rows.Item(k).Cells(cn_der).Value = xer.Value
                    DataGridView1.Rows.Item(k).Cells(cn_loc).Value = Replace(IO.File.GetLastWriteTime(Files(ki)), "01.01.1601 3:00:00", " ")
                    If bool_connection = True Then DataGridView1.Rows.Item(k).Cells(cn_rem).Value = Replace(IO.File.GetLastWriteTime(convertFilePathToRemote(Files(ki))), "01.01.1601 3:00:00", " ")

                    If compareIzmDate(DataGridView1.Rows.Item(k).Cells(cn_loc).Value, DataGridView1.Rows.Item(k).Cells(cn_rem).Value) = 1 Then 'если новый файл на локальном компе
                        DataGridView1.Rows.Item(k).Cells(cn_loc).Style.ForeColor = System.Drawing.Color.Green
                        DataGridView1.Rows.Item(k).Cells(cn_rem).Style.ForeColor = System.Drawing.Color.Red
                    ElseIf compareIzmDate(DataGridView1.Rows.Item(k).Cells(cn_loc).Value, DataGridView1.Rows.Item(k).Cells(cn_rem).Value) = 0 Or bool_connection = False Then 'если файлы одинаковые
                        DataGridView1.Rows.Item(k).Cells(cn_loc).Style.ForeColor = System.Drawing.Color.Black
                        DataGridView1.Rows.Item(k).Cells(cn_loc).Style.ForeColor = System.Drawing.Color.Black
                    Else 'если новый файл на удаленном компе
                        DataGridView1.Rows.Item(k).Cells(cn_rem).Style.ForeColor = System.Drawing.Color.Green
                        DataGridView1.Rows.Item(k).Cells(cn_loc).Style.ForeColor = System.Drawing.Color.Red
                    End If
                    DataGridView1.Rows.Item(k).Cells(cn_chk).Value = True
                    k = k + 1
                End If
            Next
        Next
        'End If
        If TextBox1.Text <> xElem_IP.Value Then ' перезаписываем ip
            xElem_IP.Value = TextBox1.Text
            xdoc.Save(SyncFileName)
        End If

        Exit Sub
err1:
        If Err.Number = 5 Then
            MsgBox(k & " Err.Number: " & Err.Number & ". " & Err.Description, vbCritical, "Ошибка")
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
        ElseIf Err.Number = 13 Then
            MsgBox("Err.Number: " & Err.Number & ". " & Err.Description, vbCritical, "Ошибка")
            Resume Next
        ElseIf Err.Number = 57 And bool_connection = False Then
        ElseIf Err.Number = 91 Then 'непонятная ошибка надо разобраться
            Resume Next
        Else
            MsgBox("Err.Number: " & Err.Number & ". " & Err.Description, vbCritical, "Ошибка")
        End If
    End Sub


    Public Function getfName(ByVal s As String, Optional b As Integer = 0) As String 'получаем имя файла
        Dim q()
        q = Split(s, "\")

        If b = 0 Then
            getfName = q(q.Length - 1)
        Else
            For i = 0 To q.Length - 2
                getfName = getfName & q(i) & "\"
            Next
        End If
        getfName = Trim(getfName)
    End Function



    Function checkFileRash(ByVal s As String) As Boolean 'проверяем расширение файла на соотвествие списку фильтров
        Dim q() As String
        Dim fr As String
        q = Split(s, ".")
        fr = q(1)
        For Each xe As XElement In xdoc.Element("Root").Element("Filters").Elements("Filter")
            If "*." & fr = xe.Value Then checkFileRash = True
        Next
    End Function

    Function getFileRash(ByVal s As String) As String 'получаем расширение файла
        Dim q() As String
        q = Split(s, ".")
        getFileRash = q(1)
    End Function

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
                If compareIzmDate(dataElem.Cells(cn_loc).Value, dataElem.Cells(cn_rem).Value) = 1 Then
                    IO.File.Copy(FullFileName(dataElem.Cells(cn_der).Value, dataElem.Cells(cn_nm).Value), FullFileName(convertFilePathToRemote(dataElem.Cells(cn_der).Value), dataElem.Cells(cn_nm).Value), True)
                End If
            ElseIf RadioButton2.Checked And dataElem.Cells(cn_chk).Value = True Then ' cюда
                If compareIzmDate(dataElem.Cells(cn_loc).Value, dataElem.Cells(cn_rem).Value) = 2 Then
                    IO.File.Copy(FullFileName(convertFilePathToRemote(dataElem.Cells(cn_der).Value), dataElem.Cells(cn_nm).Value), FullFileName(dataElem.Cells(cn_der).Value, dataElem.Cells(cn_nm).Value), True)
                End If
            ElseIf RadioButton3.Checked And dataElem.Cells(cn_chk).Value = True Then ' туда - сюда
                If compareIzmDate(dataElem.Cells(cn_loc).Value, dataElem.Cells(cn_rem).Value) = 1 Then
                    IO.File.Copy(FullFileName(dataElem.Cells(cn_der).Value, dataElem.Cells(cn_nm).Value), FullFileName(convertFilePathToRemote(dataElem.Cells(cn_der).Value), dataElem.Cells(cn_nm).Value), True)
                End If
                If compareIzmDate(dataElem.Cells(cn_loc).Value, dataElem.Cells(cn_rem).Value) = 2 Then
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
        Shell(prjDir & "\" & excelName, AppWinStyle.NormalFocus)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        AlphaCfgForm.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Shell(prjDir & "\DB\Object.mdb", AppWinStyle.NormalFocus) ' че то не работает
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If tbManualDir.Text <> xElem_prjDir.Value Then ' перезаписываем папку
            xElem_prjDir.Value = tbManualDir.Text
            xdoc.Save(SyncFileName)
        End If
        Process.Start(prjDir)
    End Sub



    Private Sub tbManualDir_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbManualDir.KeyPress
        ' запилить возможность сохранения по нажатию ЭНТЭР
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)
        Process.Start(convertFilePathToRemote(prjDir))
    End Sub
End Class
