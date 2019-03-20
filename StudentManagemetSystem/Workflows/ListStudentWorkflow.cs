using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagemetSystem.Data;
using StudentManagemetSystem.Models;
using StudentManagemetSystem.Helpers;


namespace StudentManagemetSystem.Workflows
{
    public class ListStudentWorkflow
    {
        /*Process for listing students
         1. Get a list of students from the repository
         2. Print out the students
         */
        public void Execute()
        {
            StudentRepository repo = new StudentRepository(Settings.FilePath);
            List<Student> students = repo.List();

            Console.Clear();
            Console.WriteLine("Student List");

            ConsoleIO.PrintStudentListHeader(); //call the method from the ConsoleIO to display header 

            foreach (var student in students)
            {
                Console.WriteLine(ConsoleIO.StudentLineFormat, student.LastName + ", " + student.FirstName,
                    student.Major, student.GPA);
            }

            Console.WriteLine();
            Console.WriteLine(ConsoleIO.SeparatorBar);
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }
    }
}









