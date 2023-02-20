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
            showSalaryExpired();
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

        private static void showSalaryExpired()
        {
            int salary_day = 20;
            DateTime now = DateTime.Now;
            bool is_next_mount = now.Day > salary_day;


            int Month = now.Month;
            int Year = now.Year;
            int next_mouth = Month;
            int next_year = Year;
            if (is_next_mount)
            {
                next_mouth = Month + 1;
                next_year = Year;
                if (Month == 12)
                {
                    next_mouth = 1;
                    next_year = Year + 1;
                }
            }


            DateTime zp = new DateTime(next_year, next_mouth, salary_day);
            var span = zp - now;
            int expired = span.Days + 1;
            if (span.Ticks < 0)
            {
                expired = 0;
            }
            Console.WriteLine("До зп осталось дней: " + expired);
            Console.WriteLine("");

        }

        private static void checkProjects()
        {
            ProjectBuilder pbuilder = new ProjectBuilder();
            pbuilder.create();

        }

        //проверяем что есть

    }
}
