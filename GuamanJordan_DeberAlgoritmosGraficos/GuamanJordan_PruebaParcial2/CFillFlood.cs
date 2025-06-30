using System;
using System.Collections.Generic;
using System.Drawing;

namespace GuamanJordan_PruebaParcial2
{
    internal class CFillFlood
    {
        public static List<Point> FloodFillIterativo(Bitmap bitmap, int x, int y, Color colorRelleno, Color colorObjetivo)
        {
            List<Point> puntosRellenados = new List<Point>();

            if (x < 0 || y < 0 || x >= bitmap.Width || y >= bitmap.Height)
                return puntosRellenados;

            if (colorRelleno.ToArgb() == colorObjetivo.ToArgb())
                return puntosRellenados;

            Stack<Point> pila = new Stack<Point>();
            HashSet<Point> visitados = new HashSet<Point>();
            pila.Push(new Point(x, y));

            while (pila.Count > 0)
            {
                Point punto = pila.Pop();

                if (punto.X < 0 || punto.Y < 0 || punto.X >= bitmap.Width || punto.Y >= bitmap.Height)
                    continue;

                if (visitados.Contains(punto))
                    continue;

                visitados.Add(punto);

                Color colorActual = bitmap.GetPixel(punto.X, punto.Y);

                if (colorActual.ToArgb() != colorObjetivo.ToArgb())
                    continue;

                // Rellenar el pixel
                bitmap.SetPixel(punto.X, punto.Y, colorRelleno);
                puntosRellenados.Add(punto);

                // Agregar vecinos en orden inverso para que el stack los procese en orden: Norte, Este, Sur, Oeste
                // Como el stack es LIFO (Last In, First Out), agregamos en orden inverso
                pila.Push(new Point(punto.X - 1, punto.Y)); // Oeste (se procesa último)
                pila.Push(new Point(punto.X, punto.Y + 1)); // Sur (se procesa tercero)
                pila.Push(new Point(punto.X + 1, punto.Y)); // Este (se procesa segundo)
                pila.Push(new Point(punto.X, punto.Y - 1)); // Norte (se procesa primero)
            }

            return puntosRellenados;
        }

        public static bool ValidarPunto(int x, int y, int maxX, int maxY)
        {
            return x >= 0 && y >= 0 && x < maxX && y < maxY;
        }
    }
}