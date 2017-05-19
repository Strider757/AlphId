Public Class FilesForm
    Dim SyncFileName As String = "D:\Development\Work\ProjectSync\Config.xml"
    Dim xdoc As XDocument

    Private Sub FilesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim str = "sfsf"
        Dim var

    End Sub

    Private Function xmlLoad() As Boolean 'загружаем хмл со списком файлов. При удачной загрузке возвращает true
        On Error GoTo err1
        Dim i As Integer = 0
        xdoc = XDocument.Load(SyncFileName)
        DataGridView1.Rows.Clear()
        For Each xe As XElement In xdoc.Element("Root").Element("Files").Elements("File")
            DataGridView1.Rows.Add()
            DataGridView1.Rows.Item(i).Cells(0).Value = xe.Attribute("fname").Value
            DataGridView1.Rows.Item(i).Cells(1).Value = xe.Value
            i = i + 1
        Next
        xmlLoad = True
        Exit Function
err1:
        MsgBox("Ошибка номер " & Err.Number & ". " & Err.Description, vbCritical, "Ошибка")
        xmlLoad = False

    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not xmlLoad() Then Me.Close()
    End Sub
End Class