using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using windbg_net;

namespace windbg_net
{
    class Program
    {
        static void Main(string[] args)
        {
            DeadlockHang.DeadlockHangMethod();
            //HighCpu.SetHighCpu();
            //HighMemory.SetHighMemory();
        }
    }
}
