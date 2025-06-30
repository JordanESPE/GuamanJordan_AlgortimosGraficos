using System;
using System.Collections.Generic;
using System.Drawing;

namespace GuamanJordan_PruebaParcial2
{
    internal class CBezierCurves
    {
        public static List<PointF> CalcularCurvaBezier(List<PointF> puntosControl, int numPuntos = 100)
        {
            List<PointF> puntosCurva = new List<PointF>();

            if (puntosControl == null || puntosControl.Count < 2)
                return puntosCurva;

            for (int i = 0; i <= numPuntos; i++)
            {
                float t = (float)i / numPuntos;
                PointF punto = CalcularPuntoBezier(puntosControl, t);
                puntosCurva.Add(punto);
            }

            return puntosCurva;
        }

        public static PointF CalcularPuntoBezier(List<PointF> puntosControl, float t)
        {
            if (puntosControl == null || puntosControl.Count == 0)
                return new PointF(0, 0);

            if (puntosControl.Count == 1)
                return puntosControl[0];

            List<PointF> temp = new List<PointF>();

            // Algoritmo de De Casteljau
            for (int i = 0; i < puntosControl.Count - 1; i++)
            {
                float x = (1 - t) * puntosControl[i].X + t * puntosControl[i + 1].X;
                float y = (1 - t) * puntosControl[i].Y + t * puntosControl[i + 1].Y;
                temp.Add(new PointF(x, y));
            }

            return CalcularPuntoBezier(temp, t);
        }

        public static string ObtenerTipoCurva(int numPuntos)
        {
            switch (numPuntos)
            {
                case 2:
                    return "Lineal";
                case 3:
                    return "Cuadrática";
                case 4:
                    return "Cúbica";
                default:
                    return $"Orden {numPuntos - 1}";
            }
        }

        public static List<PointF> CalcularCurvaAnimada(List<PointF> puntosControl, float progreso)
        {
            List<PointF> puntosCurva = new List<PointF>();

            if (puntosControl == null || puntosControl.Count < 2 || progreso <= 0)
                return puntosCurva;

            int numPuntosTotal = 100;
            int numPuntosActual = (int)(numPuntosTotal * progreso);

            for (int i = 0; i <= numPuntosActual; i++)
            {
                float t = (float)i / numPuntosTotal;
                PointF punto = CalcularPuntoBezier(puntosControl, t);
                puntosCurva.Add(punto);
            }

            return puntosCurva;
        }

        public static List<List<PointF>> CalcularLineasConstruccion(List<PointF> puntosControl, float t)
        {
            List<List<PointF>> todasLasLineas = new List<List<PointF>>();

            if (puntosControl == null || puntosControl.Count < 2)
                return todasLasLineas;

            List<PointF> nivel = new List<PointF>(puntosControl);

            while (nivel.Count > 1)
            {
                List<PointF> siguienteNivel = new List<PointF>();

                for (int i = 0; i < nivel.Count - 1; i++)
                {
                    float x = (1 - t) * nivel[i].X + t * nivel[i + 1].X;
                    float y = (1 - t) * nivel[i].Y + t * nivel[i + 1].Y;
                    siguienteNivel.Add(new PointF(x, y));
                }

                todasLasLineas.Add(new List<PointF>(siguienteNivel));
                nivel = siguienteNivel;
            }

            return todasLasLineas;
        }
    }
}