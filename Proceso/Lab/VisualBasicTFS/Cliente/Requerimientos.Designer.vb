﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Requerimientos
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TB1 = New System.Windows.Forms.TableLayoutPanel()
        Me.DGRequerimientos = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.BTNCrear = New System.Windows.Forms.Button()
        Me.BTNActualizar = New System.Windows.Forms.Button()
        Me.BTNEliminar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TBID = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TBNombre = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CBCategoria = New System.Windows.Forms.ComboBox()
        Me.CBTipo = New System.Windows.Forms.ComboBox()
        Me.Refresh = New System.Windows.Forms.Button()
        Me.TB1.SuspendLayout()
        CType(Me.DGRequerimientos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.TBID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TB1
        '
        Me.TB1.ColumnCount = 3
        Me.TB1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TB1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.0!))
        Me.TB1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TB1.Controls.Add(Me.DGRequerimientos, 1, 3)
        Me.TB1.Controls.Add(Me.Label1, 1, 2)
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
        Me.TB1.TabIndex = 1
        '
        'DGRequerimientos
        '
        Me.DGRequerimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGRequerimientos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGRequerimientos.Location = New System.Drawing.Point(52, 216)
        Me.DGRequerimientos.Name = "DGRequerimientos"
        Me.DGRequerimientos.Size = New System.Drawing.Size(879, 360)
        Me.DGRequerimientos.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(52, 193)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(879, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Requerimientos"
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
        Me.TableLayoutPanel2.Controls.Add(Me.BTNCrear, 3, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.BTNActualizar, 5, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.BTNEliminar, 7, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TBID, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TBNombre, 3, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 7, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.CBCategoria, 7, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.CBTipo, 5, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Refresh, 1, 4)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(52, 33)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 5
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(879, 116)
        Me.TableLayoutPanel2.TabIndex = 3
        '
        'BTNCrear
        '
        Me.BTNCrear.BackColor = System.Drawing.Color.Silver
        Me.BTNCrear.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BTNCrear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCrear.Location = New System.Drawing.Point(242, 71)
        Me.BTNCrear.Name = "BTNCrear"
        Me.BTNCrear.Size = New System.Drawing.Size(169, 42)
        Me.BTNCrear.TabIndex = 1
        Me.BTNCrear.Text = "Crear"
        Me.BTNCrear.UseVisualStyleBackColor = False
        '
        'BTNActualizar
        '
        Me.BTNActualizar.BackColor = System.Drawing.Color.Silver
        Me.BTNActualizar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BTNActualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNActualizar.Location = New System.Drawing.Point(460, 71)
        Me.BTNActualizar.Name = "BTNActualizar"
        Me.BTNActualizar.Size = New System.Drawing.Size(169, 42)
        Me.BTNActualizar.TabIndex = 2
        Me.BTNActualizar.Text = "Actualizar"
        Me.BTNActualizar.UseVisualStyleBackColor = False
        '
        'BTNEliminar
        '
        Me.BTNEliminar.BackColor = System.Drawing.Color.Silver
        Me.BTNEliminar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BTNEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNEliminar.Location = New System.Drawing.Point(678, 71)
        Me.BTNEliminar.Name = "BTNEliminar"
        Me.BTNEliminar.Size = New System.Drawing.Size(169, 42)
        Me.BTNEliminar.TabIndex = 3
        Me.BTNEliminar.Text = "Eliminar"
        Me.BTNEliminar.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(169, 23)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "ID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TBID
        '
        Me.TBID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TBID.Enabled = False
        Me.TBID.Location = New System.Drawing.Point(24, 31)
        Me.TBID.Name = "TBID"
        Me.TBID.Size = New System.Drawing.Size(169, 20)
        Me.TBID.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(242, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(169, 23)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Nombre"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TBNombre
        '
        Me.TBNombre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TBNombre.Location = New System.Drawing.Point(242, 31)
        Me.TBNombre.Name = "TBNombre"
        Me.TBNombre.Size = New System.Drawing.Size(169, 20)
        Me.TBNombre.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(460, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(169, 23)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Tipo"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(678, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(169, 23)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Categoria"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CBCategoria
        '
        Me.CBCategoria.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CBCategoria.FormattingEnabled = True
        Me.CBCategoria.Location = New System.Drawing.Point(678, 31)
        Me.CBCategoria.Name = "CBCategoria"
        Me.CBCategoria.Size = New System.Drawing.Size(169, 21)
        Me.CBCategoria.TabIndex = 17
        '
        'CBTipo
        '
        Me.CBTipo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CBTipo.FormattingEnabled = True
        Me.CBTipo.Location = New System.Drawing.Point(460, 31)
        Me.CBTipo.Name = "CBTipo"
        Me.CBTipo.Size = New System.Drawing.Size(169, 21)
        Me.CBTipo.TabIndex = 18
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
        'Requerimientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FloralWhite
        Me.ClientSize = New System.Drawing.Size(984, 611)
        Me.Controls.Add(Me.TB1)
        Me.MinimumSize = New System.Drawing.Size(850, 550)
        Me.Name = "Requerimientos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Requerimientos"
        Me.TB1.ResumeLayout(False)
        Me.TB1.PerformLayout()
        CType(Me.DGRequerimientos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.TBID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TB1 As TableLayoutPanel
    Friend WithEvents DGRequerimientos As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents BTNCrear As Button
    Friend WithEvents BTNActualizar As Button
    Friend WithEvents BTNEliminar As Button
    Friend WithEvents TBNombre As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TBID As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents CBCategoria As ComboBox
    Friend WithEvents CBTipo As ComboBox
    Friend WithEvents Refresh As Button
End Class
