using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Uploader
{
    abstract class AbstractProject
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
        public abstract string getNewVerstion(string ver, bool add);      //получение новой версии
        public abstract string getZipName();                    //получение имени для архива

        public bool isMyBuild = false;
    }
}
