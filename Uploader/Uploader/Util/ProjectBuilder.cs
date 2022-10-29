using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uploader;

namespace Util.live
{
    //класс для создания проекта
    public class ProjectBuilder
    {
        public List<string> activeProject = new List<String> { "hockey" };
        //путь до txt
        public string rootPath = "";
        public void getRootPath()
        {
            String p = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string folder = p.Replace("\\Uploader.exe", "");
            string pfolder = folder + "\\txt\\" + Uploader.DATA.hostname + "\\";
            rootPath = pfolder;
        }


        public void create()
        {
            getRootPath();
            foreach (var pname in activeProject)
            {
                try
                {
                    checkFolder(pname);
                    AbstractProject project = null;
                    AbstractProject tproject = null;



                    switch (pname)
                    {
                        case "hockey":
                            project = new Hockey(true);
                            tproject = new Hockey(true);
                            break;

                        default:
                            break;
                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine("Wrong data in project " + pname);
                    Console.WriteLine(ex.Message);

                }
            }
        }

        private void checkFolder(String name)
        {
            string filename = rootPath + name + ".txt";
            if (!File.Exists(filename))
            {
                throw new Exception(filename + "    not found");
            }
        }
    }
}
