﻿Imports System.ComponentModel
Imports System.Xml

Public Class MainForm
    Dim formWidth As Integer 'Переменная для изменения расположения элементов
    Dim bool_FormLoaded As Boolean
    Public version As String = "1.4.0 beta"
    Dim treeViewNormalSize As Size
    Dim testInt As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SyncSetForm.Visible = True
    End Sub

    'грузим форму
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabPage3.Parent = Nothing 'скрыть третью вкладку
        TreeViewContextMenu = Nothing

        initAlpohaID() 'инициализация формы для Альфа Конфигурации
        initSyncFilePanel() 'инициализация формы для синхронизации файлов
        initPropFile()
        bool_FormLoaded = True
    End Sub



    Public Sub WriteLog(ByVal mesStr As String)
        LogTextBox.AppendText(vbCrLf & "  # " & mesStr)
        LogTextBox.SelectionStart = LogTextBox.Text.Length
        LogTextBox.ScrollToCaret()
        Application.DoEvents()
    End Sub

    Private Sub initPropFile()
        With DataGridView3
            .Columns.Add("Id", "Id")
            .Columns.Add("Type", "Type")
            .Columns.Add("Value", "Type")
            .Columns(0).Width = 50
            .Columns(0).ReadOnly = True
            .Columns(1).Width = 60
            .Columns(1).ReadOnly = True
            .Columns(2).Width = 350
            .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(2).ReadOnly = True
        End With
    End Sub

#Region "Synch"

    '************************************************************************************************************************
    '***********************************ТУТА КОД ДЛЯ СИНХРОНИЗАЛКИ ФАЙЛОВ****************************************************
    '************************************************************************************************************************

    Sub initSyncFilePanel()
        Dim chk As New DataGridViewCheckBoxColumn()
        ' задаём свойства 
        With DataGridView1
            .Columns.Add(chk)
            .Columns.Add("name", "Имя")
            .Columns.Add("local", "Местный")
            .Columns.Add("remote", "Удалённый")
            .Columns.Add("directory", "Расположение")
            .Columns.Add("changed", "Изм.")
            .Columns(0).Width = 21
            .Columns(0).ReadOnly = False
            .Columns(1).Width = 310
            .Columns(1).ReadOnly = True
            .Columns(2).Width = 110
            .Columns(2).ReadOnly = True
            .Columns(3).Width = 110
            .Columns(3).ReadOnly = True
            .Columns(4).Width = 300
            .Columns(4).ReadOnly = True
            .Columns(5).Width = 50
            .Columns(5).ReadOnly = True
        End With

        RadioButton1.Checked = True

        ' проверяем наличие конфиг файла
        initConfig()

    End Sub


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim bool_connection As Boolean = False
        but_sync.Enabled = False
    End Sub



    '===================================================Кнопки===============================================================

    Private Sub but_Anal_Click(sender As Object, e As EventArgs) Handles but_Anal.Click
        anal()
        If bool_connection = True Then but_sync.Enabled = True
    End Sub


    Private Sub but_sync_Click(sender As Object, e As EventArgs) Handles but_sync.Click
        Sync()
        anal()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        On Error GoTo err1
        Dim tempDir As String
        If bool_configFileExist Then
            If tbManualDir.Text <> xElem_prjDir.Value Then ' перезаписываем папку
                tempDir = xElem_prjDir.Value
                xElem_prjDir.Value = tbManualDir.Text
                prjDir = tbManualDir.Text
                WriteLog("Папка с проектом изменена на " & prjDir)
            End If
            xdoc.Save(SyncFileName)

            Process.Start(prjDir)
        Else
            tempDir = tbManualDir.Text
            Process.Start(tbManualDir.Text)
        End If

        Exit Sub
err1:
        WriteLog("Err.Number: " & Err.Number & ". " & Err.Description)
        MsgBox("Err.Number: " & Err.Number & ". " & Err.Description, vbCritical, "Ошибка")
    End Sub


    Private Sub But_UnSel_Click(sender As Object, e As EventArgs) Handles But_UnSel.Click
        For Each dataElem As DataGridViewRow In DataGridView1.Rows
            dataElem.Cells(cn_chk).Value = False
        Next
    End Sub


    Private Sub But_selAll_Click(sender As Object, e As EventArgs) Handles But_selAll.Click
        For Each dataElem As DataGridViewRow In DataGridView1.Rows
            dataElem.Cells(cn_chk).Value = True
        Next
    End Sub

    '=================================Конец Кнопок===========================================================================

    Private Sub tbManualDir_KeyDown(sender As Object, e As KeyEventArgs) Handles tbManualDir.KeyDown
        Dim tempDir
        If e.KeyCode = 13 Then
            If tbManualDir.Text <> xElem_prjDir.Value Then ' перезаписываем папку
                tempDir = xElem_prjDir.Value
                xElem_prjDir.Value = tbManualDir.Text
                prjDir = tbManualDir.Text
            End If
            xdoc.Save(SyncFileName)
            WriteLog("Папка с проектом изменена на " & prjDir)
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        On Error GoTo err1
        Dim tempDir As String
        If bool_configFileExist Then
            If tbManualDir.Text <> xElem_prjDir.Value Then ' перезаписываем папку
                tempDir = xElem_prjDir.Value
                xElem_prjDir.Value = tbManualDir.Text
                prjDir = tbManualDir.Text
                WriteLog("Папка с проектом изменена на " & prjDir)
            End If
            xdoc.Save(SyncFileName)

            Process.Start(convertFilePathToRemote(prjDir))
        Else
            tempDir = tbManualDir.Text
            Process.Start(convertFilePathToRemote(tbManualDir.Text))
        End If

        Exit Sub
err1:
        MsgBox("Err.Number: " & Err.Number & ". " & Err.Description, vbCritical, "Ошибка")
        WriteLog("Err.Number: " & Err.Number & ". " & Err.Description)
    End Sub

    '************************************************************************************************************************
    '***********************************КОНЕЦ КОДА ДЛЯ СИНХРОНИЗАЛКИ ФАЙЛОВ**************************************************
    '************************************************************************************************************************
#End Region

#Region "WorkAlphaCfg"

    '************************************************************************************************************************
    '***********************************ТУТА КОД ДЛЯ АЛЬФА КОНФИГИ***********************************************************
    '************************************************************************************************************************
    Sub initAlpohaID() 'инициализация
        On Error GoTo err1

        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.Filter = "xmlcfg (*.xmlcfg)|*.xmlcfg"
        SaveFileDialog1.DefaultExt = "xmlcfg"
        SaveFileDialog1.Filter = "xmlcfg (*.xmlcfg)|*.xmlcfg"

        formWidth = Size.Width

        bt_saveID.Enabled = False
        MinimumSize = New Size(Size.Width, Size.Height)
        treeViewNormalSize = New Size(TreeView1.Size.Width, TreeView2.Size.Height)
        bool_FormLoaded = True

        ' PropListView.Items.Add(New ListViewItem({"Id", "Type", "Value"}))

        Exit Sub

err1:
        MsgBox("Err.Number: " & Err.Number & ". " & Err.Description, vbCritical, "Ошибка")
        WriteLog("Err.Number: " & Err.Number & ". " & Err.Description)
        Resume Next
    End Sub

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
        loadCfg(TreeView1)
        Cursor = Cursors.Default
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
        Cursor = Cursors.Default
    End Sub
    '=================================Конец реализации функции перетаскивания файлов в окно========================================



    '=================================Изменение размера окна и элементов========================================
    '' хз как по-нормальному сделать. Будет так:
    'Private Sub AlphaCfgForm_ResizeBegin(sender As Object, e As EventArgs) Handles Me.ResizeBegin
    '    formWidth = Size.Width
    'End Sub

    'Private Sub AlphaCfgForm_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
    '    Dim deltaWidth As Integer
    '    deltaWidth = (Size.Width - formWidth) / 2
    '    TreeView1.Size = New Size(TreeView1.Size.Width + deltaWidth, TreeView1.Size.Height)
    '    TreeView2.Size = New Size(TreeView2.Size.Width + deltaWidth, TreeView2.Size.Height)
    'End Sub



    'Private Sub AlphaCfgForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
    '    If Me.WindowState = FormWindowState.Maximized Then
    '        TreeView1.Size = New Size(Size.Width / 2.05, TreeView1.Size.Height)
    '        TreeView2.Size = New Size(Size.Width / 2.05, TreeView2.Size.Height)
    '        'ElseIf Me.WindowState = FormWindowState.Normal And treeViewNormalSize.Height <> 0 And treeViewNormalSize.Width <> 0 Then
    '        '    TreeView1.Size = treeViewNormalSize
    '        '    TreeView2.Size = treeViewNormalSize
    '    End If
    'End Sub
    '=================================Конец изменения размера окна и элементов========================================



    '=================================КНОПКИ ========================================

    Private Sub bt_LoadCfg_Click(sender As Object, e As EventArgs) Handles bt_LoadCfg.Click
        bool_selectCfg = True
        If confPath Is Nothing Then
            If xElem_prjDir IsNot Nothing Then OpenFileDialog1.InitialDirectory = xElem_prjDir.Value
        Else
            OpenFileDialog1.InitialDirectory = confPath
        End If
        If OpenFileDialog1.ShowDialog() = DialogResult.Cancel Then Exit Sub
        confPath = getDirectotyByFileName(OpenFileDialog1.FileName)


        loadCfg(TreeView1)
        Cursor = Cursors.Default
    End Sub

    Function getDirectotyByFileName(s As String) As String
        Dim q()
        q = Split(s, "\")
        For k = 0 To q.Length - 2
            getDirectotyByFileName = getDirectotyByFileName & q(k)
            If k = q.Length - 2 Then Exit For
            getDirectotyByFileName = getDirectotyByFileName & "\"
        Next
    End Function

    Private Sub bt_LoadNewGen_Click(sender As Object, e As EventArgs) Handles bt_LoadNewGen.Click
        bool_selectCfg = False

        If newGenPath Is Nothing Then
            If xElem_prjDir IsNot Nothing Then OpenFileDialog1.InitialDirectory = xElem_prjDir.Value
        Else
            OpenFileDialog1.InitialDirectory = newGenPath
        End If
        If OpenFileDialog1.ShowDialog() = DialogResult.Cancel Then Exit Sub
        newGenPath = getDirectotyByFileName(OpenFileDialog1.FileName)

        loadNewCfg()
        Cursor = Cursors.Default
    End Sub

    Private Sub bt_compare_Click(sender As Object, e As EventArgs) Handles bt_compare.Click

        Cursor = Cursors.WaitCursor
        analiz(rootNewGen, mainChekedNode)


        If mainChekedNode Is Nothing Then
            MsgBox("Главный узел сгенерённого файла не найден в конфигурации! скорее всего не ID розданы неправильно", vbCritical + vbOKOnly)
            WriteLog("Главный узел сгенерённого файла не найден в конфигурации! скорее всего не ID розданы неправильно")
        Else
            If comparator(rootNewGen, mainChekedNode) = False Then makeEquals(mainChekedNode, rootNewGen)
        End If

        TreeView2.Nodes.Clear()
        addToTree(rootNewGen, TreeView2)
        parentNode = Nothing
        TreeView2.Nodes(0).Expand()
        TreeView2.Select()
        bt_compare.Enabled = False
        bt_saveID.Enabled = True
        WriteLog("ID розданы для " & newGen)
        Cursor = Cursors.Default
    End Sub

    Private Sub bt_saveID_Click(sender As Object, e As EventArgs) Handles bt_saveID.Click
        SaveFileDialog1.InitialDirectory = newGenPath
        SaveFileDialog1.FileName = Replace(newGen, ".xmlcfg", "") & "_id"
        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then Exit Sub
        docNewGen.Save(saveFilePath)
        WriteLog("Сгенерённый файл сохранён в " & saveFilePath)
        MsgBox("Файл сохранён!")
    End Sub

    Private Sub bt_replaceNewGen_Click(sender As Object, e As EventArgs) Handles bt_replaceNewGen.Click
        Dim selectedNodeInCfg As XmlNode
        Dim selectedNode As XmlNode
        Dim newNode As XmlNode


        If bool_manualTargetNode = True Then ' если целевой узел был задан вручную
            selectedNodeInCfg = mainChekedNode
            If TreeView2.SelectedNode Is Nothing Then ' если ничего не выбрано в правом дереве то заменяем всё дерево
                selectedNode = rootNewGen
            Else
                selectedNode = getNodeByTreePath(TreeView2.SelectedNode.FullPath, rootNewGen)
            End If
        Else 'если целевой узел был выбран автоматически

            'If TreeView2.SelectedNode Is Nothing Then ' если ничего не выбрано в правом дереве то заменяем всё дерево
            'selectedNodeInCfg = mainChekedNode
            'selectedNode = rootNewGen
            ' Else

            'End If
            selectedNodeInCfg = getNodeByTreePath(TreeView2.SelectedNode.FullPath, mainChekedNode)
            selectedNode = getNodeByTreePath(TreeView2.SelectedNode.FullPath, rootNewGen)
        End If



        newNode = docConfig.ImportNode(selectedNode, True)


        Try
            selectedNodeInCfg.ParentNode.ReplaceChild(newNode, selectedNodeInCfg)
            ' selectedNodeInCfg is nothing
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical + vbOKOnly, "ERROR!")
            WriteLog("Ошибка! Узел " & selectedNode.Attributes("Name").Value & " не может быть заменен! " & ex.Message)
            Exit Sub
        End Try


        WriteLog("Узел " & selectedNodeInCfg.Attributes("Name").Value & " заменён полностью на " & selectedNode.Attributes("Name").Value)

        reloadCfg()

        TreeView2.Select()
    End Sub

    Private Sub bt_saveAllCfg_Click(sender As Object, e As EventArgs) Handles bt_saveAllCfg.Click
        SaveFileDialog1.InitialDirectory = confPath
        SaveFileDialog1.FileName = Replace(confFullName, ".xmlcfg", "") & "_id" ' & ""

        If SaveFileDialog1.ShowDialog() = DialogResult.Cancel Then Exit Sub
        Cursor = Cursors.WaitCursor
        docConfig.Save(saveFilePath)
        Cursor = Cursors.Default
        WriteLog("Конфигурация сохранена в файл: " & SaveFileDialog1.FileName)
        MsgBox("Файл сохранён!")
    End Sub

    '=============================КОНЕЦ КНОПКИ========================================


    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect ' что происходит после выбора узла в первом дереве
        If TreeView1.SelectedNode IsNot Nothing Then bt_setManualMainChekedNode.Enabled = True
        If TreeView1.SelectedNode IsNot Nothing And TreeView2.SelectedNode IsNot Nothing Then bt_pasteNewGen.Enabled = True
        TreeView1.SelectedNode.SelectedImageIndex = TreeView1.SelectedNode.ImageIndex
        lb_cfgPath.Text = TreeView1.SelectedNode.FullPath
        Dim tmpNdoe As XmlNode = getNodeByTreePath(TreeView1.SelectedNode.FullPath, rootConfig)

        If AttributesExist(tmpNdoe, "Id") Then
            lb_cfgId.Text = tmpNdoe.Attributes("Id").Value
        Else
            lb_cfgId.Text = "ОТСУТСТВУЕТ"
        End If


        getProperties(tmpNdoe)

    End Sub

    Private Sub getProperties(selectedNode As XmlNode)
        DataGridView3.Rows.Clear()
        Dim k = 0
        For Each ps As XmlNode In selectedNode.ChildNodes
            If ps.Name = "Properties" Then
                For Each p As XmlNode In ps.ChildNodes
                    DataGridView3.Rows.Add()
                    DataGridView3.Rows.Item(k).Cells(0).Value = p.Attributes("Id").Value
                    DataGridView3.Rows.Item(k).Cells(1).Value = p.Attributes("Type").Value
                    DataGridView3.Rows.Item(k).Cells(2).Value = p.Attributes("Value").Value
                    k = k + 1
                Next
            End If
        Next

    End Sub

    Private Sub TreeView2_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView2.AfterSelect ' что происходит после выбора узла во втором дереве
        lb_NewGPath.Text = TreeView2.SelectedNode.FullPath
        TreeView2.SelectedNode.SelectedImageIndex = TreeView2.SelectedNode.ImageIndex
        Dim tmpNdoe As XmlNode = getNodeByTreePath(TreeView2.SelectedNode.FullPath, rootNewGen)

        If AttributesExist(tmpNdoe, "Id") Then
            lb_NewGId.Text = tmpNdoe.Attributes("Id").Value
        Else
            lb_NewGId.Text = "ОТСУТСТВУЕТ"
        End If

    End Sub



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

    Private Sub bt_pasteNewGen_Click(sender As Object, e As EventArgs) Handles bt_pasteNewGen.Click
        Dim selectedNodeInCfg As XmlNode
        Dim selectedNode As XmlNode
        Dim newNode As XmlNode
        Dim massNeedToExpand() As Integer
        Dim NeedToExpand As TreeNode

        If TreeView1.SelectedNode Is Nothing Then
            MsgBox("Выбери куда вставлять!", vbOKOnly)
            Exit Sub
        End If



        ReDim massNeedToExpand(Split(TreeView1.SelectedNode.FullPath, "\").Length - 1)

        NeedToExpand = TreeView1.SelectedNode

        For k = 0 To massNeedToExpand.Length - 1
            massNeedToExpand(k) = NeedToExpand.Index
            NeedToExpand = NeedToExpand.Parent
        Next

        If TreeView2.CheckBoxes = False Then
            ' TreeView2'
            'Else
            selectedNodeInCfg = getNodeByTreePath(TreeView1.SelectedNode.FullPath, SignalsNode.ParentNode)
            selectedNode = getNodeByTreePath(TreeView2.SelectedNode.FullPath, rootNewGen)
            newNode = docConfig.ImportNode(selectedNode, True)

            selectedNodeInCfg.SelectSingleNode("Items").AppendChild(newNode)

            WriteLog("Узел " & selectedNode.Attributes("Name").Value & " добавлен в " & TreeView1.SelectedNode.FullPath)

            reloadCfg()

            TreeView2.Select()

            NeedToExpand = TreeView1.Nodes(0)
            TreeView1.Nodes(0).Expand()

            For k = 0 To massNeedToExpand.Length - 2
                NeedToExpand.Nodes(massNeedToExpand((massNeedToExpand.Length - 2) - k)).Expand()
                NeedToExpand = NeedToExpand.Nodes(massNeedToExpand((massNeedToExpand.Length - 2) - k))
            Next
            bt_pasteNewGen.Enabled = False
        End If
    End Sub

    Private Sub bt_setManualMainChekedNode_Click(sender As Object, e As EventArgs) Handles bt_setManualMainChekedNode.Click
        If TreeView1.SelectedNode Is Nothing Then Exit Sub
        mainChekedNode = getNodeByTreePath(TreeView1.SelectedNode.FullPath, SignalsNode.ParentNode)
        lb_mainChekedNode.Text = getPathByNode(mainChekedNode)
        lb_mainChekedNode.ForeColor = Color.Black
        bt_replaceNewGen.Enabled = True
        bool_manualTargetNode = True
        WriteLog("Узел " & TreeView1.SelectedNode.FullPath & " установлен на замену вручную")
    End Sub

    Private Sub bt_showCheckedNodesButton_Click(sender As Object, e As EventArgs) Handles bt_showCheckedNodesButton.Click
        If bool_Tree2Loaded = False Then Exit Sub
        If TreeView2.CheckBoxes = True Then
            TreeView2.CheckBoxes = False
            TreeView2.Nodes(0).Expand()
        Else
            TreeView2.CheckBoxes = True
        End If
    End Sub





    Private Sub TreeView2_MouseClick(sender As Object, e As MouseEventArgs) Handles TreeView2.MouseClick

        TreeView2.SelectedNode = TreeView2.GetNodeAt(e.X, e.Y)
    End Sub


    Private Sub TreeView1_MouseClick(sender As Object, e As MouseEventArgs) Handles TreeView1.MouseClick
        If bool_Tree1Loaded Then

            TreeView1.SelectedNode = TreeView1.GetNodeAt(e.X, e.Y)
        End If

    End Sub



    'Private Sub TreeViewContextMenu_MouseClick(sender As Object, e As MouseEventArgs) Handles TreeViewContextMenu.MouseClick
    '    MsgBox("d")
    'End Sub














    '************************************************************************************************************************
    '***********************************КОНЕЦ КОДА ДЛЯ АЛЬФА КОНФИГИ*********************************************************
    '************************************************************************************************************************

#End Region









#Region "xmlcfgView"

    '************************************************************************************************************************
    '***********************************КОД ДЛЯ ПРОСМОТР КОНФИГИ*************************************************************
    '************************************************************************************************************************

    '************************************************************************************************************************
    '***********************************КОНЕЦ КОДА ДЛЯ ПРОСМОТР КОНФИГИ******************************************************
    '************************************************************************************************************************
#End Region

End Class
