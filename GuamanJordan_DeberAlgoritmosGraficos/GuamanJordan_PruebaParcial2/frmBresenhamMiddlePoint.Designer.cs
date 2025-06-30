namespace GuamanJordan_PruebaParcial2
{
    partial class frmBresenhamMiddlePoint
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelCanvas;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView dgvCoordenadas;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelCanvas = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dgvCoordenadas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoordenadas)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCanvas
            // 
            this.panelCanvas.BackColor = System.Drawing.Color.White;
            this.panelCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCanvas.Location = new System.Drawing.Point(12, 12);
            this.panelCanvas.Name = "panelCanvas";
            this.panelCanvas.Size = new System.Drawing.Size(640, 480);
            this.panelCanvas.TabIndex = 0;
            this.panelCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCanvas_Paint);
            this.panelCanvas.Resize += new System.EventHandler(this.panelCanvas_Resize);
            this.panelCanvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelCanvas_MouseClick);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblInfo.Location = new System.Drawing.Point(12, 505);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(301, 18);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Haz clic para definir el radio desde el centro";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.LightCoral;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.Location = new System.Drawing.Point(670, 12);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(140, 45);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // dgvCoordenadas
            // 
            this.dgvCoordenadas.AllowUserToAddRows = false;
            this.dgvCoordenadas.AllowUserToDeleteRows = false;
            this.dgvCoordenadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCoordenadas.Location = new System.Drawing.Point(670, 70);
            this.dgvCoordenadas.Name = "dgvCoordenadas";
            this.dgvCoordenadas.RowHeadersVisible = false;
            this.dgvCoordenadas.RowTemplate.Height = 24;
            this.dgvCoordenadas.Size = new System.Drawing.Size(140, 422);
            this.dgvCoordenadas.TabIndex = 3;
            // 
            // frmBresenhamMiddlePoint
            // 
            this.ClientSize = new System.Drawing.Size(824, 541);
            this.Controls.Add(this.dgvCoordenadas);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.panelCanvas);
            this.Name = "frmBresenhamMiddlePoint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Algoritmo Punto Medio - Dibujo de Círculos";
            this.Load += new System.EventHandler(this.frmBresenhamMiddlePoint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoordenadas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
