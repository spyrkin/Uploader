using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uploader
{
    class AMF : AbstractProject
    {

        public AMF(bool b)
        {
            build = b;
            id = "12";
            exename = "AMF.exe";
            name = "amfootball";
            rootpath = "D:/PROG/ttd.amf";
            assemlyrelpath = "Basket/Properties/AssemblyInfo.cs";
            assemlypath = rootpath + "/" + assemlyrelpath;
            realesefolder = rootpath + "/" + "release";
            zipfolder = @"C: \Users\Programmist\Desktop\realeses\";
            ftpurl = "ftp://update.instatsport.com/amfootball/";
            httpurl = "http://update.instatsport.com/amfootball/";
            buildCommand = "\"C:/Program Files (x86)/Microsoft Visual Studio/2017/Community/Common7/IDE/devenv.exe\" /rebuild Release D:/PROG/ttd.amf/AMF.sln";
        }






        public override string getZipName()
        {
            throw new NotImplementedException();
        }
    }
}
