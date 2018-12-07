using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace windbg_net
{
    public static class HighCpu
    {
        public static void SetHighCpu()
        {
            Task.Factory.StartNew(() => 
            {
                while (true)
                {
                    Console.WriteLine(DateTime.Now.Ticks.ToString());
                }
            });
            Task.Factory.StartNew(() => 
            {
                while (true)
                {
                    Console.WriteLine(DateTime.Now.Ticks.ToString());
                }
            });
            Console.ReadKey();
        }
    }
}
