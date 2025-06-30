namespace GuamanJordan_PruebaParcial2
{
    partial class frmFloodFill
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
            this.btnRellenar = new System.Windows.Forms.Button();
            this.btnCerrarFigura = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.panelCanvas = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRellenar
            // 
            this.btnRellenar.BackColor = System.Drawing.Color.LightGreen;
            this.btnRellenar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnRellenar.Location = new System.Drawing.Point(12, 12);
            this.btnRellenar.Name = "btnRellenar";
            this.btnRellenar.Size = new System.Drawing.Size(200, 45);
            this.btnRellenar.TabIndex = 0;
            this.btnRellenar.Text = "Modo Relleno";
            this.btnRellenar.UseVisualStyleBackColor = false;
            this.btnRellenar.Click += new System.EventHandler(this.btnRellenar_Click);
            // 
            // btnCerrarFigura
            // 
            this.btnCerrarFigura.BackColor = System.Drawing.Color.LightBlue;
            this.btnCerrarFigura.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnCerrarFigura.Location = new System.Drawing.Point(12, 70);
            this.btnCerrarFigura.Name = "btnCerrarFigura";
            this.btnCerrarFigura.Size = new System.Drawing.Size(200, 45);
            this.btnCerrarFigura.TabIndex = 1;
            this.btnCerrarFigura.Text = "Cerrar Figura";
            this.btnCerrarFigura.UseVisualStyleBackColor = false;
            this.btnCerrarFigura.Click += new System.EventHandler(this.btnCerrarFigura_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.LightCoral;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.Location = new System.Drawing.Point(12, 128);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(200, 45);
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
            this.lblInfo.Text = "Haga clic para colocar puntos";
            // 
            // frmFloodFill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 541);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.panelCanvas);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnCerrarFigura);
            this.Controls.Add(this.btnRellenar);
            this.Name = "frmFloodFill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Algoritmo Flood Fill - Relleno por Inundación";
            this.Load += new System.EventHandler(this.frmFloodFill_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnRellenar;
        private System.Windows.Forms.Button btnCerrarFigura;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Panel panelCanvas;
        private System.Windows.Forms.Label lblInfo;
    }
}