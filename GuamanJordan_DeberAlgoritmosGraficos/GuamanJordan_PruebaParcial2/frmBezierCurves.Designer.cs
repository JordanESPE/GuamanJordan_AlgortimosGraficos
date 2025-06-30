namespace GuamanJordan_PruebaParcial2
{
    partial class frmBezierCurves
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.btnAnimar = new System.Windows.Forms.Button();
            this.btnMostrarConstruccion = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.panelCanvas = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblInstrucciones = new System.Windows.Forms.Label();
            this.lblTablaPuntosControl = new System.Windows.Forms.Label();
            this.dgvPuntosControl = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPuntosControl)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAnimar
            // 
            this.btnAnimar.BackColor = System.Drawing.Color.LightGreen;
            this.btnAnimar.Enabled = false;
            this.btnAnimar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnAnimar.Location = new System.Drawing.Point(12, 80);
            this.btnAnimar.Name = "btnAnimar";
            this.btnAnimar.Size = new System.Drawing.Size(200, 40);
            this.btnAnimar.TabIndex = 0;
            this.btnAnimar.Text = "Animar Curva";
            this.btnAnimar.UseVisualStyleBackColor = false;
            this.btnAnimar.Click += new System.EventHandler(this.btnAnimar_Click);
            // 
            // btnMostrarConstruccion
            // 
            this.btnMostrarConstruccion.BackColor = System.Drawing.Color.LightBlue;
            this.btnMostrarConstruccion.Enabled = false;
            this.btnMostrarConstruccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnMostrarConstruccion.Location = new System.Drawing.Point(12, 130);
            this.btnMostrarConstruccion.Name = "btnMostrarConstruccion";
            this.btnMostrarConstruccion.Size = new System.Drawing.Size(200, 40);
            this.btnMostrarConstruccion.TabIndex = 1;
            this.btnMostrarConstruccion.Text = "Mostrar Construcción";
            this.btnMostrarConstruccion.UseVisualStyleBackColor = false;
            this.btnMostrarConstruccion.Click += new System.EventHandler(this.btnMostrarConstruccion_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.LightCoral;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.Location = new System.Drawing.Point(12, 180);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(200, 40);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "Limpiar Canvas";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // panelCanvas
            // 
            this.panelCanvas.BackColor = System.Drawing.Color.White;
            this.panelCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCanvas.Location = new System.Drawing.Point(230, 12);
            this.panelCanvas.Name = "panelCanvas";
            this.panelCanvas.Size = new System.Drawing.Size(640, 480);
            this.panelCanvas.TabIndex = 3;
            this.panelCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCanvas_Paint);
            this.panelCanvas.Resize += new System.EventHandler(this.panelCanvas_Resize);
            this.panelCanvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelCanvas_MouseClick);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblInfo.Location = new System.Drawing.Point(230, 505);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(250, 18);
            this.lblInfo.TabIndex = 4;
            this.lblInfo.Text = "Información del estado";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(12, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(200, 25);
            this.lblTitulo.TabIndex = 5;
            this.lblTitulo.Text = "Curvas de Bézier";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInstrucciones
            // 
            this.lblInstrucciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblInstrucciones.Location = new System.Drawing.Point(12, 40);
            this.lblInstrucciones.Name = "lblInstrucciones";
            this.lblInstrucciones.Size = new System.Drawing.Size(200, 35);
            this.lblInstrucciones.TabIndex = 6;
            this.lblInstrucciones.Text = "Haga clic para agregar puntos de control";
            this.lblInstrucciones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTablaPuntosControl
            // 
            this.lblTablaPuntosControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTablaPuntosControl.Location = new System.Drawing.Point(12, 240);
            this.lblTablaPuntosControl.Name = "lblTablaPuntosControl";
            this.lblTablaPuntosControl.Size = new System.Drawing.Size(200, 20);
            this.lblTablaPuntosControl.TabIndex = 7;
            this.lblTablaPuntosControl.Text = "Puntos de Control";
            this.lblTablaPuntosControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvPuntosControl
            // 
            this.dgvPuntosControl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPuntosControl.Location = new System.Drawing.Point(12, 265);
            this.dgvPuntosControl.Name = "dgvPuntosControl";
            this.dgvPuntosControl.Size = new System.Drawing.Size(200, 120);
            this.dgvPuntosControl.TabIndex = 8;
            // 
            // frmBezierCurves
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 541);
            this.Controls.Add(this.lblTablaPuntosControl);
            this.Controls.Add(this.dgvPuntosControl);
            this.Controls.Add(this.lblInstrucciones);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.panelCanvas);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnMostrarConstruccion);
            this.Controls.Add(this.btnAnimar);
            this.Name = "frmBezierCurves";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Curvas de Bézier - Algoritmos Gráficos";
            this.Load += new System.EventHandler(this.frmBezierCurves_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPuntosControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnAnimar;
        private System.Windows.Forms.Button btnMostrarConstruccion;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Panel panelCanvas;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblInstrucciones;
        private System.Windows.Forms.Label lblTablaPuntosControl;
        private System.Windows.Forms.DataGridView dgvPuntosControl;
    }
}