using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Uploader
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //var test = new Test();
            //test.exec();
            checkInfo();
            Console.WriteLine("Ваша лодка готова, капитан!");
            Worker wk = new Worker();
            if (wk.Action == 0)
            {
                wk.CREATENEW();
            }

            if (wk.Action == 1)
            {
                wk.ZIPNEW();
            }

        }

        //проверяем что есть
        private static void checkInfo()
        {
            string host = Dns.GetHostName();
            DATA.hostname = host;
        }
    }
}
