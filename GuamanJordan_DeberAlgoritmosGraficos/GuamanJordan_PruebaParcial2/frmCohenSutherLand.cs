using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GuamanJordan_PruebaParcial2
{
    public partial class frmCohenSutherLand : Form
    {
        private Bitmap canvas;
        private Graphics gCanvas;
        private List<CCohenSutherLand.Linea> lineas;
        private List<CCohenSutherLand.LineaRecortada> lineasRecortadas;
        private Rectangle ventanaRecorte;
        private bool dibujando = false;
        private Point puntoInicio;
        private bool mostrarRecortadas = false;

        public frmCohenSutherLand()
        {
            InitializeComponent();

            lineas = new List<CCohenSutherLand.Linea>();
            lineasRecortadas = new List<CCohenSutherLand.LineaRecortada>();

            InicializarCanvas();
            InicializarTablas();
        }

        private void frmCohenSutherLand_Load(object sender, EventArgs e)
        {
            int margen = 100;
            ventanaRecorte = new Rectangle(
                margen,
                margen,
                panelCanvas.Width - 2 * margen,
                panelCanvas.Height - 2 * margen
            );

            DibujarEscena();
            lblInfo.Text = "Haga clic y arrastre para dibujar líneas";
        }

        private void InicializarCanvas()
        {
            if (panelCanvas.Width <= 0 || panelCanvas.Height <= 0) return;

            canvas = new Bitmap(panelCanvas.Width, panelCanvas.Height);
            gCanvas = Graphics.FromImage(canvas);
            gCanvas.Clear(Color.White);
            panelCanvas.BackgroundImage = canvas;
        }

        private void DibujarEscena()
        {
            if (gCanvas == null) return;

            gCanvas.Clear(Color.White);

            // Dibujar ventana de recorte
            gCanvas.DrawRectangle(new Pen(Color.Blue, 3), ventanaRecorte);
            gCanvas.FillRectangle(new SolidBrush(Color.FromArgb(30, 0, 0, 255)), ventanaRecorte);

            if (mostrarRecortadas && lineasRecortadas != null)
            {
                foreach (var lineaRecortada in lineasRecortadas)
                {
                    if (lineaRecortada.EsVisible)
                    {
                        gCanvas.DrawLine(new Pen(Color.Green, 3), lineaRecortada.P1, lineaRecortada.P2);
                    }
                }

                int contador = 0;
                foreach (var lineaRecortada in lineasRecortadas)
                {
                    if (!lineaRecortada.EsVisible)
                    {
                        contador++;
                    }
                }

                if (contador > 0)
                {
                    gCanvas.DrawString($"Líneas eliminadas: {contador}",
                                     new Font("Arial", 10), Brushes.Red, 10, 10);
                }
            }
            else if (lineas != null)
            {
                foreach (var linea in lineas)
                {
                    gCanvas.DrawLine(new Pen(Color.Black, 2), linea.P1, linea.P2);
                }
            }

            gCanvas.DrawRectangle(new Pen(Color.Blue, 3), ventanaRecorte);

            panelCanvas.Invalidate();
        }

        private void panelCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !mostrarRecortadas)
            {
                dibujando = true;
                puntoInicio = e.Location;
            }
        }

        private void panelCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && dibujando && !mostrarRecortadas && lineas != null)
            {
                dibujando = false;

                CCohenSutherLand.Linea nuevaLinea = new CCohenSutherLand.Linea(puntoInicio, e.Location);
                lineas.Add(nuevaLinea);

                DibujarEscena();
                lblInfo.Text = $"Total de líneas: {lineas.Count}";
                ActualizarTablaOriginales();
            }
        }

        private void panelCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (dibujando && !mostrarRecortadas && gCanvas != null)
            {
                DibujarEscena();
                gCanvas.DrawLine(new Pen(Color.Gray, 1), puntoInicio, e.Location);
                panelCanvas.Invalidate();
            }
        }

        private void btnRecortar_Click(object sender, EventArgs e)
        {
            if (lineas == null || lineas.Count == 0)
            {
                MessageBox.Show("No hay líneas para recortar. Dibuje algunas líneas primero.", "Aviso",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                lineasRecortadas = CCohenSutherLand.RecortarLineas(lineas, ventanaRecorte);

                mostrarRecortadas = true;
                btnRecortar.Enabled = false;
                btnMostrarOriginal.Enabled = true;

                DibujarEscena();

                int visibles = lineasRecortadas.Count(lr => lr.EsVisible);
                int eliminadas = lineasRecortadas.Count - visibles;

                lblInfo.Text = $"Recorte aplicado. Líneas visibles: {visibles}, Eliminadas: {eliminadas}";
                ActualizarTablaRecortadas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al aplicar recorte: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMostrarOriginal_Click(object sender, EventArgs e)
        {
            mostrarRecortadas = false;
            btnRecortar.Enabled = true;
            btnMostrarOriginal.Enabled = false;

            DibujarEscena();
            lblInfo.Text = $"Mostrando líneas originales. Total: {(lineas?.Count ?? 0)}";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (lineas != null) lineas.Clear();
            if (lineasRecortadas != null) lineasRecortadas.Clear();

            mostrarRecortadas = false;
            btnRecortar.Enabled = true;
            btnMostrarOriginal.Enabled = false;

            DibujarEscena();
            lblInfo.Text = "Canvas limpio. Haga clic y arrastre para dibujar líneas";
            ActualizarTablaOriginales();
            ActualizarTablaRecortadas();
        }

        private void panelCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (canvas != null)
            {
                e.Graphics.DrawImage(canvas, 0, 0);
            }
        }

        private void panelCanvas_Resize(object sender, EventArgs e)
        {
            if (panelCanvas.Width > 0 && panelCanvas.Height > 0)
            {
                InicializarCanvas();

                int margen = 100;
                ventanaRecorte = new Rectangle(
                    margen,
                    margen,
                    Math.Max(50, panelCanvas.Width - 2 * margen),
                    Math.Max(50, panelCanvas.Height - 2 * margen)
                );

                DibujarEscena();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                gCanvas?.Dispose();
                canvas?.Dispose();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en dispose: {ex.Message}");
            }
            base.OnFormClosing(e);
        }

        // --- NUEVO: Métodos para tablas ---

        private void InicializarTablas()
        {
            // Tabla de líneas originales
            dgvLineasOriginales.Columns.Clear();
            dgvLineasOriginales.Columns.Add("X1", "X1");
            dgvLineasOriginales.Columns.Add("Y1", "Y1");
            dgvLineasOriginales.Columns.Add("X2", "X2");
            dgvLineasOriginales.Columns.Add("Y2", "Y2");
            dgvLineasOriginales.ReadOnly = true;
            dgvLineasOriginales.AllowUserToAddRows = false;
            dgvLineasOriginales.RowHeadersVisible = false;

            // Tabla de líneas recortadas
            dgvLineasRecortadas.Columns.Clear();
            dgvLineasRecortadas.Columns.Add("X1", "X1");
            dgvLineasRecortadas.Columns.Add("Y1", "Y1");
            dgvLineasRecortadas.Columns.Add("X2", "X2");
            dgvLineasRecortadas.Columns.Add("Y2", "Y2");
            dgvLineasRecortadas.Columns.Add("Visible", "Visible");
            dgvLineasRecortadas.ReadOnly = true;
            dgvLineasRecortadas.AllowUserToAddRows = false;
            dgvLineasRecortadas.RowHeadersVisible = false;
        }

        private void ActualizarTablaOriginales()
        {
            dgvLineasOriginales.Rows.Clear();
            foreach (var linea in lineas)
            {
                dgvLineasOriginales.Rows.Add(
                    linea.P1.X, linea.P1.Y,
                    linea.P2.X, linea.P2.Y
                );
            }
        }

        private void ActualizarTablaRecortadas()
        {
            dgvLineasRecortadas.Rows.Clear();
            if (lineasRecortadas == null) return;
            foreach (var linea in lineasRecortadas)
            {
                dgvLineasRecortadas.Rows.Add(
                    linea.P1.X, linea.P1.Y,
                    linea.P2.X, linea.P2.Y,
                    linea.EsVisible ? "Sí" : "No"
                );
            }
        }
    }
}