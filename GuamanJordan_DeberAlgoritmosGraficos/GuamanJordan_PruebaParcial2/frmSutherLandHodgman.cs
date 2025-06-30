using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GuamanJordan_PruebaParcial2
{
    public partial class frmSutherLandHodgman : Form
    {
        private Bitmap canvas;
        private Graphics gCanvas;
        private List<Point> puntosPoligono;
        private List<Point> poligonoRecortado;
        private Rectangle ventanaRecorte;
        private bool poligonoCerrado = false;
        private bool mostrarRecortado = false;

        public frmSutherLandHodgman()
        {
            InitializeComponent();

            puntosPoligono = new List<Point>();
            poligonoRecortado = new List<Point>();

            InicializarCanvas();
            InicializarTablas();
        }

        private void frmSutherLandHodgman_Load(object sender, EventArgs e)
        {
            int margen = 120;
            ventanaRecorte = new Rectangle(
                margen,
                margen,
                panelCanvas.Width - 2 * margen,
                panelCanvas.Height - 2 * margen
            );

            DibujarEscena();
            lblInfo.Text = "Haga clic para agregar vértices al polígono";
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

            if (mostrarRecortado && poligonoRecortado != null && poligonoRecortado.Count >= 3)
            {
                gCanvas.FillPolygon(new SolidBrush(Color.FromArgb(100, 0, 255, 0)), poligonoRecortado.ToArray());
                gCanvas.DrawPolygon(new Pen(Color.Green, 3), poligonoRecortado.ToArray());

                foreach (Point punto in poligonoRecortado)
                {
                    gCanvas.FillEllipse(Brushes.Green, punto.X - 4, punto.Y - 4, 8, 8);
                }

                gCanvas.DrawString($"Polígono recortado: {poligonoRecortado.Count} vértices",
                                 new Font("Arial", 10), Brushes.Green, 10, 10);
            }
            else if (puntosPoligono != null && puntosPoligono.Count > 0)
            {
                if (puntosPoligono.Count >= 3 && poligonoCerrado)
                {
                    gCanvas.FillPolygon(new SolidBrush(Color.FromArgb(100, 255, 0, 0)), puntosPoligono.ToArray());
                    gCanvas.DrawPolygon(new Pen(Color.Red, 2), puntosPoligono.ToArray());
                }
                else if (puntosPoligono.Count > 1)
                {
                    for (int i = 0; i < puntosPoligono.Count - 1; i++)
                    {
                        gCanvas.DrawLine(new Pen(Color.Red, 2), puntosPoligono[i], puntosPoligono[i + 1]);
                    }
                }

                foreach (Point punto in puntosPoligono)
                {
                    gCanvas.FillEllipse(Brushes.Red, punto.X - 4, punto.Y - 4, 8, 8);
                    gCanvas.DrawEllipse(new Pen(Color.Black, 1), punto.X - 4, punto.Y - 4, 8, 8);
                }
            }

            gCanvas.DrawRectangle(new Pen(Color.Blue, 3), ventanaRecorte);

            panelCanvas.Invalidate();
        }

        private void panelCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !mostrarRecortado && !poligonoCerrado)
            {
                puntosPoligono.Add(e.Location);
                DibujarEscena();
                lblInfo.Text = $"Vértices: {puntosPoligono.Count}. Use 'Cerrar Polígono' para completar.";
                ActualizarTablaOriginales();
            }
        }

        private void btnCerrarPoligono_Click(object sender, EventArgs e)
        {
            if (puntosPoligono.Count < 3)
            {
                MessageBox.Show("Necesita al menos 3 vértices para formar un polígono.", "Aviso",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            poligonoCerrado = true;
            btnCerrarPoligono.Enabled = false;
            btnRecortar.Enabled = true;

            DibujarEscena();
            lblInfo.Text = $"Polígono cerrado con {puntosPoligono.Count} vértices. Puede aplicar recorte.";
            ActualizarTablaOriginales();
        }

        private void btnRecortar_Click(object sender, EventArgs e)
        {
            if (!poligonoCerrado || puntosPoligono.Count < 3)
            {
                MessageBox.Show("Primero debe cerrar el polígono.", "Aviso",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                List<PointF> poligonoF = CSutherLandHodgman.ConvertirAPointF(puntosPoligono);
                RectangleF ventanaF = new RectangleF(ventanaRecorte.X, ventanaRecorte.Y,
                                                    ventanaRecorte.Width, ventanaRecorte.Height);

                List<PointF> resultadoF = CSutherLandHodgman.RecortarPoligono(poligonoF, ventanaF);

                poligonoRecortado = CSutherLandHodgman.ConvertirAPoint(resultadoF);

                mostrarRecortado = true;
                btnRecortar.Enabled = false;
                btnMostrarOriginal.Enabled = true;

                DibujarEscena();

                if (poligonoRecortado.Count > 0)
                {
                    lblInfo.Text = $"Recorte aplicado. Polígono resultante: {poligonoRecortado.Count} vértices";
                }
                else
                {
                    lblInfo.Text = "El polígono queda completamente fuera de la ventana de recorte";
                }
                ActualizarTablaRecortados();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al aplicar recorte: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMostrarOriginal_Click(object sender, EventArgs e)
        {
            mostrarRecortado = false;
            btnRecortar.Enabled = true;
            btnMostrarOriginal.Enabled = false;

            DibujarEscena();
            lblInfo.Text = $"Mostrando polígono original con {puntosPoligono.Count} vértices";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            puntosPoligono.Clear();
            poligonoRecortado.Clear();
            poligonoCerrado = false;
            mostrarRecortado = false;

            btnCerrarPoligono.Enabled = true;
            btnRecortar.Enabled = false;
            btnMostrarOriginal.Enabled = false;

            DibujarEscena();
            lblInfo.Text = "Canvas limpio. Haga clic para agregar vértices al polígono";
            ActualizarTablaOriginales();
            ActualizarTablaRecortados();
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

                int margen = 120;
                ventanaRecorte = new Rectangle(
                    margen,
                    margen,
                    Math.Max(100, panelCanvas.Width - 2 * margen),
                    Math.Max(100, panelCanvas.Height - 2 * margen)
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
            dgvVerticesOriginales.Columns.Clear();
            dgvVerticesOriginales.Columns.Add("X", "X");
            dgvVerticesOriginales.Columns.Add("Y", "Y");
            dgvVerticesOriginales.ReadOnly = true;
            dgvVerticesOriginales.AllowUserToAddRows = false;
            dgvVerticesOriginales.RowHeadersVisible = false;

            dgvVerticesRecortados.Columns.Clear();
            dgvVerticesRecortados.Columns.Add("X", "X");
            dgvVerticesRecortados.Columns.Add("Y", "Y");
            dgvVerticesRecortados.ReadOnly = true;
            dgvVerticesRecortados.AllowUserToAddRows = false;
            dgvVerticesRecortados.RowHeadersVisible = false;
        }

        private void ActualizarTablaOriginales()
        {
            dgvVerticesOriginales.Rows.Clear();
            foreach (var punto in puntosPoligono)
            {
                dgvVerticesOriginales.Rows.Add(punto.X, punto.Y);
            }
        }

        private void ActualizarTablaRecortados()
        {
            dgvVerticesRecortados.Rows.Clear();
            foreach (var punto in poligonoRecortado)
            {
                dgvVerticesRecortados.Rows.Add(punto.X, punto.Y);
            }
        }
    }
}