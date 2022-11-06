using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uploader
{
    class BOnliner : AbstractProject
    {

        public BOnliner(bool b)
        {
            build = b;
            id = "17";
            exename = "BASKET_ONLINER.exe";
            name = "bonliner";
            rootpath = "C:/Users/Programmist/Desktop/BasketOnliner";
            assemlyrelpath = "Basket/Properties/AssemblyInfo.cs";
            assemlypath = rootpath + "/" + assemlyrelpath;
            realesefolder = rootpath + "/" + "release";
            zipfolder = @"C: \Users\Programmist\Desktop\realeses\";
            ftpurl = "ftp://update.instatsport.com/basketonliner/";
            httpurl = "http://update.instatsport.com/basketonliner/";
            buildCommand = "\"C:/Program Files (x86)/Microsoft Visual Studio/2017/Community/Common7/IDE/devenv.exe\" /rebuild Debug C:/Users/Programmist/Desktop/BasketOnliner/BOnliner.sln";
        }






        public override string getZipName()
        {
            throw new NotImplementedException();
        }
    }
}
