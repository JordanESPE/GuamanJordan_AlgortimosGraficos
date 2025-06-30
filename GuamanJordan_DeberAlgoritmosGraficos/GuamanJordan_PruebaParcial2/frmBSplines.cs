using System;
using System.Drawing;
using System.Windows.Forms;

namespace GuamanJordan_PruebaParcial2
{
    public partial class frmBSplines : Form
    {
        private CBSplines spline = new CBSplines();
        private PointF puntoHover = PointF.Empty;
        private bool mostrandoHover = false;

        public frmBSplines()
        {
            InitializeComponent();
            ConfigurarFormulario();
            spline.CurvaActualizada += Spline_CurvaActualizada;
            InicializarTablaPuntosControl();
        }

        private void ConfigurarFormulario()
        {
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.Font = new Font("Segoe UI", 9F);

            panelDibujo.BackColor = Color.White;
            panelDibujo.MouseMove += PanelDibujo_MouseMove;
            panelDibujo.MouseLeave += PanelDibujo_MouseLeave;

            EstilizarBoton(btnLimpiar, Color.FromArgb(244, 67, 54));
            EstilizarBoton(btnEliminar, Color.FromArgb(255, 152, 0));

            lblInstrucciones.Font = new Font("Segoe UI", 10F);
            lblInstrucciones.ForeColor = Color.FromArgb(100, 100, 100);

            lstPuntos.Font = new Font("Consolas", 9F);
            lstPuntos.BackColor = Color.FromArgb(250, 250, 250);
            lstPuntos.BorderStyle = BorderStyle.None;

            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, panelDibujo, new object[] { true });
        }

        private void EstilizarBoton(Button btn, Color color)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = color;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;

            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = ControlPaint.Light(color, 0.2f);
            };
            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor = color;
            };
        }

        private void Spline_CurvaActualizada(object sender, EventArgs e)
        {
            panelDibujo.Invalidate();
        }

        private void PanelDibujo_MouseMove(object sender, MouseEventArgs e)
        {
            puntoHover = e.Location;
            mostrandoHover = true;
            panelDibujo.Invalidate();
        }

        private void PanelDibujo_MouseLeave(object sender, EventArgs e)
        {
            mostrandoHover = false;
            panelDibujo.Invalidate();
        }

        private void panelDibujo_MouseClick(object sender, MouseEventArgs e)
        {
            spline.AgregarPunto(e.Location);
            lstPuntos.Items.Add($"P{spline.PuntosControl.Count}: ({e.X}, {e.Y})");
            panelDibujo.Invalidate();
            ActualizarTablaPuntosControl();
        }

        private void panelDibujo_Paint(object sender, PaintEventArgs e)
        {
            DibujarGrid(e.Graphics);

            spline.Dibujar(e.Graphics);

            if (mostrandoHover)
            {
                using (Pen previewPen = new Pen(Color.FromArgb(100, Color.Gray)))
                {
                    previewPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    e.Graphics.DrawEllipse(previewPen, puntoHover.X - 5, puntoHover.Y - 5, 10, 10);
                }
            }
        }

        private void DibujarGrid(Graphics g)
        {
            using (Pen gridPen = new Pen(Color.FromArgb(30, Color.Gray)))
            {
                int gridSize = 20;
                for (int x = 0; x < panelDibujo.Width; x += gridSize)
                {
                    g.DrawLine(gridPen, x, 0, x, panelDibujo.Height);
                }
                for (int y = 0; y < panelDibujo.Height; y += gridSize)
                {
                    g.DrawLine(gridPen, 0, y, panelDibujo.Width, y);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            spline.Limpiar();
            lstPuntos.Items.Clear();
            panelDibujo.Invalidate();
            ActualizarTablaPuntosControl();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            spline.EliminarUltimoPunto();
            if (lstPuntos.Items.Count > 0)
                lstPuntos.Items.RemoveAt(lstPuntos.Items.Count - 1);
            panelDibujo.Invalidate();
            ActualizarTablaPuntosControl();
        }

        private void frmBSplines_Load(object sender, EventArgs e)
        {
            this.Text = "🎨 Curvas B-Spline Interactivas - GuamanJordan";
            lblInstrucciones.Text = "✨ Haz clic en el panel para agregar puntos de control\n📐 Observa cómo se forma la curva en tiempo real";
            ActualizarTablaPuntosControl();
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
            for (int i = 0; i < spline.PuntosControl.Count; i++)
            {
                dgvPuntosControl.Rows.Add(i + 1, (int)spline.PuntosControl[i].X, (int)spline.PuntosControl[i].Y);
            }
        }
    }
}