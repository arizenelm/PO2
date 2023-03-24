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

        public string String { get; set; }

        public bool isZero
        {
            get 
            {
                if (String == Zero)
                    return true;
                else
                    return false;
            }
            protected set { isZero = value; }
        }

        public void Add(char ch) 
        {
            String.Append(ch);
        }

        public void AddSign(char sign) 
        {
            StringBuilder sb = new StringBuilder(String);
            if (String.Last() != '+' && String.Last() != '-' && String.Last() != '/' && String.Last() != '*')
            {
                sb.Append(sign);
            }
            else
            {
                sb[sb.Length - 1] = sign;
            }
            String = sb.ToString();
        }

        public void AddDigitP(int a) 
        {
            if (isZero)
                String = "";
            char ch = Converter.Conver_10_p.int_to_Char(a);
            StringBuilder sb = new StringBuilder(String + ch);
            String = sb.ToString();
            //this.String.Append('@');
        }

        public void AddZero() 
        {
            if (!isZero)
                String += Zero;
        }

        public void Backspace() 
        {
            if (!isZero)
            {
                String.Remove(String.Length - 1);
                if (String.Length == 0)
                    String = Zero;
            }
        }

        public void Clear() { String = Zero;  }
   

        public TEditor() { String = Zero; }

        public void Edit() { }

    }
}
