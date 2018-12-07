using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace windbg_net
{
    public static class HighMemory
    {
        private static List<Bitmap> localCache = new List<Bitmap>();
        public static void SetHighMemory()
        {
            for (long i = 0; i < 1000000; i++)
            {
                var pic = ReadImageFile("G:\\GitHub\\windbg_test\\windbg\\windbg_net\\bin\\Debug\\time.jpg");
                localCache.Add(pic);
            }
            Console.ReadKey();
        }

        public static Bitmap ReadImageFile(string path)
        {
            FileStream fs = File.OpenRead(path); //OpenRead
            int filelength = 0;
            filelength = (int)fs.Length; //获得文件长度 
            Byte[] image = new Byte[filelength]; //建立一个字节数组 
            fs.Read(image, 0, filelength); //按字节流读取 
            System.Drawing.Image result = System.Drawing.Image.FromStream(fs);
            fs.Close();
            Bitmap bit = new Bitmap(result);
            return bit;
        }
    }
}
