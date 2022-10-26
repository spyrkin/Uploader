using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uploader.Projects
{
    class TestProject : AbstractProject
    {
        public override string getNewVerstion(string ver, bool add)
        {

            string newversion = "";
            string cver = ver.Substring(1, ver.Length - 2); //обрезанная версия
            string[] versnum = cver.Split(new String[] { "." }, StringSplitOptions.None);
            int n1 = Convert.ToInt32(versnum[0]);
            int n2 = Convert.ToInt32(versnum[1]);
            int n3 = Convert.ToInt32(versnum[2]);
            int n4 = Convert.ToInt32(versnum[3]);
            int new_number = n4 + n3 * 100 + n2 * 10000 + n1 * 1000000;

            if (add)
            {
                new_number++;
            }
            return new_number.ToString();
        }



        public override string getZipName()
        {
            throw new NotImplementedException();

        }
    }
}
