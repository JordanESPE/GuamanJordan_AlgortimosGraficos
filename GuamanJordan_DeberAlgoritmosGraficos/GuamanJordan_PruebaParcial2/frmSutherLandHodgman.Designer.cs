namespace GuamanJordan_PruebaParcial2
{
    partial class frmSutherLandHodgman
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
            this.btnCerrarPoligono = new System.Windows.Forms.Button();
            this.btnRecortar = new System.Windows.Forms.Button();
            this.btnMostrarOriginal = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.panelCanvas = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblTablaOriginales = new System.Windows.Forms.Label();
            this.dgvVerticesOriginales = new System.Windows.Forms.DataGridView();
            this.lblTablaRecortados = new System.Windows.Forms.Label();
            this.dgvVerticesRecortados = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVerticesOriginales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVerticesRecortados)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCerrarPoligono
            // 
            this.btnCerrarPoligono.BackColor = System.Drawing.Color.LightYellow;
            this.btnCerrarPoligono.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnCerrarPoligono.Location = new System.Drawing.Point(12, 50);
            this.btnCerrarPoligono.Name = "btnCerrarPoligono";
            this.btnCerrarPoligono.Size = new System.Drawing.Size(200, 40);
            this.btnCerrarPoligono.TabIndex = 0;
            this.btnCerrarPoligono.Text = "Cerrar Polígono";
            this.btnCerrarPoligono.UseVisualStyleBackColor = false;
            this.btnCerrarPoligono.Click += new System.EventHandler(this.btnCerrarPoligono_Click);
            // 
            // btnRecortar
            // 
            this.btnRecortar.BackColor = System.Drawing.Color.LightGreen;
            this.btnRecortar.Enabled = false;
            this.btnRecortar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnRecortar.Location = new System.Drawing.Point(12, 100);
            this.btnRecortar.Name = "btnRecortar";
            this.btnRecortar.Size = new System.Drawing.Size(200, 40);
            this.btnRecortar.TabIndex = 1;
            this.btnRecortar.Text = "Aplicar Recorte";
            this.btnRecortar.UseVisualStyleBackColor = false;
            this.btnRecortar.Click += new System.EventHandler(this.btnRecortar_Click);
            // 
            // btnMostrarOriginal
            // 
            this.btnMostrarOriginal.BackColor = System.Drawing.Color.LightBlue;
            this.btnMostrarOriginal.Enabled = false;
            this.btnMostrarOriginal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnMostrarOriginal.Location = new System.Drawing.Point(12, 150);
            this.btnMostrarOriginal.Name = "btnMostrarOriginal";
            this.btnMostrarOriginal.Size = new System.Drawing.Size(200, 40);
            this.btnMostrarOriginal.TabIndex = 2;
            this.btnMostrarOriginal.Text = "Mostrar Original";
            this.btnMostrarOriginal.UseVisualStyleBackColor = false;
            this.btnMostrarOriginal.Click += new System.EventHandler(this.btnMostrarOriginal_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.LightCoral;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.Location = new System.Drawing.Point(12, 200);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(200, 40);
            this.btnLimpiar.TabIndex = 3;
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
            this.panelCanvas.TabIndex = 4;
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
            this.lblInfo.TabIndex = 5;
            this.lblInfo.Text = "Información del estado";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(12, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(200, 30);
            this.lblTitulo.TabIndex = 6;
            this.lblTitulo.Text = "Sutherland-Hodgman";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTablaOriginales
            // 
            this.lblTablaOriginales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTablaOriginales.Location = new System.Drawing.Point(12, 260);
            this.lblTablaOriginales.Name = "lblTablaOriginales";
            this.lblTablaOriginales.Size = new System.Drawing.Size(200, 20);
            this.lblTablaOriginales.TabIndex = 7;
            this.lblTablaOriginales.Text = "Vértices Originales";
            this.lblTablaOriginales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvVerticesOriginales
            // 
            this.dgvVerticesOriginales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVerticesOriginales.Location = new System.Drawing.Point(12, 285);
            this.dgvVerticesOriginales.Name = "dgvVerticesOriginales";
            this.dgvVerticesOriginales.Size = new System.Drawing.Size(200, 100);
            this.dgvVerticesOriginales.TabIndex = 8;
            // 
            // lblTablaRecortados
            // 
            this.lblTablaRecortados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTablaRecortados.Location = new System.Drawing.Point(12, 390);
            this.lblTablaRecortados.Name = "lblTablaRecortados";
            this.lblTablaRecortados.Size = new System.Drawing.Size(200, 20);
            this.lblTablaRecortados.TabIndex = 9;
            this.lblTablaRecortados.Text = "Vértices Recortados";
            this.lblTablaRecortados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvVerticesRecortados
            // 
            this.dgvVerticesRecortados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVerticesRecortados.Location = new System.Drawing.Point(12, 415);
            this.dgvVerticesRecortados.Name = "dgvVerticesRecortados";
            this.dgvVerticesRecortados.Size = new System.Drawing.Size(200, 100);
            this.dgvVerticesRecortados.TabIndex = 10;
            // 
            // frmSutherLandHodgman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 541);
            this.Controls.Add(this.lblTablaRecortados);
            this.Controls.Add(this.dgvVerticesRecortados);
            this.Controls.Add(this.lblTablaOriginales);
            this.Controls.Add(this.dgvVerticesOriginales);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.panelCanvas);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnMostrarOriginal);
            this.Controls.Add(this.btnRecortar);
            this.Controls.Add(this.btnCerrarPoligono);
            this.Name = "frmSutherLandHodgman";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Algoritmo Sutherland-Hodgman - Recorte de Polígonos";
            this.Load += new System.EventHandler(this.frmSutherLandHodgman_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVerticesOriginales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVerticesRecortados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnCerrarPoligono;
        private System.Windows.Forms.Button btnRecortar;
        private System.Windows.Forms.Button btnMostrarOriginal;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Panel panelCanvas;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblTablaOriginales;
        private System.Windows.Forms.DataGridView dgvVerticesOriginales;
        private System.Windows.Forms.Label lblTablaRecortados;
        private System.Windows.Forms.DataGridView dgvVerticesRecortados;
    }
}