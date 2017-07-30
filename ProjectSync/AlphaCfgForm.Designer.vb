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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TreeView1
        '
        Me.TreeView1.Location = New System.Drawing.Point(12, 12)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(425, 290)
        Me.TreeView1.TabIndex = 0
        '
        'TreeView2
        '
        Me.TreeView2.Location = New System.Drawing.Point(483, 11)
        Me.TreeView2.Name = "TreeView2"
        Me.TreeView2.Size = New System.Drawing.Size(425, 290)
        Me.TreeView2.TabIndex = 3
        '
        'bt_LoadCfg
        '
        Me.bt_LoadCfg.Location = New System.Drawing.Point(12, 307)
        Me.bt_LoadCfg.Name = "bt_LoadCfg"
        Me.bt_LoadCfg.Size = New System.Drawing.Size(118, 46)
        Me.bt_LoadCfg.TabIndex = 4
        Me.bt_LoadCfg.Text = "Загрузить конфигурацию"
        Me.bt_LoadCfg.UseVisualStyleBackColor = True
        '
        'bt_LoadNewGen
        '
        Me.bt_LoadNewGen.Location = New System.Drawing.Point(483, 307)
        Me.bt_LoadNewGen.Name = "bt_LoadNewGen"
        Me.bt_LoadNewGen.Size = New System.Drawing.Size(118, 46)
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
        Me.bt_compare.Enabled = False
        Me.bt_compare.Location = New System.Drawing.Point(312, 324)
        Me.bt_compare.Name = "bt_compare"
        Me.bt_compare.Size = New System.Drawing.Size(125, 29)
        Me.bt_compare.TabIndex = 6
        Me.bt_compare.Text = "Раздать ID"
        Me.bt_compare.UseVisualStyleBackColor = True
        '
        'lb_cfgPath
        '
        Me.lb_cfgPath.AutoSize = True
        Me.lb_cfgPath.Location = New System.Drawing.Point(179, 307)
        Me.lb_cfgPath.Name = "lb_cfgPath"
        Me.lb_cfgPath.Size = New System.Drawing.Size(19, 13)
        Me.lb_cfgPath.TabIndex = 7
        Me.lb_cfgPath.Text = "***"
        '
        'lb_cfgId
        '
        Me.lb_cfgId.AutoSize = True
        Me.lb_cfgId.Location = New System.Drawing.Point(179, 324)
        Me.lb_cfgId.Name = "lb_cfgId"
        Me.lb_cfgId.Size = New System.Drawing.Size(19, 13)
        Me.lb_cfgId.TabIndex = 8
        Me.lb_cfgId.Text = "***"
        '
        'lb_maxId
        '
        Me.lb_maxId.AutoSize = True
        Me.lb_maxId.Location = New System.Drawing.Point(179, 340)
        Me.lb_maxId.Name = "lb_maxId"
        Me.lb_maxId.Size = New System.Drawing.Size(19, 13)
        Me.lb_maxId.TabIndex = 9
        Me.lb_maxId.Text = "***"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(136, 340)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Max Id:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(136, 324)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(19, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Id:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(136, 307)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Path:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(607, 324)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Id:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(607, 307)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Path:"
        '
        'lb_NewGId
        '
        Me.lb_NewGId.AutoSize = True
        Me.lb_NewGId.Location = New System.Drawing.Point(650, 324)
        Me.lb_NewGId.Name = "lb_NewGId"
        Me.lb_NewGId.Size = New System.Drawing.Size(19, 13)
        Me.lb_NewGId.TabIndex = 14
        Me.lb_NewGId.Text = "***"
        '
        'lb_NewGPath
        '
        Me.lb_NewGPath.AutoSize = True
        Me.lb_NewGPath.Location = New System.Drawing.Point(650, 307)
        Me.lb_NewGPath.Name = "lb_NewGPath"
        Me.lb_NewGPath.Size = New System.Drawing.Size(19, 13)
        Me.lb_NewGPath.TabIndex = 13
        Me.lb_NewGPath.Text = "***"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(841, 309)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(67, 42)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 372)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(920, 22)
        Me.StatusStrip1.TabIndex = 19
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(111, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'SaveFileDialog1
        '
        '
        'AlphaCfgForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(920, 394)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lb_NewGId)
        Me.Controls.Add(Me.lb_NewGPath)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lb_maxId)
        Me.Controls.Add(Me.lb_cfgId)
        Me.Controls.Add(Me.lb_cfgPath)
        Me.Controls.Add(Me.bt_compare)
        Me.Controls.Add(Me.bt_LoadNewGen)
        Me.Controls.Add(Me.bt_LoadCfg)
        Me.Controls.Add(Me.TreeView2)
        Me.Controls.Add(Me.TreeView1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AlphaCfgForm"
        Me.Text = "Alpha Конфига"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
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
    Friend WithEvents Button1 As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
End Class
