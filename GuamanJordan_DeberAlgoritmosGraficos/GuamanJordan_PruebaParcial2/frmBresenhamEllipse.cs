using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GuamanJordan_PruebaParcial2
{
    public partial class frmBresenhamEllipse : Form
    {
        private Bitmap canvas;
        private Graphics gCanvas;

        private const int ESCALA_GRID = 20;

        private bool dibujandoLinea = false;
        private Point lineaInicio;
        private Point lineaFin;

        private Point? diagonalMayorStart = null;
        private Point? diagonalMayorEnd = null;

        private Point? diagonalMenorStart = null;
        private Point? diagonalMenorEnd = null;

        private int paso = 0;

        public frmBresenhamEllipse()
        {
            InitializeComponent();

            // Agregar columnas al DataGridView UNA vez aquí
            dgvPuntos.Columns.Clear();
            dgvPuntos.Columns.Add("ColX", "X");
            dgvPuntos.Columns.Add("ColY", "Y");

            InicializarCanvas();
        }

        private void frmBresenhamEllipse_Load(object sender, EventArgs e)
        {
            DibujarGrid();
        }

        private void InicializarCanvas()
        {
            canvas = new Bitmap(panelCanvas.Width, panelCanvas.Height);
            gCanvas = Graphics.FromImage(canvas);
            gCanvas.Clear(Color.White);
            panelCanvas.BackgroundImage = canvas;
        }

        private void DibujarGrid()
        {
            gCanvas.Clear(Color.White);
            Pen penGrid = new Pen(Color.LightGray, 1);
            Pen penFuerte = new Pen(Color.Gray, 1);
            Font fuente = new Font("Arial", 7);
            Brush brush = Brushes.Black;

            for (int x = 0; x <= panelCanvas.Width; x += ESCALA_GRID)
            {
                bool fuerte = (x % (ESCALA_GRID * 5)) == 0;
                Pen p = fuerte ? penFuerte : penGrid;
                gCanvas.DrawLine(p, x, 0, x, panelCanvas.Height);

                if (fuerte)
                {
                    int val = (x - panelCanvas.Width / 2) / ESCALA_GRID;
                    gCanvas.DrawString(val.ToString(), fuente, brush, x + 2, panelCanvas.Height / 2 + 2);
                }
            }

            for (int y = 0; y <= panelCanvas.Height; y += ESCALA_GRID)
            {
                bool fuerte = (y % (ESCALA_GRID * 5)) == 0;
                Pen p = fuerte ? penFuerte : penGrid;
                gCanvas.DrawLine(p, 0, y, panelCanvas.Width, y);

                if (fuerte)
                {
                    int val = (panelCanvas.Height / 2 - y) / ESCALA_GRID;
                    gCanvas.DrawString(val.ToString(), fuente, brush, panelCanvas.Width / 2 + 2, y + 2);
                }
            }

            panelCanvas.Invalidate();
        }

        private Point AjustarAGrid(Point p)
        {
            int x = (p.X / ESCALA_GRID) * ESCALA_GRID;
            int y = (p.Y / ESCALA_GRID) * ESCALA_GRID;
            return new Point(x, y);
        }

        private void panelCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (paso == 2) return;

            dibujandoLinea = true;
            lineaInicio = AjustarAGrid(e.Location);
            lineaFin = lineaInicio;
        }

        private void panelCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!dibujandoLinea) return;

            lineaFin = AjustarAGrid(e.Location);
            DibujarGrid();
            DibujarLineas();

            Pen pen = paso == 0 ? new Pen(Color.Blue, 2) : new Pen(Color.Red, 2);
            gCanvas.DrawLine(pen, lineaInicio, lineaFin);
            panelCanvas.Invalidate();
        }

        private void panelCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!dibujandoLinea) return;

            dibujandoLinea = false;
            lineaFin = AjustarAGrid(e.Location);

            if (paso == 0)
            {
                diagonalMayorStart = lineaInicio;
                diagonalMayorEnd = lineaFin;
                paso = 1;
                MessageBox.Show("Diagonal mayor definida (azul). Ahora dibuja la menor (rojo).");
            }
            else if (paso == 1)
            {
                diagonalMenorStart = lineaInicio;
                diagonalMenorEnd = lineaFin;
                DibujarGrid();
                DibujarLineas();
                DibujarElipse();
                paso = 2;
                MessageBox.Show("Elipse dibujada.");
            }
        }

        private void DibujarLineas()
        {
            if (diagonalMayorStart != null && diagonalMayorEnd != null)
                gCanvas.DrawLine(new Pen(Color.Blue, 2), diagonalMayorStart.Value, diagonalMayorEnd.Value);

            if (diagonalMenorStart != null && diagonalMenorEnd != null)
                gCanvas.DrawLine(new Pen(Color.Red, 2), diagonalMenorStart.Value, diagonalMenorEnd.Value);
        }

        private void DibujarElipse()
        {
            if (diagonalMayorStart == null || diagonalMayorEnd == null ||
                diagonalMenorStart == null || diagonalMenorEnd == null) return;

            int cx = (diagonalMayorStart.Value.X + diagonalMayorEnd.Value.X) / 2;
            int cy = (diagonalMayorStart.Value.Y + diagonalMayorEnd.Value.Y) / 2;

            double r1 = Distancia(diagonalMayorStart.Value, diagonalMayorEnd.Value) / 2.0;
            double r2 = Distancia(diagonalMenorStart.Value, diagonalMenorEnd.Value) / 2.0;

            int rx = (int)Math.Round(r1);
            int ry = (int)Math.Round(r2);

            var puntos = CalcularPuntosElipse(cx, cy, rx, ry);
            dgvPuntos.Rows.Clear();

            foreach (var p in puntos)
            {
                if (p.X >= 0 && p.X < canvas.Width && p.Y >= 0 && p.Y < canvas.Height)
                {
                    canvas.SetPixel(p.X, p.Y, Color.Black);

                    // Convertir a coordenadas cartesianas de la grilla
                    int xg = (p.X - panelCanvas.Width / 2) / ESCALA_GRID;
                    int yg = (panelCanvas.Height / 2 - p.Y) / ESCALA_GRID;

                    dgvPuntos.Rows.Add(xg, yg);
                }
            }

            panelCanvas.Invalidate();
        }

        private double Distancia(Point p1, Point p2)
        {
            int dx = p2.X - p1.X;
            int dy = p2.Y - p1.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        private List<Point> CalcularPuntosElipse(int cx, int cy, int rx, int ry)
        {
            List<Point> puntos = new List<Point>();
            int rx2 = rx * rx, ry2 = ry * ry;
            int twoRx2 = 2 * rx2, twoRy2 = 2 * ry2;
            int x = 0, y = ry, px = 0, py = twoRx2 * y;

            int p = (int)(ry2 - (rx2 * ry) + (0.25 * rx2));
            while (px < py)
            {
                AgregarSimetricos(puntos, cx, cy, x, y);
                x++; px += twoRy2;
                if (p < 0) p += ry2 + px;
                else { y--; py -= twoRx2; p += ry2 + px - py; }
            }

            p = (int)(ry2 * (x + 0.5) * (x + 0.5) + rx2 * (y - 1) * (y - 1) - rx2 * ry2);
            while (y >= 0)
            {
                AgregarSimetricos(puntos, cx, cy, x, y);
                y--; py -= twoRx2;
                if (p > 0) p += rx2 - py;
                else { x++; px += twoRy2; p += rx2 - py + px; }
            }

            return puntos;
        }

        private void AgregarSimetricos(List<Point> pts, int cx, int cy, int x, int y)
        {
            pts.Add(new Point(cx + x, cy + y));
            pts.Add(new Point(cx - x, cy + y));
            pts.Add(new Point(cx + x, cy - y));
            pts.Add(new Point(cx - x, cy - y));
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            diagonalMayorStart = diagonalMayorEnd = null;
            diagonalMenorStart = diagonalMenorEnd = null;
            paso = 0;
            dgvPuntos.Rows.Clear();
            InicializarCanvas();
            DibujarGrid();
        }

        private void panelCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (canvas != null)
                e.Graphics.DrawImage(canvas, 0, 0);
        }

        private void panelCanvas_Resize(object sender, EventArgs e)
        {
            InicializarCanvas();
            DibujarGrid();
        }
    }
}
