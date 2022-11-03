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



        public override string getNewVerstion(string ver, bool add)
        {

            string newversion = "";
            string cver = ver.Substring(1, ver.Length - 2); //обрезанная версия
            string[] versnum = cver.Split(new String[] {"."}, StringSplitOptions.None);
            int n1 = Convert.ToInt32(versnum[0]);
            int n2 = Convert.ToInt32(versnum[1]);
            int n3 = Convert.ToInt32(versnum[2]);
            int n4 = Convert.ToInt32(versnum[3]);
            int new_number = n3 * 100 + n2 * 10000 + n1 * 1000000;

            if (add)
            {
                new_number = new_number + 100;
            }
            return new_number.ToString();
        }

        public override string getZipName()
        {
            throw new NotImplementedException();
        }
    }
}
