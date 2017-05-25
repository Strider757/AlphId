Public Class FiltersForm
    Private Sub FiltersForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error GoTo err1
        DataGridView1.Columns.Add("name", "Наименование фильтра")
        DataGridView1.Columns(0).Width = 203
        Dim i As Integer = 0
        DataGridView1.Rows.Clear()
        For Each xe As XElement In MainForm.xdoc.Element("Root").Element("Filters").Elements("Filter")
            DataGridView1.Rows.Add()
            DataGridView1.Rows.Item(i).Cells(0).Value = xe.Value
            i = i + 1
        Next
        Exit Sub
err1:
        MsgBox("Ошибка номер " & Err.Number & ". " & Err.Description, vbCritical, "Ошибка")
    End Sub

    Private Sub But_save_Click(sender As Object, e As EventArgs) Handles But_save.Click
        MainForm.xdoc.Element("Root").Element("Filters").Remove()

        Dim xmlTree1 As XElement = _
            <Filters>
            </Filters>

        For Each dataElem As DataGridViewRow In DataGridView1.Rows
            If dataElem.Cells(0).Value <> "" Then
                xmlTree1.Add(New XElement(<Filter>
                                              <%=
                                                  dataElem.Cells(0).Value
                                              %>
                                          </Filter>))
            End If
        Next

        MainForm.xdoc.Element("Root").Add(New XElement(xmlTree1))
        MainForm.xdoc.Save(MainForm.SyncFileName)
        Call FilesForm.addToCoBox()
        'Dim xe As XElement = xdoc.Element("Root").Element("Filters")
        MsgBox("Список фильтров сохранён!", vbOKOnly, "Фильтры")
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DataGridView1.Rows.RemoveAt(DataGridView1.CurrentCell.RowIndex)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DataGridView1.Rows.Clear()
    End Sub
End Class