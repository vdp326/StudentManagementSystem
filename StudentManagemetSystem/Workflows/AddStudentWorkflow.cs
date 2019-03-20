using StudentManagemetSystem.Data;
using StudentManagemetSystem.Helpers;
using StudentManagemetSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagemetSystem.Workflows
{
    public class  AddStudentWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Add Student");
            Console.WriteLine(ConsoleIO.SeparatorBar);
            Console.WriteLine();

            //create a Student object
            Student newStudent = new Student();

            //get student information
            newStudent.FirstName = ConsoleIO.GetRequiredStringFromUser("First Name: ");
            newStudent.LastName = ConsoleIO.GetRequiredStringFromUser("Last Name: ");
            newStudent.Major = ConsoleIO.GetRequiredStringFromUser("Major: ");
            newStudent.GPA = ConsoleIO.GetRequiredDecimalFromUser("GPA: ");

            Console.WriteLine();
            ConsoleIO.PrintStudentListHeader(); //print confirmation after adding new student info
            Console.WriteLine(ConsoleIO.StudentLineFormat, newStudent.LastName + ", " + newStudent.FirstName,
                    newStudent.Major, newStudent.GPA);

            Console.WriteLine();

            //ask if they want to add the student
            if(ConsoleIO.GetYesNoAnswerFromUser("Add the following information") == "Y")
            { //if they want to add we add it
                StudentRepository repo = new StudentRepository(Settings.FilePath);
                repo.Add(newStudent);
                Console.WriteLine("Student Added!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else //else we cancel
            {
                Console.WriteLine("Add cancelled");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
