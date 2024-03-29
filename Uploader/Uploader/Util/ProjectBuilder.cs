﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uploader;

namespace Util.live
{
    //класс для создания проекта
    public class ProjectBuilder
    {
        public List<string> activeProject = new List<String> { "hockey", "basket", "handball", "amf" };
        //путь до txt


        public AbstractProject GetProject(string pname)
        {
            AbstractProject tproject = null;
            switch (pname)
            {
                case "hockey":
                    tproject = new Hockey(true);

                    break;

                case "basket":
                    tproject = new Basket(true);

                    break;

                case "handball":
                    tproject = new Handball(true);

                    break;


                case "amf":
                    tproject = new AMF(true);

                    break;



                default:
                    break;
            }
            tproject.filsystem = DATA.rootPath + pname + ".txt";
            tproject.adjast();
            return tproject;
        }


        public void create()
        {
            foreach (var pname in activeProject)
            {
                try
                {
                    checkFolder(pname);
                    AbstractProject project = null;
                    AbstractProject tproject = null;



                    switch (pname)
                    {
                        case "hockey":
                            project = new Hockey(true);
                            tproject = new Hockey(true);
                            break;

                        case "basket":
                            project = new Basket(true);
                            tproject = new Basket(true);
                            break;

                        case "handball":
                            project = new Handball(true);
                            tproject = new Handball(true);
                            break;

                        case "amf":
                            project = new AMF(true);
                            tproject = new AMF(true);
                            break;

                        default:
                            break;
                    }
                    tproject.filsystem = DATA.rootPath + pname + ".txt";
                    tproject.adjast();

                    checkProjects(project, tproject);


                }
                catch (Exception ex)
                {
                    Console.WriteLine("Wrong data in project " + pname);
                    Console.WriteLine(ex.Message);

                }
            }
        }

        private void checkProjects(AbstractProject project1, AbstractProject project2)
        {

            //if (project1.zipfolder != project2.zipfolder)
            //{
            //    Console.WriteLine("WRONG " + project1.name + "  " + "zipfolder");
            //    Console.WriteLine(project1.zipfolder);
            //    Console.WriteLine(project2.zipfolder);

            //}

            //if (project1.rootpath != project2.rootpath)
            //{
            //    Console.WriteLine("WRONG " + project1.name + "  " + "rootpath");
            //    Console.WriteLine(project1.rootpath);
            //    Console.WriteLine(project2.rootpath);

            //}


            //if (project1.buildCommand != project2.buildCommand)
            //{
            //    Console.WriteLine("WRONG " + project1.name + "  " + "buildCommand");
            //    Console.WriteLine(project1.buildCommand);
            //    Console.WriteLine(project2.buildCommand);

            //}
        }

        private void checkFolder(String name)
        {
            string filename = DATA.rootPath + name + ".txt";
            if (!File.Exists(filename))
            {
                throw new Exception(filename + "    not found");
            }
        }
    }
}
