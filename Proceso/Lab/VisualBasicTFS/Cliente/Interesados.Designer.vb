<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Interesados
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
        Me.CBNiveles = New System.Windows.Forms.ComboBox()
        Me.BTNCrear = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TBApellido = New System.Windows.Forms.TextBox()
        Me.BTNActualizar = New System.Windows.Forms.Button()
        Me.BTNEliminar = New System.Windows.Forms.Button()
        Me.TBID = New System.Windows.Forms.NumericUpDown()
        Me.TB1 = New System.Windows.Forms.TableLayoutPanel()
        Me.DGInteresados = New System.Windows.Forms.DataGridView()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Refresh = New System.Windows.Forms.Button()
        CType(Me.TBID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TB1.SuspendLayout()
        CType(Me.DGInteresados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TBNombre
        '
        Me.TBNombre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TBNombre.ForeColor = System.Drawing.SystemColors.InfoText
        Me.TBNombre.Location = New System.Drawing.Point(242, 31)
        Me.TBNombre.Multiline = True
        Me.TBNombre.Name = "TBNombre"
        Me.TBNombre.Size = New System.Drawing.Size(169, 26)
        Me.TBNombre.TabIndex = 2
        '
        'CBNiveles
        '
        Me.CBNiveles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CBNiveles.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBNiveles.ForeColor = System.Drawing.SystemColors.InfoText
        Me.CBNiveles.FormattingEnabled = True
        Me.CBNiveles.Items.AddRange(New Object() {"Alto", "Medio", "Bajo"})
        Me.CBNiveles.Location = New System.Drawing.Point(678, 31)
        Me.CBNiveles.Name = "CBNiveles"
        Me.CBNiveles.Size = New System.Drawing.Size(169, 24)
        Me.CBNiveles.TabIndex = 4
        Me.CBNiveles.Text = "Seleccione un nivel"
        '
        'BTNCrear
        '
        Me.BTNCrear.BackColor = System.Drawing.Color.Silver
        Me.BTNCrear.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BTNCrear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BTNCrear.Location = New System.Drawing.Point(242, 71)
        Me.BTNCrear.Name = "BTNCrear"
        Me.BTNCrear.Size = New System.Drawing.Size(169, 42)
        Me.BTNCrear.TabIndex = 6
        Me.BTNCrear.Text = "Registrar"
        Me.BTNCrear.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(78, 284)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 13)
        Me.Label4.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(78, 331)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 13)
        Me.Label5.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(81, 331)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(0, 13)
        Me.Label9.TabIndex = 14
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(84, 254)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(0, 13)
        Me.Label11.TabIndex = 16
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(89, 331)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(0, 13)
        Me.Label12.TabIndex = 17
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(76, 401)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(0, 13)
        Me.Label13.TabIndex = 18
        '
        'TBApellido
        '
        Me.TBApellido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TBApellido.Location = New System.Drawing.Point(460, 31)
        Me.TBApellido.Multiline = True
        Me.TBApellido.Name = "TBApellido"
        Me.TBApellido.Size = New System.Drawing.Size(169, 26)
        Me.TBApellido.TabIndex = 20
        '
        'BTNActualizar
        '
        Me.BTNActualizar.BackColor = System.Drawing.Color.Silver
        Me.BTNActualizar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BTNActualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BTNActualizar.Location = New System.Drawing.Point(460, 71)
        Me.BTNActualizar.Name = "BTNActualizar"
        Me.BTNActualizar.Size = New System.Drawing.Size(169, 42)
        Me.BTNActualizar.TabIndex = 23
        Me.BTNActualizar.Text = "Modificar"
        Me.BTNActualizar.UseVisualStyleBackColor = False
        '
        'BTNEliminar
        '
        Me.BTNEliminar.BackColor = System.Drawing.Color.Silver
        Me.BTNEliminar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BTNEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BTNEliminar.Location = New System.Drawing.Point(678, 71)
        Me.BTNEliminar.Name = "BTNEliminar"
        Me.BTNEliminar.Size = New System.Drawing.Size(169, 42)
        Me.BTNEliminar.TabIndex = 24
        Me.BTNEliminar.Text = "Eliminar"
        Me.BTNEliminar.UseVisualStyleBackColor = False
        '
        'TBID
        '
        Me.TBID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TBID.Enabled = False
        Me.TBID.Location = New System.Drawing.Point(24, 31)
        Me.TBID.Name = "TBID"
        Me.TBID.Size = New System.Drawing.Size(169, 20)
        Me.TBID.TabIndex = 34
        '
        'TB1
        '
        Me.TB1.ColumnCount = 3
        Me.TB1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TB1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.0!))
        Me.TB1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TB1.Controls.Add(Me.DGInteresados, 1, 3)
        Me.TB1.Controls.Add(Me.Label18, 1, 2)
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
        Me.TB1.TabIndex = 36
        '
        'DGInteresados
        '
        Me.DGInteresados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGInteresados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGInteresados.Location = New System.Drawing.Point(52, 216)
        Me.DGInteresados.Name = "DGInteresados"
        Me.DGInteresados.Size = New System.Drawing.Size(879, 360)
        Me.DGInteresados.TabIndex = 1
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
        Me.Label18.Text = "Interesados"
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
        Me.TableLayoutPanel2.Controls.Add(Me.TBID, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label21, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label22, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label23, 7, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BTNEliminar, 7, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.BTNActualizar, 5, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.Refresh, 1, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.TBApellido, 5, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.BTNCrear, 3, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.TBNombre, 3, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.CBNiveles, 7, 2)
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
        Me.Label23.Text = "Nivel de interes"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'Interesados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FloralWhite
        Me.ClientSize = New System.Drawing.Size(984, 611)
        Me.Controls.Add(Me.TB1)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.MinimumSize = New System.Drawing.Size(1000, 650)
        Me.Name = "Interesados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Interesados"
        CType(Me.TBID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TB1.ResumeLayout(False)
        Me.TB1.PerformLayout()
        CType(Me.DGInteresados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TBNombre As TextBox
    Friend WithEvents CBNiveles As ComboBox
    Friend WithEvents BTNCrear As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents TBApellido As TextBox
    Friend WithEvents BTNActualizar As Button
    Friend WithEvents BTNEliminar As Button
    Friend WithEvents TBID As NumericUpDown
    Friend WithEvents TB1 As TableLayoutPanel
    Friend WithEvents DGInteresados As DataGridView
    Friend WithEvents Label18 As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Refresh As Button
End Class
