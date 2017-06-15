Public Class Form1
    Public xconfig As XDocument
    Dim parentNode As TreeNode
    Dim key As Integer = 1
    Public confFullName As String = "C:\Users\user\Desktop\AlphaTestTrendNalarm\mainTestConfig.xmlcfg"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        xconfig = XDocument.Load(confFullName)
        addToTree(xconfig.Element("Configuration").Element("Signals"))


    End Sub
    Sub addToTree(xe As XElement, Optional parent As TreeNode = Nothing)

        For Each x As XElement In xe.Element("Items").Elements("Item")
            If parent Is Nothing Then
                parentNode = TreeView1.Nodes.Add(key, x.Attribute("Name"))
                key = key + 1
            Else
                parentNode = parent.Nodes.Add(key, x.Attribute("Name"))
                key = key + 1
            End If

            If x.Nodes.Any Then
                addToTree(x, parentNode)
            End If

        Next
    End Sub



    Private Sub TreeView1_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        Label1.Text = TreeView1.SelectedNode.FullPath
    End Sub

    Private Sub Form1_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
        MsgBox("драг")
    End Sub
End Class