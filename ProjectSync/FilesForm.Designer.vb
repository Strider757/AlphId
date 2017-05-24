<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FilesForm
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.But_add = New System.Windows.Forms.Button()
        Me.But_save = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.but_addFilter = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'But_add
        '
        Me.But_add.Location = New System.Drawing.Point(12, 323)
        Me.But_add.Name = "But_add"
        Me.But_add.Size = New System.Drawing.Size(111, 28)
        Me.But_add.TabIndex = 2
        Me.But_add.Text = "Добавить"
        Me.But_add.UseVisualStyleBackColor = True
        '
        'But_save
        '
        Me.But_save.Location = New System.Drawing.Point(129, 323)
        Me.But_save.Name = "But_save"
        Me.But_save.Size = New System.Drawing.Size(111, 28)
        Me.But_save.TabIndex = 3
        Me.But_save.Text = "Сохранить"
        Me.But_save.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(6, 19)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(118, 21)
        Me.ComboBox1.TabIndex = 5
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(578, 323)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(111, 28)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Очистить таблицу"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(677, 291)
        Me.DataGridView1.TabIndex = 7
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.but_addFilter)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(246, 309)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(208, 49)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Фильтр"
        '
        'but_addFilter
        '
        Me.but_addFilter.Location = New System.Drawing.Point(130, 17)
        Me.but_addFilter.Name = "but_addFilter"
        Me.but_addFilter.Size = New System.Drawing.Size(68, 23)
        Me.but_addFilter.TabIndex = 6
        Me.but_addFilter.Text = "Ред. спис."
        Me.but_addFilter.UseVisualStyleBackColor = True
        '
        'FilesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(701, 370)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.But_save)
        Me.Controls.Add(Me.But_add)
        Me.Name = "FilesForm"
        Me.Text = "FilesForm"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents But_add As System.Windows.Forms.Button
    Friend WithEvents But_save As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents but_addFilter As System.Windows.Forms.Button
End Class
