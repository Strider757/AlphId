﻿Public Class FiltersForm

    Dim fltStr As String

    Private Sub FiltersForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error GoTo err1
        DataGridView1.Columns.Add("name", "Наименование фильтра")
        DataGridView1.Columns(0).Width = 203
        Dim i As Integer = 0
        DataGridView1.Rows.Clear()
        OpenFileDialog1.Multiselect = False
        For Each xe As XElement In xdoc.Element("Root").Element("Filters").Elements("Filter")
            DataGridView1.Rows.Add()
            DataGridView1.Rows.Item(i).Cells(0).Value = xe.Value
            i = i + 1
        Next
        Exit Sub
err1:
        MsgBox("Ошибка номер " & Err.Number & ". " & Err.Description, vbCritical, "Ошибка")
    End Sub


    Private Sub But_save_Click(sender As Object, e As EventArgs) Handles But_save.Click
        xdoc.Element("Root").Element("Filters").Remove()

        Dim xmlTree1 As XElement =
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

        xdoc.Element("Root").Add(New XElement(xmlTree1))
        xdoc.Save(SyncFileName)
        Call SyncSetForm.addToCoBox()
        'Dim xe As XElement = xdoc.Element("Root").Element("Filters")
        MsgBox("Список фильтров сохранён!", vbOKOnly, "Фильтры")
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DataGridView1.Rows.RemoveAt(DataGridView1.CurrentCell.RowIndex)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DataGridView1.Rows.Clear()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim q()
        If OpenFileDialog1.ShowDialog() = DialogResult.Cancel Then Exit Sub

        q = Split(OpenFileDialog1.FileName, ".")
        fltStr = "*." & q(q.Length - 1)
        DataGridView1.Rows.Add(fltStr)
        'OpenFileDialog1.FileName
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        fltStr = OpenFileDialog1.FileName
    End Sub
End Class