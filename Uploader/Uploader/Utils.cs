using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uploader
{
    public class Utils
    {

        public string getFileContent(string path)
        {
            String content = "";
            String line = "";
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                content = content + line + '\n';
            }

            file.Close();

            // Suspend the screen.
            return content;
        }

        public void saveFileContent(string path, string content)
        {
            File.WriteAllText(path, content);

        }


    }
}
