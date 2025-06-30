using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuamanJordan_PruebaParcial2
{
    public partial class frmFloodFill : Form
    {
        private Bitmap canvas;
        private Graphics gCanvas;
        private List<Point> puntosLinea;
        private Point? puntoInicio = null;
        private Color colorRelleno = Color.Yellow;
        private Color colorLinea = Color.Black;
        private Color colorFondo = Color.White;
        private bool rellenando = false;
        private bool modoRelleno = false;
        private Timer rellenoTimer;
        private List<Point> puntosARellenar;
        private int indiceRelleno = 0;

        public frmFloodFill()
        {
            InitializeComponent();
            InicializarCanvas();
            InicializarTimer();
            puntosLinea = new List<Point>();
            puntosARellenar = new List<Point>();
        }

        private void frmFloodFill_Load(object sender, EventArgs e)
        {
            lblInfo.Text = "Haga clic para colocar puntos";
        }

        private void InicializarCanvas()
        {
            if (panelCanvas.Width <= 0 || panelCanvas.Height <= 0) return;

            canvas = new Bitmap(panelCanvas.Width, panelCanvas.Height);
            gCanvas = Graphics.FromImage(canvas);
            gCanvas.Clear(colorFondo);
            gCanvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            panelCanvas.BackgroundImage = canvas;
        }

        private void InicializarTimer()
        {
            rellenoTimer = new Timer();
            rellenoTimer.Interval = 10; // 10ms para mejor visualización del algoritmo
            rellenoTimer.Tick += RellenoTimer_Tick;
        }

        private void panelCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (modoRelleno)
                {
                    if (!rellenando)
                    {
                        IniciarRelleno(e.X, e.Y);
                    }
                }
                else
                {
                    DibujarLineaRecta(e.Location);
                }
            }
        }

        private void DibujarLineaRecta(Point puntoActual)
        {
            if (puntoInicio == null)
            {
                // Primer punto
                puntoInicio = puntoActual;
                gCanvas.FillEllipse(Brushes.Red, puntoActual.X - 2, puntoActual.Y - 2, 4, 4);
                puntosLinea.Add(puntoActual);
                lblInfo.Text = $"Punto inicial establecido en ({puntoActual.X}, {puntoActual.Y})";
            }
            else
            {
                // Dibujar línea desde el punto anterior al actual
                using (Pen pen = new Pen(colorLinea, 2))
                {
                    gCanvas.DrawLine(pen, puntoInicio.Value, puntoActual);
                }
                gCanvas.FillEllipse(Brushes.Red, puntoActual.X - 2, puntoActual.Y - 2, 4, 4);

                puntosLinea.Add(puntoActual);
                puntoInicio = puntoActual;

                lblInfo.Text = $"Línea dibujada. Total puntos: {puntosLinea.Count}";
            }

            panelCanvas.Invalidate();
        }

        private void btnRellenar_Click(object sender, EventArgs e)
        {
            if (rellenando)
            {
                MessageBox.Show("Ya hay un relleno en progreso.", "Aviso",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            modoRelleno = !modoRelleno;

            if (modoRelleno)
            {
                btnRellenar.Text = "Modo Dibujo";
                btnRellenar.BackColor = Color.Orange;
                lblInfo.Text = "Modo relleno activado. Haga clic dentro de una figura para rellenar.";
                panelCanvas.Cursor = Cursors.Cross;
            }
            else
            {
                btnRellenar.Text = "Modo Relleno";
                btnRellenar.BackColor = Color.LightGreen;
                lblInfo.Text = "Modo dibujo activado. Haga clic para dibujar líneas.";
                panelCanvas.Cursor = Cursors.Default;
            }
        }

        private void IniciarRelleno(int x, int y)
        {
            try
            {
                if (x < 0 || y < 0 || x >= canvas.Width || y >= canvas.Height)
                {
                    MessageBox.Show("Coordenadas fuera del canvas.", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Color colorObjetivo = canvas.GetPixel(x, y);

                if (colorObjetivo.ToArgb() == colorRelleno.ToArgb())
                {
                    MessageBox.Show("El área ya está rellena con este color.", "Aviso",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (colorObjetivo.ToArgb() == colorLinea.ToArgb())
                {
                    MessageBox.Show("No se puede rellenar desde una línea. Haga clic dentro de una figura.", "Aviso",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                rellenando = true;
                btnRellenar.Enabled = false;
                btnCerrarFigura.Enabled = false;
                btnLimpiar.Enabled = false;
                lblInfo.Text = "Rellenando por inundación...";

                // Crear una copia del canvas para hacer el cálculo
                Bitmap canvasCopia = new Bitmap(canvas);

                // Calcular todos los puntos a rellenar
                puntosARellenar = CFillFlood.FloodFillIterativo(canvasCopia, x, y, colorRelleno, colorObjetivo);

                // Dispose de la copia
                canvasCopia.Dispose();

                if (puntosARellenar.Count == 0)
                {
                    MessageBox.Show("No hay área para rellenar en este punto.", "Aviso",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FinalizarRelleno();
                    return;
                }

                // Iniciar animación de relleno
                indiceRelleno = 0;
                rellenoTimer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar relleno: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                FinalizarRelleno();
            }
        }

        private void RellenoTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // Rellenar varios pixels por tick para mejor rendimiento
                int pixelsPorTick = Math.Max(1, Math.Min(20, puntosARellenar.Count / 150));

                for (int i = 0; i < pixelsPorTick && indiceRelleno < puntosARellenar.Count; i++)
                {
                    Point punto = puntosARellenar[indiceRelleno];
                    canvas.SetPixel(punto.X, punto.Y, colorRelleno);
                    indiceRelleno++;
                }

                panelCanvas.Invalidate();

                if (indiceRelleno >= puntosARellenar.Count)
                {
                    rellenoTimer.Stop();
                    lblInfo.Text = $"Relleno completado. Total de pixels rellenados: {puntosARellenar.Count}";
                    FinalizarRelleno();
                }
            }
            catch (Exception ex)
            {
                rellenoTimer.Stop();
                MessageBox.Show($"Error durante el relleno: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                FinalizarRelleno();
            }
        }

        private void FinalizarRelleno()
        {
            rellenando = false;
            btnRellenar.Enabled = true;
            btnCerrarFigura.Enabled = true;
            btnLimpiar.Enabled = true;
        }

        private void btnCerrarFigura_Click(object sender, EventArgs e)
        {
            if (puntosLinea.Count >= 2 && puntoInicio != null)
            {
                // Conectar el último punto con el primero
                using (Pen pen = new Pen(colorLinea, 2))
                {
                    gCanvas.DrawLine(pen, puntoInicio.Value, puntosLinea[0]);
                }
                panelCanvas.Invalidate();
                puntoInicio = null;
                lblInfo.Text = "Figura cerrada. Puede activar modo relleno.";
            }
            else
            {
                MessageBox.Show("Necesita al menos 2 puntos para cerrar la figura.", "Aviso",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (rellenando)
            {
                rellenoTimer.Stop();
                FinalizarRelleno();
            }

            gCanvas.Clear(colorFondo);
            panelCanvas.Invalidate();
            puntosLinea.Clear();
            puntosARellenar.Clear();
            puntoInicio = null;
            modoRelleno = false;
            btnRellenar.Text = "Modo Relleno";
            btnRellenar.BackColor = Color.LightGreen;
            panelCanvas.Cursor = Cursors.Default;
            lblInfo.Text = "Canvas limpio. Puede comenzar a dibujar.";
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
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                rellenoTimer?.Stop();
                rellenoTimer?.Dispose();
                gCanvas?.Dispose();
                canvas?.Dispose();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en dispose: {ex.Message}");
            }
            base.OnFormClosing(e);
        }
    }
}