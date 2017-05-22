Public Class FilesForm
    Dim SyncFileName As String = "D:\Development\Work\ProjectSync\Config.xml"
    Dim fileCollect As New ArrayList
    Dim xdoc As XDocument

    Private Sub FilesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        With DataGridView1
            .Columns.Add("name", "name")
            .Columns.Add("location", "location")
        End With

        With OpenFileDialog1
            .Multiselect = True
            .Title = "Окно выбора файлов"
            '.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        End With

        If Not xmlLoad() Then Me.Close()
    End Sub

    '    Private Function xmlLoad() As Boolean 'загружаем хмл со списком файлов. При удачной загрузке возвращает true
    '        On Error GoTo err1
    '        Dim i As Integer = 0
    '        xdoc = XDocument.Load(SyncFileName)
    '        DataGridView1.Rows.Clear()
    '        For Each xe As XElement In xdoc.Element("Root").Element("Files").Elements("File")
    '            DataGridView1.Rows.Add()
    '            DataGridView1.Rows.Item(i).Cells(0).Value = xe.Attribute("fname").Value
    '            DataGridView1.Rows.Item(i).Cells(1).Value = xe.Value
    '            i = i + 1
    '        Next
    '        xmlLoad = True
    '        Exit Function
    'err1:
    '        MsgBox("Ошибка номер " & Err.Number & ". " & Err.Description, vbCritical, "Ошибка")
    '        xmlLoad = False

    '    End Function

    Private Function xmlLoad() As Boolean 'загружаем хмл со списком файлов. При удачной загрузке возвращает true
        On Error GoTo err1
        Dim i As Integer = 0
        xdoc = XDocument.Load(SyncFileName)
        DataGridView1.Rows.Clear()
        For Each xe As XElement In xdoc.Element("Root").Element("Files").Elements("File")
            fileCollect.Add(New FileObj)
            fileCollect.Item(i).Name = xe.Attribute("fname").Value
            fileCollect.Item(i).Location = xe.Value
            i = i + 1
        Next
        xmlLoad = True
        Exit Function
err1:
        MsgBox("Ошибка номер " & Err.Number & ". " & Err.Description, vbCritical, "Ошибка")
        xmlLoad = False

    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        If Not xmlLoad() Then Me.Close()
    End Sub

    Private Sub But_add_Click(sender As Object, e As EventArgs) Handles But_add.Click
        MsgBox(OpenFileDialog1.Filter)
        OpenFileDialog1.ShowDialog()
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DataGridView1.Rows.Clear()
    End Sub

    Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox1.KeyDown
        If e.KeyCode = 13 Then
            ComboBox1.Items.Add(ComboBox1.Text)
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        OpenFileDialog1.Filter = "Filter| " & ComboBox1.Text
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class