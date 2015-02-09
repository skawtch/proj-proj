using System;
using System.Reflection;
using Microsoft.Office.Interop.MSProject;

namespace ProjectTimesheet
{
    class projectFile
    {
        static int openfile(string file_path)
        {
            ApplicationClass app = new ApplicationClass();
            app.FileOpenEx(file_path);
            Project proj = app.Projects[0];
            return 0;
        }
    }
}
