using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uploader
{
    class HockeyRedbull : AbstractProject
    {

        public HockeyRedbull(bool b)
        {
            build = b;
            id = "20";
            exename = "HOCKEY_REDBULL.exe";
            name = "hockeyredbull";
            rootpath = "C:/Users/Programmist/Desktop/Redbull";
            assemlyrelpath = "Basket/Properties/AssemblyInfo.cs";
            assemlypath = rootpath + "/" + assemlyrelpath;
            realesefolder = rootpath + "/" + "release";
            zipfolder = @"C: \Users\Programmist\Desktop\realeses\";
            ftpurl = "ftp://update.instatsport.com/hockeyredbull/";
            httpurl = "http://update.instatsport.com/hockeyredbull/";
            buildCommand = getbuildcommabd(VSversion.VS2017);
        }

        public string getbuildcommabd(VSversion vs)
        {
            if (vs == VSversion.VS2015)
            {
                return "\"C:/Program Files (x86)/Microsoft Visual Studio 14.0/Common7/IDE/devenv.exe\" /rebuild Debug C:/Users/Programmist/Desktop/Redbull/HockeyRedbull.sln";
            }

            if (vs == VSversion.VS2017)
            {
                return "\"C:/Program Files (x86)/Microsoft Visual Studio/2017/Community/Common7/IDE/devenv.exe\" /rebuild Debug C:/Users/Programmist/Desktop/Redbull/HockeyRedbull.sln";
            }
            return "";

        }

        public override string getNewVerstion(string ver, bool add)
        {

            string newversion = "";
            string cver = ver.Substring(1, ver.Length - 2); //обрезанная версия
            string[] versnum = cver.Split(new String[] { "." }, StringSplitOptions.None);
            int n1 = Convert.ToInt32(versnum[0]);
            int n2 = Convert.ToInt32(versnum[1]);
            int n3 = Convert.ToInt32(versnum[2]);
            int n4 = Convert.ToInt32(versnum[3]);
            int new_number = n4 + n3 * 100 + n2 * 10000 + n1 * 1000000;

            if (add)
            {
                new_number++;
            }
            return new_number.ToString();
        }



        public override string getZipName()
        {
            throw new NotImplementedException();
        }
    }
}
