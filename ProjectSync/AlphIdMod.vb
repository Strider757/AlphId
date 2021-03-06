﻿Imports System
Imports System.IO
Imports System.Text
Imports System.Xml



Module AlphIdMod

    '=================Переменные для альфа конфиги===================

    Public docConfig As XmlDocument = New XmlDocument() 'Альфа конфига
    Public strNewGen As String 'Сгенерёнынй ХМЛ файл  из workwithexel в виде строки
    Public docNewGen As XmlDocument = New XmlDocument() 'Сгенерёнынй ХМЛ файл из workwithexel

    Public rootConfig As XmlNode
    Public SignalsNode As XmlNode
    Public rootNewGen As XmlNode

    Public parentNode As TreeNode
    Dim mainNode As TreeNode

    Public mainChekedNode As XmlNode
    Dim chekedNode As XmlNode
    Dim tempSearchedNode As XmlNode

    Public bool_selectCfg As Boolean
    Public bool_Tree1Loaded As Boolean
    Public bool_Tree2Loaded As Boolean
    Dim key As Integer = 1
    Dim maxId As Integer
    Public bool_manualTargetNode As Boolean

    Public bool_configaInTV2 As Boolean



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
    Dim TreeImageList As ImageList = MainForm.TreeImageList



    Sub addToTree(xe As XmlNode, Optional tree As TreeView = Nothing, Optional parent As TreeNode = Nothing) 'Рекурсивная процедура добавления xml узла в дерево. xe-добавляемый узел, tree-treeView  в который добавлем, parent - предок узла(если есть)
        For Each x As XmlNode In xe.ChildNodes ' и так. 
            If x.Name = "Item" Then
                If parent Is Nothing Then
                    If tree.Nodes.Count < 1 Then
                        If x.ParentNode.ParentNode.Attributes.Count > 0 Then
                            mainNode = tree.Nodes.Add(key.ToString, x.ParentNode.ParentNode.Attributes("Name").Value)
                        Else
                            mainNode = tree.Nodes.Add(key.ToString, x.ParentNode.ParentNode.Name)

                        End If
                        key = key + 1
                    End If
                    parentNode = mainNode.Nodes.Add(key.ToString, x.Attributes("Name").Value, imgNum(x)) '                    
                    key = key + 1
                    If AttributesExist(x, "Id") And tree.Name = "TreeView1" Then If maxId < x.Attributes("Id").Value Then maxId = x.Attributes("Id").Value 'ищем максимальный ID и смотрим что бы он искался только в конфигурации, то есть в левом окошке
                Else
                    parentNode = parent.Nodes.Add(key.ToString, x.Attributes("Name").Value, imgNum(x))
                    key = key + 1
                    If AttributesExist(x, "Id") And tree.Name = "TreeView1" Then If maxId < x.Attributes("Id").Value Then maxId = x.Attributes("Id").Value
                End If
            End If
            If x.HasChildNodes Then
                addToTree(x, tree, parentNode)
            End If
        Next
    End Sub

    Function imgNum(x As XmlNode) As Integer
        Select Case x.Attributes("Type").Value
            Case "Folder"
                imgNum = 0
            Case "Int1"
                imgNum = 1
            Case "UInt1"
                imgNum = 2
            Case "Int2"
                imgNum = 3
            Case "UInt2"
                imgNum = 4
            Case "Int4"
                imgNum = 5
            Case "UInt4"
                imgNum = 6
            Case "Int8"
                imgNum = 7
            Case "UInt8"
                imgNum = 8
            Case "Float"
                imgNum = 9
            Case "Double"
                imgNum = 10
            Case "Bool"
                imgNum = 11
            Case "String"
                imgNum = 12
            Case Else
                imgNum = 13
        End Select
    End Function

    Sub analiz(xe As XmlNode, y As XmlNode) ' x - узел из сгенеренного файла, y - аналогичный узел из конфиги
        Dim bool_sEq As Boolean 'успех присываивания ID
        Dim tmpCkNode As XmlNode
        Dim msRes As MsgBoxResult
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
                        bool_sEq = makeEquals(tmpCkNode, x)
                        If bool_sEq = False Then msRes = MsgBox("Одному из элементов не удалось присвоить ID. Продолжить присвоение?", vbYesNo, "Ошибка") 'ПОТОМ ДОДЕЛАЮ НОРМАЛЬНЫЙ ВЫХОД ИЗ РЕКУРСИИ
                        If msRes = vbNo Then
                            MsgBox("Лень делать нормальный выход из рекурсивной функции поэтому приложение будет закрыто :)")
                            End
                        End If
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
        '
        Dim attr_Id As XmlAttribute
        attr_Id = docNewGen.CreateAttribute("Id") ' создаем атрибут ИД для того что бы вставляь его там где его нет
        If AttributesExist(newGenNode, "Id") Then
            newGenNode.Attributes("Id").Value = configNode.Attributes("Id").Value
        Else
            On Error GoTo err1
            newGenNode.Attributes.Append(attr_Id)
            newGenNode.Attributes("Id").Value = configNode.Attributes("Id").Value
        End If
        makeEquals = True
        Exit Function
err1:
        If Err.Number = 91 And AttributesExist(configNode, "Id") = False Then
            makeEquals = False
            MsgBox("Err.Number: " & Err.Number & ". " & Err.Description & " В конфигурации присутсвуют элементы без Id. Скорее всего Id розданы неверно!", vbCritical, "Ошибка")
            MainForm.WriteLog("Err.Number: " & Err.Number & ". " & Err.Description & " В конфигурации присутсвуют элементы без Id. Скорее всего Id розданы неверно!")
        Else
            makeEquals = False
            MsgBox("Err.Number: " & Err.Number & ". " & Err.Description, vbCritical, "Ошибка")
            MainForm.WriteLog("Err.Number: " & Err.Number & ". " & Err.Description)
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



    Sub loadCfg(ByRef TrVi As TreeView) 'тута грузим конфигу альфы
        On Error GoTo err1
        MainForm.Cursor = Cursors.WaitCursor
        docConfig.Load(confFullName) 'загружаем хмл файл
        rootConfig = docConfig.DocumentElement ' Выбираем главный узел

        SignalsNode = rootConfig.SelectSingleNode("//Configuration/Signals/Items") 'в главном узле выбираем только ветку Сигналы


        'TreeImageList.Images.Add()


        TrVi.ImageList = TreeImageList
        TrVi.Nodes.Clear() '
        bool_Tree1Loaded = False ' 

        maxId = 0 ' сбрасываем максимальный ID

        MainForm.WriteLog("Конфигурационный файл загружается...")

        addToTree(SignalsNode, TrVi) 'добавляем в дерево
        parentNode = Nothing 'обнуление родительского узла
        TrVi.Nodes(0).Expand() ' раскрываем дерево
        bool_Tree1Loaded = True

        MainForm.WriteLog("Конфигурационный файл " & confFullName & " загружен.")

        MyMainForm.lb_maxId.Text = maxId
        newIds = maxId + 100 'задаём начало новых ID
        setMainChekedNode() 'Находим сравниваемый узел
        MyMainForm.lb_peret1.Visible = False

        Exit Sub
err1:
        MsgBox("Err.Number: " & Err.Number & ". " & Err.Description, vbCritical, "Ошибка")
        MainForm.WriteLog("Err.Number: " & Err.Number & ". " & Err.Description)

    End Sub

    Sub reloadCfg() 'Перезагружаем дерево конфигурации альфа сервера
        MainForm.Cursor = Cursors.WaitCursor
        TreeView1.Nodes.Clear() '
        bool_Tree1Loaded = False ' 

        maxId = 0 ' сбрасываем максимальный ID
        MainForm.WriteLog("Перезагружается конфигурация...")
        addToTree(SignalsNode, TreeView1) 'добавляем в дерево

        parentNode = Nothing 'обнуление родительского узла

        TreeView1.Nodes(0).Expand() ' раскрываем дерево
        bool_Tree1Loaded = True

        MyMainForm.lb_maxId.Text = maxId
        setMainChekedNode() 'Находим сравниваемый узел

        newIds = maxId + 100 'задаём начало новых ID
        MainForm.WriteLog("Конфигурация перезагружена")
        MainForm.Cursor = Cursors.Default
    End Sub


    Sub loadNewCfg() 'тута грузим сгенерённый файл+6

        On Error GoTo err1
        MainForm.Cursor = Cursors.WaitCursor
        Dim backup_strNewGen As String
        Dim backup_docNewGen As XmlDocument
        Dim backup_bool_configaInTV2 As Boolean
        backup_strNewGen = strNewGen
        backup_docNewGen = docNewGen
        backup_bool_configaInTV2 = bool_configaInTV2

        bool_configaInTV2 = False
letsTry:
        MainForm.WriteLog("Сгенеренный файл загружается...")
        strNewGen = My.Computer.FileSystem.ReadAllText(newGen, Encoding.Default) 'Сразу грузить в XML документ он не может из-за проблем с кодировками, поэтому сначала читаем как текст.
        docNewGen.LoadXml(strNewGen) 'загружаем хмл файл

        If docNewGen.DocumentElement.Name = "Configuration" Then
            GoTo configaInTV2
        End If
letsContinue:
        'docNewGen.Load(newGen) 'загружаем хмл файл
        rootNewGen = docNewGen.DocumentElement ' Выбираем главный узел
        TreeView2.ImageList = TreeImageList
        TreeView2.Nodes.Clear()
        bool_Tree2Loaded = False

        addToTree(rootNewGen, TreeView2)
        parentNode = Nothing

        TreeView2.Nodes(0).Expand()
        bool_Tree2Loaded = True
        MainForm.bt_replaceNewGen.Enabled = False
        bool_manualTargetNode = False


        MyMainForm.lb_peret2.Visible = False

        setMainChekedNode() 'Находим сравниваемый узел
        MainForm.bt_saveID.Enabled = False
        MainForm.WriteLog("Сгенерённый файл " & newGen & " загружен")
        TreeView2.Select()
        'TreeView1.Nodes.Item(0).ForeColor = Color.Red

        Exit Sub
configaInTV2:
        Dim msgb_res1 As MsgBoxResult
        msgb_res1 = MsgBox("Похоже, что в область для загрузки сгенеренного файла пытается загрузится конфигурация. Продолжить?", vbCritical + vbYesNo, "Ошибка")
        If msgb_res1 = vbYes Then
            bool_configaInTV2 = True
            GoTo letsContinue
        ElseIf msgb_res1 = vbNo Then
            GoTo backup
        End If

        Exit Sub
backup:
        strNewGen = backup_strNewGen
        If strNewGen IsNot Nothing Then docNewGen.LoadXml(strNewGen)
        bool_configaInTV2 = backup_bool_configaInTV2
        MainForm.WriteLog("Загрузка отменена")

        Exit Sub
err1:
        Dim msgb_res As MsgBoxResult
        Dim manualRoot As String
        If Err.Number = 5 And (Err.Description Like "*Существует несколько корневых элементов*" Or Err.Description Like "*There are multiple root elements*") Then 'Обрабатываем исключение, когда у нас несколько корневых узлов.
            msgb_res = MsgBox("Err.Number: " & Err.Number & ". " & Err.Description & " Добавить главный корневой эелемент самостоятельно? Внимание! Файл будет пересохранён!", vbCritical + vbYesNo, "Ошибка")
            If msgb_res = 6 Then
                manualRoot = InputBox("Введите имя корневого элемента: ") ' запрашиваем нового корневого узла
                If manualRoot = "" Then GoTo backup
                setRootManual(manualRoot) ' задаём корневой узел вручную
                GoTo letsTry
            ElseIf msgb_res = 7 Then
                GoTo backup
            End If
        Else
            MsgBox("Err.Number: " & Err.Number & ". " & Err.Description, vbCritical, "Ошибка")
            MainForm.WriteLog("Err.Number: " & Err.Number & ". " & Err.Description)
        End If

    End Sub

    Sub setMainChekedNode() 'если два дерева загружены, то ищем в конфигурации аналагочиный узел, который будем сравнивать с корневым узлом в сгенерённом файле 
        If bool_configaInTV2 Then Exit Sub

        If bool_Tree1Loaded And bool_Tree2Loaded Then

            mainChekedNode = SignalsNode.SelectSingleNode("//Item[@Name='" & CStr(rootNewGen.Attributes("Name").Value) & "']") 'Здесь выбираем узел аналогичный сгенеренному  в конфиге
            If mainChekedNode Is Nothing Then
                MsgBox("Внимание! Корневой узел сгенеренного файла не найден в файле конфигурации. Замена недоступна.", vbCritical, "Ошибка")
                MainForm.WriteLog("Внимание! Корневой узел сгенеренного файла не найден в файле конфигурации. Замена недоступна.")
                MainForm.lb_mainChekedNode.Text = "NOT_FOUND"
            Else
                MyMainForm.bt_compare.Enabled = True 'включаем кнопу
                MainForm.bt_replaceNewGen.Enabled = True
                MainForm.lb_mainChekedNode.Text = getPathByNode(mainChekedNode) & "   - Авто определение"
                MainForm.lb_mainChekedNode.ForeColor = Color.Green
                bool_manualTargetNode = False
            End If

            'MainForm.bt_pasteNewGen.Enabled = True

        End If
    End Sub

    Sub insertInCfg()

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
        MainForm.WriteLog("Задан общий корневой узел " & str & ". Сохранено в " & newGen)
    End Sub




    Public Function getNodeByTreePath(ByVal s As String, mNode As XmlNode) As XmlNode ' получем узел по пути в дереве "FIX\MNS1\AN"
        Dim q()
        q = Split(s, "\")
        tempSearchedNode = mNode
        If InStr(s, "Signals") Then tempSearchedNode = mNode.SelectSingleNode("Signals")
        If mNode.Name = "Signals" Then tempSearchedNode = mNode
        For k = 1 To q.Length - 1
            tempSearchedNode = tempSearchedNode.SelectSingleNode("Items/Item[@Name='" & q(k) & "']")
        Next
        getNodeByTreePath = tempSearchedNode
        tempSearchedNode = Nothing
    End Function

    Function getPathByNode(mNode As XmlNode) As String ' получем путь узла "FIX\MNS1\AN"
        Dim tempStr As String
        Dim tempNode As XmlNode
        Dim nParent As Integer
        Dim strPath(0) As String ' Динамический массив строк
        nParent = 0
        tempNode = mNode

        strPath(0) = tempNode.Attributes("Name").Value

        Do While tempNode.Name <> "Signals"
            tempNode = getParentNodeForAlphaConf(tempNode)
            nParent = nParent + 1
            If tempNode.Name = "Signals" Then Exit Do
            ReDim Preserve strPath(nParent)
            strPath(nParent - 1) = tempNode.Attributes("Name").Value
        Loop
        For k = 2 To strPath.Length
            tempStr = tempStr & strPath(strPath.Length - k) & "\"
        Next
        tempStr = tempStr & mNode.Attributes("Name").Value
        getPathByNode = tempStr
    End Function

    Function getParentNodeForAlphaConf(xNode As XmlNode) As XmlNode
        getParentNodeForAlphaConf = xNode.ParentNode.ParentNode
    End Function

End Module
