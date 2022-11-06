using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uploader
{
    class HOnliner : AbstractProject
    {

        public HOnliner(bool b)
        {
            build = b;
            id = "19";
            exename = "HANDBALL_ONLINER.exe";
            name = "honliner";
            rootpath = "C:/Users/Programmist/Desktop/HANDBALL2";
            assemlyrelpath = "Basket/Properties/AssemblyInfo.cs";
            assemlypath = rootpath + "/" + assemlyrelpath;
            realesefolder = rootpath + "/" + "release";
            zipfolder = @"C: \Users\Programmist\Desktop\realeses\";
            ftpurl = "ftp://update.instatsport.com/handballonliner/";
            httpurl = "http://update.instatsport.com/handballonliner/";
            buildCommand = "\"C:/Program Files (x86)/Microsoft Visual Studio/2017/Community/Common7/IDE/devenv.exe\" /rebuild Debug C:/Users/Programmist/Desktop/HANDBALL2/HOnliner.sln";
        }







        public override string getZipName()
        {
            throw new NotImplementedException();
        }
    }
}
