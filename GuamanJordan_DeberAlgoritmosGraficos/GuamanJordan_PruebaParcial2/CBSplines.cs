using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GuamanJordan_PruebaParcial2
{
    public class CBSplines
    {
        public List<PointF> PuntosControl { get; private set; } = new List<PointF>();
        public int Grado { get; set; } = 3;
        private List<PointF> puntosCalculados = new List<PointF>();
        private int indiceDibujo = 0;
        private Timer animationTimer;

        public event EventHandler CurvaActualizada;

        public CBSplines()
        {
            animationTimer = new Timer();
            animationTimer.Interval = 30;
            animationTimer.Tick += AnimationTimer_Tick;
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (indiceDibujo < puntosCalculados.Count - 1)
            {
                indiceDibujo = Math.Min(indiceDibujo + 3, puntosCalculados.Count - 1);
                CurvaActualizada?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                animationTimer.Stop();
            }
        }

        public void AgregarPunto(PointF punto)
        {
            PuntosControl.Add(punto);
            RecalcularCurva();

            // Dibuja inmediatamente incluso con el primer punto
            CurvaActualizada?.Invoke(this, EventArgs.Empty);
        }

        public void EliminarUltimoPunto()
        {
            if (PuntosControl.Count > 0)
            {
                PuntosControl.RemoveAt(PuntosControl.Count - 1);
                RecalcularCurva();
            }
        }

        public void Limpiar()
        {
            PuntosControl.Clear();
            puntosCalculados.Clear();
            indiceDibujo = 0;
            animationTimer.Stop();
            CurvaActualizada?.Invoke(this, EventArgs.Empty);
        }

        private void RecalcularCurva()
        {
            puntosCalculados = CalcularBSpline(200);
            indiceDibujo = 0;

            if (puntosCalculados.Count > 1)
                animationTimer.Start();
        }

        public List<PointF> CalcularBSpline(int numPuntos = 100)
        {
            var resultado = new List<PointF>();
            int n = PuntosControl.Count - 1;
            int k = Grado;

            if (n < k || k < 1) return resultado;

            List<float> knots = new List<float>();
            int m = n + k + 1;

            for (int i = 0; i <= m; i++)
            {
                if (i < k) knots.Add(0);
                else if (i > m - k) knots.Add(1);
                else knots.Add((float)(i - k + 1) / (m - 2 * k + 1));
            }

            for (int i = 0; i <= numPuntos; i++)
            {
                float t = (float)i / numPuntos;
                PointF punto = DeBoor(k, t, knots, PuntosControl);
                resultado.Add(punto);
            }

            return resultado;
        }

        public void Dibujar(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;

            // Líneas guía entre puntos
            if (PuntosControl.Count > 1)
            {
                using (Pen pGuia = new Pen(Color.FromArgb(100, Color.Gray)))
                {
                    pGuia.DashStyle = DashStyle.Dot;
                    for (int i = 0; i < PuntosControl.Count - 1; i++)
                        g.DrawLine(pGuia, PuntosControl[i], PuntosControl[i + 1]);
                }
            }

            // Curva animada
            if (puntosCalculados.Count > 1 && indiceDibujo > 0)
            {
                using (Pen curvaPen = new Pen(Color.FromArgb(255, 33, 150, 243), 3f))
                {
                    curvaPen.StartCap = LineCap.Round;
                    curvaPen.EndCap = LineCap.Round;
                    curvaPen.LineJoin = LineJoin.Round;

                    using (LinearGradientBrush brush = new LinearGradientBrush(
                        new Point(0, 0),
                        new Point(500, 400),
                        Color.FromArgb(255, 33, 150, 243),
                        Color.FromArgb(255, 156, 39, 176)))
                    {
                        curvaPen.Brush = brush;
                        for (int i = 0; i < Math.Min(indiceDibujo, puntosCalculados.Count - 1); i++)
                            g.DrawLine(curvaPen, puntosCalculados[i], puntosCalculados[i + 1]);
                    }
                }
            }

            // Puntos de control
            for (int i = 0; i < PuntosControl.Count; i++)
            {
                PointF p = PuntosControl[i];

                using (SolidBrush sombra = new SolidBrush(Color.FromArgb(50, Color.Black)))
                    g.FillEllipse(sombra, p.X - 6, p.Y - 4, 12, 12);

                using (SolidBrush relleno = new SolidBrush(Color.FromArgb(255, 244, 67, 54)))
                    g.FillEllipse(relleno, p.X - 5, p.Y - 5, 10, 10);

                using (Pen borde = new Pen(Color.White, 2))
                    g.DrawEllipse(borde, p.X - 5, p.Y - 5, 10, 10);

                using (Font fuente = new Font("Arial", 8, FontStyle.Bold))
                using (SolidBrush texto = new SolidBrush(Color.White))
                {
                    string numero = (i + 1).ToString();
                    SizeF tam = g.MeasureString(numero, fuente);
                    g.DrawString(numero, fuente, texto, p.X - tam.Width / 2, p.Y - tam.Height / 2);
                }
            }
        }

        private PointF DeBoor(int k, float t, List<float> knots, List<PointF> ctrl)
        {
            int n = ctrl.Count - 1;
            int s = k;

            for (int i = k; i <= n + 1; i++)
            {
                if (t >= knots[i] && t < knots[i + 1])
                {
                    s = i;
                    break;
                }
            }

            List<PointF> d = new List<PointF>();
            for (int j = 0; j <= k; j++)
                d.Add(ctrl[s - k + j]);

            for (int r = 1; r <= k; r++)
            {
                for (int j = k; j >= r; j--)
                {
                    float alpha = (t - knots[s - k + j]) / (knots[s + 1 + j - r] - knots[s - k + j]);
                    d[j] = new PointF(
                        (1 - alpha) * d[j - 1].X + alpha * d[j].X,
                        (1 - alpha) * d[j - 1].Y + alpha * d[j].Y
                    );
                }
            }

            return d[k];
        }
    }
}
