Imports System
Imports System.IO
Imports System.Xml

Public Class AlphaCfgForm
    Public xconfig As XDocument

    Public docConfig As XmlDocument = New XmlDocument()
    Public docNewGen As XmlDocument = New XmlDocument()

    Dim rootConfig As XmlNode
    Dim SignalsNode As XmlNode
    Dim rootNewGen As XmlNode

    Dim parentNode As TreeNode
    Dim mainNode As TreeNode

    Dim mainChekedNode As XmlNode
    Dim chekedNode As XmlNode
    Dim tempSearchedNode As XmlNode

    Dim b_selectCfg As Boolean
    Dim b_Tree1Loaded As Boolean
    Dim b_Tree2Loaded As Boolean
    Dim key As Integer = 1
    Dim maxId As Integer

    Dim newIds As Integer

    Public confFullName As String '= "D:\Development\Work\AlphaConfigIDTest\mainTestConfig_id.xmlcfg"
    Public newGen As String '= "D:\Development\Work\AlphaConfigIDTest\AnalogsInCfg ID 1.xmlcfg"
    Public saveFilePath As String



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error GoTo err1

        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.Filter = "xmlcfg (*.xmlcfg)|*.xmlcfg"
        ToolStripStatusLabel1.Text = ""
        Exit Sub
err1:
        MsgBox("Err.Number: " & Err.Number & ". " & Err.Description, vbCritical, "Ошибка")
        Resume Next
    End Sub


    Sub addToTree(xe As XmlNode, Optional tree As TreeView = Nothing, Optional parent As TreeNode = Nothing)

        For Each x As XmlNode In xe.ChildNodes
            If x.Name = "Item" Then
                If parent Is Nothing Then
                    If tree.Nodes.Count < 1 Then
                        If x.ParentNode.ParentNode.Attributes.Count > 0 Then
                            mainNode = tree.Nodes.Add(key, x.ParentNode.ParentNode.Attributes("Name").Value)
                        Else
                            mainNode = tree.Nodes.Add(key, x.ParentNode.ParentNode.Name)
                        End If
                        key = key + 1
                    End If
                    parentNode = mainNode.Nodes.Add(key, x.Attributes("Name").Value) '                    parentNode = tree.Nodes.Add(key, x.Attributes(0).Value)
                    key = key + 1

                    If AttributesExist(x, "Id") Then If maxId < x.Attributes("Id").Value Then maxId = x.Attributes("Id").Value 'ищем максимальный ID
                Else
                    parentNode = parent.Nodes.Add(key, x.Attributes("Name").Value)
                    key = key + 1

                    If AttributesExist(x, "Id") Then If maxId < x.Attributes("Id").Value Then maxId = x.Attributes("Id").Value
                End If
            End If
            If x.HasChildNodes Then
                addToTree(x, tree, parentNode)
            End If

        Next

    End Sub

    Sub analiz(xe As XmlNode, y As XmlNode) ' x - узел из сгенеренного файла, chekedNode - аналогичный узел из конфиги
        Dim tmpCkNode As XmlNode
        tmpCkNode = y
        For Each x As XmlNode In xe.ChildNodes
            If x.Name = "Item" Then
                If y IsNot Nothing Then tmpCkNode = y.SelectSingleNode(".//Item[@Name='" & CStr(x.Attributes("Name").Value) & "']")
                If tmpCkNode Is Nothing Then
                    setNewId(x)
                Else
                    If comparator(x, tmpCkNode) Then
                        'RichTextBox1.AppendText("Атрибуты узла " & x.Attributes("Name").Value & " соотвествуют узлу аналогичному в конфигурации " & vbCrLf)
                    Else
                        'RichTextBox1.AppendText("Атрибуты узла " & x.Attributes("Name").Value & " отличаются от узла аналогичного в конфигурации" & vbCrLf)
                        makeEquals(tmpCkNode, x)
                    End If
                End If

            End If
            If x.HasChildNodes Then
                analiz(x, tmpCkNode)
            End If
        Next
    End Sub

    Sub setNewId(x As XmlNode)
        Dim attr_Id As XmlAttribute
        attr_Id = docNewGen.CreateAttribute("Id") ' создаем атрибут ИД для того что бы вставляь его там где его нет
        If AttributesExist(x, "Id") Then
            x.Attributes("Id").Value = newIds
        Else
            x.Attributes.Append(attr_Id)
            x.Attributes("Id").Value = newIds
        End If
        newIds = newIds + 1
    End Sub

    Function comparator(node1 As XmlNode, node2 As XmlNode) As Boolean
        If node1.Attributes("Name").Value = node2.Attributes("Name").Value Then
            If node1.Attributes("Type").Value = node2.Attributes("Type").Value Then
                If AttributesExist(node1, "Id") And AttributesExist(node2, "Id") Then '
                    If node1.Attributes("Id").Value = node2.Attributes("Id").Value Then
                        comparator = True
                    End If
                End If
            End If
        End If
        If comparator <> True Then comparator = False
    End Function

    Function makeEquals(configNode As XmlNode, newGenNode As XmlNode) As Boolean
        Dim attr_Id As XmlAttribute
        attr_Id = docNewGen.CreateAttribute("Id") ' создаем атрибут ИД для того что бы вставляь его там где его нет
        If AttributesExist(newGenNode, "Id") Then
            newGenNode.Attributes("Id").Value = configNode.Attributes("Id").Value
        Else
            newGenNode.Attributes.Append(attr_Id)
            newGenNode.Attributes("Id").Value = configNode.Attributes("Id").Value
        End If
    End Function

    Function AttributesExist(x As XmlNode, ByVal str As String) As Boolean
        On Error GoTo err2
        Dim tempStr = x.Attributes(str).Value
        AttributesExist = True
        Exit Function
err2:
        AttributesExist = False
    End Function

    Private Sub Form1_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
        MsgBox("драг")
    End Sub


    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        ' analiz()
    End Sub


    Private Sub OpenFileDialog1_FileOk(sender As Object, e As ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        If b_selectCfg Then 'если нажата кнопка загурзки конфигурации
            b_selectCfg = Nothing
            confFullName = OpenFileDialog1.FileName
        ElseIf b_selectCfg = False Then ' если нажата кнопка загрузки сгенеренного файла
            b_selectCfg = Nothing
            newGen = OpenFileDialog1.FileName
        End If
    End Sub


    Private Sub bt_LoadCfg_Click(sender As Object, e As EventArgs) Handles bt_LoadCfg.Click

        b_selectCfg = True
        If OpenFileDialog1.ShowDialog() = DialogResult.Cancel Then Exit Sub
        loadCfg()

    End Sub

    Sub loadCfg()
        On Error GoTo err1
        ToolStripStatusLabel1.Text = "Гружу конфигурацию"

        docConfig.Load(confFullName) 'загружаем хмл файл
        rootConfig = docConfig.DocumentElement ' Выбираем главный узел

        SignalsNode = rootConfig.SelectSingleNode("//Configuration/Signals/Items")

        TreeView1.Nodes.Clear()

        addToTree(SignalsNode, TreeView1) 'добавляем в дерево
        parentNode = Nothing 'обнуление родительского узла

        TreeView1.Nodes(0).Expand() ' раскрываем дерево
        b_Tree1Loaded = True
        lb_maxId.Text = maxId

        newIds = maxId + 1000
        If b_Tree1Loaded And b_Tree2Loaded Then bt_compare.Enabled = True
        ToolStripStatusLabel1.Text = "Конфигурация загружена!"
        Exit Sub
err1:
        MsgBox("Err.Number: " & Err.Number & ". " & Err.Description, vbCritical, "Ошибка")
    End Sub

    Private Sub bt_LoadNewGen_Click(sender As Object, e As EventArgs) Handles bt_LoadNewGen.Click

        b_selectCfg = False
        If OpenFileDialog1.ShowDialog() = DialogResult.Cancel Then Exit Sub
        loadNewCfg()

    End Sub
    Sub loadNewCfg()
        On Error GoTo err1
        ToolStripStatusLabel1.Text = "Гружу сгенеренный файл"

        docNewGen.Load(newGen) 'загружаем хмл файл
        rootNewGen = docNewGen.DocumentElement ' Выбираем главный узел

        TreeView2.Nodes.Clear()

        addToTree(rootNewGen, TreeView2)
        parentNode = Nothing

        TreeView2.Nodes(0).Expand()
        b_Tree2Loaded = True


        ToolStripStatusLabel1.Text = "Сгенеренный файл загружен!"
        If b_Tree1Loaded And b_Tree2Loaded Then bt_compare.Enabled = True
        Exit Sub
err1:
        MsgBox("Err.Number: " & Err.Number & ". " & Err.Description, vbCritical, "Ошибка")
    End Sub

    Private Sub bt_compare_Click(sender As Object, e As EventArgs) Handles bt_compare.Click

        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then Exit Sub

        ToolStripStatusLabel1.Text = "Раздаю ID"

        mainChekedNode = SignalsNode.SelectSingleNode("//Item[@Name='" & CStr(rootNewGen.Attributes("Name").Value) & "']") 'Здесь выбираем узел аналогичный сгенеренному  в конфиге
        'chekedNode = mainChekedNode
        analiz(rootNewGen, mainChekedNode)
        If comparator(rootNewGen, mainChekedNode) = False Then makeEquals(mainChekedNode, rootNewGen)

        docNewGen.Save(saveFilePath)
        ToolStripStatusLabel1.Text = "Файл сохранен с новыми Id!"
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        lb_cfgPath.Text = TreeView1.SelectedNode.FullPath
        Dim tmpNdoe As XmlNode = getNodeByTreePath(TreeView1.SelectedNode.FullPath, rootConfig)

        If AttributesExist(tmpNdoe, "Id") Then
            lb_cfgId.Text = tmpNdoe.Attributes("Id").Value
        Else
            lb_cfgId.Text = "ОТСУТСТВУЕТ"
        End If

    End Sub



    Function getNodeByTreePath(ByVal s As String, mNode As XmlNode) As XmlNode '"FIX\MNS1\AN"
        Dim q()
        q = Split(s, "\")
        tempSearchedNode = mNode
        For k = 1 To q.Length - 1
            tempSearchedNode = tempSearchedNode.SelectSingleNode(".//Items/Item[@Name='" & q(k) & "']")
        Next
        getNodeByTreePath = tempSearchedNode
        tempSearchedNode = Nothing
    End Function

    Function getTreePathByNode(x As XmlNode) As String

    End Function

    Private Sub TreeView2_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView2.AfterSelect
        lb_NewGPath.Text = TreeView2.SelectedNode.FullPath

        Dim tmpNdoe As XmlNode = getNodeByTreePath(TreeView2.SelectedNode.FullPath, rootNewGen)

        If AttributesExist(tmpNdoe, "Id") Then
            lb_NewGId.Text = tmpNdoe.Attributes("Id").Value
        Else
            lb_NewGId.Text = "ОТСУТСТВУЕТ"
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim n As TreeNode
        n = TreeView1.Nodes.Find("3", True)(0)
        MsgBox(n.Text)
    End Sub

    Private Sub SaveFileDialog1_FileOk(sender As Object, e As ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        saveFilePath = SaveFileDialog1.FileName
    End Sub

    Private Sub TreeView1_DragEnter(sender As Object, e As DragEventArgs) Handles TreeView1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub TreeView1_DragDrop(sender As Object, e As DragEventArgs) Handles TreeView1.DragDrop
        confFullName = e.Data.GetData(DataFormats.FileDrop)(0)
        loadCfg()
    End Sub

    Private Sub TreeView2_DragEnter(sender As Object, e As DragEventArgs) Handles TreeView2.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub TreeView2_DragDrop(sender As Object, e As DragEventArgs) Handles TreeView2.DragDrop
        newGen = e.Data.GetData(DataFormats.FileDrop)(0)
        loadNewCfg()
    End Sub
End Class