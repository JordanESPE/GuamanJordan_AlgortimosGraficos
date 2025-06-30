using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GuamanJordan_PruebaParcial2
{
    public partial class frmHomeAlgorithms : Form
    {
        private float opacity = 0f;

        private struct AlgoritmoInfo
        {
            public string Titulo;
            public string Descripcion;
            public Color Color;
            public Type FormType;

            public AlgoritmoInfo(string titulo, string descripcion, Color color, Type formType)
            {
                Titulo = titulo;
                Descripcion = descripcion;
                Color = color;
                FormType = formType;
            }
        }

        private AlgoritmoInfo[] algoritmos = new AlgoritmoInfo[]
        {
            new AlgoritmoInfo("CURVAS DE BÉZIER", "Algoritmo para generar curvas paramétricas suaves", Color.FromArgb(239, 68, 68), typeof(frmBezierCurves)),
            new AlgoritmoInfo("LÍNEAS DDA", "Digital Differential Analyzer para líneas", Color.FromArgb(34, 197, 94), typeof(frmDDA)),
            new AlgoritmoInfo("LÍNEAS BRESENHAM", "Algoritmo de Bresenham para líneas rectas", Color.FromArgb(168, 85, 247), typeof(frmBresenhamLines)),
            new AlgoritmoInfo("CÍRCULOS BRESENHAM", "Algoritmo del punto medio para círculos", Color.FromArgb(59, 130, 246), typeof(frmBresenhamMiddlePoint)),
            new AlgoritmoInfo("ELIPSES BRESENHAM", "Algoritmo de Bresenham para elipses", Color.FromArgb(245, 101, 101), typeof(frmBresenhamEllipse)),
            new AlgoritmoInfo("FLOOD FILL", "Algoritmo de relleno por inundación", Color.FromArgb(16, 185, 129), typeof(frmFloodFill)),
            new AlgoritmoInfo("COHEN-SUTHERLAND", "Algoritmo de recorte de líneas 2D", Color.FromArgb(249, 115, 22), typeof(frmCohenSutherLand)),
            new AlgoritmoInfo("SUTHERLAND-HODGMAN", "Algoritmo de recorte de polígonos", Color.FromArgb(139, 92, 246), typeof(frmSutherLandHodgman)),
            new AlgoritmoInfo("BOUNDARY FILL", "Algoritmo de relleno de límites con animación radial", Color.FromArgb(236, 72, 153), typeof(frmBoundaryFill)),
            new AlgoritmoInfo("B-SPLINES", "Curvas B-Spline uniformes y no uniformes", Color.FromArgb(251, 146, 60), typeof(frmBSplines)),
        };

        public frmHomeAlgorithms()
        {
            InitializeComponent();
            algoritmos = algoritmos.Where(a => a.FormType != null).ToArray();
            CrearBotonesMenu();
        }

        private void CrearBotonesMenu()
        {
            int columnas = 4;
            int filas = (int)Math.Ceiling((double)algoritmos.Length / columnas);
            int spacing = 20;

            int buttonWidth = (menuPanel.Width - (columnas + 1) * spacing) / columnas;
            int buttonHeight = (menuPanel.Height - (filas + 1) * spacing) / filas;

            for (int i = 0; i < algoritmos.Length; i++)
            {
                int fila = i / columnas;
                int columna = i % columnas;

                int x = spacing + columna * (buttonWidth + spacing);
                int y = spacing + fila * (buttonHeight + spacing);

                CrearBotonAlgoritmo(algoritmos[i], x, y, buttonWidth, buttonHeight, i);
            }
        }

        private void CrearBotonAlgoritmo(AlgoritmoInfo algoritmo, int x, int y, int width, int height, int index)
        {
            Panel buttonPanel = new Panel
            {
                Size = new Size(width, height),
                Location = new Point(x, y),
                BackColor = algoritmo.Color,
                Cursor = Cursors.Hand,
                Padding = new Padding(10, 8, 10, 8)
            };

            float scale = 1.0f;
            float targetScale = 1.0f;
            Color originalColor = algoritmo.Color;
            Color hoverColor = AjustarBrillo(originalColor, 1.18f);
            Color currentColor = originalColor;
            Color targetColor = originalColor;

            Timer animTimer = new Timer { Interval = 15 };
            animTimer.Tick += (s, e) =>
            {
                float scaleStep = 0.13f;
                scale += (targetScale - scale) * scaleStep;
                if (Math.Abs(scale - targetScale) < 0.01f) scale = targetScale;

                float colorStep = 0.18f;
                int r = (int)(currentColor.R + (targetColor.R - currentColor.R) * colorStep);
                int g = (int)(currentColor.G + (targetColor.G - currentColor.G) * colorStep);
                int b = (int)(currentColor.B + (targetColor.B - currentColor.B) * colorStep);
                currentColor = Color.FromArgb(r, g, b);

                int newWidth = (int)(width * scale);
                int newHeight = (int)(height * scale);
                int newX = x - (newWidth - width) / 2;
                int newY = y - (newHeight - height) / 2;
                buttonPanel.Bounds = new Rectangle(newX, newY, newWidth, newHeight);
                buttonPanel.BackColor = currentColor;

                if (Math.Abs(scale - targetScale) < 0.01f &&
                    Math.Abs(currentColor.R - targetColor.R) < 2 &&
                    Math.Abs(currentColor.G - targetColor.G) < 2 &&
                    Math.Abs(currentColor.B - targetColor.B) < 2)
                {
                    scale = targetScale;
                    currentColor = targetColor;
                    buttonPanel.Bounds = new Rectangle(x - (int)((width * scale - width) / 2), y - (int)((height * scale - height) / 2), (int)(width * scale), (int)(height * scale));
                    buttonPanel.BackColor = targetColor;
                    animTimer.Stop();
                }
            };

            // Controla el hover solo desde el panel principal
            void HoverIn()
            {
                targetScale = 1.08f;
                targetColor = hoverColor;
                animTimer.Start();
            }
            void HoverOut()
            {
                targetScale = 1.0f;
                targetColor = originalColor;
                animTimer.Start();
            }

            buttonPanel.MouseEnter += (s, e) => HoverIn();
            buttonPanel.MouseLeave += (s, e) =>
            {
                // Solo si el mouse realmente sale del panel y no entra a un hijo
                if (!buttonPanel.ClientRectangle.Contains(buttonPanel.PointToClient(Cursor.Position)))
                    HoverOut();
            };
            buttonPanel.Click += (s, e) => AbrirFormulario(algoritmo);

            Label lblIcono = new Label
            {
                Text = ObtenerIcono(index),
                Font = new Font("Segoe UI Emoji", 18, FontStyle.Regular),
                ForeColor = Color.White,
                Size = new Size(44, 44),
                Location = new Point(10, 10),
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter
            };

            int maxTitleLength = 16;
            string titulo = algoritmo.Titulo.Length > maxTitleLength ? algoritmo.Titulo.Substring(0, maxTitleLength - 1) + "…" : algoritmo.Titulo;
            float fontSize = algoritmo.Titulo.Length > maxTitleLength ? 11.5f : 13f;

            Label lblTitulo = new Label
            {
                Text = titulo,
                Font = new Font("Segoe UI", fontSize, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(60, 10),
                Size = new Size(width - 70, 28),
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleLeft,
                AutoEllipsis = true
            };

            Label lblDescripcion = new Label
            {
                Text = algoritmo.Descripcion,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.FromArgb(240, 255, 255, 255),
                Location = new Point(15, 44),
                Size = new Size(width - 30, height - 60),
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.TopLeft,
                AutoEllipsis = true
            };

            Label lblEstado = new Label
            {
                Text = "● Disponible",
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                ForeColor = Color.FromArgb(200, 34, 197, 94),
                Size = new Size(120, 15),
                Location = new Point(width - 130, height - 22),
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleRight
            };

            // Los hijos no deben interferir con el hover, pero sí con el click
            foreach (Control ctrl in new Control[] { lblIcono, lblTitulo, lblDescripcion, lblEstado })
            {
                ctrl.Click += (s, e) => AbrirFormulario(algoritmo);
                ctrl.MouseEnter += (s, e) => HoverIn();
                ctrl.MouseLeave += (s, e) =>
                {
                    if (!buttonPanel.ClientRectangle.Contains(buttonPanel.PointToClient(Cursor.Position)))
                        HoverOut();
                };
                buttonPanel.Controls.Add(ctrl);
            }

            menuPanel.Controls.Add(buttonPanel);
        }

        private string ObtenerIcono(int index)
        {
            string[] iconos = { "🎨", "📏", "📐", "⭕", "⚪", "🎯", "✂️", "🔷", "🖌️", "🔍" };
            return iconos[index % iconos.Length];
        }

        private void AbrirFormulario(AlgoritmoInfo algoritmo)
        {
            try
            {
                if (algoritmo.FormType == null)
                {
                    MessageBox.Show("Este algoritmo no está disponible.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Form form = (Form)Activator.CreateInstance(algoritmo.FormType);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el formulario:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void headerPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, headerPanel.Width, headerPanel.Height);

            using (System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(rect, Color.FromArgb(37, 99, 235), Color.FromArgb(29, 78, 216), 45f))
            {
                e.Graphics.FillRectangle(brush, rect);
            }

            using (Pen patternPen = new Pen(Color.FromArgb(20, 255, 255, 255), 1))
            {
                for (int i = 0; i < rect.Width; i += 40)
                {
                    e.Graphics.DrawLine(patternPen, i, 0, i + 20, rect.Height);
                }
            }
        }

        private void fadeTimer_Tick(object sender, EventArgs e)
        {
            opacity += 0.08f;
            if (opacity >= 1.0f)
            {
                opacity = 1.0f;
                fadeTimer.Stop();
            }
            this.Opacity = opacity;
        }

        private void frmHomeAlgorithms_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            fadeTimer.Start();
        }

        private Color AjustarBrillo(Color color, float factor)
        {
            int r = Math.Min(255, Math.Max(0, (int)(color.R * factor)));
            int g = Math.Min(255, Math.Max(0, (int)(color.G * factor)));
            int b = Math.Min(255, Math.Max(0, (int)(color.B * factor)));
            return Color.FromArgb(color.A, r, g, b);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            fadeTimer?.Stop();
            fadeTimer?.Dispose();
            base.OnFormClosing(e);
        }
    }
}