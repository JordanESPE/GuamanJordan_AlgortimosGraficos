using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GuamanJordan_PruebaParcial2
{
    public partial class frmBezierCurves : Form
    {
        private Bitmap canvas;
        private Graphics gCanvas;
        private List<PointF> puntosControl;
        private List<PointF> puntosCurva;
        private Timer animacionTimer;
        private float progresoAnimacion = 0f;
        private bool animando = false;
        private bool mostrarLineasConstruccion = false;
        private float tActual = 0f;

        public frmBezierCurves()
        {
            InitializeComponent();

            puntosControl = new List<PointF>();
            puntosCurva = new List<PointF>();

            InicializarCanvas();
            InicializarTablaPuntosControl();
        }

        private void frmBezierCurves_Load(object sender, EventArgs e)
        {
            if (puntosControl == null)
                puntosControl = new List<PointF>();
            if (puntosCurva == null)
                puntosCurva = new List<PointF>();

            InicializarCanvas();
            InicializarTimer();
            DibujarEscena();
            lblInfo.Text = "Haga clic para agregar puntos de control";
            ActualizarTablaPuntosControl();
        }

        private void InicializarCanvas()
        {
            if (panelCanvas.Width <= 0 || panelCanvas.Height <= 0)
            {
                panelCanvas.Width = 640;
                panelCanvas.Height = 480;
            }

            if (canvas != null)
                canvas.Dispose();
            if (gCanvas != null)
                gCanvas.Dispose();

            canvas = new Bitmap(panelCanvas.Width, panelCanvas.Height);
            gCanvas = Graphics.FromImage(canvas);
            gCanvas.Clear(Color.White);
            gCanvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            panelCanvas.BackgroundImage = canvas;
        }

        private void InicializarTimer()
        {
            if (animacionTimer != null)
            {
                animacionTimer.Stop();
                animacionTimer.Dispose();
            }

            animacionTimer = new Timer();
            animacionTimer.Interval = 50;
            animacionTimer.Tick += AnimacionTimer_Tick;
        }

        private void DibujarEscena()
        {
            if (gCanvas == null || puntosControl == null) return;

            gCanvas.Clear(Color.White);
            DibujarGrid();

            if (puntosControl.Count >= 2)
            {
                if (animando)
                {
                    puntosCurva = CBezierCurves.CalcularCurvaAnimada(puntosControl, progresoAnimacion);

                    if (mostrarLineasConstruccion && progresoAnimacion > 0)
                        DibujarLineasConstruccion();
                }
                else
                {
                    puntosCurva = CBezierCurves.CalcularCurvaBezier(puntosControl);
                }

                if (puntosCurva != null && puntosCurva.Count > 1)
                {
                    using (Pen penCurva = new Pen(Color.Red, 3))
                    {
                        for (int i = 0; i < puntosCurva.Count - 1; i++)
                        {
                            gCanvas.DrawLine(penCurva, puntosCurva[i], puntosCurva[i + 1]);
                        }
                    }
                }

                DibujarLineasControl();
            }

            DibujarPuntosControl();

            if (puntosControl.Count >= 2)
            {
                string tipoCurva = CBezierCurves.ObtenerTipoCurva(puntosControl.Count);
                using (Font font = new Font("Arial", 10, FontStyle.Bold))
                {
                    gCanvas.DrawString($"Curva {tipoCurva} - {puntosControl.Count} puntos de control",
                                     font, Brushes.Black, 10, 10);
                }
            }

            panelCanvas.Invalidate();
        }

        private void DibujarGrid()
        {
            using (Pen penGrid = new Pen(Color.LightGray, 1))
            {
                for (int x = 0; x < panelCanvas.Width; x += 20)
                    gCanvas.DrawLine(penGrid, x, 0, x, panelCanvas.Height);

                for (int y = 0; y < panelCanvas.Height; y += 20)
                    gCanvas.DrawLine(penGrid, 0, y, panelCanvas.Width, y);
            }
        }

        private void DibujarPuntosControl()
        {
            if (puntosControl == null) return;

            for (int i = 0; i < puntosControl.Count; i++)
            {
                PointF punto = puntosControl[i];
                gCanvas.FillEllipse(Brushes.Blue, punto.X - 6, punto.Y - 6, 12, 12);
                using (Pen pen = new Pen(Color.Black, 2))
                {
                    gCanvas.DrawEllipse(pen, punto.X - 6, punto.Y - 6, 12, 12);
                }
                using (Font font = new Font("Arial", 8, FontStyle.Bold))
                {
                    gCanvas.DrawString(i.ToString(), font, Brushes.White, punto.X - 4, punto.Y - 4);
                }
            }
        }

        private void DibujarLineasControl()
        {
            if (puntosControl == null || puntosControl.Count < 2) return;

            using (Pen penControl = new Pen(Color.Gray, 1))
            {
                penControl.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                for (int i = 0; i < puntosControl.Count - 1; i++)
                {
                    gCanvas.DrawLine(penControl, puntosControl[i], puntosControl[i + 1]);
                }
            }
        }

        private void DibujarLineasConstruccion()
        {
            if (puntosControl == null || puntosControl.Count < 2) return;

            List<List<PointF>> lineasConstruccion = CBezierCurves.CalcularLineasConstruccion(puntosControl, tActual);
            if (lineasConstruccion == null) return;

            Color[] colores = { Color.Green, Color.Orange, Color.Purple, Color.Brown, Color.Pink };

            for (int nivel = 0; nivel < lineasConstruccion.Count; nivel++)
            {
                Color color = colores[nivel % colores.Length];
                List<PointF> puntosNivel = lineasConstruccion[nivel];
                if (puntosNivel == null) continue;

                using (Pen pen = new Pen(color, 2))
                using (SolidBrush brush = new SolidBrush(color))
                {
                    for (int i = 0; i < puntosNivel.Count; i++)
                    {
                        gCanvas.FillEllipse(brush, puntosNivel[i].X - 3, puntosNivel[i].Y - 3, 6, 6);
                    }
                }
            }
        }

        private void AnimacionTimer_Tick(object sender, EventArgs e)
        {
            progresoAnimacion += 0.02f;
            tActual = progresoAnimacion;

            if (progresoAnimacion >= 1.0f)
            {
                progresoAnimacion = 1.0f;
                DetenerAnimacion();
            }

            DibujarEscena();

            if (lblInfo != null)
                lblInfo.Text = $"Animando... {(int)(progresoAnimacion * 100)}%";
        }

        private void DetenerAnimacion()
        {
            animando = false;
            if (animacionTimer != null)
                animacionTimer.Stop();

            if (btnAnimar != null)
                btnAnimar.Text = "Animar Curva";

            if (btnLimpiar != null)
                btnLimpiar.Enabled = true;

            DibujarEscena();
        }

        private void btnAnimar_Click(object sender, EventArgs e)
        {
            if (puntosControl == null || puntosControl.Count < 2)
            {
                MessageBox.Show("Necesita al menos 2 puntos de control para animar.", "Aviso",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!animando)
            {
                animando = true;
                progresoAnimacion = 0f;
                btnAnimar.Text = "Detener Animación";
                btnLimpiar.Enabled = false;
                if (animacionTimer != null)
                    animacionTimer.Start();
            }
            else
            {
                DetenerAnimacion();
            }
        }

        private void btnMostrarConstruccion_Click(object sender, EventArgs e)
        {
            mostrarLineasConstruccion = !mostrarLineasConstruccion;
            btnMostrarConstruccion.Text = mostrarLineasConstruccion ? "Ocultar Construcción" : "Mostrar Construcción";
            btnMostrarConstruccion.BackColor = mostrarLineasConstruccion ? Color.Orange : Color.LightBlue;

            if (!animando)
            {
                tActual = 0.5f;
                DibujarEscena();
            }
        }

        private void panelCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !animando)
            {
                if (puntosControl == null)
                    puntosControl = new List<PointF>();

                puntosControl.Add(new PointF(e.X, e.Y));
                DibujarEscena();
                ActualizarTablaPuntosControl();

                string tipoCurva = puntosControl.Count >= 2 ? CBezierCurves.ObtenerTipoCurva(puntosControl.Count) : "";
                lblInfo.Text = $"Puntos de control: {puntosControl.Count} {tipoCurva}";

                if (puntosControl.Count >= 2)
                {
                    btnAnimar.Enabled = true;
                    btnMostrarConstruccion.Enabled = true;
                }
            }
        }

        private void panelCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (canvas != null)
                e.Graphics.DrawImage(canvas, 0, 0);
        }

        private void panelCanvas_Resize(object sender, EventArgs e)
        {
            if (panelCanvas != null && panelCanvas.Width > 0 && panelCanvas.Height > 0)
            {
                InicializarCanvas();
                DibujarEscena();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (animando)
                DetenerAnimacion();

            if (puntosControl == null)
                puntosControl = new List<PointF>();
            else
                puntosControl.Clear();

            if (puntosCurva == null)
                puntosCurva = new List<PointF>();
            else
                puntosCurva.Clear();

            progresoAnimacion = 0f;
            mostrarLineasConstruccion = false;

            btnAnimar.Enabled = false;
            btnMostrarConstruccion.Enabled = false;
            btnMostrarConstruccion.Text = "Mostrar Construcción";
            btnMostrarConstruccion.BackColor = Color.LightBlue;

            DibujarEscena();
            lblInfo.Text = "Canvas limpio. Haga clic para agregar puntos de control";
            ActualizarTablaPuntosControl();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                animacionTimer?.Stop();
                animacionTimer?.Dispose();
                gCanvas?.Dispose();
                canvas?.Dispose();
            }
            catch { }
            base.OnFormClosing(e);
        }

        // --- NUEVO: Métodos para la tabla de puntos de control ---

        private void InicializarTablaPuntosControl()
        {
            dgvPuntosControl.Columns.Clear();
            dgvPuntosControl.Columns.Add("Indice", "#");
            dgvPuntosControl.Columns.Add("X", "X");
            dgvPuntosControl.Columns.Add("Y", "Y");
            dgvPuntosControl.ReadOnly = true;
            dgvPuntosControl.AllowUserToAddRows = false;
            dgvPuntosControl.RowHeadersVisible = false;
        }

        private void ActualizarTablaPuntosControl()
        {
            dgvPuntosControl.Rows.Clear();
            for (int i = 0; i < puntosControl.Count; i++)
            {
                dgvPuntosControl.Rows.Add(i, (int)puntosControl[i].X, (int)puntosControl[i].Y);
            }
        }
    }
}