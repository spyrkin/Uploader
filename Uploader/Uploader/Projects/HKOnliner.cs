using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uploader
{
    class HOKnliner : AbstractProject
    {

        public HOKnliner(bool b)
        {
            build = b;
            id = "0";
            exename = "HOCKEY_ONLINER.exe";
            name = "hkonliner";
            rootpath = "C:/Users/Programmist/Desktop/HockeyOnliner";
            assemlyrelpath = "Basket/Properties/AssemblyInfo.cs";
            assemlypath = rootpath + "/" + assemlyrelpath;
            realesefolder = rootpath + "/" + "release";
            zipfolder = @"C: \Users\Programmist\Desktop\realeses\";
            ftpurl = "ftp://update.instatsport.com/hockeyonliner/";
            httpurl = "http://update.instatsport.com/hockeyonliner/";
            buildCommand = "\"C:/Program Files (x86)/Microsoft Visual Studio/2017/Community/Common7/IDE/devenv.exe\" /rebuild Debug C:/Users/Programmist/Desktop/HockeyOnliner/HKOnliner.sln";
        }






        public override string getZipName()
        {
            throw new NotImplementedException();
        }
    }
}
