using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Pengamatan6
{
    class Program
    {
        void Write()
        {
            int n;
            Console.Write("Masukan Jumlah Array :");
            n = int.Parse(Console.ReadLine());
            int[] array_sort = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Array no :" + (i + 1) + " = ");
                array_sort[i] = int.Parse(Console.ReadLine());
            }
          
            using (BinaryWriter binWriter = new BinaryWriter(File.Open("file.bin", FileMode.Create)))
            {
                foreach(int i in array_sort)
                {
                    binWriter.Write(i);
                    Console.WriteLine("Berhasil Menulis : {0} pada file.bin", i);
                    Thread.Sleep(1000);
                }
            }
        }
        void Read()
        {
            using (BinaryReader b = new BinaryReader(File.Open("file.bin", FileMode.Open)))
            {
                int pos = 0;
                int length = (int)b.BaseStream.Length;
                while(pos < length)
                {
                    int V = b.ReadInt32();
                    Console.WriteLine("Berhasil Membaca {0} pada file.bin", V);
                    pos += sizeof(int);
                    if(V == 55)
                    {
                        Thread.CurrentThread.Abort();
                    }
                    Thread.Sleep(1000);

                }
            }
        }
        static void Main(string[] args)
        {
            Program rw = new Program();
            rw.Write();
            rw.Read();

            Console.ReadKey();

        }
    }
}
