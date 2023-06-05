using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Uploader
{
    public abstract class AbstractProject
    {
        public bool build = true;
        public string name;                                     //used for zip name
        public string id;                                       //id на football-parser
        public string rootpath;                                 //путь до папки с проектом
        public string assemlypath;                              //путь до AssemblyInfo.cs
        public string assemlyrelpath;                           //относительный путь до файла (для гита)
        public string zipfolder;                                //местро куда будет положен zip архив
        public string realesefolder;                            //realise
        public string buildCommand;                             //команда используемая для билда
        public string ftpurl;
        public string httpurl;
        public string exename;
        public abstract string getZipName();                    //получение имени для архива

        public string filsystem;                                //испольем для получения пути от которого будем собирать

        public bool isMyBuild = false;


        public virtual string getNewVerstion(string ver, bool add)
        {

            string newversion = "";
            string cver = ver.Substring(1, ver.Length - 2); //обрезанная версия
            string[] versnum = cver.Split(new String[] { "." }, StringSplitOptions.None);
            int n1 = Convert.ToInt32(versnum[0]);
            int n2 = Convert.ToInt32(versnum[1]);
            int n3 = Convert.ToInt32(versnum[2]);
            int n4 = Convert.ToInt32(versnum[3]);
            int new_number = n3 * 100 + n2 * 10000 + n1 * 1000000;

            if (add)
            {
                new_number = new_number + 100;
            }
            return new_number.ToString();
        }




        //достаем часть данных из файоа
        public void adjast()
        {
            string content = Util.live.FileWorker.ReadFileContent(filsystem);
            String[] lines = content.Split(new string[] { "\n" }, StringSplitOptions.None);
            foreach (var l in lines)
            {
                String[] destr = l.Split(new string[] { "=" }, StringSplitOptions.None);
                string tname = destr[0];
                string tvalue = destr[1];

                if (tname == "zipfolder")
                {
                    zipfolder = tvalue;
                }

                if (tname == "rootpath")
                {
                    rootpath = tvalue;
                }

                if (tname == "buildCommand")
                {
                    
                    buildCommand = tvalue;
                    buildCommand = buildCommand.Replace("\\", "");
                }


            }
            assemlypath = rootpath + "/" + assemlyrelpath;
            realesefolder = rootpath + "/" + "release";
            zipfolder = DATA.zipfolder;


        }
    }
}
