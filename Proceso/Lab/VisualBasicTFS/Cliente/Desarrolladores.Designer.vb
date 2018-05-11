<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Desarrolladores
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TBNombre = New System.Windows.Forms.TextBox()
        Me.TBApellido = New System.Windows.Forms.TextBox()
        Me.TBRol = New System.Windows.Forms.TextBox()
        Me.TBID = New System.Windows.Forms.NumericUpDown()
        Me.TB1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.DGDevelopers = New System.Windows.Forms.DataGridView()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.BTNEliminar = New System.Windows.Forms.Button()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.BTNMod = New System.Windows.Forms.Button()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.BTNCrear = New System.Windows.Forms.Button()
        Me.Refresh = New System.Windows.Forms.Button()
        CType(Me.TBID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TB1.SuspendLayout()
        CType(Me.DGDevelopers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TBNombre
        '
        Me.TBNombre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TBNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBNombre.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TBNombre.Location = New System.Drawing.Point(242, 31)
        Me.TBNombre.Name = "TBNombre"
        Me.TBNombre.Size = New System.Drawing.Size(169, 20)
        Me.TBNombre.TabIndex = 1
        '
        'TBApellido
        '
        Me.TBApellido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TBApellido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBApellido.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TBApellido.Location = New System.Drawing.Point(460, 31)
        Me.TBApellido.Name = "TBApellido"
        Me.TBApellido.Size = New System.Drawing.Size(169, 20)
        Me.TBApellido.TabIndex = 2
        '
        'TBRol
        '
        Me.TBRol.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TBRol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBRol.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TBRol.Location = New System.Drawing.Point(678, 31)
        Me.TBRol.Name = "TBRol"
        Me.TBRol.Size = New System.Drawing.Size(169, 20)
        Me.TBRol.TabIndex = 3
        '
        'TBID
        '
        Me.TBID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TBID.Enabled = False
        Me.TBID.Location = New System.Drawing.Point(24, 31)
        Me.TBID.Name = "TBID"
        Me.TBID.Size = New System.Drawing.Size(169, 20)
        Me.TBID.TabIndex = 11
        '
        'TB1
        '
        Me.TB1.ColumnCount = 3
        Me.TB1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TB1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.0!))
        Me.TB1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TB1.Controls.Add(Me.Label18, 1, 2)
        Me.TB1.Controls.Add(Me.DGDevelopers, 1, 3)
        Me.TB1.Controls.Add(Me.TableLayoutPanel2, 1, 1)
        Me.TB1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TB1.Location = New System.Drawing.Point(0, 0)
        Me.TB1.Name = "TB1"
        Me.TB1.RowCount = 5
        Me.TB1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TB1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TB1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TB1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TB1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TB1.Size = New System.Drawing.Size(984, 611)
        Me.TB1.TabIndex = 37
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label18.Location = New System.Drawing.Point(52, 193)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(879, 20)
        Me.Label18.TabIndex = 2
        Me.Label18.Text = "Desarrolladores"
        '
        'DGDevelopers
        '
        Me.DGDevelopers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGDevelopers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGDevelopers.Location = New System.Drawing.Point(52, 216)
        Me.DGDevelopers.Name = "DGDevelopers"
        Me.DGDevelopers.Size = New System.Drawing.Size(879, 360)
        Me.DGDevelopers.TabIndex = 8
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 9
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.5!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.5!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label20, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BTNEliminar, 7, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.Label21, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BTNMod, 5, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.Label22, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label23, 7, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TBRol, 7, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.BTNCrear, 3, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.Refresh, 1, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.TBApellido, 5, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.TBID, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.TBNombre, 3, 2)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(52, 33)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 5
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.58621!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.896552!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(879, 116)
        Me.TableLayoutPanel2.TabIndex = 3
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(24, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(169, 23)
        Me.Label20.TabIndex = 8
        Me.Label20.Text = "ID"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BTNEliminar
        '
        Me.BTNEliminar.BackColor = System.Drawing.Color.Silver
        Me.BTNEliminar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BTNEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BTNEliminar.Location = New System.Drawing.Point(678, 71)
        Me.BTNEliminar.Name = "BTNEliminar"
        Me.BTNEliminar.Size = New System.Drawing.Size(169, 42)
        Me.BTNEliminar.TabIndex = 10
        Me.BTNEliminar.Text = "Eliminar"
        Me.BTNEliminar.UseVisualStyleBackColor = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(242, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(169, 23)
        Me.Label21.TabIndex = 9
        Me.Label21.Text = "Nombre"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BTNMod
        '
        Me.BTNMod.BackColor = System.Drawing.Color.Silver
        Me.BTNMod.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BTNMod.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BTNMod.Location = New System.Drawing.Point(460, 71)
        Me.BTNMod.Name = "BTNMod"
        Me.BTNMod.Size = New System.Drawing.Size(169, 42)
        Me.BTNMod.TabIndex = 9
        Me.BTNMod.Text = "Modificar"
        Me.BTNMod.UseVisualStyleBackColor = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(460, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(169, 23)
        Me.Label22.TabIndex = 15
        Me.Label22.Text = "Apellido"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(678, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(169, 23)
        Me.Label23.TabIndex = 16
        Me.Label23.Text = "Rol"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BTNCrear
        '
        Me.BTNCrear.BackColor = System.Drawing.Color.Silver
        Me.BTNCrear.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BTNCrear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BTNCrear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BTNCrear.Location = New System.Drawing.Point(242, 71)
        Me.BTNCrear.Name = "BTNCrear"
        Me.BTNCrear.Size = New System.Drawing.Size(169, 42)
        Me.BTNCrear.TabIndex = 4
        Me.BTNCrear.Text = "Crear"
        Me.BTNCrear.UseVisualStyleBackColor = False
        '
        'Refresh
        '
        Me.Refresh.BackColor = System.Drawing.Color.Silver
        Me.Refresh.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Refresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Refresh.Location = New System.Drawing.Point(24, 71)
        Me.Refresh.Name = "Refresh"
        Me.Refresh.Size = New System.Drawing.Size(169, 42)
        Me.Refresh.TabIndex = 19
        Me.Refresh.Text = "Refrescar"
        Me.Refresh.UseVisualStyleBackColor = False
        '
        'Desarrolladores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FloralWhite
        Me.ClientSize = New System.Drawing.Size(984, 611)
        Me.Controls.Add(Me.TB1)
        Me.MinimumSize = New System.Drawing.Size(1000, 650)
        Me.Name = "Desarrolladores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Desarrolladores"
        CType(Me.TBID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TB1.ResumeLayout(False)
        Me.TB1.PerformLayout()
        CType(Me.DGDevelopers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TBNombre As TextBox
    Friend WithEvents TBApellido As TextBox
    Friend WithEvents TBRol As TextBox
    Friend WithEvents TBID As NumericUpDown
    Friend WithEvents TB1 As TableLayoutPanel
    Friend WithEvents Label18 As Label
    Friend WithEvents DGDevelopers As DataGridView
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Label20 As Label
    Friend WithEvents BTNEliminar As Button
    Friend WithEvents Label21 As Label
    Friend WithEvents BTNMod As Button
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents BTNCrear As Button
    Friend WithEvents Refresh As Button
End Class
