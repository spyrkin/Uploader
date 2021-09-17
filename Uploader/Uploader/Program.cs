using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uploader
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var test = new Test();
            test.exec();
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

       
    }
}
