using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uploader
{
    class Worker
    {
        public Utils utils;
        public AbstractProject project;
        public string currentVersion = "";
        public string newVersion = "";
        public string bserVersion = "";
        public string YOUR_GIT_INSTALLED_DIRECTORY = "C:/Program Files/Git/";
        public string zipname;

        public int Action = 0; // 0 = создать новую версию, 1 - создать архив


        public Worker()
        {
            setAction();
            if (Action == 2)
            {
                TestBserv();
                Thread.Sleep(10000);
                return;
            }
            setProject();
            utils = new Utils();
        }

        public void setAction()
        {
            Console.WriteLine("Выберите действие: ");
            Console.WriteLine("0 - НОВАЯ ВЕРСИЯ  ");
            Console.WriteLine("1 - АРХИВ ");

            //Console.WriteLine("2 - ЧИСТИМ ТЕЛЕФОН ");

            string name = Console.ReadLine();

            switch (name)
            {
                case "0":
                    Action =0;
                    break;
                case "1":
                    Action = 1;
                    break;

                //case "2":
                //    Action = 2;
                //    break;
                default:
                    setAction();
                    break;
            }
        }

        public void setProject()
        {

            //if (Action == 2)
            //{
            //    return;
            //}
            Console.WriteLine("Введите номер проекта: ");
            Console.WriteLine("1 - баскетбол ");
            Console.WriteLine("2 - хоккей ");
            Console.WriteLine("3 - амфутбол ");
            //Console.WriteLine("4 - гандболл ");
            Console.WriteLine("5 - баскетбол_онлайнер ");
            //Console.WriteLine("6 - волейболл_онлайнер ");
            Console.WriteLine("7 - гандболл_онлайнер ");
            Console.WriteLine("8 - гантбол ");

            //Console.WriteLine("8 - хоккей_онлайнер ");
            Console.WriteLine("r - хоккей редбулл ");






            //Console.WriteLine("8 - баскетбол without build");
            //Console.WriteLine("9 - хоккей  without build");
            string name = Console.ReadLine();
            switch (name)
            {
                case "1":
                    project = new Basket(true);
                    break;
                case "2":
                    project = new Hockey(true);
                    break;
                case "3":
                    project = new AMF(true);
                    break;
                //case "4":
                //    project = new Handball(true);
                //    break;
                case "5":
                    project = new BOnliner(true);
                    break;
                case "6":
                    project = new VOnliner(true);
                    break;
                case "7":
                    project = new HOnliner(true);
                    break;
                case "8":
                    project = new Handball(true);
                    break;
                case "r":
                    project = new HockeyRedbull(true);
                    break;
                //case "8":
                //    project = new HOKnliner(true);
                //    break;
                //case "8":
                //    project = new Basket(false);
                //    break;
                //case "9":
                //    project = new Hockey(false);
                //    break;
                default:
                    setProject();
                    break;
            }
        }

    

        public string setVersion()
        {
            Utils utils = new Utils();
            string assemlyContent = "";
            assemlyContent = utils.getFileContent(project.assemlypath);
            int st_index = assemlyContent.IndexOf("AssemblyVersion");
            int l1 = "AssemblyVersion(".Length;
            int st1 = st_index + l1;                                                           //индекс откуда начинается строка версия
            int st2 = 0;                                                                       //индекс где кончается строка версия

            for (int i = st1; i < assemlyContent.Length - 1; i++)
            {
                if (assemlyContent[i] == ')')
                {
                    st2 = i;
                    break;
                }
            }
            currentVersion = assemlyContent.Substring(st1, st2 - st1);                         //получаем старую версию

            Console.WriteLine("Current version: " + currentVersion);
            if (project.build)
            {
                newVersion = project.getNewVerstion(currentVersion, true); //получаем новую версию

                bserVersion = modifyVersion(); //получаем представление версии в формала 1.2.3.4                                  
                Console.WriteLine("NewVersion version: " + bserVersion);
                assemlyContent = assemlyContent.Substring(0, st1) + "\"" + bserVersion + "\"" + //заменяем
                                 assemlyContent.Substring(st2, assemlyContent.Length - st2);

                utils.saveFileContent(project.assemlypath, assemlyContent); //сохраняем файл
            }
            else
            {
                newVersion = project.getNewVerstion(currentVersion, false);
            }
            return currentVersion;

        }

        private string modifyVersion()
        {
            string res = "";
            int nv = Convert.ToInt32(newVersion);
            int num1 = nv / 1000000;
            nv = nv - num1 * 1000000;
            int num2 = nv / 10000;
            nv = nv - num2 * 10000;
            int num3 = nv / 100;
            nv = nv - num3 * 100;
            int num4 = nv;
            res = num1 + "." + num2 + "." + num3 + "." + num4;
            return res;
        }

        public void commit()
        {
            ProcessStartInfo gitInfo = new ProcessStartInfo();
            gitInfo.CreateNoWindow = true;
            gitInfo.RedirectStandardError = true;
            gitInfo.RedirectStandardOutput = true;
            gitInfo.FileName = YOUR_GIT_INSTALLED_DIRECTORY + @"\bin\git.exe";

            Process gitProcessAdd = new Process();
            gitInfo.Arguments = "add " + project.assemlyrelpath; // such as "fetch orign"
            gitInfo.WorkingDirectory = project.rootpath;
            gitInfo.UseShellExecute = false;
            gitProcessAdd.StartInfo = gitInfo;
            gitProcessAdd.Start();

            string stderr_strAdd = gitProcessAdd.StandardError.ReadToEnd();  // pick up STDERR
            string stdout_strAdd = gitProcessAdd.StandardOutput.ReadToEnd(); // pick up STDOUT
            Console.WriteLine(stderr_strAdd);
            Console.WriteLine(stdout_strAdd);

            String sdate = DateTime.Today.ToString("yyyy-MM-dd");

            Process gitProcess = new Process();
            gitInfo.Arguments = "commit -m changeversion"; // such as "fetch orign"
            gitInfo.WorkingDirectory = project.rootpath;
            gitInfo.UseShellExecute = false;
            gitProcess.StartInfo = gitInfo;
            gitProcess.Start();

            string stderr_str = gitProcess.StandardError.ReadToEnd();  // pick up STDERR
            string stdout_str = gitProcess.StandardOutput.ReadToEnd(); // pick up STDOUT
            Console.WriteLine(stderr_str);
            Console.WriteLine(stdout_str);
            gitProcess.WaitForExit();
            gitProcess.Close();

        }

        public bool createZip()
        {
            bool res = true;
            DateTime thisDay = DateTime.Today;
            string stDate = thisDay.ToString("yyyy-MM-dd");
            zipname = project.name + "-" + stDate + "_v_" + newVersion + ".zip";
            string fullzipname = project.zipfolder + "/" + zipname;
            Console.WriteLine("Create arhive: " + zipname);
            File.Delete(fullzipname);
            System.IO.Compression.ZipFile.CreateFromDirectory(project.realesefolder, fullzipname);

            Console.WriteLine("Проверка существования .exe");
            if (Directory.Exists(project.zipfolder + "\\TEST_R"))
            {
                Directory.Delete(project.zipfolder + "\\TEST_R", true);
            }

            Directory.CreateDirectory(project.zipfolder + "\\TEST_R");
            Console.WriteLine(" *");
            System.IO.Compression.ZipFile.ExtractToDirectory(fullzipname, project.zipfolder + "\\TEST_R");
            if (File.Exists(project.zipfolder + "\\TEST_R\\" + project.exename))
            {
                res = true;
            }
            else
            {
                res = false;
            }
            Console.WriteLine(" *");
            Directory.Delete(project.zipfolder + "\\TEST_R", true);
            Console.WriteLine(" *");
            return res;
        }

        public int ftpUpload()
        {
            string fullzipname = project.zipfolder + "/" + zipname;
            Console.WriteLine("Upload to: " + project.ftpurl + zipname);
            using (WebClient client = new WebClient())
            {
                client.Credentials = new NetworkCredential("update", "Wu5yooDa");
                try
                {
                    client.UploadFile(project.ftpurl + zipname, "STOR", fullzipname);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    Thread.Sleep(10*1000);
                    return 1;
                }
            }
            return 0;
        }

        public void CREATENEW()
        {
            infowork();
            clearFolder();
            setVersion();
            if (project.build)
            {

                build();

                Thread.Sleep(60 * 1000);
                commit();
            }
            int i = 0;
            recursiveWork(0);

            Console.WriteLine("Press any Key to Continue");
            Console.ReadKey();

        }

        public void infowork()
        {
            int i = 0;
            int j = 0;
            int k = 0;
            int h = 0;
            int bo = 0;
            int vo = 0;
            int ho = 0;
            int hko = 0;


            Console.WriteLine("");
            Console.WriteLine(new String('=',20));

            float folderSize = 0.0f;
            DirectoryInfo info = new DirectoryInfo(project.zipfolder);
            long sizes = DirSize(info);
            double gb = sizes / (Math.Pow(2,30));
            string stringSize = gb.ToString(".00");
            Console.WriteLine("Releases sizes:" +stringSize);

            foreach (FileInfo f in info.GetFiles())
            {
                if (f.Name.Contains("basket"))
                {
                    i++;
                }

                if (f.Name.Contains("hockey"))
                {
                    j++;
                }
                if (f.Name.Contains("amfootball"))
                {
                    k++;
                }

                if (f.Name.Contains("handball"))
                {
                    h++;
                }
                if (f.Name.Contains("bonliner"))
                {
                    bo++;
                }
                if (f.Name.Contains("vonliner"))
                {
                    vo++;
                }
                if (f.Name.Contains("honliner"))
                {
                    ho++;
                }
                if (f.Name.Contains("hkonliner"))
                {
                    hko++;
                }
            }

            Console.WriteLine("");
            Console.WriteLine("basket: " + i);
            Console.WriteLine("hockey: " + j);
            Console.WriteLine("amfootball: " + k);
            Console.WriteLine("handball: " + h);
            Console.WriteLine("bonliner: " + bo);
            Console.WriteLine("vonliner: " + vo);
            Console.WriteLine("honliner: " + ho);
            Console.WriteLine("hkonliner: " + hko);









            Console.WriteLine(new String('=', 20));
            Console.WriteLine("");
        }

        public static long DirSize(DirectoryInfo d)
        {
            long Size = 0;
            // Add file sizes.
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                Size += fi.Length;
            }
            return Size;
        }

        public void recursiveWork(int i)
        {
            Console.WriteLine("Попытка: " + i);
            bool zip_res = createZip();
            if (zip_res)
            {
                Console.WriteLine("exist");
                int ret = ftpUpload();
                if (ret == 1)
                {
                    i++;
                    recursiveWork(i);
                    return;
                }
                updateService();
                if (project.id == "8" || project.id == "9" || project.id == "13")
                {
                    updateServicBserv();
                }
            }
            else
            {
                i++;
                Console.WriteLine("NO");
                recursiveWork(i);
            }
        }

        public void build()
        {

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    RedirectStandardInput = true,
                    UseShellExecute = false
                }
            };
            process.Start();
            process.EnableRaisingEvents = true;

            process.Exited += new EventHandler(process_Exited);

            using (StreamWriter pWriter = process.StandardInput)
            {
                if (pWriter.BaseStream.CanWrite)
                {
                    foreach (var line in project.buildCommand.Split('\n'))
                        pWriter.WriteLine(line);
                }
            }
            process.WaitForExit();
            process.Close();

        }

        private void process_Exited(object sender, EventArgs e)
        {
            Console.WriteLine("Building done wait ....");
        }


        private void clearReleaseFolder()
        {
            string FolderName = project.zipfolder;
            DirectoryInfo folder = new DirectoryInfo(FolderName);

            foreach (FileInfo file in folder.GetFiles())
            {

                file.Delete();
                Console.WriteLine("Delete: "+file.Name);
            }

            foreach (DirectoryInfo dir in folder.GetDirectories())
            {
                dir.Delete(true);
                Console.WriteLine("Delete: " + folder.Name);

            }
        }

        private void clearFolder()
        {

            string FolderName = project.realesefolder + "/db/";
            DirectoryInfo dir = new DirectoryInfo(FolderName);

            foreach (FileInfo fi in dir.GetFiles())
            {
                Console.WriteLine("Delete : " + fi.Name);
                fi.Delete();
            }

            string FolderName2 = project.realesefolder;
            DirectoryInfo dir2 = new DirectoryInfo(FolderName2);

            foreach (FileInfo fi in dir2.GetFiles())
            {

                if (fi.Extension == ".lastuser")
                {
                    Console.WriteLine("Delete : " + fi.Name);
                    fi.Delete();
                }
                if (fi.Extension == ".log")
                {
                    Console.WriteLine("Delete : " + fi.Name);
                    fi.Delete();
                }
                if (fi.Extension == ".auto")
                {
                    Console.WriteLine("Delete : " + fi.Name);
                    fi.Delete();
                }
            }
            string cashfolder = project.realesefolder + "/cache/";
            string debugFolder = project.realesefolder + "/debug/";


            if (Directory.Exists(cashfolder))
            {
                Directory.Delete(cashfolder, true);
            }

            if (Directory.Exists(debugFolder))
            {
                Directory.Delete(debugFolder, true);
            }
            Directory.CreateDirectory(cashfolder);
            Directory.CreateDirectory(debugFolder);

            if (File.Exists(project.realesefolder + "\\_UPDATELINK.txt"))
            {
                File.Delete(project.realesefolder + "\\_UPDATELINK.txt");
                Console.WriteLine("Delete : UPDATELINK.txt");
            }


        }

        private async void updateServicBserv()
        {


            try
            {

                Console.WriteLine("Change in bserv");
                UpldateDataJson ud = new UpldateDataJson();
                ud.Id = project.id;
                ud.Link = project.httpurl + zipname;
                ud.Version = bserVersion;
                string web_url = "https://bserv.instatfootball.tv/Updates/UpVersion";

                HttpClient client = new HttpClient();

                var stream1 = new MemoryStream();
                var ser = new DataContractJsonSerializer(typeof(UpldateDataJson));
                ser.WriteObject(stream1, ud);
                stream1.Position = 0;
                var sr = new StreamReader(stream1);
                var data = sr.ReadToEnd();

                HttpContent httpContent = new StringContent(data);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.PostAsync(web_url, httpContent);
                Console.WriteLine(response.StatusCode.ToString());
                var responseString = await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            //try
            //{
            //    Console.WriteLine("Change in bserv");
            //    UpldateData2 ud = new UpldateData2();
            //    ud.id = project.id;
            //    ud.link = project.httpurl + zipname;
            //    ud.version = bserVersion;
            //    string web_url = "https://bserv.instatfootball.tv/Updates/UpVersion";
            //    ud.setValues();
            //    HttpClient client = new HttpClient();
            //    HttpContent httpContent = new FormUrlEncodedContent(ud.values);
            //    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //    var response = await client.PostAsync(web_url, httpContent);
            //    Console.WriteLine(response.StatusCode.ToString());
            //    var responseString = await response.Content.ReadAsStringAsync();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    Console.ReadKey();
            //}
        }


        public static HttpClient GetClient(string username, string password)
        {
            var authValue = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}")));

            var client = new HttpClient()
            {
                DefaultRequestHeaders = { Authorization = authValue }
                //Set some other client defaults like timeout / BaseAddress
            };
            return client;
        }



        private async void updateService()
        {
            try
            {
                Console.WriteLine("Change in http://data.instatfootball.tv/views_custom/desktop_updates.php");
                UpldateData ud = new UpldateData();
                ud.id = project.id;
                ud.version = newVersion;
                ud.update = project.httpurl + zipname;
                string web_url = "http://data.instatfootball.tv/views_custom/desktop_updates.php";
                ud.setValues();
                HttpClient client = new HttpClient();
                var content = new FormUrlEncodedContent(ud.values);
                var response = await client.PostAsync(web_url, content);
                Console.WriteLine(response.StatusCode.ToString());
                var responseString = await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }

        [DataContract]
        public class UpldateDataJson
        {
            [DataMember(Name = "Id")]
            public string Id;
            [DataMember(Name = "Link")]
            public string Link;
            [DataMember(Name = "Version")]
            public string Version;
            [DataMember(Name = "Password")]
            public string Password = "tr452ff441123dddffs123";
        }

        public class UpldateData2
        {

            public Dictionary<string, string> values = new Dictionary<string, string>();
            public string link;
            public string version;
            public string id;

            public void setValues()
            {
                values.Add("Link", link);
                values.Add("Password", "tr452ff441123dddffs123");
                values.Add("Version", version);
                values.Add("Id", id);

            }
        }


        public class UpldateData
        {

            public Dictionary<string, string> values = new Dictionary<string, string>();
            public string id;
            public string version;
            public string update;

            public void setValues()
            {
                values.Add("id", id);
                values.Add("version", version);
                values.Add("update", update);
                values.Add("action", "edit");

            }
        }

        public void ZIPNEW()
        {
            Console.WriteLine("ZIP NEW ");

            clearFolder();
            string path1 = project.rootpath + "/release1.7z";
            string path2 = project.rootpath + "/release1.zip";
            string path3 = project.rootpath + "/release1.rar";
            string path4 = project.rootpath + "/release1.zip";

            if (File.Exists(path1))
            {
                File.Delete(path1);
                Console.WriteLine("remove archive: " + path1);
            }

            if (File.Exists(path2))
            {
                File.Delete(path2);
                Console.WriteLine("remove archive: " + path2);
            }

            if (File.Exists(path3))
            {
                File.Delete(path3);
                Console.WriteLine("remove archive: " + path3);
            }

            clearReleaseFolder();

            Console.WriteLine("creating .... ");
            DateTime thisDay = DateTime.Today;
            string stDate = thisDay.ToString("yyyy-MM-dd");
            zipname = project.zipfolder + "/"+project.name + "-" + stDate+".zip";

            System.IO.Compression.ZipFile.CreateFromDirectory(project.realesefolder, zipname);
            StringCollection paths = new StringCollection();
            paths.Add(zipname);
            Clipboard.SetFileDropList(paths);

            Console.WriteLine("DONE");

            Console.ReadLine();

        }

        public void ClearTel()
        {
            String path = new System.IO.FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName;
            path = path + "\\TelClear.txt";
            List<String> lines = new List<string>();
            const Int32 BufferSize = 128;
            using (var fileStream = File.OpenRead(path))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {

                    lines.Add(line);
                }
            }


            foreach (string s in lines)
            {

                string pp = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                System.Diagnostics.Process.Start("explorer", pp);

                DirectoryInfo dir = new DirectoryInfo(@s);
                if (!dir.Exists)
                {
                    Console.WriteLine("111");
                }
                foreach (FileInfo fi in dir.GetFiles())
                {
                    Console.WriteLine("Delete : " + fi.Name);

                    //fi.Delete();
                }
            }

        }

        public void TestBserv()
        {
            try
            {
                updateServicBservTest();
            }
            catch (Exception ex)
            {

            }
        }


        private async void updateServicBservTest()
        {
            try
            {
                //ServicePointManager.ServerCertificateValidationCallback = new
                //    RemoteCertificateValidationCallback
                //    (
                //       delegate { return true; }
                //    );

                Console.WriteLine("Change in bserv");
                UpldateDataJson ud = new UpldateDataJson();
                ud.Id = "13";
                ud.Link = "http://update.instatsport.com/handball/handball-2021-06-29_v_1006400.zip";
                ud.Version = "1.0.64.0";
                string web_url = "https://bserv.instatfootball.tv/Updates/UpVersion";

                HttpClient client = new HttpClient();

                var stream1 = new MemoryStream();
                var ser = new DataContractJsonSerializer(typeof(UpldateDataJson));
                ser.WriteObject(stream1, ud);
                stream1.Position = 0;
                var sr = new StreamReader(stream1);
                var data = sr.ReadToEnd();

                HttpContent httpContent = new StringContent(data);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                
                var response = await client.PostAsync(web_url, httpContent);
                Console.WriteLine(response.StatusCode.ToString());
                var responseString = await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
    }
}
