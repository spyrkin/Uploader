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
            DATA.INIT();

            checkProjects();
            //Console.ReadKey();
            //return;
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

        private static void checkProjects()
        {
            ProjectBuilder pbuilder = new ProjectBuilder();
            pbuilder.create();

        }

        //проверяем что есть

    }
}
