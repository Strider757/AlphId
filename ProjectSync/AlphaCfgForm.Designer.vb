<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AlphaCfgForm
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
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.TreeView2 = New System.Windows.Forms.TreeView()
        Me.bt_LoadCfg = New System.Windows.Forms.Button()
        Me.bt_LoadNewGen = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.bt_compare = New System.Windows.Forms.Button()
        Me.lb_cfgPath = New System.Windows.Forms.Label()
        Me.lb_cfgId = New System.Windows.Forms.Label()
        Me.lb_maxId = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lb_NewGId = New System.Windows.Forms.Label()
        Me.lb_NewGPath = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lb_peret2 = New System.Windows.Forms.Label()
        Me.lb_peret1 = New System.Windows.Forms.Label()
        Me.bt_addNewGen = New System.Windows.Forms.Button()
        Me.bt_saveID = New System.Windows.Forms.Button()
        Me.bt_saveAllCfg = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TreeView1
        '
        Me.TreeView1.AllowDrop = True
        Me.TreeView1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TreeView1.Location = New System.Drawing.Point(4, 46)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(450, 300)
        Me.TreeView1.TabIndex = 0
        '
        'TreeView2
        '
        Me.TreeView2.AllowDrop = True
        Me.TreeView2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TreeView2.Location = New System.Drawing.Point(469, 46)
        Me.TreeView2.Name = "TreeView2"
        Me.TreeView2.Size = New System.Drawing.Size(450, 300)
        Me.TreeView2.TabIndex = 3
        '
        'bt_LoadCfg
        '
        Me.bt_LoadCfg.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.bt_LoadCfg.Location = New System.Drawing.Point(6, 6)
        Me.bt_LoadCfg.Name = "bt_LoadCfg"
        Me.bt_LoadCfg.Size = New System.Drawing.Size(118, 36)
        Me.bt_LoadCfg.TabIndex = 4
        Me.bt_LoadCfg.Text = "Загрузить конфигурацию"
        Me.bt_LoadCfg.UseVisualStyleBackColor = True
        '
        'bt_LoadNewGen
        '
        Me.bt_LoadNewGen.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.bt_LoadNewGen.Location = New System.Drawing.Point(469, 6)
        Me.bt_LoadNewGen.Name = "bt_LoadNewGen"
        Me.bt_LoadNewGen.Size = New System.Drawing.Size(118, 36)
        Me.bt_LoadNewGen.TabIndex = 5
        Me.bt_LoadNewGen.Text = "Загрузить сгенеренный файл"
        Me.bt_LoadNewGen.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'bt_compare
        '
        Me.bt_compare.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.bt_compare.Enabled = False
        Me.bt_compare.Location = New System.Drawing.Point(593, 6)
        Me.bt_compare.Name = "bt_compare"
        Me.bt_compare.Size = New System.Drawing.Size(118, 36)
        Me.bt_compare.TabIndex = 6
        Me.bt_compare.Text = "Раздать ID"
        Me.bt_compare.UseVisualStyleBackColor = True
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
        'lb_cfgId
        '
        Me.lb_cfgId.AutoSize = True
        Me.lb_cfgId.Location = New System.Drawing.Point(54, 33)
        Me.lb_cfgId.Name = "lb_cfgId"
        Me.lb_cfgId.Size = New System.Drawing.Size(19, 13)
        Me.lb_cfgId.TabIndex = 8
        Me.lb_cfgId.Text = "***"
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Max Id:"
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
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Path:"
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Path:"
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
        'lb_NewGPath
        '
        Me.lb_NewGPath.AutoSize = True
        Me.lb_NewGPath.Location = New System.Drawing.Point(49, 16)
        Me.lb_NewGPath.Name = "lb_NewGPath"
        Me.lb_NewGPath.Size = New System.Drawing.Size(19, 13)
        Me.lb_NewGPath.TabIndex = 13
        Me.lb_NewGPath.Text = "***"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 461)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(930, 22)
        Me.StatusStrip1.TabIndex = 19
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lb_cfgPath)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lb_cfgId)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lb_maxId)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 352)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(450, 76)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.lb_NewGPath)
        Me.GroupBox2.Controls.Add(Me.lb_NewGId)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(469, 352)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(449, 76)
        Me.GroupBox2.TabIndex = 21
        Me.GroupBox2.TabStop = False
        '
        'lb_peret2
        '
        Me.lb_peret2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.lb_peret2.AutoSize = True
        Me.lb_peret2.BackColor = System.Drawing.Color.White
        Me.lb_peret2.ForeColor = System.Drawing.Color.DarkGray
        Me.lb_peret2.Location = New System.Drawing.Point(507, 187)
        Me.lb_peret2.Name = "lb_peret2"
        Me.lb_peret2.Size = New System.Drawing.Size(97, 13)
        Me.lb_peret2.TabIndex = 22
        Me.lb_peret2.Text = "+ Перетащи сюда"
        Me.lb_peret2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lb_peret1
        '
        Me.lb_peret1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.lb_peret1.AutoSize = True
        Me.lb_peret1.BackColor = System.Drawing.Color.White
        Me.lb_peret1.ForeColor = System.Drawing.Color.DarkGray
        Me.lb_peret1.Location = New System.Drawing.Point(31, 187)
        Me.lb_peret1.Name = "lb_peret1"
        Me.lb_peret1.Size = New System.Drawing.Size(97, 13)
        Me.lb_peret1.TabIndex = 23
        Me.lb_peret1.Text = "+ Перетащи сюда"
        Me.lb_peret1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'bt_addNewGen
        '
        Me.bt_addNewGen.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.bt_addNewGen.Location = New System.Drawing.Point(408, 6)
        Me.bt_addNewGen.Name = "bt_addNewGen"
        Me.bt_addNewGen.Size = New System.Drawing.Size(46, 36)
        Me.bt_addNewGen.TabIndex = 24
        Me.bt_addNewGen.Text = "<"
        Me.bt_addNewGen.UseVisualStyleBackColor = True
        '
        'bt_saveID
        '
        Me.bt_saveID.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.bt_saveID.Location = New System.Drawing.Point(717, 6)
        Me.bt_saveID.Name = "bt_saveID"
        Me.bt_saveID.Size = New System.Drawing.Size(118, 36)
        Me.bt_saveID.TabIndex = 25
        Me.bt_saveID.Text = "Сохранить c ID"
        Me.bt_saveID.UseVisualStyleBackColor = True
        '
        'bt_saveAllCfg
        '
        Me.bt_saveAllCfg.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.bt_saveAllCfg.Location = New System.Drawing.Point(284, 4)
        Me.bt_saveAllCfg.Name = "bt_saveAllCfg"
        Me.bt_saveAllCfg.Size = New System.Drawing.Size(118, 36)
        Me.bt_saveAllCfg.TabIndex = 26
        Me.bt_saveAllCfg.Text = "Сохранить конфигурацию"
        Me.bt_saveAllCfg.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(0, 5)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(930, 478)
        Me.TabControl1.TabIndex = 27
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lb_peret2)
        Me.TabPage1.Controls.Add(Me.bt_saveID)
        Me.TabPage1.Controls.Add(Me.bt_saveAllCfg)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.bt_compare)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.bt_addNewGen)
        Me.TabPage1.Controls.Add(Me.lb_peret1)
        Me.TabPage1.Controls.Add(Me.TreeView2)
        Me.TabPage1.Controls.Add(Me.TreeView1)
        Me.TabPage1.Controls.Add(Me.bt_LoadNewGen)
        Me.TabPage1.Controls.Add(Me.bt_LoadCfg)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(922, 452)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "AlphaКонфига"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(922, 452)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Синхронизация файлов ВУ"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'AlphaCfgForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(930, 483)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "AlphaCfgForm"
        Me.Text = "AlphID"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents TreeView2 As TreeView
    Friend WithEvents bt_LoadCfg As Button
    Friend WithEvents bt_LoadNewGen As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents bt_compare As Button
    Friend WithEvents lb_cfgPath As Label
    Friend WithEvents lb_cfgId As Label
    Friend WithEvents lb_maxId As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lb_NewGId As Label
    Friend WithEvents lb_NewGPath As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lb_peret2 As Label
    Friend WithEvents lb_peret1 As Label
    Friend WithEvents bt_addNewGen As Button
    Friend WithEvents bt_saveID As Button
    Friend WithEvents bt_saveAllCfg As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
End Class
