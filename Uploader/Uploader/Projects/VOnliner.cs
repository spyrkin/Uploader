using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uploader
{
    class VOnliner : AbstractProject
    {

        public VOnliner(bool b)
        {
            build = b;
            id = "18";
            exename = "VBALL_ONLINER.exe";
            name = "vonliner";
            rootpath = "C:/Users/Programmist/Desktop/VolleyOnliner";
            assemlyrelpath = "Basket/Properties/AssemblyInfo.cs";
            assemlypath = rootpath + "/" + assemlyrelpath;
            realesefolder = rootpath + "/" + "release";
            zipfolder = @"C: \Users\Programmist\Desktop\realeses\";
            ftpurl = "ftp://update.instatsport.com/volleyballonliner/";
            httpurl = "http://update.instatsport.com/volleyballonliner/";
            buildCommand = "\"C:/Program Files (x86)/Microsoft Visual Studio/2017/Community/Common7/IDE/devenv.exe\" /rebuild Debug C:/Users/Programmist/Desktop/VolleyOnliner/VOnliner.sln";
        }


        public override string getZipName()
        {
            throw new NotImplementedException();
        }
    }
}
