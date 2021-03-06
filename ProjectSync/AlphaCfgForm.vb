﻿Imports System
Imports System.IO
Imports System.Xml

Public Class AlphaCfgForm


    '=================Переменные для альфа конфиги===================

    Public docConfig As XmlDocument = New XmlDocument() 'Альфа конфига
    Public docNewGen As XmlDocument = New XmlDocument() 'Сгенерёнынй ХМЛ файл из workwithexel

    Dim rootConfig As XmlNode
    Dim SignalsNode As XmlNode
    Dim rootNewGen As XmlNode

    Dim parentNode As TreeNode
    Dim mainNode As TreeNode

    Dim mainChekedNode As XmlNode
    Dim chekedNode As XmlNode
    Dim tempSearchedNode As XmlNode

    Dim bool_selectCfg As Boolean
    Dim bool_Tree1Loaded As Boolean
    Dim bool_Tree2Loaded As Boolean
    Dim key As Integer = 1
    Dim maxId As Integer

    Dim bool_FormLoaded As Boolean

    Dim newIds As Integer
    Dim tempWth As Integer

    Dim formWidth As Integer

    Public confFullName As String '= "D:\Development\Work\AlphaConfigIDTest\mainTestConfig_id.xmlcfg"
    Public newGen As String '= "D:\Development\Work\AlphaConfigIDTest\AnalogsInCfg ID 1.xmlcfg"
    Public saveFilePath As String

    '=================Переменные для альфа конфиги===================





    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initAlpohaID() 'инициализация
    End Sub

    Sub initAlpohaID() 'инициализация
        On Error GoTo err1

        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.Filter = "xmlcfg (*.xmlcfg)|*.xmlcfg"
        SaveFileDialog1.DefaultExt = "xmlcfg"
        SaveFileDialog1.Filter = "xmlcfg (*.xmlcfg)|*.xmlcfg"

        formWidth = Me.Size.Width

        bt_saveID.Enabled = False
        Me.MinimumSize = New Size(Me.Size.Width, Me.Size.Height)

        bool_FormLoaded = True
        Exit Sub

err1:
        MsgBox("Err.Number: " & Err.Number & ". " & Err.Description, vbCritical, "Ошибка")
        Resume Next
    End Sub


    Sub addToTree(xe As XmlNode, Optional tree As TreeView = Nothing, Optional parent As TreeNode = Nothing) 'Рекурсивная процедура добавления xml узла в дерево. xe-добавляемый узел, tree-treeView  в который добавлем, parent - предок узла(если есть)
        For Each x As XmlNode In xe.ChildNodes ' и так. 
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
                    parentNode = mainNode.Nodes.Add(key, x.Attributes("Name").Value) '                    
                    key = key + 1
                    If AttributesExist(x, "Id") And tree.Name = "TreeView1" Then If maxId < x.Attributes("Id").Value Then maxId = x.Attributes("Id").Value 'ищем максимальный ID и смотрим что бы он искался только в конфигурации, то есть в левом окошке
                Else
                    parentNode = parent.Nodes.Add(key, x.Attributes("Name").Value)
                    key = key + 1
                    If AttributesExist(x, "Id") And tree.Name = "TreeView1" Then If maxId < x.Attributes("Id").Value Then maxId = x.Attributes("Id").Value
                End If
            End If
            If x.HasChildNodes Then
                addToTree(x, tree, parentNode)
            End If
        Next
    End Sub

    Sub analiz(xe As XmlNode, y As XmlNode) ' x - узел из сгенеренного файла, y - аналогичный узел из конфиги
        Dim tmpCkNode As XmlNode
        tmpCkNode = y
        For Each x As XmlNode In xe.ChildNodes
            If x.Name = "Item" Then
                'If y IsNot Nothing Then tmpCkNode = y.SelectSingleNode(".//Item[@Name='" & CStr(x.Attributes("Name").Value) & "']")
                If y IsNot Nothing Then tmpCkNode = y.SelectSingleNode("Items/Item[@Name='" & CStr(x.Attributes("Name").Value) & "']")
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

    Function AttributesExist(x As XmlNode, ByVal str As String) As Boolean ' проверка на наличие атрибута
        On Error GoTo err2
        If x.Attributes.Count < 1 Then GoTo err2
        For Each at In x.Attributes
            If at.name = str Then AttributesExist = True
        Next
        If AttributesExist <> True Then AttributesExist = False
        Exit Function
err2:
        AttributesExist = False
    End Function

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        If bool_selectCfg Then 'если нажата кнопка загурзки конфигурации
            bool_selectCfg = Nothing
            confFullName = OpenFileDialog1.FileName
        ElseIf bool_selectCfg = False Then ' если нажата кнопка загрузки сгенеренного файла
            bool_selectCfg = Nothing
            newGen = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub SaveFileDialog1_FileOk(sender As Object, e As ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        saveFilePath = SaveFileDialog1.FileName
    End Sub

    Sub loadCfg() 'тута грузим конфигу альфы
        On Error GoTo err1

        docConfig.Load(confFullName) 'загружаем хмл файл
        rootConfig = docConfig.DocumentElement ' Выбираем главный узел

        SignalsNode = rootConfig.SelectSingleNode("//Configuration/Signals/Items") 'в главном узле выбираем только ветку Сигналы

        TreeView1.Nodes.Clear() '
        bool_Tree1Loaded = False ' 
        maxId = 0 ' сбрасываем максимальный ID
        addToTree(SignalsNode, TreeView1) 'добавляем в дерево
        parentNode = Nothing 'обнуление родительского узла
        TreeView1.Nodes(0).Expand() ' раскрываем дерево
        bool_Tree1Loaded = True
        lb_maxId.Text = maxId
        newIds = maxId + 100 'задаём начало новых ID
        setMainChekedNode() 'Находим сравниваемый узел
        lb_peret1.Visible = False

        Exit Sub
err1:
        MsgBox("Err.Number: " & Err.Number & ". " & Err.Description, vbCritical, "Ошибка")
    End Sub

    Sub reloadCfg() 'Перезагружаем дерево конфигурации альфа сервера

        TreeView1.Nodes.Clear() '
        bool_Tree1Loaded = False ' 
        maxId = 0 ' сбрасываем максимальный ID

        addToTree(SignalsNode, TreeView1) 'добавляем в дерево

        parentNode = Nothing 'обнуление родительского узла

        TreeView1.Nodes(0).Expand() ' раскрываем дерево
        bool_Tree1Loaded = True
        lb_maxId.Text = maxId

        newIds = maxId + 100 'задаём начало новых ID
    End Sub


    Sub loadNewCfg() 'тута грузин сгенерённый файл
        On Error GoTo err1
letsTry:
        docNewGen.Load(newGen) 'загружаем хмл файл
        rootNewGen = docNewGen.DocumentElement ' Выбираем главный узел

        TreeView2.Nodes.Clear()
        bool_Tree2Loaded = False

        addToTree(rootNewGen, TreeView2)
        parentNode = Nothing

        TreeView2.Nodes(0).Expand()
        bool_Tree2Loaded = True

        lb_peret2.Visible = False

        setMainChekedNode() 'Находим сравниваемый узел

        'TreeView1.Nodes.Item(0).ForeColor = Color.Red
        Exit Sub
err1:
        Dim msgb_res As MsgBoxResult
        Dim manualRoot As String
        If Err.Number = 5 And Err.Description Like "*Существует несколько корневых элементов*" Then 'Обрабатываем исключение, когда у нас несколько корневых узлов.
            msgb_res = MsgBox("Err.Number: " & Err.Number & ". " & Err.Description & " Добавить главный корневой эелемент самостоятельно? Внимание! Файл будет пересохранён!", vbCritical + vbYesNo, "Ошибка")
            If msgb_res = 6 Then
                manualRoot = InputBox("Введите имя корневого элемента: ") ' запрашиваем нового корневого узла
                If manualRoot = "" Then Exit Sub
                setRootManual(manualRoot) ' задаём корневой узел вручную
                GoTo letsTry
            End If
        Else
            MsgBox("Err.Number: " & Err.Number & ". " & Err.Description, vbCritical, "Ошибка")
        End If
    End Sub

    Sub setMainChekedNode() 'если два дерева загружены, то ищем в конфигурации аналагочиный узел, который будем сравнивать с корневым узлом в сгенерённом файле 
        If bool_Tree1Loaded And bool_Tree2Loaded Then
            bt_compare.Enabled = True 'включаем кнопу
            mainChekedNode = SignalsNode.SelectSingleNode("//Item[@Name='" & CStr(rootNewGen.Attributes("Name").Value) & "']") 'Здесь выбираем узел аналогичный сгенеренному  в конфиге
        End If
    End Sub

    Sub setRootManual(str As String) ' задаём корневой узел вручную. Нужен для обработки исключения
        Dim editText As String = "<Item Name=""" & str & """ Type=""Folder"">
                                        <Properties />
                                        <Items> 
                                        " & File.ReadAllText(newGen) ' текст вначале и наш файл

        File.WriteAllText(newGen, editText & "             </Items>
                </Item>") ' записываем текст и плюс текст в конце
    End Sub


    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect ' что происходит после выбора узла в первом дереве

        lb_cfgPath.Text = TreeView1.SelectedNode.FullPath
        Dim tmpNdoe As XmlNode = getNodeByTreePath(TreeView1.SelectedNode.FullPath, rootConfig)

        If AttributesExist(tmpNdoe, "Id") Then
            lb_cfgId.Text = tmpNdoe.Attributes("Id").Value
        Else
            lb_cfgId.Text = "ОТСУТСТВУЕТ"
        End If

    End Sub

    Private Sub TreeView2_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView2.AfterSelect ' что происходит после выбора узла во втором дереве
        lb_NewGPath.Text = TreeView2.SelectedNode.FullPath

        Dim tmpNdoe As XmlNode = getNodeByTreePath(TreeView2.SelectedNode.FullPath, rootNewGen)

        If AttributesExist(tmpNdoe, "Id") Then
            lb_NewGId.Text = tmpNdoe.Attributes("Id").Value
        Else
            lb_NewGId.Text = "ОТСУТСТВУЕТ"
        End If

    End Sub

    Function getNodeByTreePath(ByVal s As String, mNode As XmlNode) As XmlNode ' получем узел по пути в дереве "FIX\MNS1\AN"
        Dim q()
        q = Split(s, "\")
        tempSearchedNode = mNode
        If InStr(s, "Signals") Then tempSearchedNode = mNode.SelectSingleNode("Signals")
        For k = 1 To q.Length - 1
            tempSearchedNode = tempSearchedNode.SelectSingleNode("Items/Item[@Name='" & q(k) & "']")
        Next
        getNodeByTreePath = tempSearchedNode
        tempSearchedNode = Nothing
    End Function





    '=================================Реализация функции перетаскивания файлов в окно========================================
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
    '=================================Конец реализации функции перетаскивания файлов в окно========================================



    '=================================Изменение расзмера окна и элементов========================================
    ' хз как по-нормальному сделать. Будет так:
    Private Sub AlphaCfgForm_ResizeBegin(sender As Object, e As EventArgs) Handles Me.ResizeBegin
        formWidth = Me.Size.Width
    End Sub

    Private Sub AlphaCfgForm_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
        Dim deltaWidth As Integer
        deltaWidth = (Me.Size.Width - formWidth) / 2
        TreeView1.Size = New Size(TreeView1.Size.Width + deltaWidth, TreeView1.Size.Height)
        TreeView2.Size = New Size(TreeView2.Size.Width + deltaWidth, TreeView2.Size.Height)
    End Sub



    Private Sub AlphaCfgForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then
            TreeView1.Size = New Size(Me.Size.Width / 2.05, TreeView1.Size.Height)
            TreeView2.Size = New Size(Me.Size.Width / 2.05, TreeView2.Size.Height)
        End If
    End Sub
    '=================================Конец изменения расзмера окна и элементов========================================



    '=================================КНОПКИ ========================================

    Private Sub bt_LoadCfg_Click(sender As Object, e As EventArgs) Handles bt_LoadCfg.Click
        bool_selectCfg = True
        If OpenFileDialog1.ShowDialog() = DialogResult.Cancel Then Exit Sub
        loadCfg()
    End Sub

    Private Sub bt_LoadNewGen_Click(sender As Object, e As EventArgs) Handles bt_LoadNewGen.Click
        bool_selectCfg = False
        If OpenFileDialog1.ShowDialog() = DialogResult.Cancel Then Exit Sub
        loadNewCfg()
    End Sub

    Private Sub bt_compare_Click(sender As Object, e As EventArgs) Handles bt_compare.Click

        analiz(rootNewGen, mainChekedNode)

        If comparator(rootNewGen, mainChekedNode) = False Then makeEquals(mainChekedNode, rootNewGen)

        TreeView2.Nodes.Clear()
        addToTree(rootNewGen, TreeView2)
        parentNode = Nothing
        TreeView2.Nodes(0).Expand()
        bt_compare.Enabled = False
        bt_saveID.Enabled = True
    End Sub

    Private Sub bt_saveID_Click(sender As Object, e As EventArgs) Handles bt_saveID.Click
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then Exit Sub
        docNewGen.Save(saveFilePath)
    End Sub

    Private Sub bt_addNewGen_Click(sender As Object, e As EventArgs) Handles bt_addNewGen.Click
        Dim selectedNodeInCfg As XmlNode
        Dim selectedNode As XmlNode
        Dim newNode As XmlNode

        selectedNodeInCfg = getNodeByTreePath(TreeView2.SelectedNode.FullPath, mainChekedNode)
        selectedNode = getNodeByTreePath(TreeView2.SelectedNode.FullPath, rootNewGen)
        newNode = docConfig.ImportNode(selectedNode, True)

        selectedNodeInCfg.ParentNode.ReplaceChild(newNode, selectedNodeInCfg)

        reloadCfg()

    End Sub

    Private Sub bt_saveAllCfg_Click(sender As Object, e As EventArgs) Handles bt_saveAllCfg.Click
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then Exit Sub
        docConfig.Save(saveFilePath)
    End Sub

    '=============================КОНЕЦ КНОПКИ========================================
End Class