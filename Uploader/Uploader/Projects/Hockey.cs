using System;
using System.Xml.Linq;


namespace Uploader
{
    class Hockey : AbstractProject
    {

        public Hockey(bool b)
        {
            build = b;
            id = "9";
            exename = "hokreg.exe";
            name = "hockey";
            Aname = "Hokreg";
            rootpath = "D:/PROG/ttd.hokreg3";
            assemlyrelpath = "Hokreg/Hokreg.csproj";
            assemlypath = rootpath + "/" + assemlyrelpath;
            realesefolder = rootpath + "/bin/Release/net461";
            zipfolder = @"C: \Users\Programmist\Desktop\realeses\";
            ftpurl = "ftp://update.instatsport.com/hokreg/";
            httpurl = "http://update.instatsport.com/hokreg/";
            buildCommand = "\"C:/Program Files (x86)/Microsoft Visual Studio/2017/Community/Common7/IDE/devenv.exe\" /rebuild Release D:/PROG/ttd.hocker2/TTD.Hockey/Hokreg.sln";
            isMyBuild = false;



        }




        public override string getZipName()
        {
            throw new NotImplementedException();
        }
    }
}
