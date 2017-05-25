Imports System.IO
Imports System.Text

Public Class FilesForm

    Private Sub FilesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error GoTo err1

        With DataGridView1
            .Columns.Add("name", "name")
            .Columns.Add("location", "location")
            .Columns(0).Width = 130
            .Columns(1).Width = 488
        End With

        With OpenFileDialog1
            .Multiselect = True
            .Title = "Окно выбора файлов"
        End With

        addToCoBox()
        addToGrid()

        Exit Sub
err1:
        MsgBox("Ошибка номер " & Err.Number & ". " & Err.Description, vbCritical, "Ошибка")
    End Sub

    Public Sub addToCoBox()

        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("") 'добавляем пустой фильтр

        For Each xe As XElement In MainForm.xdoc.Element("Root").Element("Filters").Elements("Filter") 'Читаем список фильтров и добавляем его в комбобокс
            ComboBox1.Items.Add(xe.Value)
        Next
        ComboBox1.SelectedIndex = 0

    End Sub

    Public Function xmlLoad() As Boolean 'загружаем хмл со списком файлов. И сохраняем его  При удачной загрузке возвращает true
        On Error GoTo err1
        Dim i As Integer = 0
        MainForm.fileCollect.Clear()

        If MainForm.xdoc.Element("Root").Element("Files") Is Nothing Then
            xmlLoad = False
            Exit Function
        End If

        For Each xe As XElement In MainForm.xdoc.Element("Root").Element("Files").Elements("File")
            MainForm.fileCollect.Add(New FileObj)
            MainForm.fileCollect.Item(i).Name = xe.Attribute("fname").Value
            MainForm.fileCollect.Item(i).Location = xe.Value
            i = i + 1
        Next

        xmlLoad = True

        Exit Function
err1:
        MsgBox("Ошибка номер " & Err.Number & ". " & Err.Description, vbCritical, "Ошибка")
        xmlLoad = False
    End Function

    Sub addToGrid() 'добавляем в табличку
        Dim i As Integer = 0
        DataGridView1.Rows.Clear()

        For Each fObj As FileObj In MainForm.fileCollect
            DataGridView1.Rows.Add()
            DataGridView1.Rows.Item(i).Cells(0).Value = fObj.Name
            DataGridView1.Rows.Item(i).Cells(1).Value = fObj.Location
            i = i + 1
        Next

    End Sub

    Function getfName(ByVal s As String, Optional b As Integer = 0) As String
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

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        If Not xmlLoad() Then Me.Close()
    End Sub

    Private Sub But_add_Click(sender As Object, e As EventArgs) Handles But_add.Click
        OpenFileDialog1.ShowDialog()
        Dim rowsCount = DataGridView1.Rows.Count - 1

        For i = 0 To OpenFileDialog1.FileNames().Length - 1
            DataGridView1.Rows.Add()
            DataGridView1.Rows.Item(rowsCount).Cells(0).Value = getfName(OpenFileDialog1.FileNames(i))
            DataGridView1.Rows.Item(rowsCount).Cells(1).Value = getfName(OpenFileDialog1.FileNames(i), 1)
            rowsCount = rowsCount + 1
        Next

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DataGridView1.Rows.Clear()
    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text <> "" Then
            OpenFileDialog1.Filter = "Filter| " & ComboBox1.Text
        Else
            OpenFileDialog1.Filter = ComboBox1.Text
        End If
    End Sub

    Private Sub but_addFilter_Click(sender As Object, e As EventArgs) Handles but_addFilter.Click
        FiltersForm.Show()
    End Sub

    Private Sub But_save_Click(sender As Object, e As EventArgs) Handles But_save.Click ' сохраняем и еще раз загружаем в коллекцию список файлов

        If Not MainForm.bool_configFileExist Then
            Dim fs As FileStream = File.Create(MainForm.SyncFileName)
            Dim info As Byte() = New UTF8Encoding(True).GetBytes("<?xml version=""1.0"" encoding=""utf-8""?>" & Chr(13) & "<Root>" & Chr(13) & "</Root>")
            fs.Write(info, 0, info.Length)
            fs.Close()
            MainForm.xdoc = XDocument.Load(MainForm.SyncFileName)
        End If

        If Not MainForm.xdoc.Element("Root").Element("Files") Is Nothing Then MainForm.xdoc.Element("Root").Element("Files").Remove()

        Dim xmlTree1 As XElement = _
            <Files>
            </Files>

        For Each dataElem As DataGridViewRow In DataGridView1.Rows
            If dataElem.Cells(0).Value <> "" Then
                xmlTree1.Add(New XElement(<File fname=<%= dataElem.Cells(0).Value %>>
                                              <Location><%= dataElem.Cells(1).Value %></Location>
                                          </File>))
            End If
        Next

        MainForm.xdoc.Element("Root").Add(New XElement(xmlTree1))
        MainForm.xdoc.Save(MainForm.SyncFileName)
        xmlLoad()

        MsgBox("Успешно сохранено!", vbOKOnly)

    End Sub

    'Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
    '    For i = 0 To DataGridView1.SelectedRows.Count - 1
    '        DataGridView1.SelectedRows(i).Cells.RemoveAt(i)
    '        DataGridView1.Rows.RemoveAt()
    '    Next

    'End Sub
End Class