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

        public TMemory<T> Memory { get; set; }

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
                    int start = Editor.Str.IndexOf((char)Processor.Operation, 1);
                    string tmp = Editor.Str.Substring(start + 1);
                    Processor.Rop.SetNumStr(tmp);
                    State = States.r_val;
                }
                return Editor.Str;
            }

            // Добавить в память
            if (i == 16)
            {
                if (Memory.FState)
                {
                    if (State == States.l_val)
                        Memory.Add(Processor.Lop_Res);
                }
                return Editor.Str;
            }

            // Сохранить в память
            if (i == 17)
            {
                if (Memory.FState)
                {
                    if (State == States.l_val)
                        Memory.FNumber = Processor.Lop_Res;
                }
                return Editor.Str;
            }

            // Взять из памяти
            if (i == 18)
            {
                if (Memory.FState)
                {
                    if (State == States.l_val)
                    {
                        Editor.Str = Memory.GetStr();
                        Processor.Lop_Res = Memory.FNumber;
                    }
                    else if (State == States.op)
                    {
                        Editor.Str += Memory.GetStr();
                        Processor.Rop.Num = Memory.GetNum();
                        State = States.r_val;
                    }                 
                }
                return Editor.Str;
            }

            // Очистить память
            if (i == 19)
            {
                Memory.Clear();
                return Editor.Str;
            }


            //CE
            if (i == 21)
            {
                State = States.l_val;
                Processor.Clear();
                Editor.Clear();
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
                else if (old_state == States.op)
                    Processor.ResetOp();
                else
                    Processor.Clear();

                return Editor.Str;
            }

            // Смена знака
            if (i == 23)
            {
                Processor.Lop_Res.Num = -Processor.Lop_Res.Num;
                Editor.AddMinusFront();
                
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
                    Processor.ResetFunc();
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
                    Processor.ResetOp();
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
                    Processor.ResetOp(); // Сделать, чтобы установление режима функции автоматически убирало режим операции
                    Editor.Add(funcInv);
                    State = States.func;
                }
                return Editor.Str;
            }            

            // Изменение основания системы счисления
            if (32 <= i && i <= 46)
            {
                int new_p = i - 30;
                Processor.Lop_Res.P = new_p;
                Processor.Rop.P = new_p;
                Editor.Str = Processor.Lop_Res.Value;
                if (State != States.l_val)
                {
                    Editor.Str += (char)Processor.Operation;
                    if (State == States.r_val)
                        Editor.Str += Processor.Rop.Value;
                }
                if (Memory.FState)
                {
                    Memory.FNumber.P = new_p;
                }
                return Editor.Str;
            }

            // Режим целых
            if (i == 47)
            {
                floatMode = false;
                if (State == States.l_val)
                {
                    Processor.Lop_Res.Num = (int)Processor.Lop_Res.Num;
                    Editor.Str = Processor.Lop_Res.Value;
                }                
                return Editor.Str;
            }

            // Режим дробных
            if (i == 48)
            {
                floatMode = true;
                return Editor.Str;
            }

            // Изменение точности
            if (49 <= i && i <= 56)
            {
                int new_acc = i - 47;
                Processor.Lop_Res.Acc = new_acc;
                Processor.Rop.Acc = new_acc;
                Editor.Str = Processor.Lop_Res.Value;
                if (State != States.l_val)
                {
                    Editor.Str += (char)Processor.Operation;
                    if (State == States.r_val)
                        Editor.Str += Processor.Rop.Value;
                }
                if (Memory.FState)
                {
                    Memory.FNumber.Acc = new_acc;
                }
                return Editor.Str;
            }

            // Выключить память
            if (i == 57)
            {
                Memory.Clear();
                Memory.FState = false;
                return Editor.Str;
            }

            // Включить память
            if (i == 58)
            {
                Memory.FState = true;
                return Editor.Str;
            }

            return "";
        }

    }
}
