using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO2
{


    public class TPNumber
    {
        // Переконвертация value при изменении значения, системы счисления или точности
        private void Reconvert() 
        {
            double tmp = Math.Round(num, acc);
            value = Converter.Convert(tmp, p, acc, Delim);
        }

        // Представление числа в системе счисления P
        private string value;
        public string Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public char Delim { get; set; }



        // Система счисления
        private int p;
        public int P
        {
            get { return p; }
            protected set
            {
                if (value < 2 || value > 16)
                    throw new BaseException("P must be in [2; 16]\n");
                P = value;
            }
        }

        // Точность представления
        private int acc;
        public int Acc
        {
            get { return acc; }
            set
            {
                acc = value;
                Reconvert();
            }
        }
        // Число в десятичной системе
        private double num;
        public double Num
        {
            get { return num; }
            set
            {
                num = value;
                Reconvert();
            }
        }

        public TPNumber() { num = 0.0; acc = 5; p = 10; Delim = ','; Reconvert();  }

        public TPNumber(string _Value, int _P, int _Accuracy) { Delim = ','; value = _Value; p = _P; acc = _Accuracy; }

        public TPNumber(double _Num, int _P, int _Acc) { num = _Num; p = _P; acc = _Acc; Delim = ','; Reconvert(); }

        public TPNumber(TPNumber d) { value = d.Value; p = d.P; acc = d.Acc; num = d.Num; Delim = d.Delim; }



        public static TPNumber operator+(TPNumber d1, TPNumber d2)
        {
            if (d1.p != d2.p)
                throw new BaseException("Different bases in operator+\n");
            return new TPNumber(d1.num + d2.num, d1.p, d1.acc);
        }

        public static TPNumber operator*(TPNumber d1, TPNumber d2)
        {
            if (d1.p != d2.p)
                throw new BaseException("Different bases in operator*\n");
            return new TPNumber(d1.num * d2.num, d1.p, d1.acc);
        }

        public static TPNumber operator-(TPNumber d1, TPNumber d2)
        {
            if (d1.p != d2.p)
                throw new BaseException("Different bases in operator-\n");
            return new TPNumber(d1.num - d2.num, d1.p, d1.acc);
        }

        public static TPNumber operator/(TPNumber d1, TPNumber d2)
        {
            if (d1.p != d2.p)
                throw new BaseException("Different bases in operator/\n");
            if (d2.num == 0)
                throw new ArithmeticException("Ошибка: деление на ноль\n");
            return new TPNumber(d1.num / d2.num, d1.p, d1.acc);
        }

        public TPNumber Reverse()
        {
            if (num == 0)
                throw new ArithmeticException("Ошибка: ноль необратим\n");
            return new TPNumber(1 / num, p, acc);
        }

        public TPNumber Sqare()
        {
            return new TPNumber(num * num, p, acc);
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

        public void SetNumStr(string _Num)
        {
            num = Convert.ToInt32(_Num);
        }
    }
}
