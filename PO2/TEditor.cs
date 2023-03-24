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


        //public int P { get; set; }

        private StringBuilder sb;
        public string String 
        { 
            get { return sb.ToString(); } 
            set { sb.Clear(); sb.Append(value); }
        }

        public bool isZero()
        {
            return String == Zero;
        }

        public void Add(char ch) 
        {
            sb.Append(ch);
        }

        public void Add(string str)
        {
            sb.Append(str);
        }

        public void AddSign(char sign) 
        {
            if (String.Last() != '+' && String.Last() != '-' && String.Last() != '/' && String.Last() != '*')
            {
                sb.Append(sign);
            }
            else
            {
                sb[sb.Length - 1] = sign;
            }
        }

        public void AddDigitP(int a) 
        {
            if (isZero())
                String = "";
            char ch = Converter.Conver_10_p.int_to_Char(a);
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
                sb.Remove(String.Length - 1, 1);
                if (String.Length == 0)
                    String = Zero;
            }
        }

        public void Clear() { String = Zero;  }
   

        public TEditor() { sb = new StringBuilder(Zero); }

        public void Edit() { }

    }
}
