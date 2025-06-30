using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuamanJordan_PruebaParcial2
{
    public partial class frmDDA : Form
    {
        private List<Point> puntosLinea = new List<Point>();
        private Bitmap canvas;
        private Graphics gCanvas;

        private const int ESCALA_GRID = 20;

        private Point? puntoInicio = null;
        private Point? puntoFin = null;

        public frmDDA()
        {
            InitializeComponent();
            InicializarCanvas();
        }

        private void frmDDA_Load(object sender, EventArgs e)
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

        private async void panelCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            int xGrid = (int)Math.Round((double)e.X / ESCALA_GRID);
            int yGrid = (int)Math.Round((double)(panelCanvas.Height - e.Y) / ESCALA_GRID);

            if (puntoInicio == null)
            {
                puntoInicio = new Point(xGrid, yGrid);
                lblInfo.Text = $"Punto inicio seleccionado: ({xGrid}, {yGrid}). Ahora selecciona punto final.";
            }
            else if (puntoFin == null)
            {
                puntoFin = new Point(xGrid, yGrid);

                if (!CDDA.ValidarCoordenadas(puntoInicio.Value.X, puntoInicio.Value.Y, puntoFin.Value.X, puntoFin.Value.Y, panelCanvas.Width, panelCanvas.Height, ESCALA_GRID))
                {
                    MessageBox.Show("Uno o ambos puntos están fuera del rango válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    puntoInicio = null;
                    puntoFin = null;
                    lblInfo.Text = "Puntos inválidos. Seleccione de nuevo punto inicio.";
                    return;
                }

                lblInfo.Text = $"Puntos seleccionados: Inicio({puntoInicio.Value.X},{puntoInicio.Value.Y}), Fin({puntoFin.Value.X},{puntoFin.Value.Y}). Dibujando línea...";

                puntosLinea = CDDA.CalcularPuntosDDA(puntoInicio.Value.X, puntoInicio.Value.Y, puntoFin.Value.X, puntoFin.Value.Y, ESCALA_GRID, panelCanvas.Height);

                gCanvas.Clear(Color.White);
                DibujarGrid();
                dgvPuntos.Rows.Clear();

                await DibujarLineaProgresivo();

                lblInfo.Text = $"Línea dibujada con {puntosLinea.Count} puntos.";

                puntoInicio = null;
                puntoFin = null;
            }
        }

        private async Task DibujarLineaProgresivo()
        {
            Pen penLinea = new Pen(Color.Red, 3);

            for (int i = 0; i < puntosLinea.Count; i++)
            {
                if (i > 0)
                {
                    gCanvas.DrawLine(penLinea, puntosLinea[i - 1], puntosLinea[i]);
                }

                int radio = ESCALA_GRID / 3;
                gCanvas.FillEllipse(Brushes.Blue, puntosLinea[i].X - radio, puntosLinea[i].Y - radio, radio * 2, radio * 2);

                dgvPuntos.Rows.Clear();
                for (int j = 0; j <= i; j++)
                {
                    int xGrid = puntosLinea[j].X / ESCALA_GRID;
                    int yGrid = (panelCanvas.Height - puntosLinea[j].Y) / ESCALA_GRID;
                    dgvPuntos.Rows.Add(xGrid, yGrid);
                }

                panelCanvas.Invalidate();

                await Task.Delay(100);
            }

            if (puntosLinea.Count > 0)
            {
                int radio = ESCALA_GRID / 2;
                gCanvas.FillEllipse(Brushes.Green, puntosLinea[0].X - radio, puntosLinea[0].Y - radio, radio * 2, radio * 2);
                gCanvas.FillEllipse(Brushes.Orange, puntosLinea[puntosLinea.Count - 1].X - radio, puntosLinea[puntosLinea.Count - 1].Y - radio, radio * 2, radio * 2);
                panelCanvas.Invalidate();
            }
        }

        private void DibujarGrid()
        {
            Pen penGrid = new Pen(Color.LightGray, 1);
            Pen penGridGrueso = new Pen(Color.Gray, 1);
            Font fuente = new Font("Arial", 8);
            Brush brushTexto = Brushes.Black;

            for (int x = 0; x < panelCanvas.Width; x += ESCALA_GRID)
            {
                bool esLineaPrincipal = (x % (ESCALA_GRID * 5)) == 0;
                Pen pen = esLineaPrincipal ? penGridGrueso : penGrid;
                gCanvas.DrawLine(pen, x, 0, x, panelCanvas.Height);

                if (esLineaPrincipal && x > 0)
                {
                    int valorX = x / ESCALA_GRID;
                    gCanvas.DrawString(valorX.ToString(), fuente, brushTexto, x - 8, panelCanvas.Height - 20);
                }
            }

            for (int y = 0; y < panelCanvas.Height; y += ESCALA_GRID)
            {
                bool esLineaPrincipal = (y % (ESCALA_GRID * 5)) == 0;
                Pen pen = esLineaPrincipal ? penGridGrueso : penGrid;
                gCanvas.DrawLine(pen, 0, y, panelCanvas.Width, y);

                if (esLineaPrincipal && y > 0)
                {
                    int valorY = (panelCanvas.Height - y) / ESCALA_GRID;
                    gCanvas.DrawString(valorY.ToString(), fuente, brushTexto, 2, y - 8);
                }
            }

            gCanvas.DrawLine(new Pen(Color.Black, 2), 0, panelCanvas.Height - 1, panelCanvas.Width, panelCanvas.Height - 1);
            gCanvas.DrawLine(new Pen(Color.Black, 2), 0, 0, 0, panelCanvas.Height);

            panelCanvas.Invalidate();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            gCanvas.Clear(Color.White);
            DibujarGrid();
            panelCanvas.Invalidate();

            puntosLinea.Clear();
            dgvPuntos.Rows.Clear();

            puntoInicio = null;
            puntoFin = null;

            lblInfo.Text = "Canvas y datos limpiados. Seleccione punto inicio con click.";
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
                DibujarGrid();
            }
        }
    }
}
