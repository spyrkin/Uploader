using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uploader
{
    class Handball : AbstractProject
    {

        public Handball(bool b)
        {
            build = b;
            id = "13";
            exename = "HANDBALL.exe";
            name = "handball";
            rootpath = "D:/PROG/ttd.handball";
            assemlyrelpath = "Basket/Properties/AssemblyInfo.cs";
            assemlypath = rootpath + "/" + assemlyrelpath;
            realesefolder = rootpath + "/" + "release";
            zipfolder = @"C: \Users\Programmist\Desktop\realeses\";
            ftpurl = "ftp://update.instatsport.com/handball/";
            httpurl = "http://update.instatsport.com/handball/";
            buildCommand = "\"C:/Program Files (x86)/Microsoft Visual Studio/2017/Community/Common7/IDE/devenv.exe\" /rebuild Release D:/PROG/ttd.handball/HANDBALL.sln";
        }









        public override string getZipName()
        {
            throw new NotImplementedException();
        }
    }
}
