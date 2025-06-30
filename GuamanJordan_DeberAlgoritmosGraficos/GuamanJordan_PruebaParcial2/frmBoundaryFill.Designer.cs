namespace GuamanJordan_PruebaParcial2
{
    partial class frmBoundaryFill
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Controles de formulario
        private System.Windows.Forms.PictureBox pictureBoxCanvas;
        private System.Windows.Forms.Button btnModoDibujo;
        private System.Windows.Forms.Button btnModoRelleno;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnPausar;
        private System.Windows.Forms.Button btnColorRelleno;
        private System.Windows.Forms.Button btnColorBorde;
        private System.Windows.Forms.DataGridView tablaPixeles;
        private System.Windows.Forms.TrackBar velocidadTrackBar;
        private System.Windows.Forms.Label lblVelocidad;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.GroupBox grpControles;
        private System.Windows.Forms.GroupBox grpColores;
        private System.Windows.Forms.GroupBox grpDatos;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (timerExpansion != null)
                {
                    timerExpansion.Stop();
                    timerExpansion.Dispose();
                }
                if (gCanvas != null)
                    gCanvas.Dispose();
                if (canvas != null)
                    canvas.Dispose();
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.pictureBoxCanvas = new System.Windows.Forms.PictureBox();
            this.btnModoDibujo = new System.Windows.Forms.Button();
            this.btnModoRelleno = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnPausar = new System.Windows.Forms.Button();
            this.btnColorRelleno = new System.Windows.Forms.Button();
            this.btnColorBorde = new System.Windows.Forms.Button();
            this.tablaPixeles = new System.Windows.Forms.DataGridView();
            this.velocidadTrackBar = new System.Windows.Forms.TrackBar();
            this.lblVelocidad = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.grpControles = new System.Windows.Forms.GroupBox();
            this.grpColores = new System.Windows.Forms.GroupBox();
            this.grpDatos = new System.Windows.Forms.GroupBox();

            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaPixeles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.velocidadTrackBar)).BeginInit();
            this.grpControles.SuspendLayout();
            this.grpColores.SuspendLayout();
            this.grpDatos.SuspendLayout();

            // 
            // pictureBoxCanvas
            // 
            this.pictureBoxCanvas.BackColor = System.Drawing.Color.White;
            this.pictureBoxCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxCanvas.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBoxCanvas.Location = new System.Drawing.Point(20, 20);
            this.pictureBoxCanvas.Name = "pictureBoxCanvas";
            this.pictureBoxCanvas.Size = new System.Drawing.Size(650, 550);
            this.pictureBoxCanvas.TabIndex = 0;
            this.pictureBoxCanvas.TabStop = false;
            this.pictureBoxCanvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCanvas_MouseClick);
            this.pictureBoxCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCanvas_MouseMove);

            // 
            // grpControles
            // 
            this.grpControles.Controls.Add(this.btnModoDibujo);
            this.grpControles.Controls.Add(this.btnModoRelleno);
            this.grpControles.Controls.Add(this.btnPausar);
            this.grpControles.Controls.Add(this.btnLimpiar);
            this.grpControles.Controls.Add(this.lblVelocidad);
            this.grpControles.Controls.Add(this.velocidadTrackBar);
            this.grpControles.Location = new System.Drawing.Point(690, 20);
            this.grpControles.Name = "grpControles";
            this.grpControles.Size = new System.Drawing.Size(180, 220);
            this.grpControles.TabIndex = 1;
            this.grpControles.TabStop = false;
            this.grpControles.Text = "Controles de Operación";

            // 
            // btnModoDibujo
            // 
            this.btnModoDibujo.BackColor = System.Drawing.Color.LightGreen;
            this.btnModoDibujo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModoDibujo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnModoDibujo.Location = new System.Drawing.Point(10, 25);
            this.btnModoDibujo.Name = "btnModoDibujo";
            this.btnModoDibujo.Size = new System.Drawing.Size(160, 35);
            this.btnModoDibujo.TabIndex = 0;
            this.btnModoDibujo.Text = "🖊️ Modo Dibujo";
            this.btnModoDibujo.UseVisualStyleBackColor = false;
            this.btnModoDibujo.Click += new System.EventHandler(this.btnModoDibujo_Click);

            // 
            // btnModoRelleno
            // 
            this.btnModoRelleno.BackColor = System.Drawing.Color.LightBlue;
            this.btnModoRelleno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModoRelleno.Font = new System.Drawing.Font("Arial", 9F);
            this.btnModoRelleno.Location = new System.Drawing.Point(10, 65);
            this.btnModoRelleno.Name = "btnModoRelleno";
            this.btnModoRelleno.Size = new System.Drawing.Size(160, 35);
            this.btnModoRelleno.TabIndex = 1;
            this.btnModoRelleno.Text = "🌊 Modo Relleno";
            this.btnModoRelleno.UseVisualStyleBackColor = false;
            this.btnModoRelleno.Click += new System.EventHandler(this.btnModoRelleno_Click);

            // 
            // btnPausar
            // 
            this.btnPausar.BackColor = System.Drawing.Color.LightYellow;
            this.btnPausar.Enabled = false;
            this.btnPausar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPausar.Location = new System.Drawing.Point(10, 105);
            this.btnPausar.Name = "btnPausar";
            this.btnPausar.Size = new System.Drawing.Size(75, 30);
            this.btnPausar.TabIndex = 2;
            this.btnPausar.Text = "⏸️ Pausar";
            this.btnPausar.UseVisualStyleBackColor = false;
            this.btnPausar.Click += new System.EventHandler(this.btnPausar_Click);

            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.LightCoral;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Location = new System.Drawing.Point(95, 105);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 30);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "🗑️ Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            // 
            // lblVelocidad
            // 
            this.lblVelocidad.AutoSize = true;
            this.lblVelocidad.Location = new System.Drawing.Point(10, 145);
            this.lblVelocidad.Name = "lblVelocidad";
            this.lblVelocidad.Size = new System.Drawing.Size(150, 20);
            this.lblVelocidad.TabIndex = 4;
            this.lblVelocidad.Text = "Velocidad de Expansión:";

            // 
            // velocidadTrackBar
            // 
            this.velocidadTrackBar.Location = new System.Drawing.Point(10, 165);
            this.velocidadTrackBar.Maximum = 200;
            this.velocidadTrackBar.Minimum = 1;
            this.velocidadTrackBar.Name = "velocidadTrackBar";
            this.velocidadTrackBar.Size = new System.Drawing.Size(160, 45);
            this.velocidadTrackBar.TabIndex = 5;
            this.velocidadTrackBar.TickFrequency = 25;
            this.velocidadTrackBar.TickStyle = System.Windows.Forms.TickStyle.BottomRight;
            this.velocidadTrackBar.Value = 150;
            this.velocidadTrackBar.ValueChanged += new System.EventHandler(this.velocidadTrackBar_ValueChanged);

            // 
            // grpColores
            // 
            this.grpColores.Controls.Add(this.btnColorRelleno);
            this.grpColores.Controls.Add(this.btnColorBorde);
            this.grpColores.Controls.Add(this.lblEstado);
            this.grpColores.Location = new System.Drawing.Point(690, 250);
            this.grpColores.Name = "grpColores";
            this.grpColores.Size = new System.Drawing.Size(180, 100);
            this.grpColores.TabIndex = 2;
            this.grpColores.TabStop = false;
            this.grpColores.Text = "Configuración de Colores";

            // 
            // btnColorRelleno
            // 
            this.btnColorRelleno.BackColor = System.Drawing.Color.Blue;
            this.btnColorRelleno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColorRelleno.Location = new System.Drawing.Point(10, 25);
            this.btnColorRelleno.Name = "btnColorRelleno";
            this.btnColorRelleno.Size = new System.Drawing.Size(75, 30);
            this.btnColorRelleno.TabIndex = 0;
            this.btnColorRelleno.Text = "Color Relleno";
            this.btnColorRelleno.UseVisualStyleBackColor = false;
            this.btnColorRelleno.Click += new System.EventHandler(this.btnColorRelleno_Click);

            // 
            // btnColorBorde
            // 
            this.btnColorBorde.BackColor = System.Drawing.Color.Black;
            this.btnColorBorde.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColorBorde.ForeColor = System.Drawing.Color.White;
            this.btnColorBorde.Location = new System.Drawing.Point(95, 25);
            this.btnColorBorde.Name = "btnColorBorde";
            this.btnColorBorde.Size = new System.Drawing.Size(75, 30);
            this.btnColorBorde.TabIndex = 1;
            this.btnColorBorde.Text = "Color Borde";
            this.btnColorBorde.UseVisualStyleBackColor = false;
            this.btnColorBorde.Click += new System.EventHandler(this.btnColorBorde_Click);

            // 
            // lblEstado
            // 
            this.lblEstado.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblEstado.Location = new System.Drawing.Point(10, 65);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(160, 25);
            this.lblEstado.TabIndex = 2;
            this.lblEstado.Text = "Estado: Modo Dibujo Activo";
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // grpDatos
            // 
            this.grpDatos.Controls.Add(this.tablaPixeles);
            this.grpDatos.Location = new System.Drawing.Point(690, 360);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Size = new System.Drawing.Size(480, 310);
            this.grpDatos.TabIndex = 3;
            this.grpDatos.TabStop = false;
            this.grpDatos.Text = "Registro de Píxeles Rellenados";

            // 
            // tablaPixeles
            // 
            this.tablaPixeles.AllowUserToAddRows = false;
            this.tablaPixeles.AllowUserToDeleteRows = false;
            this.tablaPixeles.BackgroundColor = System.Drawing.Color.White;
            this.tablaPixeles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaPixeles.Location = new System.Drawing.Point(10, 25);
            this.tablaPixeles.MultiSelect = false;
            this.tablaPixeles.Name = "tablaPixeles";
            this.tablaPixeles.ReadOnly = true;
            this.tablaPixeles.RowHeadersWidth = 51;
            this.tablaPixeles.RowTemplate.Height = 24;
            this.tablaPixeles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaPixeles.Size = new System.Drawing.Size(460, 275);
            this.tablaPixeles.TabIndex = 0;

            // Agregar columnas
            this.tablaPixeles.ColumnCount = 4;
            this.tablaPixeles.Columns[0].Name = "Onda";
            this.tablaPixeles.Columns[1].Name = "X";
            this.tablaPixeles.Columns[2].Name = "Y";
            this.tablaPixeles.Columns[3].Name = "Tiempo";

            this.tablaPixeles.Columns[0].Width = 60;
            this.tablaPixeles.Columns[1].Width = 60;
            this.tablaPixeles.Columns[2].Width = 60;
            this.tablaPixeles.Columns[3].Width = 120;

            this.tablaPixeles.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
            this.tablaPixeles.DefaultCellStyle.BackColor = System.Drawing.Color.White;

            // 
            // lblInfo
            // 
            this.lblInfo.BackColor = System.Drawing.Color.LightYellow;
            this.lblInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInfo.Font = new System.Drawing.Font("Arial", 9F);
            this.lblInfo.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblInfo.Location = new System.Drawing.Point(20, 580);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(650, 90);
            this.lblInfo.TabIndex = 4;
            this.lblInfo.Text = "💡 INSTRUCCIONES:\n• Modo Dibujo: Click izquierdo para puntos, click derecho para cerrar figura\n• Modo Relleno: Click izquierdo dentro de la figura para colocar semilla\n• Use el control de velocidad para ajustar la animación";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.TopLeft;

            // 
            // frmBoundaryFill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 680);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.grpDatos);
            this.Controls.Add(this.grpColores);
            this.Controls.Add(this.grpControles);
            this.Controls.Add(this.pictureBoxCanvas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.Name = "frmBoundaryFill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Boundary Fill - Simulación de Expansión Radial";
            this.Load += new System.EventHandler(this.frmBoundaryFill_Load);

            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCanvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaPixeles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.velocidadTrackBar)).EndInit();
            this.grpControles.ResumeLayout(false);
            this.grpControles.PerformLayout();
            this.grpColores.ResumeLayout(false);
            this.grpDatos.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}
