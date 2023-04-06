using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO2
{
    class Converter
    {
        public static string Convert(double n, int p, int c, char delim)
        {
            string res = Conver_10_p.Do(Math.Abs(n), p, c, delim);
            if (n < 0)
                res = "-" + res;
            return res;
        }

        public static double Convert(string P_num, int p, char delim)
        {
            return Conver_p_10.dval(P_num, p, delim);
        }

        public class Conver_10_p
        {
            public static string Do(double n, int p, int c, char delim)
            {
                if (n == 0)
                    return "0";
                string integer = long_to_P((long)n, p);
                string fraction;
                if (n - (int)n == 0)
                    return integer;
                else
                    fraction = flt_to_P(n - (long)n, p, c);
                return integer + delim + fraction;
            }

            public static char long_to_Char(long d)
            {
                if (d < 10)
                    return (char)('0' + d);
                else
                    return (char)(d - 10 + 'A');
            }

            private static string long_to_P(long n, int p)
            {
                StringBuilder result = new StringBuilder("");
                StringBuilder tmp = new StringBuilder("");
                do
                {
                    tmp.Append(long_to_Char(n % p));
                    n /= p;
                } while (n > 0);
                result = new StringBuilder(new string('@', tmp.Length));
                for (int i = 0; i < tmp.Length; i++)
                    result[i] = tmp[tmp.Length - 1 - i];
                return result.ToString();
            }

            private static string flt_to_P(double d, int p, int c)
            {
                StringBuilder result = new StringBuilder();
                double delim = 1.0 / p;
                for (int i = 1; i <= c; i++)
                {
                    int temp = (int)(d / delim);
                    if (temp >= 1)
                        d -= delim * temp;
                    result.Append(long_to_Char(temp));
                    if (Math.Abs(d) < 1 / Math.Pow(p, c))
                        break;
                    delim /= p;
                }
                return result.ToString();
            }
        }

        public class Conver_p_10
        {
            public static double dval(string P_num, int P, char delim)
            {
                int pos = P_num.IndexOf(delim);
                double weight;
                if (pos == -1)
                    weight = Math.Pow(P, P_num.Length - 1);
                else
                {              
                    P_num.Remove(pos, 1);
                    if (pos == 1)
                    {
                        if (P_num[0] == '0')
                        {
                            P_num.Remove(0, 1);
                            weight = 1 / P;
                        }
                        else
                            weight = 1;
                    }
                    else
                        weight = Math.Pow(P, pos - 1);
                }
                return convert(P_num, P, weight);
            }

            //Возвращает десятичное значение цифры в какой-либо другой системе счисления.
            static public long char_To_num(char ch)
            {
                if (ch >= '0' && ch <= '9')
                    return ch - '0';
                if (ch >= 'A' && ch <= 'F')
                    return ch - 'A' + 10;
                return 0;
            }

            private static double convert(string P_num, int P, double weight)
            {
                double result = 0;
                for (int i = 0; i < P_num.Length; i++)
                {
                    result += char_To_num(P_num[i]) * weight;
                    weight /= P;
                }
                return result;
            }
        }
    }
}
