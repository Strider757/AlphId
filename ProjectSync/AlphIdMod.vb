Imports System
Imports System.IO
Imports System.Text
Imports System.Xml



Module AlphIdMod

    '=================Переменные для альфа конфиги===================

    Public docConfig As XmlDocument = New XmlDocument() 'Альфа конфига
    Public strNewGen As String 'Сгенерёнынй ХМЛ файл  из workwithexel в виде строки
    Public docNewGen As XmlDocument = New XmlDocument() 'Сгенерёнынй ХМЛ файл из workwithexel

    Public rootConfig As XmlNode
    Dim SignalsNode As XmlNode
    Public rootNewGen As XmlNode

    Public parentNode As TreeNode
    Dim mainNode As TreeNode

    Public mainChekedNode As XmlNode
    Dim chekedNode As XmlNode
    Dim tempSearchedNode As XmlNode

    Public bool_selectCfg As Boolean
    Dim bool_Tree1Loaded As Boolean
    Dim bool_Tree2Loaded As Boolean
    Dim key As Integer = 1
    Dim maxId As Integer



    Dim newIds As Integer
    Dim tempWth As Integer



    Public confFullName As String '= "D:\Development\Work\AlphaConfigIDTest\mainTestConfig_id.xmlcfg"
    Public newGen As String '= "D:\Development\Work\AlphaConfigIDTest\AnalogsInCfg ID 1.xmlcfg"
    Public saveFilePath As String

    Public confPath As String
    Public newGenPath As String


    '=================Конец переменные для альфа конфиги===================


    Dim MyMainForm As MainForm = MainForm
    Dim OpenFileDialog1 As OpenFileDialog = MainForm.OpenFileDialog1
    Dim SaveFileDialog1 As SaveFileDialog = MainForm.SaveFileDialog1
    Dim TreeView1 As TreeView = MainForm.TreeView1
    Dim TreeView2 As TreeView = MainForm.TreeView2


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
        MainForm.ToolStripStatusLabel1.Text = "Конфигурация загружена"
        MyMainForm.lb_maxId.Text = maxId
        newIds = maxId + 100 'задаём начало новых ID
        setMainChekedNode() 'Находим сравниваемый узел
        MyMainForm.lb_peret1.Visible = False

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
        MyMainForm.lb_maxId.Text = maxId

        newIds = maxId + 100 'задаём начало новых ID
        MainForm.ToolStripStatusLabel1.Text = "Конфигурация перезагружена"
    End Sub


    Sub loadNewCfg() 'тута грузин сгенерённый файл
        On Error GoTo err1
letsTry:
        strNewGen = My.Computer.FileSystem.ReadAllText(newGen, Encoding.Default) 'Сразу грузить в XML документ он не может из-за проблем с кодировками, поэтому сначала читаем как текст.
        docNewGen.LoadXml(strNewGen) 'загружаем хмл файл
        'docNewGen.Load(newGen) 'загружаем хмл файл
        rootNewGen = docNewGen.DocumentElement ' Выбираем главный узел

        TreeView2.Nodes.Clear()
        bool_Tree2Loaded = False

        addToTree(rootNewGen, TreeView2)
        parentNode = Nothing

        TreeView2.Nodes(0).Expand()
        bool_Tree2Loaded = True


        MyMainForm.lb_peret2.Visible = False

        setMainChekedNode() 'Находим сравниваемый узел
        MainForm.ToolStripStatusLabel1.Text = "Сгенерённый файл загружен"
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
            MainForm.bt_addNewGen.Enabled = True
            MyMainForm.bt_compare.Enabled = True 'включаем кнопу
            mainChekedNode = SignalsNode.SelectSingleNode("//Item[@Name='" & CStr(rootNewGen.Attributes("Name").Value) & "']") 'Здесь выбираем узел аналогичный сгенеренному  в конфиге
        End If
    End Sub

    Sub setRootManual(str As String) ' задаём корневой узел вручную. Нужен для обработки исключения
        'Dim editTextUtf8 As String
        Dim editText As String = "<Item Name=""" & str & """ Type=""Folder"">
                                    <Properties />
                                    <Items> 
                                    " & File.ReadAllText(newGen, Encoding.Default) ' текст вначале и наш файл , Encoding.Default

        'Dim UTF8 As Encoding = Encoding.UTF8
        'Dim Def As Encoding = Encoding.Default
        'Dim DefButes As Byte() = Def.GetBytes(editText)
        'Dim UTF8Bytes As Byte() = Encoding.Convert(UTF8, Def, DefButes)
        'editTextUtf8 = UTF8.GetString(UTF8Bytes)


        File.WriteAllText(newGen, editText & "             </Items>
            </Item>", Encoding.Default) ' записываем текст и плюс текст в конце
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
End Module
