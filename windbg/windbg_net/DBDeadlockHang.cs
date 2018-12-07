using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace windbg_net
{
    public class DBDeadlockHang
    {
        private static DBWrapper1 db1;
        private static DBWrapper2 db2;
        public static void DBDeadlockHangMethod()
        {
            db1 = new DBWrapper1("DBCon1");
            db2 = new DBWrapper2("DBCon2");
            new Thread(new ThreadStart(ThreadProc)).Start();
            Thread.Sleep(0x7b0);
            lock (db2)
            {
                Console.WriteLine("Update DB2");
                Thread.Sleep(0x7b0);
                lock (db1)
                {
                    Console.WriteLine("Update DB1");
                }
            }
        }

        private static void ThreadProc()
        {
            Console.WriteLine("Start worker thread");
            lock (db1)
            {
                Console.WriteLine("Update DB1");
                Thread.Sleep(0xbb8);
                lock (db2)
                {
                    Console.WriteLine("Update DB2");
                }
            }
            Console.WriteLine("Out");
        }
    }

    public class DBWrapper1
    {
        private string _conn;
        public DBWrapper1(string conn)
        {
            _conn = conn;
        }
    }
    public class DBWrapper2
    {
        private string _conn;
        public DBWrapper2(string conn)
        {
            _conn = conn;
        }
    }
}
