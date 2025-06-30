using System;
using System.Collections.Generic;
using System.Drawing;

namespace GuamanJordan_PruebaParcial2
{
    internal class CCohenSutherLand
    {
        private const int INSIDE = 0; // 0000
        private const int LEFT = 1;   // 0001
        private const int RIGHT = 2;  // 0010
        private const int BOTTOM = 4; // 0100
        private const int TOP = 8;    // 1000

        public struct Linea
        {
            public Point P1;
            public Point P2;
            public bool Visible;

            public Linea(Point p1, Point p2)
            {
                P1 = p1;
                P2 = p2;
                Visible = true;
            }
        }

        public struct LineaRecortada
        {
            public Point P1;
            public Point P2;
            public bool EsVisible;

            public LineaRecortada(Point p1, Point p2, bool visible)
            {
                P1 = p1;
                P2 = p2;
                EsVisible = visible;
            }
        }

        // Calcular código de región para un punto
        private static int CalcularCodigo(Point punto, Rectangle ventana)
        {
            int codigo = INSIDE;

            if (punto.X < ventana.Left)
                codigo |= LEFT;
            else if (punto.X > ventana.Right)
                codigo |= RIGHT;

            if (punto.Y < ventana.Top)
                codigo |= TOP;
            else if (punto.Y > ventana.Bottom)
                codigo |= BOTTOM;

            return codigo;
        }

        // Algoritmo principal de Cohen-Sutherland
        public static LineaRecortada RecortarLinea(Point p1, Point p2, Rectangle ventana)
        {
            int codigo1 = CalcularCodigo(p1, ventana);
            int codigo2 = CalcularCodigo(p2, ventana);

            bool acepta = false;
            Point nuevoP1 = p1;
            Point nuevoP2 = p2;

            while (true)
            {
                if ((codigo1 | codigo2) == 0)
                {
                    // Ambos puntos están dentro
                    acepta = true;
                    break;
                }
                else if ((codigo1 & codigo2) != 0)
                {
                    // Ambos puntos están en la misma región exterior
                    break;
                }
                else
                {
                    // La línea puede ser parcialmente visible
                    int codigoFuera = (codigo1 != 0) ? codigo1 : codigo2;
                    Point puntoInterseccion = new Point();

                    // Encontrar punto de intersección
                    if ((codigoFuera & TOP) != 0)
                    {
                        // Intersección con el borde superior
                        puntoInterseccion.X = nuevoP1.X + (nuevoP2.X - nuevoP1.X) * (ventana.Top - nuevoP1.Y) / (nuevoP2.Y - nuevoP1.Y);
                        puntoInterseccion.Y = ventana.Top;
                    }
                    else if ((codigoFuera & BOTTOM) != 0)
                    {
                        // Intersección con el borde inferior
                        puntoInterseccion.X = nuevoP1.X + (nuevoP2.X - nuevoP1.X) * (ventana.Bottom - nuevoP1.Y) / (nuevoP2.Y - nuevoP1.Y);
                        puntoInterseccion.Y = ventana.Bottom;
                    }
                    else if ((codigoFuera & RIGHT) != 0)
                    {
                        // Intersección con el borde derecho
                        puntoInterseccion.Y = nuevoP1.Y + (nuevoP2.Y - nuevoP1.Y) * (ventana.Right - nuevoP1.X) / (nuevoP2.X - nuevoP1.X);
                        puntoInterseccion.X = ventana.Right;
                    }
                    else if ((codigoFuera & LEFT) != 0)
                    {
                        // Intersección con el borde izquierdo
                        puntoInterseccion.Y = nuevoP1.Y + (nuevoP2.Y - nuevoP1.Y) * (ventana.Left - nuevoP1.X) / (nuevoP2.X - nuevoP1.X);
                        puntoInterseccion.X = ventana.Left;
                    }

                    // Reemplazar el punto exterior con el punto de intersección
                    if (codigoFuera == codigo1)
                    {
                        nuevoP1 = puntoInterseccion;
                        codigo1 = CalcularCodigo(nuevoP1, ventana);
                    }
                    else
                    {
                        nuevoP2 = puntoInterseccion;
                        codigo2 = CalcularCodigo(nuevoP2, ventana);
                    }
                }
            }

            return new LineaRecortada(nuevoP1, nuevoP2, acepta);
        }

        public static List<LineaRecortada> RecortarLineas(List<Linea> lineas, Rectangle ventana)
        {
            List<LineaRecortada> resultado = new List<LineaRecortada>();

            foreach (Linea linea in lineas)
            {
                LineaRecortada lineaRecortada = RecortarLinea(linea.P1, linea.P2, ventana);
                resultado.Add(lineaRecortada);
            }

            return resultado;
        }
    }
}