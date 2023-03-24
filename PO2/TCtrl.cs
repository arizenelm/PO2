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

        public enum States { l_val = 0, op, r_val, func }

        public bool floatMode;

        private const string funcInv = "^(-1)";
        private const string funcSqr = "^2";
        TEditor Editor { get; set; }

        TProc<T> Processor { get; set; }

        TMemory<T> Memory { get; set; }

        States State { get; set; }

        T Number { get; set; }

        private static char ConvertToOperator(int i)
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

        private static bool isOperator(char ch)
        {
            return (ch == '-' || ch == '+' || ch == '*' || ch == '/');
        }

        public TCtrl()
        {
            Editor = new TEditor();
            Processor = new TProc<T>();
            Memory = new TMemory<T>();
            State = States.l_val;
            Number = new T();
            floatMode = false;
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

            // Backspace
            if (i == 22)
            {
                States old_state = State;
                if (old_state == States.func)
                {
                    if (Processor.Function == TProc<T>.Functions.Sqr)
                        for (int j = 0; j < funcSqr.Length; j++) { Editor.Backspace(); }
                    else
                        for (int j = 0; j < funcInv.Length; j++) { Editor.Backspace(); }
                    State = States.l_val;
                    Processor.ResetFunc();
                    return Editor.String;
                }
                Editor.Backspace();
                
                if (old_state == States.r_val)
                {
                    if (isOperator(Editor.String.Last()))
                    {
                        State = States.op;
                        Processor.Rop = new T();
                    }
                }

                return Editor.String;
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

            // Ввод знака равенства
            if (i == 25)
            {
                try
                {
                    if (State == States.op)
                    {
                        Processor.Rop = Processor.Lop_Res;
                        Processor.ExecOperation();
                    }
                    else if (State == States.func)
                    {
                        Processor.ExecFunction();
                    }
                    else
                        Processor.ExecOperation();
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


            // Ввод оператора
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


            // Возведение в квадрат
            if (i == 30)
            {
                if (State == States.l_val)
                {
                    Processor.Function = TProc<T>.Functions.Sqr;
                    Editor.Add(funcSqr);
                    State = States.func;
                }
                return Editor.String;
            }

            // Инверсия числа
            if (i == 31)
            {
                if (State == States.l_val)
                {
                    Processor.Function = TProc<T>.Functions.Inv;
                    Editor.Add(funcInv);
                    State = States.func;
                }
                return Editor.String;
            }            

            return "";
        }

    }
}
