<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.but_Anal = New System.Windows.Forms.Button()
        Me.but_sync = New System.Windows.Forms.Button()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.But_selAll = New System.Windows.Forms.Button()
        Me.But_UnSel = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lb_peret2 = New System.Windows.Forms.Label()
        Me.lb_peret1 = New System.Windows.Forms.Label()
        Me.bt_saveID = New System.Windows.Forms.Button()
        Me.bt_saveAllCfg = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lb_cfgPath = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lb_cfgId = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lb_maxId = New System.Windows.Forms.Label()
        Me.bt_compare = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lb_NewGPath = New System.Windows.Forms.Label()
        Me.lb_NewGId = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.bt_addNewGen = New System.Windows.Forms.Button()
        Me.TreeView2 = New System.Windows.Forms.TreeView()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.bt_LoadNewGen = New System.Windows.Forms.Button()
        Me.bt_LoadCfg = New System.Windows.Forms.Button()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.tbManualDir = New System.Windows.Forms.TextBox()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.LogTextBox = New System.Windows.Forms.RichTextBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(370, 54)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(130, 38)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Настройка синхронизации..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(19, 17)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(95, 20)
        Me.TextBox1.TabIndex = 3
        Me.TextBox1.Text = "192.168.209.17"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DataGridView1.Location = New System.Drawing.Point(4, 98)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.ShowEditingIcon = False
        Me.DataGridView1.Size = New System.Drawing.Size(922, 369)
        Me.DataGridView1.TabIndex = 4
        '
        'but_Anal
        '
        Me.but_Anal.Location = New System.Drawing.Point(4, 10)
        Me.but_Anal.Name = "but_Anal"
        Me.but_Anal.Size = New System.Drawing.Size(141, 38)
        Me.but_Anal.TabIndex = 5
        Me.but_Anal.Text = "Анализ"
        Me.but_Anal.UseVisualStyleBackColor = True
        '
        'but_sync
        '
        Me.but_sync.Enabled = False
        Me.but_sync.Location = New System.Drawing.Point(4, 55)
        Me.but_sync.Name = "but_sync"
        Me.but_sync.Size = New System.Drawing.Size(141, 38)
        Me.but_sync.TabIndex = 10
        Me.but_sync.Text = "Синхронизация"
        Me.but_sync.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(6, 15)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(49, 17)
        Me.RadioButton1.TabIndex = 11
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Туда"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(6, 37)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(52, 17)
        Me.RadioButton2.TabIndex = 12
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Сюда"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(6, 60)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(79, 17)
        Me.RadioButton3.TabIndex = 13
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "Туда-Сюда"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Controls.Add(Me.RadioButton3)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Location = New System.Drawing.Point(151, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(98, 88)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Куда?"
        '
        'But_selAll
        '
        Me.But_selAll.Location = New System.Drawing.Point(255, 54)
        Me.But_selAll.Name = "But_selAll"
        Me.But_selAll.Size = New System.Drawing.Size(109, 38)
        Me.But_selAll.TabIndex = 15
        Me.But_selAll.Text = "Выбрать всё"
        Me.But_selAll.UseVisualStyleBackColor = True
        '
        'But_UnSel
        '
        Me.But_UnSel.Location = New System.Drawing.Point(255, 10)
        Me.But_UnSel.Name = "But_UnSel"
        Me.But_UnSel.Size = New System.Drawing.Size(109, 38)
        Me.But_UnSel.TabIndex = 16
        Me.But_UnSel.Text = "Снять выбор"
        Me.But_UnSel.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(938, 488)
        Me.TabControl1.TabIndex = 17
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lb_peret2)
        Me.TabPage2.Controls.Add(Me.lb_peret1)
        Me.TabPage2.Controls.Add(Me.bt_saveID)
        Me.TabPage2.Controls.Add(Me.bt_saveAllCfg)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.bt_compare)
        Me.TabPage2.Controls.Add(Me.GroupBox5)
        Me.TabPage2.Controls.Add(Me.bt_addNewGen)
        Me.TabPage2.Controls.Add(Me.TreeView2)
        Me.TabPage2.Controls.Add(Me.TreeView1)
        Me.TabPage2.Controls.Add(Me.bt_LoadNewGen)
        Me.TabPage2.Controls.Add(Me.bt_LoadCfg)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(930, 462)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "ID для Alpha.Server"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lb_peret2
        '
        Me.lb_peret2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.lb_peret2.AutoSize = True
        Me.lb_peret2.BackColor = System.Drawing.Color.White
        Me.lb_peret2.ForeColor = System.Drawing.Color.DarkGray
        Me.lb_peret2.Location = New System.Drawing.Point(644, 203)
        Me.lb_peret2.Name = "lb_peret2"
        Me.lb_peret2.Size = New System.Drawing.Size(97, 13)
        Me.lb_peret2.TabIndex = 24
        Me.lb_peret2.Text = "+ Перетащи сюда"
        Me.lb_peret2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lb_peret1
        '
        Me.lb_peret1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lb_peret1.AutoSize = True
        Me.lb_peret1.BackColor = System.Drawing.Color.White
        Me.lb_peret1.ForeColor = System.Drawing.Color.DarkGray
        Me.lb_peret1.Location = New System.Drawing.Point(183, 203)
        Me.lb_peret1.Name = "lb_peret1"
        Me.lb_peret1.Size = New System.Drawing.Size(97, 13)
        Me.lb_peret1.TabIndex = 25
        Me.lb_peret1.Text = "+ Перетащи сюда"
        Me.lb_peret1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'bt_saveID
        '
        Me.bt_saveID.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bt_saveID.Location = New System.Drawing.Point(718, 6)
        Me.bt_saveID.Name = "bt_saveID"
        Me.bt_saveID.Size = New System.Drawing.Size(118, 36)
        Me.bt_saveID.TabIndex = 35
        Me.bt_saveID.Text = "Сохранить c ID"
        Me.bt_saveID.UseVisualStyleBackColor = True
        '
        'bt_saveAllCfg
        '
        Me.bt_saveAllCfg.Location = New System.Drawing.Point(127, 6)
        Me.bt_saveAllCfg.Name = "bt_saveAllCfg"
        Me.bt_saveAllCfg.Size = New System.Drawing.Size(118, 36)
        Me.bt_saveAllCfg.TabIndex = 36
        Me.bt_saveAllCfg.Text = "Сохранить конфигурацию"
        Me.bt_saveAllCfg.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.lb_cfgPath)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.lb_cfgId)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.lb_maxId)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 378)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(450, 76)
        Me.GroupBox2.TabIndex = 32
        Me.GroupBox2.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Path:"
        '
        'lb_cfgPath
        '
        Me.lb_cfgPath.AutoSize = True
        Me.lb_cfgPath.Location = New System.Drawing.Point(54, 13)
        Me.lb_cfgPath.Name = "lb_cfgPath"
        Me.lb_cfgPath.Size = New System.Drawing.Size(19, 13)
        Me.lb_cfgPath.TabIndex = 7
        Me.lb_cfgPath.Text = "***"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(19, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Id:"
        '
        'lb_cfgId
        '
        Me.lb_cfgId.AutoSize = True
        Me.lb_cfgId.Location = New System.Drawing.Point(54, 33)
        Me.lb_cfgId.Name = "lb_cfgId"
        Me.lb_cfgId.Size = New System.Drawing.Size(19, 13)
        Me.lb_cfgId.TabIndex = 8
        Me.lb_cfgId.Text = "***"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Max Id:"
        '
        'lb_maxId
        '
        Me.lb_maxId.AutoSize = True
        Me.lb_maxId.Location = New System.Drawing.Point(54, 50)
        Me.lb_maxId.Name = "lb_maxId"
        Me.lb_maxId.Size = New System.Drawing.Size(19, 13)
        Me.lb_maxId.TabIndex = 9
        Me.lb_maxId.Text = "***"
        '
        'bt_compare
        '
        Me.bt_compare.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bt_compare.Enabled = False
        Me.bt_compare.Location = New System.Drawing.Point(594, 6)
        Me.bt_compare.Name = "bt_compare"
        Me.bt_compare.Size = New System.Drawing.Size(118, 36)
        Me.bt_compare.TabIndex = 31
        Me.bt_compare.Text = "Раздать ID"
        Me.bt_compare.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.lb_NewGPath)
        Me.GroupBox5.Controls.Add(Me.lb_NewGId)
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Location = New System.Drawing.Point(470, 378)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(450, 76)
        Me.GroupBox5.TabIndex = 33
        Me.GroupBox5.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Path:"
        '
        'lb_NewGPath
        '
        Me.lb_NewGPath.AutoSize = True
        Me.lb_NewGPath.Location = New System.Drawing.Point(49, 16)
        Me.lb_NewGPath.Name = "lb_NewGPath"
        Me.lb_NewGPath.Size = New System.Drawing.Size(19, 13)
        Me.lb_NewGPath.TabIndex = 13
        Me.lb_NewGPath.Text = "***"
        '
        'lb_NewGId
        '
        Me.lb_NewGId.AutoSize = True
        Me.lb_NewGId.Location = New System.Drawing.Point(49, 37)
        Me.lb_NewGId.Name = "lb_NewGId"
        Me.lb_NewGId.Size = New System.Drawing.Size(19, 13)
        Me.lb_NewGId.TabIndex = 14
        Me.lb_NewGId.Text = "***"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Id:"
        '
        'bt_addNewGen
        '
        Me.bt_addNewGen.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bt_addNewGen.Enabled = False
        Me.bt_addNewGen.Location = New System.Drawing.Point(409, 6)
        Me.bt_addNewGen.Name = "bt_addNewGen"
        Me.bt_addNewGen.Size = New System.Drawing.Size(46, 36)
        Me.bt_addNewGen.TabIndex = 34
        Me.bt_addNewGen.Text = "<"
        Me.bt_addNewGen.UseVisualStyleBackColor = True
        '
        'TreeView2
        '
        Me.TreeView2.AllowDrop = True
        Me.TreeView2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.TreeView2.Location = New System.Drawing.Point(470, 48)
        Me.TreeView2.Name = "TreeView2"
        Me.TreeView2.Size = New System.Drawing.Size(450, 328)
        Me.TreeView2.TabIndex = 28
        '
        'TreeView1
        '
        Me.TreeView1.AllowDrop = True
        Me.TreeView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TreeView1.Location = New System.Drawing.Point(3, 48)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(450, 328)
        Me.TreeView1.TabIndex = 27
        '
        'bt_LoadNewGen
        '
        Me.bt_LoadNewGen.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bt_LoadNewGen.Location = New System.Drawing.Point(470, 6)
        Me.bt_LoadNewGen.Name = "bt_LoadNewGen"
        Me.bt_LoadNewGen.Size = New System.Drawing.Size(118, 36)
        Me.bt_LoadNewGen.TabIndex = 30
        Me.bt_LoadNewGen.Text = "Загрузить сгенеренный файл"
        Me.bt_LoadNewGen.UseVisualStyleBackColor = True
        '
        'bt_LoadCfg
        '
        Me.bt_LoadCfg.Location = New System.Drawing.Point(3, 6)
        Me.bt_LoadCfg.Name = "bt_LoadCfg"
        Me.bt_LoadCfg.Size = New System.Drawing.Size(118, 36)
        Me.bt_LoadCfg.TabIndex = 29
        Me.bt_LoadCfg.Text = "Загрузить конфигурацию"
        Me.bt_LoadCfg.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Button5)
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Controls.Add(Me.Button8)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.But_UnSel)
        Me.TabPage1.Controls.Add(Me.But_selAll)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.but_sync)
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Controls.Add(Me.but_Anal)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(930, 462)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Синхронизация файлов ВУ"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(506, 73)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(130, 20)
        Me.Button5.TabIndex = 34
        Me.Button5.Text = "Открыть на удал."
        Me.Button5.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.tbManualDir)
        Me.GroupBox4.Location = New System.Drawing.Point(506, 6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(130, 43)
        Me.GroupBox4.TabIndex = 32
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Папка с проектом:"
        '
        'tbManualDir
        '
        Me.tbManualDir.Location = New System.Drawing.Point(6, 17)
        Me.tbManualDir.Name = "tbManualDir"
        Me.tbManualDir.Size = New System.Drawing.Size(118, 20)
        Me.tbManualDir.TabIndex = 3
        Me.tbManualDir.Text = "C:\Dynamics\SSN"
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(506, 53)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(130, 20)
        Me.Button8.TabIndex = 31
        Me.Button8.Text = "Открыть"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TextBox1)
        Me.GroupBox3.Location = New System.Drawing.Point(370, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(130, 43)
        Me.GroupBox3.TabIndex = 30
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Удаленная машина"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox6)
        Me.TabPage3.Controls.Add(Me.DateTimePicker1)
        Me.TabPage3.Controls.Add(Me.Button2)
        Me.TabPage3.Controls.Add(Me.Button3)
        Me.TabPage3.Controls.Add(Me.DataGridView2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(930, 462)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Backup"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.TextBox2)
        Me.GroupBox6.Location = New System.Drawing.Point(151, 49)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(206, 43)
        Me.GroupBox6.TabIndex = 33
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Папка с проектом:"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(6, 17)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(194, 20)
        Me.TextBox2.TabIndex = 3
        Me.TextBox2.Text = "C:\Dynamics\SSN"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(157, 17)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 13
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(4, 55)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(141, 38)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "Бэкап"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(4, 10)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(141, 38)
        Me.Button3.TabIndex = 11
        Me.Button3.Text = "Найти"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AllowUserToResizeRows = False
        Me.DataGridView2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView2.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DataGridView2.Location = New System.Drawing.Point(4, 98)
        Me.DataGridView2.MultiSelect = False
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.ShowEditingIcon = False
        Me.DataGridView2.Size = New System.Drawing.Size(922, 351)
        Me.DataGridView2.TabIndex = 5
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'SaveFileDialog1
        '
        '
        'ToolTip1
        '
        Me.ToolTip1.ToolTipTitle = "Заменить выбранный узел"
        '
        'LogTextBox
        '
        Me.LogTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LogTextBox.BackColor = System.Drawing.SystemColors.Window
        Me.LogTextBox.Location = New System.Drawing.Point(0, 490)
        Me.LogTextBox.Name = "LogTextBox"
        Me.LogTextBox.ReadOnly = True
        Me.LogTextBox.Size = New System.Drawing.Size(938, 44)
        Me.LogTextBox.TabIndex = 18
        Me.LogTextBox.Text = ""
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(938, 537)
        Me.Controls.Add(Me.LogTextBox)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "MainForm"
        Me.Text = "Для ВУ"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents but_Anal As System.Windows.Forms.Button
    Friend WithEvents but_sync As System.Windows.Forms.Button
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents But_selAll As System.Windows.Forms.Button
    Friend WithEvents But_UnSel As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents bt_saveID As Button
    Friend WithEvents bt_saveAllCfg As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents lb_cfgPath As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lb_cfgId As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lb_maxId As Label
    Friend WithEvents bt_compare As Button
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lb_NewGPath As Label
    Friend WithEvents lb_NewGId As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents bt_addNewGen As Button
    Friend WithEvents TreeView2 As TreeView
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents bt_LoadNewGen As Button
    Friend WithEvents bt_LoadCfg As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents lb_peret2 As Label
    Friend WithEvents lb_peret1 As Label
    Friend WithEvents Button8 As Button
    Friend WithEvents GroupBox4 As GroupBox
    Public WithEvents TextBox1 As TextBox
    Public WithEvents tbManualDir As TextBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents GroupBox6 As GroupBox
    Public WithEvents TextBox2 As TextBox
    Friend WithEvents LogTextBox As RichTextBox
    Friend WithEvents Button5 As Button
End Class
