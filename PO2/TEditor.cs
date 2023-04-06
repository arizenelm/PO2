using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO2
{
    class TEditor
    {
        public const string Zero = "0";
        public const string Delim = ",";

        private StringBuilder sb;
        public string Str 
        { 
            get { return sb.ToString(); } 
            set { sb.Clear(); sb.Append(value); }
        }

        public bool isZero()
        {
            return Str == Zero;
        }

        public void Add(char ch) 
        {
            sb.Append(ch);
        }

        public void Add(string str)
        {
            sb.Append(str);
        }

        public void AddComma()
        {
            if (Str.Substring(Str.Length - 1) != Delim)
                Add(Delim);
        }
        public void AddSign(char sign) 
        {
            if (Str.Last() != '+' && Str.Last() != '-' && Str.Last() != '/' && Str.Last() != '*')
            {
                sb.Append(sign);
            }
            else
            {
                sb[sb.Length - 1] = sign;
            }
        }

        public void AddMinusFront()
        {
            if (sb[0] != '-')
                Str = "-" + Str;
            else
                Str = Str.Substring(1);
        }

        public void AddDigitP(int a) 
        {
            if (isZero())
                Str = "";
            char ch = Converter.Conver_10_p.long_to_Char(a);
            sb.Append(ch);
        }

        public void AddZero() 
        {
            if (!isZero())
                sb.Append(Zero);
        }

        public void Backspace() 
        {
            if (!isZero())
            {
                sb.Remove(Str.Length - 1, 1);
                if (Str.Length == 0)
                    Str = Zero;
            }
        }

        public void Clear() { Str = Zero;  }
   

        public TEditor() { sb = new StringBuilder(Zero); }

        public void Edit() { }

    }
}
