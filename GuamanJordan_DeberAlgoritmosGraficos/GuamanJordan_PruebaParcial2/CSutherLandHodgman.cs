using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GuamanJordan_PruebaParcial2
{
    internal class CSutherLandHodgman
    {
        public enum Lado
        {
            Izquierdo,
            Derecho,
            Superior,
            Inferior
        }

        public static List<PointF> RecortarPoligono(List<PointF> poligono, RectangleF ventana)
        {
            if (poligono == null || poligono.Count < 3)
                return new List<PointF>();

            if (!AlMenosUnPuntoDentro(poligono, ventana))
            {
                MessageBox.Show("Todos los puntos están fuera del rectángulo de recorte. Al menos un punto debe estar dentro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return new List<PointF>();
            }

            List<PointF> resultado = new List<PointF>(poligono);

            resultado = RecortarContraLado(resultado, ventana, Lado.Izquierdo);
            resultado = RecortarContraLado(resultado, ventana, Lado.Derecho);
            resultado = RecortarContraLado(resultado, ventana, Lado.Superior);
            resultado = RecortarContraLado(resultado, ventana, Lado.Inferior);

            return resultado;
        }

        private static bool AlMenosUnPuntoDentro(List<PointF> poligono, RectangleF ventana)
        {
            return poligono.Any(p => ventana.Contains(p));
        }

        private static List<PointF> RecortarContraLado(List<PointF> poligono, RectangleF ventana, Lado lado)
        {
            if (poligono.Count == 0)
                return new List<PointF>();

            List<PointF> resultado = new List<PointF>();

            for (int i = 0; i < poligono.Count; i++)
            {
                PointF puntoActual = poligono[i];
                PointF puntoAnterior = poligono[i == 0 ? poligono.Count - 1 : i - 1];

                bool actualDentro = EstaDentro(puntoActual, ventana, lado);
                bool anteriorDentro = EstaDentro(puntoAnterior, ventana, lado);

                if (actualDentro)
                {
                    if (!anteriorDentro)
                    {
                        // Entrando: agregar intersección y punto actual
                        PointF interseccion = CalcularInterseccion(puntoAnterior, puntoActual, ventana, lado);
                        if (!float.IsNaN(interseccion.X) && !float.IsNaN(interseccion.Y))
                        {
                            resultado.Add(interseccion);
                        }
                    }
                    // Punto actual está dentro, siempre agregarlo
                    resultado.Add(puntoActual);
                }
                else if (anteriorDentro)
                {
                    // Saliendo: agregar solo intersección
                    PointF interseccion = CalcularInterseccion(puntoAnterior, puntoActual, ventana, lado);
                    if (!float.IsNaN(interseccion.X) && !float.IsNaN(interseccion.Y))
                    {
                        resultado.Add(interseccion);
                    }
                }
                // Si ambos están fuera, no agregamos nada
            }

            return resultado;
        }

        private static bool EstaDentro(PointF punto, RectangleF ventana, Lado lado)
        {
            switch (lado)
            {
                case Lado.Izquierdo:
                    return punto.X >= ventana.Left;
                case Lado.Derecho:
                    return punto.X <= ventana.Right;
                case Lado.Superior:
                    return punto.Y >= ventana.Top;
                case Lado.Inferior:
                    return punto.Y <= ventana.Bottom;
                default:
                    return false;
            }
        }

        private static PointF CalcularInterseccion(PointF p1, PointF p2, RectangleF ventana, Lado lado)
        {
            float x, y;

            switch (lado)
            {
                case Lado.Izquierdo:
                    x = ventana.Left;
                    if (Math.Abs(p2.X - p1.X) < 0.001f)
                        return new PointF(float.NaN, float.NaN);
                    y = p1.Y + (p2.Y - p1.Y) * (x - p1.X) / (p2.X - p1.X);
                    return new PointF(x, y);

                case Lado.Derecho:
                    x = ventana.Right;
                    if (Math.Abs(p2.X - p1.X) < 0.001f)
                        return new PointF(float.NaN, float.NaN);
                    y = p1.Y + (p2.Y - p1.Y) * (x - p1.X) / (p2.X - p1.X);
                    return new PointF(x, y);

                case Lado.Superior:
                    y = ventana.Top;
                    if (Math.Abs(p2.Y - p1.Y) < 0.001f)
                        return new PointF(float.NaN, float.NaN);
                    x = p1.X + (p2.X - p1.X) * (y - p1.Y) / (p2.Y - p1.Y);
                    return new PointF(x, y);

                case Lado.Inferior:
                    y = ventana.Bottom;
                    if (Math.Abs(p2.Y - p1.Y) < 0.001f)
                        return new PointF(float.NaN, float.NaN);
                    x = p1.X + (p2.X - p1.X) * (y - p1.Y) / (p2.Y - p1.Y);
                    return new PointF(x, y);

                default:
                    return new PointF(float.NaN, float.NaN);
            }
        }

        public static List<Point> ConvertirAPoint(List<PointF> puntosF)
        {
            return puntosF.Select(p => new Point((int)Math.Round(p.X), (int)Math.Round(p.Y))).ToList();
        }

        public static List<PointF> ConvertirAPointF(List<Point> puntos)
        {
            return puntos.Select(p => new PointF(p.X, p.Y)).ToList();
        }
    }
}