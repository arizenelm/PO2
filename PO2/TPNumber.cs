using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO2
{


    public class TPNumber
    {

        public string Value
        {
            get { return Converter.Convert(num, p, acc, Delim); }
            set { }
        }


        public static char Delim { get; set; }

        private int p;

        public  int P
        {
            get { return p; }
            set
            {
                if (value < 2 || value > 16)
                    throw new BaseException("Основание должно быть в [2; 16]\n");
                p = value;
            }
        }

        private int acc;


        public int Acc
        {
            get { return acc; }
            set { acc = value; }
        }

        private double num;

        public double Num
        {
            get { return num; }
            set { num = value; }
        }

        public TPNumber() { num = 0.0; acc = 5; p = 10; Delim = ','; }

        public TPNumber(string _Value, int _P, int _Accuracy) { num = Converter.Convert(_Value, _P, Delim); p = _P; acc = _Accuracy; }

        public TPNumber(double _Num, int _P, int _Accuracy) { num = _Num; p = _P; acc = _Accuracy; }

        public TPNumber(TPNumber d) { num = d.Num; p = d.P; acc = d.Acc; }



        public static TPNumber operator+(TPNumber d1, TPNumber d2)
        {
            if (d1.P != d2.P)
                throw new BaseException("Разные основания в operator+\n");
            double res = d1.Num + d2.Num;
            if (double.IsInfinity(res))
                throw new OverflowException();
            return checked(new TPNumber(res, d1.P, d1.Acc));
        }

        public static TPNumber operator*(TPNumber d1, TPNumber d2)
        {
            if (d1.P != d2.P)
                throw new BaseException("Разные основания в operator*\n");
            double res = d1.Num * d2.Num;
            if (double.IsInfinity(res))
                throw new OverflowException();
            return checked(new TPNumber(res, d1.P, d1.Acc));
        }

        public static TPNumber operator-(TPNumber d1, TPNumber d2)
        {
            if (d1.P != d2.P)
                throw new BaseException("Разные основания в operator-\n");
            double res = d1.Num - d2.Num;
            if (double.IsInfinity(res))
                throw new OverflowException();
            return checked(new TPNumber(res, d1.P, d1.Acc));
        }

        public static TPNumber operator/(TPNumber d1, TPNumber d2)
        {
            if (d1.P != d2.P)
                throw new BaseException("Разные основания в operator/\n");
            if (d2.Num == 0)
                throw new ArithmeticException("Ошибка: деление на ноль\n");
            double res = d1.Num / d2.Num;
            if (double.IsInfinity(res))
                throw new OverflowException();
            return checked(new TPNumber(res, d1.P, d1.Acc));
        }

        public TPNumber Inverse()
        {
            if (num == 0)
                throw new ArithmeticException("Ошибка: ноль необратим\n");
            double res = 1 / num;
            if (double.IsInfinity(res))
                throw new OverflowException();
            return checked(new TPNumber(res, p, acc));
        }

        public TPNumber Sqare()
        {
            double res = num * num;
            if (double.IsInfinity(res))
                throw new OverflowException();
            return new TPNumber(res, p, acc);
        }

        public string StrP()
        {
            return p.ToString();
        }

        public string StrNum()
        {
            return num.ToString();
        }

        public string StrAcc()
        {
            return acc.ToString();
        }

        public void SetAccStr(string _Acc)
        {
            acc = Convert.ToInt32(_Acc);
        }

        public void SetPStr(string _P)
        {
            p = Convert.ToInt32(_P);
        }

        public void SetNumStr(string _Num, char delim = ',')
        {
            num = Converter.Convert(_Num, p, delim);
        }
    }
}
