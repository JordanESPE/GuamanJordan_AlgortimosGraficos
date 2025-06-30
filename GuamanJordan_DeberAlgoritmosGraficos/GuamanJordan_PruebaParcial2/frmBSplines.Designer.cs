namespace GuamanJordan_PruebaParcial2
{
    partial class frmBSplines
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador

        private void InitializeComponent()
        {
            this.panelDibujo = new System.Windows.Forms.Panel();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblInstrucciones = new System.Windows.Forms.Label();
            this.lstPuntos = new System.Windows.Forms.ListBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.grpControles = new System.Windows.Forms.GroupBox();
            this.grpPuntos = new System.Windows.Forms.GroupBox();
            this.lblTablaPuntosControl = new System.Windows.Forms.Label();
            this.dgvPuntosControl = new System.Windows.Forms.DataGridView();
            this.grpControles.SuspendLayout();
            this.grpPuntos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPuntosControl)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDibujo
            // 
            this.panelDibujo.BackColor = System.Drawing.Color.White;
            this.panelDibujo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.panelDibujo.Cursor = System.Windows.Forms.Cursors.Cross;
            this.panelDibujo.Location = new System.Drawing.Point(20, 60);
            this.panelDibujo.Name = "panelDibujo";
            this.panelDibujo.Size = new System.Drawing.Size(500, 400);
            this.panelDibujo.TabIndex = 0;
            this.panelDibujo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDibujo_Paint);
            this.panelDibujo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelDibujo_MouseClick);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(15, 120);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(130, 35);
            this.btnLimpiar.TabIndex = 1;
            this.btnLimpiar.Text = "🗑️ Limpiar Todo";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(15, 80);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(130, 35);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "❌ Eliminar Último";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // lblInstrucciones
            // 
            this.lblInstrucciones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInstrucciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblInstrucciones.Location = new System.Drawing.Point(15, 25);
            this.lblInstrucciones.Name = "lblInstrucciones";
            this.lblInstrucciones.Size = new System.Drawing.Size(130, 50);
            this.lblInstrucciones.TabIndex = 4;
            this.lblInstrucciones.Text = "✨ Haz clic en el panel para agregar puntos de control";
            this.lblInstrucciones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstPuntos
            // 
            this.lstPuntos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.lstPuntos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstPuntos.Font = new System.Drawing.Font("Consolas", 8F);
            this.lstPuntos.FormattingEnabled = true;
            this.lstPuntos.ItemHeight = 15;
            this.lstPuntos.Location = new System.Drawing.Point(15, 25);
            this.lstPuntos.Name = "lstPuntos";
            this.lstPuntos.Size = new System.Drawing.Size(130, 165);
            this.lstPuntos.TabIndex = 3;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(696, 35);
            this.lblTitulo.TabIndex = 5;
            this.lblTitulo.Text = "🎨 Visualizador Interactivo de Curvas B-Spline";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpControles
            // 
            this.grpControles.Controls.Add(this.lblInstrucciones);
            this.grpControles.Controls.Add(this.btnEliminar);
            this.grpControles.Controls.Add(this.btnLimpiar);
            this.grpControles.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpControles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.grpControles.Location = new System.Drawing.Point(540, 60);
            this.grpControles.Name = "grpControles";
            this.grpControles.Size = new System.Drawing.Size(160, 180);
            this.grpControles.TabIndex = 6;
            this.grpControles.TabStop = false;
            this.grpControles.Text = "⚙️ Controles";
            // 
            // grpPuntos
            // 
            this.grpPuntos.Controls.Add(this.lstPuntos);
            this.grpPuntos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpPuntos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.grpPuntos.Location = new System.Drawing.Point(540, 250);
            this.grpPuntos.Name = "grpPuntos";
            this.grpPuntos.Size = new System.Drawing.Size(160, 210);
            this.grpPuntos.TabIndex = 7;
            this.grpPuntos.TabStop = false;
            this.grpPuntos.Text = "📍 Puntos de Control";
            // 
            // lblTablaPuntosControl
            // 
            this.lblTablaPuntosControl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTablaPuntosControl.Location = new System.Drawing.Point(540, 470);
            this.lblTablaPuntosControl.Name = "lblTablaPuntosControl";
            this.lblTablaPuntosControl.Size = new System.Drawing.Size(160, 20);
            this.lblTablaPuntosControl.TabIndex = 8;
            this.lblTablaPuntosControl.Text = "Tabla de Puntos";
            this.lblTablaPuntosControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvPuntosControl
            // 
            this.dgvPuntosControl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPuntosControl.Location = new System.Drawing.Point(540, 495);
            this.dgvPuntosControl.Name = "dgvPuntosControl";
            this.dgvPuntosControl.Size = new System.Drawing.Size(160, 120);
            this.dgvPuntosControl.TabIndex = 9;
            // 
            // frmBSplines
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(720, 630);
            this.Controls.Add(this.lblTablaPuntosControl);
            this.Controls.Add(this.dgvPuntosControl);
            this.Controls.Add(this.grpPuntos);
            this.Controls.Add(this.grpControles);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panelDibujo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmBSplines";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "B-Splines Interactivo - GuamanJordan";
            this.Load += new System.EventHandler(this.frmBSplines_Load);
            this.grpControles.ResumeLayout(false);
            this.grpPuntos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPuntosControl)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelDibujo;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblInstrucciones;
        private System.Windows.Forms.ListBox lstPuntos;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox grpControles;
        private System.Windows.Forms.GroupBox grpPuntos;
        private System.Windows.Forms.Label lblTablaPuntosControl;
        private System.Windows.Forms.DataGridView dgvPuntosControl;
    }
}