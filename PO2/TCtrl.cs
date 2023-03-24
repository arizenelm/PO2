using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO2
{
    public class TCtrl<T> where T : TPNumber, new()
    {
        //public enum TCtrlState {cStart = 0, cEditing, /*FunDone,*/ cValDone, cExpDone, cOpChange, cError }

        public enum States { l_val = 0, op, r_val }
        
        TEditor Editor { get; set; }

        TProc<T> Processor { get; set; }

        TMemory<T> Memory { get; set; }

        States State { get; set; }

        T Number { get; set; }

        public static char ConvertToOperator(int i)
        {
            switch (i)
            {
                case 26:
                    return '+';
                case 27:
                    return '-';
                case 28:
                    return '*';
                case 29:
                    return '/';
                default:
                    return '\0';
            }

        }

        public TCtrl()
        {
            Editor = new TEditor();
            Processor = new TProc<T>();
            Memory = new TMemory<T>();
            State = States.l_val;
            Number = new T();
            
        }

        public string Command(int i)
        {
            // Ввод цифры
            if (0 <= i && i <= 15)
            {
                if (i == 0)
                    Editor.AddZero();
                else
                    Editor.AddDigitP(i);

                if (State == States.l_val)
                    Processor.Lop_Res.SetNumStr(Editor.String);
            
                else
                {
                    int start = Editor.String.IndexOf((char)Processor.Operation);
                    string tmp = Editor.String.Substring(start + 1);
                    Processor.Rop.SetNumStr(tmp);
                    State = States.r_val;
                }
                return Editor.String;
            }

            // Ввод операнда
            if (26 <= i && i <= 29)
            {
                if (State == States.l_val || State == States.op)
                {
                    char ch = ConvertToOperator(i);
                    Editor.AddSign(ch);
                    Processor.Operation = (TProc<T>.Operations)ch;
                    State = States.op;
                }
                return Editor.String;
            }

            // Ввод знака равенства
            if (i == 25)
            {
                try
                {
                    if (State == States.r_val)
                    {
                        Processor.ExecOperation();
                        Editor.String = Processor.Lop_Res.Value;
                    }
                    else if (State == States.op)
                    {
                        Processor.Rop = Processor.Lop_Res;
                        Processor.ExecOperation();
                    }
                    else
                    {
                        Processor.ExecOperation();
                    }
                    Editor.String = Processor.Lop_Res.Value;
                    State = States.l_val;
                    return Editor.String;
                }
                catch (Exception e)
                {
                    Editor.String = TEditor.Zero;
                    Processor.Clear();
                    State = States.l_val;
                    return e.Message;
                }
            }

            // Смена знака
            if (i == 23)
            {
                if (State == States.l_val)
                {
                    Processor.Lop_Res.Num = -Processor.Lop_Res.Num;
                    Editor.String = Processor.Lop_Res.Value;
                }
                return Editor.String;
            }
            return "";
        }

    }
}
