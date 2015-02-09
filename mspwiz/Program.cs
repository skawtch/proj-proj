using System;
using System.Reflection;
using System.Collections;
using Microsoft.Office.Interop.MSProject;

namespace mspwiz
{
    class Program
    {
        static void Main(string[] args)
        {
            string file_path = "C:\\Users\\mblake\\Desktop\\project d\\Business Project\\PM\\";
            string file_name = "TAH Timeline.mpp";
            DateTime begDate = Convert.ToDateTime("1/1/2015");
            DateTime endDate = Convert.ToDateTime("1/31/2015");

            PjTaskTimescaledData wtype = PjTaskTimescaledData.pjTaskTimescaledActualWork;          
            PjTimescaleUnit wunit = PjTimescaleUnit.pjTimescaleDays;

            Application app = new Application();
            // PjAssignmentTimescaledData.pjAssignmentTimescaledWork;
            // PjTimescaleUnit.pjTimescaleDays;

            app.FileOpenEx(file_path + file_name);

            Project theProj = app.Projects[file_name];
            
            // get ONE task (method dev)
            foreach (Task t in theProj.Tasks)
            {
                if (t != null && t.UniqueID == 111)
                {   // get assignments
                    Assignments task_assignments = t.Assignments;
                    
                    foreach (Assignment task_assignment in task_assignments)
                    {
                        //setup test values to add (these will be part of a JSON set)
                        dynamic task_minutes = 480;
                        dynamic dex = 0;

                        //get assigment's time by day
                        TimeScaleValues time_data = task_assignment.TimeScaleData(begDate, endDate, PjAssignmentTimescaledData.pjAssignmentTimescaledActualWork, PjTimescaleUnit.pjTimescaleDays, 1);
                        
                        foreach (TimeScaleValue td in time_data)
                        {
                            dynamic sd = td.StartDate;

                            if (sd == Convert.ToDateTime("1/14/2015"))
                            {
                                dex = td.Index;
                                Console.WriteLine("");
                            }
                                
                            
                        }
                        //ADD value to timescale dataset
                        time_data.Add(task_minutes, dex);
                    }

                }
                
            }
            theProj.SaveAs(file_path+file_name);
            Console.WriteLine("here we are..." + theProj.Author);
            
        }
    }
}
