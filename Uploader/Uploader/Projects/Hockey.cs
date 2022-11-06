using System;


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
            rootpath = "D:/PROG/ttd.hokreg";
            assemlyrelpath = "Hokreg/Properties/AssemblyInfo.cs";
            assemlypath = rootpath + "/" + assemlyrelpath;
            realesefolder = rootpath + "/" + "release";
            zipfolder = @"C: \Users\Programmist\Desktop\realeses\";
            ftpurl = "ftp://update.instatsport.com/hokreg/";
            httpurl = "http://update.instatsport.com/hokreg/";
            buildCommand = "\"C:/Program Files (x86)/Microsoft Visual Studio/2017/Community/Common7/IDE/devenv.exe\" /rebuild Release D:/PROG/ttd.hokreg/Hokreg.sln";
            isMyBuild = false;



        }




        public override string getZipName()
        {
            throw new NotImplementedException();
        }
    }
}
