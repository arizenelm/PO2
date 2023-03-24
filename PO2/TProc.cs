using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO2
{
    class TProc<T> where T: TPNumber, new()
    {
        public enum Operations { None = '\0', Add = '+', Sub = '-', Mul = '*', Dvd = '/' }

        public enum Functions { Rev = 0, Sqr }
        
        public Operations Operation { get;  set; }
        public Functions Function { get;  set; }

        public TProc()
        {
            Clear();
        }

        public void Clear()
        {
            Lop_Res = new T();
            Rop = new T();
            Operation = Operations.None;
        }

        public void Reset()
        {
            Operation = Operations.None;
        }

        public void ExecOperation()
        {
            switch (Operation)
            {
                case Operations.None:
                    return;
                case Operations.Add:
                    Lop_Res = (T)(Lop_Res + Rop);
                    break;
                case Operations.Sub:
                    Lop_Res = (T)(Lop_Res - Rop);
                    break;
                case Operations.Mul:
                    Lop_Res = (T)(Lop_Res * Rop);
                    break;
                case Operations.Dvd:
                    Lop_Res = (T)(Lop_Res / Rop);
                    break;
            }
        }

        public void ExecFunction()
        {
            switch(Function)
            {
                case Functions.Rev:
                    Rop = (T)(Rop.Reverse());
                    break;
                case Functions.Sqr:
                    Rop = (T)(Rop.Sqare());
                    break;
            }
        }

        public T Lop_Res { get; set; }
        
        public T Rop { get; set; }


    }
}
