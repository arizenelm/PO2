using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO2
{
    public class TCtrl<T> where T : TPNumber, new()
    {
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

        private static bool IsOperator(char ch)
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
                    Processor.Lop_Res.SetNumStr(Editor.Str);
            
                else
                {
                    int start = Editor.Str.IndexOf((char)Processor.Operation);
                    string tmp = Editor.Str.Substring(start + 1);
                    Processor.Rop.SetNumStr(tmp);
                    State = States.r_val;
                }
                return Editor.Str;
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
                    return Editor.Str;
                }
                Editor.Backspace();
                
                if (old_state == States.r_val)
                {
                    if (IsOperator(Editor.Str.Last()))
                    {
                        State = States.op;
                        Processor.Rop = new T();
                    }
                }

                return Editor.Str;
            }

            // Смена знака
            if (i == 23)
            {
                if (State == States.l_val)
                {
                    Processor.Lop_Res.Num = -Processor.Lop_Res.Num;
                    Editor.Str = Processor.Lop_Res.Value;
                }
                return Editor.Str;
            }

            // Ввод запятой
            if (i == 24)
            {
                if (!floatMode)
                    return Editor.Str;
                if (State == States.l_val || State == States.r_val)
                    Editor.AddComma();
                return Editor.Str;
            }

            // Ввод знака равенства
            // Отрицательное минус число не работает
            // Обработать переполнение
            // В каких то ситуация перестают вводиться функции
            if (i == 25)
            {
                try
                {
                    if (State == States.op)
                    {
                        Processor.Rop = Processor.Lop_Res;
                        Processor.ExecOperation();
                        Processor.ResetFunc();
                    }
                    else if (State == States.func)
                    {
                        Processor.ExecFunction();
                        Processor.ResetOp();
                    }
                    else
                    {
                        // Сделать просто Exec() ?
                        Processor.ExecOperation();
                        Processor.ExecFunction();
                    }
                    if (!floatMode)
                        Processor.Lop_Res.Num = (int)Processor.Lop_Res.Num;
                    Editor.Str = Processor.Lop_Res.Value;
                    State = States.l_val;
                    return Editor.Str;
                }
                catch (Exception e)
                {
                    Editor.Str = TEditor.Zero;
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
                return Editor.Str;
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
                return Editor.Str;
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
                return Editor.Str;
            }            

            return "";
        }

    }
}
