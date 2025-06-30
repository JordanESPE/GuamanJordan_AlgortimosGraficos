namespace GuamanJordan_PruebaParcial2
{
    partial class frmCohenSutherLand
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
            this.btnRecortar = new System.Windows.Forms.Button();
            this.btnMostrarOriginal = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.panelCanvas = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgvLineasOriginales = new System.Windows.Forms.DataGridView();
            this.dgvLineasRecortadas = new System.Windows.Forms.DataGridView();
            this.lblTablaOriginales = new System.Windows.Forms.Label();
            this.lblTablaRecortadas = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineasOriginales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineasRecortadas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRecortar
            // 
            this.btnRecortar.BackColor = System.Drawing.Color.LightGreen;
            this.btnRecortar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnRecortar.Location = new System.Drawing.Point(12, 50);
            this.btnRecortar.Name = "btnRecortar";
            this.btnRecortar.Size = new System.Drawing.Size(220, 45);
            this.btnRecortar.TabIndex = 0;
            this.btnRecortar.Text = "Aplicar Recorte";
            this.btnRecortar.UseVisualStyleBackColor = false;
            this.btnRecortar.Click += new System.EventHandler(this.btnRecortar_Click);
            // 
            // btnMostrarOriginal
            // 
            this.btnMostrarOriginal.BackColor = System.Drawing.Color.LightBlue;
            this.btnMostrarOriginal.Enabled = false;
            this.btnMostrarOriginal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnMostrarOriginal.Location = new System.Drawing.Point(12, 110);
            this.btnMostrarOriginal.Name = "btnMostrarOriginal";
            this.btnMostrarOriginal.Size = new System.Drawing.Size(220, 45);
            this.btnMostrarOriginal.TabIndex = 1;
            this.btnMostrarOriginal.Text = "Mostrar Original";
            this.btnMostrarOriginal.UseVisualStyleBackColor = false;
            this.btnMostrarOriginal.Click += new System.EventHandler(this.btnMostrarOriginal_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.LightCoral;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.Location = new System.Drawing.Point(12, 170);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(220, 45);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "Limpiar Canvas";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // panelCanvas
            // 
            this.panelCanvas.BackColor = System.Drawing.Color.White;
            this.panelCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCanvas.Location = new System.Drawing.Point(250, 12);
            this.panelCanvas.Name = "panelCanvas";
            this.panelCanvas.Size = new System.Drawing.Size(800, 600);
            this.panelCanvas.TabIndex = 3;
            this.panelCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCanvas_Paint);
            this.panelCanvas.Resize += new System.EventHandler(this.panelCanvas_Resize);
            this.panelCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelCanvas_MouseDown);
            this.panelCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelCanvas_MouseMove);
            this.panelCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelCanvas_MouseUp);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblInfo.Location = new System.Drawing.Point(250, 625);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(250, 18);
            this.lblInfo.TabIndex = 4;
            this.lblInfo.Text = "Información del estado";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(12, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(220, 30);
            this.lblTitulo.TabIndex = 5;
            this.lblTitulo.Text = "Cohen-Sutherland";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTablaOriginales
            // 
            this.lblTablaOriginales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTablaOriginales.Location = new System.Drawing.Point(12, 230);
            this.lblTablaOriginales.Name = "lblTablaOriginales";
            this.lblTablaOriginales.Size = new System.Drawing.Size(220, 20);
            this.lblTablaOriginales.TabIndex = 8;
            this.lblTablaOriginales.Text = "Líneas Originales";
            this.lblTablaOriginales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvLineasOriginales
            // 
            this.dgvLineasOriginales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineasOriginales.Location = new System.Drawing.Point(12, 255);
            this.dgvLineasOriginales.Name = "dgvLineasOriginales";
            this.dgvLineasOriginales.Size = new System.Drawing.Size(220, 120);
            this.dgvLineasOriginales.TabIndex = 6;
            // 
            // lblTablaRecortadas
            // 
            this.lblTablaRecortadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTablaRecortadas.Location = new System.Drawing.Point(12, 390);
            this.lblTablaRecortadas.Name = "lblTablaRecortadas";
            this.lblTablaRecortadas.Size = new System.Drawing.Size(220, 20);
            this.lblTablaRecortadas.TabIndex = 9;
            this.lblTablaRecortadas.Text = "Líneas Recortadas";
            this.lblTablaRecortadas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvLineasRecortadas
            // 
            this.dgvLineasRecortadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineasRecortadas.Location = new System.Drawing.Point(12, 415);
            this.dgvLineasRecortadas.Name = "dgvLineasRecortadas";
            this.dgvLineasRecortadas.Size = new System.Drawing.Size(220, 120);
            this.dgvLineasRecortadas.TabIndex = 7;
            // 
            // frmCohenSutherLand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 670);
            this.Controls.Add(this.lblTablaRecortadas);
            this.Controls.Add(this.lblTablaOriginales);
            this.Controls.Add(this.dgvLineasRecortadas);
            this.Controls.Add(this.dgvLineasOriginales);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.panelCanvas);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnMostrarOriginal);
            this.Controls.Add(this.btnRecortar);
            this.Name = "frmCohenSutherLand";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Algoritmo Cohen-Sutherland - Recorte de Líneas";
            this.Load += new System.EventHandler(this.frmCohenSutherLand_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineasOriginales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineasRecortadas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnRecortar;
        private System.Windows.Forms.Button btnMostrarOriginal;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Panel panelCanvas;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvLineasOriginales;
        private System.Windows.Forms.DataGridView dgvLineasRecortadas;
        private System.Windows.Forms.Label lblTablaOriginales;
        private System.Windows.Forms.Label lblTablaRecortadas;
    }
}