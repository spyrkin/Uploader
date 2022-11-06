using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Uploader
{

    public static class DATA
    {
        public static string hostname;
        public static string rootPath;
        public static string YOUR_GIT_INSTALLED_DIRECTORY;
        public static string zipfolder;


        public static void INIT()
        {
            getHost();
            getRootPath();
            fillData();
        }


        public static  void getRootPath()
        {
            String p = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string folder = p.Replace("\\Uploader.exe", "");
            string pfolder = folder + "\\txt\\" + Uploader.DATA.hostname + "\\";
            DATA.rootPath = pfolder;
        }


        private static void getHost()
        {
            string host = Dns.GetHostName();
            DATA.hostname = host;
        }


        public static void fillData()
        {
            string filesystem = DATA.rootPath + "settings.txt";
            string content = Util.live.FileWorker.ReadFileContent(filesystem);
            String[] lines = content.Split(new string[] { "\n" }, StringSplitOptions.None);
            foreach (var l in lines)
            {
                String[] destr = l.Split(new string[] { "=" }, StringSplitOptions.None);
                string tname = destr[0];
                string tvalue = destr[1];

                if (tname == "YOUR_GIT_INSTALLED_DIRECTORY")
                {
                    YOUR_GIT_INSTALLED_DIRECTORY = tvalue;
                }

                if (tname == "zipfolder")
                {
                    zipfolder = tvalue;
                }
            }


        }
    }
}
