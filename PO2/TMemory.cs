using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO2
{
    
    public class TMemory<T> where T : TPNumber, new()
    {
        public TMemory() { fNumber = new T(); }
        private T fNumber;
        public T FNumber
        {
            get
            {
                return fNumber;
            }
            set
            {
                FNumber = Activator.CreateInstance(typeof(T), new object[] { value }) as T;
                FState = true;
            }
        }

        public bool FState { get; protected set; }

        public void Add(T E)
        {
            fNumber = (T)(fNumber + E);
        }

        public void Clear()
        {
            fNumber = new T();
            FState = false;
        }
        
        public string GetStr() { return fNumber.Value;  }

        public double GetNum() { return fNumber.Num; }

    }
}
