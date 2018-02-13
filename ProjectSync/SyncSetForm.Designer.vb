<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SyncSetForm
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
        Me.But_add_cat = New System.Windows.Forms.Button()
        Me.But_save = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.but_addFilter = New System.Windows.Forms.Button()
        Me.b_Deff = New System.Windows.Forms.Button()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.But_add_file = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'But_add_cat
        '
        Me.But_add_cat.Location = New System.Drawing.Point(6, 313)
        Me.But_add_cat.Name = "But_add_cat"
        Me.But_add_cat.Size = New System.Drawing.Size(117, 28)
        Me.But_add_cat.TabIndex = 2
        Me.But_add_cat.Text = "Добавить каталог..."
        Me.But_add_cat.UseVisualStyleBackColor = True
        '
        'But_save
        '
        Me.But_save.Location = New System.Drawing.Point(264, 318)
        Me.But_save.Name = "But_save"
        Me.But_save.Size = New System.Drawing.Size(111, 55)
        Me.But_save.TabIndex = 3
        Me.But_save.Text = "Сохранить"
        Me.But_save.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(6, 14)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(118, 21)
        Me.ComboBox1.TabIndex = 5
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(578, 345)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(111, 28)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Очистить таблицу"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.but_addFilter)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(129, 309)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(129, 68)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Фильтры"
        '
        'but_addFilter
        '
        Me.but_addFilter.Location = New System.Drawing.Point(6, 41)
        Me.but_addFilter.Name = "but_addFilter"
        Me.but_addFilter.Size = New System.Drawing.Size(118, 23)
        Me.but_addFilter.TabIndex = 6
        Me.but_addFilter.Text = "Редакт. список..."
        Me.but_addFilter.UseVisualStyleBackColor = True
        '
        'b_Deff
        '
        Me.b_Deff.Location = New System.Drawing.Point(578, 313)
        Me.b_Deff.Name = "b_Deff"
        Me.b_Deff.Size = New System.Drawing.Size(111, 28)
        Me.b_Deff.TabIndex = 9
        Me.b_Deff.Text = "Ст. набор"
        Me.b_Deff.UseVisualStyleBackColor = True
        Me.b_Deff.Visible = False
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToResizeRows = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(1, 2)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(696, 301)
        Me.DataGridView2.TabIndex = 8
        '
        'But_add_file
        '
        Me.But_add_file.Location = New System.Drawing.Point(6, 345)
        Me.But_add_file.Name = "But_add_file"
        Me.But_add_file.Size = New System.Drawing.Size(117, 28)
        Me.But_add_file.TabIndex = 11
        Me.But_add_file.Text = "Добавить файлы..."
        Me.But_add_file.UseVisualStyleBackColor = True
        '
        'SyncSetForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(701, 380)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.But_add_file)
        Me.Controls.Add(Me.b_Deff)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.But_save)
        Me.Controls.Add(Me.But_add_cat)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SyncSetForm"
        Me.Text = "Настройка синхронизации"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents But_add_cat As System.Windows.Forms.Button
    Friend WithEvents But_save As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents but_addFilter As System.Windows.Forms.Button
    Friend WithEvents b_Deff As System.Windows.Forms.Button
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents But_add_file As Button
End Class
