using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GuamanJordan_PruebaParcial2
{
    public partial class frmBresenhamMiddlePoint : Form
    {
        private List<Point> puntosCirculo;
        private List<Point> puntosOrdenadosPorAngulo;
        private Bitmap canvas;
        private Graphics gCanvas;
        private const int ESCALA_DIBUJO = 20;
        private Point centroPixel;

        private Timer timerDibujo;
        private int indiceDibujo;
        private Point? ultimoPuntoDibujado = null;

        public frmBresenhamMiddlePoint()
        {
            InitializeComponent();
            puntosCirculo = new List<Point>();
            puntosOrdenadosPorAngulo = new List<Point>();
            InicializarCanvas();

            timerDibujo = new Timer();
            timerDibujo.Interval = 50;
            timerDibujo.Tick += TimerDibujo_Tick;
        }

        private void frmBresenhamMiddlePoint_Load(object sender, EventArgs e)
        {
            centroPixel = new Point(panelCanvas.Width / 2, panelCanvas.Height / 2);
            DibujarGrid();
            lblInfo.Text = "Haz clic para definir el radio desde el centro de la grilla.";

            dgvCoordenadas.Columns.Clear();
            dgvCoordenadas.Columns.Add("X", "X");
            dgvCoordenadas.Columns.Add("Y", "Y");
            dgvCoordenadas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCoordenadas.ReadOnly = true;
        }

        private void InicializarCanvas()
        {
            if (panelCanvas.Width > 0 && panelCanvas.Height > 0)
            {
                canvas = new Bitmap(panelCanvas.Width, panelCanvas.Height);
                gCanvas = Graphics.FromImage(canvas);
                gCanvas.Clear(Color.White);
                panelCanvas.BackgroundImage = canvas;
            }
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
            InicializarCanvas();
            centroPixel = new Point(panelCanvas.Width / 2, panelCanvas.Height / 2);
            DibujarGrid();
            lblInfo.Text = "Haz clic para definir el radio desde el centro de la grilla.";
            panelCanvas.Invalidate();
        }

        private void panelCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (timerDibujo.Enabled)
                return;

            int dx = e.X - centroPixel.X;
            int dy = centroPixel.Y - e.Y;
            double distancia = Math.Sqrt(dx * dx + dy * dy);
            int radio = (int)Math.Round(distancia / ESCALA_DIBUJO);

            if (radio <= 0)
            {
                MessageBox.Show("Seleccione un punto diferente al centro para definir el radio.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var puntosRelativos = CBresenhamMiddlePoint.CalcularPuntosCirculo(radio);

            puntosCirculo.Clear();
            foreach (var p in puntosRelativos)
            {
                int xAbs = centroPixel.X + p.X * ESCALA_DIBUJO;
                int yAbs = centroPixel.Y - p.Y * ESCALA_DIBUJO;
                puntosCirculo.Add(new Point(xAbs, yAbs));
            }

            puntosOrdenadosPorAngulo = new List<Point>(puntosCirculo);
            puntosOrdenadosPorAngulo.Sort((a, b) =>
            {
                double angA = Math.Atan2(centroPixel.Y - a.Y, a.X - centroPixel.X);
                double angB = Math.Atan2(centroPixel.Y - b.Y, b.X - centroPixel.X);
                return angA.CompareTo(angB);
            });

            indiceDibujo = 0;
            ultimoPuntoDibujado = null;

            gCanvas.Clear(Color.White);
            DibujarGrid();

            int radioCentro = ESCALA_DIBUJO / 4;
            gCanvas.FillEllipse(Brushes.Blue, centroPixel.X - radioCentro, centroPixel.Y - radioCentro, radioCentro * 2, radioCentro * 2);

            dgvCoordenadas.Rows.Clear();
            panelCanvas.Invalidate();

            timerDibujo.Start();

            lblInfo.Text = $"Dibujando círculo con radio aprox = {radio} unidades...";
        }

        private void TimerDibujo_Tick(object sender, EventArgs e)
        {
            if (indiceDibujo >= puntosOrdenadosPorAngulo.Count)
            {
                timerDibujo.Stop();

                if (puntosOrdenadosPorAngulo.Count > 1)
                {
                    Point primero = puntosOrdenadosPorAngulo[0];
                    Point ultimo = puntosOrdenadosPorAngulo[puntosOrdenadosPorAngulo.Count - 1];
                    gCanvas.DrawLine(Pens.DarkBlue, ultimo, primero);

                    // Dibujar círculo verde perfecto como referencia
                    int radioPixel = (int)Math.Round(
                        Math.Sqrt(Math.Pow(primero.X - centroPixel.X, 2) +
                                  Math.Pow(primero.Y - centroPixel.Y, 2))
                    );

                    gCanvas.DrawEllipse(new Pen(Color.Green, 2),
                        centroPixel.X - radioPixel,
                        centroPixel.Y - radioPixel,
                        radioPixel * 2,
                        radioPixel * 2);

                    panelCanvas.Invalidate();
                }

                lblInfo.Text = $"Círculo completo dibujado con {puntosOrdenadosPorAngulo.Count} puntos.";
                return;
            }

            Point punto = puntosOrdenadosPorAngulo[indiceDibujo];

            gCanvas.FillEllipse(Brushes.Red, punto.X - 2, punto.Y - 2, 4, 4);

            if (ultimoPuntoDibujado != null)
            {
                gCanvas.DrawLine(Pens.DarkBlue, ultimoPuntoDibujado.Value, punto);
            }

            ultimoPuntoDibujado = punto;

            int xRel = (punto.X - centroPixel.X) / ESCALA_DIBUJO;
            int yRel = (centroPixel.Y - punto.Y) / ESCALA_DIBUJO;
            dgvCoordenadas.Rows.Add(xRel, yRel);

            panelCanvas.Invalidate();

            indiceDibujo++;
        }

        private void DibujarGrid()
        {
            Pen penGrid = new Pen(Color.LightGray, 1);
            Pen penGridGrueso = new Pen(Color.Gray, 1);
            Font fuente = new Font("Arial", 8);
            Brush brushTexto = Brushes.Black;

            for (int x = 0; x < panelCanvas.Width; x += ESCALA_DIBUJO)
            {
                bool lineaPrincipal = (x % (ESCALA_DIBUJO * 5)) == 0;
                Pen pen = lineaPrincipal ? penGridGrueso : penGrid;
                gCanvas.DrawLine(pen, x, 0, x, panelCanvas.Height);

                if (lineaPrincipal)
                {
                    int valorX = x / ESCALA_DIBUJO - (panelCanvas.Width / (2 * ESCALA_DIBUJO));
                    gCanvas.DrawString(valorX.ToString(), fuente, brushTexto, x - 8, panelCanvas.Height / 2 + 2);
                }
            }

            for (int y = 0; y < panelCanvas.Height; y += ESCALA_DIBUJO)
            {
                bool lineaPrincipal = (y % (ESCALA_DIBUJO * 5)) == 0;
                Pen pen = lineaPrincipal ? penGridGrueso : penGrid;
                gCanvas.DrawLine(pen, 0, y, panelCanvas.Width, y);

                if (lineaPrincipal)
                {
                    int valorY = (panelCanvas.Height / (2 * ESCALA_DIBUJO)) - (y / ESCALA_DIBUJO);
                    gCanvas.DrawString(valorY.ToString(), fuente, brushTexto, panelCanvas.Width / 2 + 2, y - 8);
                }
            }

            gCanvas.DrawLine(new Pen(Color.Black, 2), 0, centroPixel.Y, panelCanvas.Width, centroPixel.Y);
            gCanvas.DrawLine(new Pen(Color.Black, 2), centroPixel.X, 0, centroPixel.X, panelCanvas.Height);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (timerDibujo.Enabled)
                timerDibujo.Stop();

            gCanvas.Clear(Color.White);
            DibujarGrid();
            panelCanvas.Invalidate();

            puntosCirculo.Clear();
            puntosOrdenadosPorAngulo.Clear();
            ultimoPuntoDibujado = null;
            dgvCoordenadas.Rows.Clear();

            lblInfo.Text = "Canvas limpiado. Haz clic para definir el radio desde el centro de la grilla.";
        }
    }
}
