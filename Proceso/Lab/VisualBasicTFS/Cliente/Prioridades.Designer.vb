<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Prioridades
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.CBRequerimientos = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TBBeneficio = New System.Windows.Forms.TextBox()
        Me.TBPenalidad = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Interesados = New System.Windows.Forms.Button()
        Me.Desarrolladores = New System.Windows.Forms.Button()
        Me.Requerimientos = New System.Windows.Forms.Button()
        Me.Categorias = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TBCosto = New System.Windows.Forms.TextBox()
        Me.TBRiesgo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.BTNDecartar = New System.Windows.Forms.Button()
        Me.BTNCalcular = New System.Windows.Forms.Button()
        Me.DGPrioridades = New System.Windows.Forms.DataGridView()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        CType(Me.DGPrioridades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel4, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.DGPrioridades, 1, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 8
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1034, 681)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 7
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.5!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.5!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.CBRequerimientos, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Label2, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.TBBeneficio, 3, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.TBPenalidad, 5, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Label3, 3, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label4, 5, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(54, 445)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(924, 96)
        Me.TableLayoutPanel4.TabIndex = 4
        '
        'CBRequerimientos
        '
        Me.CBRequerimientos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CBRequerimientos.FormattingEnabled = True
        Me.CBRequerimientos.Location = New System.Drawing.Point(26, 51)
        Me.CBRequerimientos.Name = "CBRequerimientos"
        Me.CBRequerimientos.Size = New System.Drawing.Size(409, 21)
        Me.CBRequerimientos.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(26, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(409, 48)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Requerimiento"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TBBeneficio
        '
        Me.TBBeneficio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TBBeneficio.Location = New System.Drawing.Point(487, 51)
        Me.TBBeneficio.Name = "TBBeneficio"
        Me.TBBeneficio.Size = New System.Drawing.Size(178, 20)
        Me.TBBeneficio.TabIndex = 16
        '
        'TBPenalidad
        '
        Me.TBPenalidad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TBPenalidad.Location = New System.Drawing.Point(717, 51)
        Me.TBPenalidad.Name = "TBPenalidad"
        Me.TBPenalidad.Size = New System.Drawing.Size(178, 20)
        Me.TBPenalidad.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(487, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(178, 48)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Beneficio"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(717, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(178, 48)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Penalidad"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.TableLayoutPanel2.Controls.Add(Me.Interesados, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Desarrolladores, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Requerimientos, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Categorias, 7, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(54, 37)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(924, 62)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Interesados
        '
        Me.Interesados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Interesados.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Interesados.Location = New System.Drawing.Point(26, 3)
        Me.Interesados.Name = "Interesados"
        Me.Interesados.Size = New System.Drawing.Size(178, 56)
        Me.Interesados.TabIndex = 0
        Me.Interesados.Text = "Interesados"
        Me.Interesados.UseVisualStyleBackColor = True
        '
        'Desarrolladores
        '
        Me.Desarrolladores.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Desarrolladores.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Desarrolladores.Location = New System.Drawing.Point(256, 3)
        Me.Desarrolladores.Name = "Desarrolladores"
        Me.Desarrolladores.Size = New System.Drawing.Size(178, 56)
        Me.Desarrolladores.TabIndex = 1
        Me.Desarrolladores.Text = "Desarrolladores"
        Me.Desarrolladores.UseVisualStyleBackColor = True
        '
        'Requerimientos
        '
        Me.Requerimientos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Requerimientos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Requerimientos.Location = New System.Drawing.Point(486, 3)
        Me.Requerimientos.Name = "Requerimientos"
        Me.Requerimientos.Size = New System.Drawing.Size(178, 56)
        Me.Requerimientos.TabIndex = 2
        Me.Requerimientos.Text = "Requerimientos"
        Me.Requerimientos.UseVisualStyleBackColor = True
        '
        'Categorias
        '
        Me.Categorias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Categorias.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Categorias.Location = New System.Drawing.Point(716, 3)
        Me.Categorias.Name = "Categorias"
        Me.Categorias.Size = New System.Drawing.Size(178, 56)
        Me.Categorias.TabIndex = 3
        Me.Categorias.Text = "Categorias"
        Me.Categorias.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(54, 102)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(924, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Prioridades"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel6, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel5, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(54, 547)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 96.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(924, 96)
        Me.TableLayoutPanel3.TabIndex = 3
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 5
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.5!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.5!))
        Me.TableLayoutPanel6.Controls.Add(Me.Label5, 1, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.TBCosto, 1, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.TBRiesgo, 3, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.Label6, 3, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(465, 3)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 2
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.45454!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.54546!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(456, 90)
        Me.TableLayoutPanel6.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(23, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(176, 40)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Costo"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TBCosto
        '
        Me.TBCosto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TBCosto.Location = New System.Drawing.Point(23, 43)
        Me.TBCosto.Name = "TBCosto"
        Me.TBCosto.Size = New System.Drawing.Size(176, 20)
        Me.TBCosto.TabIndex = 18
        '
        'TBRiesgo
        '
        Me.TBRiesgo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TBRiesgo.Location = New System.Drawing.Point(250, 43)
        Me.TBRiesgo.Name = "TBRiesgo"
        Me.TBRiesgo.Size = New System.Drawing.Size(176, 20)
        Me.TBRiesgo.TabIndex = 19
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(250, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(176, 40)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Riesgo"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 2
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.BTNDecartar, 1, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.BTNCalcular, 0, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(456, 90)
        Me.TableLayoutPanel5.TabIndex = 0
        '
        'BTNDecartar
        '
        Me.BTNDecartar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BTNDecartar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNDecartar.Location = New System.Drawing.Point(231, 31)
        Me.BTNDecartar.Name = "BTNDecartar"
        Me.BTNDecartar.Size = New System.Drawing.Size(222, 56)
        Me.BTNDecartar.TabIndex = 5
        Me.BTNDecartar.Text = "Descartar"
        Me.BTNDecartar.UseVisualStyleBackColor = True
        '
        'BTNCalcular
        '
        Me.BTNCalcular.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BTNCalcular.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCalcular.Location = New System.Drawing.Point(3, 31)
        Me.BTNCalcular.Name = "BTNCalcular"
        Me.BTNCalcular.Size = New System.Drawing.Size(222, 56)
        Me.BTNCalcular.TabIndex = 4
        Me.BTNCalcular.Text = "Calcular"
        Me.BTNCalcular.UseVisualStyleBackColor = True
        '
        'DGPrioridades
        '
        Me.DGPrioridades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGPrioridades.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGPrioridades.Location = New System.Drawing.Point(54, 122)
        Me.DGPrioridades.Name = "DGPrioridades"
        Me.DGPrioridades.Size = New System.Drawing.Size(924, 300)
        Me.DGPrioridades.TabIndex = 5
        '
        'Prioridades
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FloralWhite
        Me.ClientSize = New System.Drawing.Size(1034, 681)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.MinimumSize = New System.Drawing.Size(1050, 720)
        Me.Name = "Prioridades"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Main"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        Me.TableLayoutPanel5.ResumeLayout(False)
        CType(Me.DGPrioridades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Interesados As Button
    Friend WithEvents Desarrolladores As Button
    Friend WithEvents Requerimientos As Button
    Friend WithEvents Categorias As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents DGPrioridades As DataGridView
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents CBRequerimientos As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TBBeneficio As TextBox
    Friend WithEvents TBPenalidad As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TBCosto As TextBox
    Friend WithEvents TBRiesgo As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents BTNDecartar As Button
    Friend WithEvents BTNCalcular As Button
End Class
