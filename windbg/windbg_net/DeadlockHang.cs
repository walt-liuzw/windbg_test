using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace windbg_net
{
    public class DeadlockHang
    {
        private static object db1 = new object();
        private static object db2 = new object();
        public static void DeadlockHangMethod()
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            Task.Factory.StartNew(() =>
            {
                lock (db1)
                {
                    Console.WriteLine("Update db1-1");
                    lock (db2)
                    {
                        Console.WriteLine("Update db1-2");
                    }
                }
            });
            Task.Factory.StartNew(() =>
            {
                lock (db2)
                {
                    Console.WriteLine("Update db2-1");
                    lock (db1)
                    {
                        Console.WriteLine("Update db2-2");
                    }
                }
            });

            Console.ReadLine();
        }

    }
}
