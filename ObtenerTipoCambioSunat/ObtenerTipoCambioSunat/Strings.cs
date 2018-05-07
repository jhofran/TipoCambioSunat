using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObtenerTipoCambioSunat
{
    public static class Strings
    {
        public static int MonthGet(this string MonthName)
        {
            int result = 0;

            switch (MonthName)
            {
                case "APERTURA":
                    result = 0;
                    break;
                case "ENERO":
                    result = 1;
                    break;
                case "FEBRERO":
                    result = 2;
                    break;
                case "MARZO":
                    result = 3;
                    break;
                case "ABRIL":
                    result = 4;
                    break;
                case "MAYO":
                    result = 5;
                    break;
                case "JUNIO":
                    result = 6;
                    break;
                case "JULIO":
                    result = 7;
                    break;
                case "AGOSTO":
                    result = 8;
                    break;
                case "SEPTIEMBRE":
                    result = 9;
                    break;
                case "SETIEMBRE":
                    result = 9;
                    break;
                case "OCTUBRE":
                    result = 10;
                    break;
                case "NOVIEMBRE":
                    result = 11;
                    break;
                case "DICIEMBRE":
                    result = 12;
                    break;
                case "CIERRE":
                    result = 13;
                    break;
            }

            return result;
        }

        public static string Right(this string str, int Length)
        {
            int LenT = str.Length;
            if (LenT <= Length)
            {
                return str;
            }
            else
            {
                return str.Substring(LenT - Length);
            }
        }

    }
}
