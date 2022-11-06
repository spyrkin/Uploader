using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uploader
{
    class Basket: AbstractProject
    {

        public Basket(bool b)
        {
            build = b;
            id = "8";
            exename = "basket.exe";
            name = "basket";
            rootpath = "D:/PROG/ttd.basket";
            assemlyrelpath = "Basket/Properties/AssemblyInfo.cs";
            assemlypath = rootpath + "/" + assemlyrelpath;
            realesefolder = rootpath + "/" + "release";
            zipfolder = @"C: \Users\Programmist\Desktop\realeses\";
            ftpurl = "ftp://update.instatsport.com/basket/";
            httpurl = "http://update.instatsport.com/basket/";
            buildCommand = "\"C:/Program Files (x86)/Microsoft Visual Studio/2017/Community/Common7/IDE/devenv.exe\" /rebuild Release D:/PROG/ttd.basket/Basket.sln";
        }






        public override string getZipName()
        {
            throw new NotImplementedException();
        }
    }
}
