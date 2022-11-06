using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Util.live;

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
            checkProjects();

            Console.WriteLine("Ваша лодка готова, капитан!");
            //Console.ReadKey();
            //return;
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

        private static void checkProjects()
        {
            ProjectBuilder pbuilder = new ProjectBuilder();
            pbuilder.create();

        }

        //проверяем что есть
        private static void checkInfo()
        {
            string host = Dns.GetHostName();
            DATA.hostname = host;
        }
    }
}
