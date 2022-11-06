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
            buildCommand = "\"C:/Program Files (x86)/Microsoft Visual Studio/2017/Community/Common7/IDE/devenv.exe\" /rebuild Debug C:/Users/Programmist/Desktop/Redbull/HockeyRedbull.sln";
        }







        public override string getZipName()
        {
            throw new NotImplementedException();
        }
    }
}
