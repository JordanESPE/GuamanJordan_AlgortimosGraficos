using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GuamanJordan_PruebaParcial2
{
    public partial class frmBoundaryFill : Form
    {
        private Bitmap canvas;
        private Graphics gCanvas;
        private bool modoDibujo = true;
        private List<Point> puntosDibujo = new List<Point>();
        private bool figuraCerrada = false;

        private Color colorBorde = Color.Black;
        private Color colorRelleno = Color.Blue;

        private System.Windows.Forms.Timer timerExpansion;
        private int velocidadMs = 150;

        private bool rellenandoActivo = false;
        private bool pausado = false;

        private Queue<List<Point>> ondasExpansion;
        private HashSet<Point> pixelesRellenados;
        private int ondaActual = 0;
        private Point puntoSemilla;

        public frmBoundaryFill()
        {
            InitializeComponent();
        }

        private void frmBoundaryFill_Load(object sender, EventArgs e)
        {
            canvas = new Bitmap(pictureBoxCanvas.Width, pictureBoxCanvas.Height);
            gCanvas = Graphics.FromImage(canvas);
            gCanvas.Clear(Color.White);
            pictureBoxCanvas.Image = canvas;

            timerExpansion = new System.Windows.Forms.Timer();
            timerExpansion.Interval = velocidadMs;
            timerExpansion.Tick += TimerExpansion_Tick;

            CambiarModo(true);
        }

        private void CambiarModo(bool modoDibujoActivado)
        {
            modoDibujo = modoDibujoActivado;
            lblEstado.Text = modoDibujo ? "Estado: Modo Dibujo Activo" : "Estado: Modo Relleno Activo";
            btnModoDibujo.BackColor = modoDibujo ? Color.LightGreen : SystemColors.Control;
            btnModoRelleno.BackColor = modoDibujo ? SystemColors.Control : Color.LightBlue;
            btnPausar.Enabled = false;
        }

        private void btnModoDibujo_Click(object sender, EventArgs e)
        {
            CambiarModo(true);
        }

        private void btnModoRelleno_Click(object sender, EventArgs e)
        {
            CambiarModo(false);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarTodo();
        }

        private void LimpiarTodo()
        {
            timerExpansion.Stop();
            rellenandoActivo = false;
            pausado = false;
            figuraCerrada = false;
            puntosDibujo.Clear();
            gCanvas.Clear(Color.White);
            pictureBoxCanvas.Invalidate();
            tablaPixeles.Rows.Clear();
            lblEstado.Text = "Estado: Modo Dibujo Activo";
            CambiarModo(true);
            btnPausar.Enabled = false;
        }

        private void btnPausar_Click(object sender, EventArgs e)
        {
            if (!rellenandoActivo) return;

            if (pausado)
            {
                timerExpansion.Start();
                btnPausar.Text = "⏸️ Pausar";
                lblEstado.Text = "Estado: Rellenando...";
            }
            else
            {
                timerExpansion.Stop();
                btnPausar.Text = "▶️ Continuar";
                lblEstado.Text = "Estado: Pausado";
            }
            pausado = !pausado;
        }

        private void btnColorBorde_Click(object sender, EventArgs e)
        {
            using (ColorDialog cd = new ColorDialog())
            {
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    colorBorde = cd.Color;
                    btnColorBorde.BackColor = colorBorde;
                    if (figuraCerrada)
                        DibujarFigura(true);
                }
            }
        }

        private void btnColorRelleno_Click(object sender, EventArgs e)
        {
            using (ColorDialog cd = new ColorDialog())
            {
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    colorRelleno = cd.Color;
                    btnColorRelleno.BackColor = colorRelleno;
                }
            }
        }

        private void velocidadTrackBar_ValueChanged(object sender, EventArgs e)
        {
            velocidadMs = 201 - velocidadTrackBar.Value; // Invertido para que al subir sea más rápido
            if (timerExpansion != null)
                timerExpansion.Interval = velocidadMs;
        }

        private void pictureBoxCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (modoDibujo)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (!figuraCerrada)
                    {
                        puntosDibujo.Add(e.Location);
                        DibujarFigura(false);
                    }
                }
                else if (e.Button == MouseButtons.Right)
                {
                    if (!figuraCerrada && puntosDibujo.Count > 2)
                    {
                        figuraCerrada = true;
                        DibujarFigura(true);
                    }
                }
            }
            else
            {
                if (e.Button == MouseButtons.Left && figuraCerrada)
                {
                    if (!rellenandoActivo)
                        IniciarRellenoRadial(e.Location);
                }
            }
        }

        private void pictureBoxCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            // Puedes implementar para mostrar coordenadas o algo visual si deseas.
        }

        private void DibujarFigura(bool cerrar)
        {
            gCanvas.Clear(Color.White);

            if (puntosDibujo.Count == 0)
            {
                pictureBoxCanvas.Invalidate();
                return;
            }

            using (Pen pen = new Pen(colorBorde, 2))
            {
                for (int i = 0; i < puntosDibujo.Count - 1; i++)
                {
                    gCanvas.DrawLine(pen, puntosDibujo[i], puntosDibujo[i + 1]);
                }

                if (cerrar)
                {
                    gCanvas.DrawLine(pen, puntosDibujo[puntosDibujo.Count - 1], puntosDibujo[0]);
                }
            }

            pictureBoxCanvas.Invalidate();
        }

        // MÉTODO CORREGIDO CON FLUSH DE CARGA
        private void IniciarRellenoRadial(Point semilla)
        {
            if (semilla.X < 0 || semilla.Y < 0 || semilla.X >= canvas.Width || semilla.Y >= canvas.Height)
                return;

            Color colorInicial = canvas.GetPixel(semilla.X, semilla.Y);

            if (ColoresIguales(colorInicial, colorBorde) || ColoresIguales(colorInicial, colorRelleno))
                return;

            rellenandoActivo = true;
            pausado = false;
            puntoSemilla = semilla;
            ondasExpansion = new Queue<List<Point>>();
            pixelesRellenados = new HashSet<Point>();
            ondaActual = 0;
            tablaPixeles.Rows.Clear();
            btnPausar.Enabled = true;

            // Mostrar pantalla de carga mientras se calcula el relleno
            using (var loading = new LoadingForm())
            {
                loading.Show();
                Application.DoEvents();

                // Llamar a BoundaryFillRadial para obtener las ondas (píxeles por onda)
                var ondas = CBoundaryFill.BoundaryFillRadial(canvas, semilla.X, semilla.Y, colorBorde, colorRelleno, RegistrarPixelRellenado, false);

                foreach (var onda in ondas)
                {
                    ondasExpansion.Enqueue(onda);
                }

                loading.Close();
            }

            timerExpansion.Interval = velocidadMs;
            timerExpansion.Start();
            lblEstado.Text = "Estado: Rellenando...";
        }

        private void TimerExpansion_Tick(object sender, EventArgs e)
        {
            if (ondasExpansion.Count == 0)
            {
                timerExpansion.Stop();
                rellenandoActivo = false;
                btnPausar.Enabled = false;
                lblEstado.Text = "Estado: Rellenado terminado";
                return;
            }

            var pixels = ondasExpansion.Dequeue();

            foreach (var pt in pixels)
            {
                if (!pixelesRellenados.Contains(pt))
                {
                    pixelesRellenados.Add(pt);
                    canvas.SetPixel(pt.X, pt.Y, colorRelleno);
                    pictureBoxCanvas.Invalidate(new Rectangle(pt.X, pt.Y, 1, 1));
                    RegistrarPixelRellenado(pt, ondaActual);
                }
            }

            ondaActual++;
        }

        private void RegistrarPixelRellenado(Point pt, int onda)
        {
            tablaPixeles.Rows.Add(onda, pt.X, pt.Y, DateTime.Now.ToString("HH:mm:ss.fff"));
        }

        private bool ColoresIguales(Color c1, Color c2)
        {
            return c1.ToArgb() == c2.ToArgb();
        }
    }
}