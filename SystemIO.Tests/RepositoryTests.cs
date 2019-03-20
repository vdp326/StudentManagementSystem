using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using StudentManagemetSystem.Data;
using StudentManagemetSystem.Models;
using System.IO;


namespace SystemIO.Tests
{
    [TestFixture]
    class RepositoryTests
    {
        private const string _filePath = @"C:\Data1\SystemIO\StudentTest.txt";
        private const string _originalData = @"C:\Data1\SystemIO\StudentTestSeed.txt";

        [SetUp]
        public void Setup()
        {
            /*
             When working with sample data, create a process to reset and 
             restore the original data so your tests will always work
             */
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
            //copy the original data to the file path
            //so every time the unit tests are run it deletes the test data and restore the original data
            File.Copy(_originalData, _filePath); 
        }
        [Test]
        public void CanReadDataFromFile()
        {
            StudentRepository repo = new StudentRepository(_filePath);

            List <Student> students = repo.List();

            Assert.AreEqual(4, students.Count());

            Student check = students[2];

            Assert.AreEqual("Jane", check.FirstName);
            Assert.AreEqual("Doe", check.LastName);
            Assert.AreEqual("Computer Science", check.Major);
            Assert.AreEqual(4.0M, check.GPA);
        }

        [Test]
        public void CanAddStudentToFile()
        {
            StudentRepository repo = new StudentRepository(_filePath);

            Student newStudent = new Student();
            newStudent.FirstName = "Testy";
            newStudent.LastName = "Tester";
            newStudent.Major = "Research";
            newStudent.GPA = 3.2M;

            repo.Add(newStudent);

            List<Student> students = repo.List();

            Assert.AreEqual(5, students.Count());

            Student check = students[4]; //grab the fifth student which is at index 4

            Assert.AreEqual("Testy", check.FirstName);
            Assert.AreEqual("Tester", check.LastName);
            Assert.AreEqual("Research", check.Major);
            Assert.AreEqual(3.2M, check.GPA);

        }

        [Test]
        public void CanDeleteStudent()
        {
            StudentRepository repo = new StudentRepository(_filePath);
            repo.Delete(0); //delete the first student

            List<Student> students = repo.List();

            Assert.AreEqual(3, students.Count); //there should only be 3 students left

            Student check = students[0]; 

            Assert.AreEqual("Mary", check.FirstName);
            Assert.AreEqual("Jone", check.LastName);
            Assert.AreEqual("Business", check.Major);
            Assert.AreEqual(3.0M, check.GPA);


        }

        [Test]
        public void CanEditStudent()
        {
            StudentRepository repo = new StudentRepository(_filePath);
            List<Student> students = repo.List(); //get a list of students

            Student editedStudent = students[0];
            editedStudent.GPA = 3.0M;

            repo.Edit(editedStudent,0); //edit the first student's gpa from 3.5 to 3.0

            

            Assert.AreEqual(4, students.Count); //there should only be 3 students left

            students = repo.List();
            Student check = students[0];

            Assert.AreEqual("Joe", check.FirstName);
            Assert.AreEqual("Smith", check.LastName);
            Assert.AreEqual("Computer Science", check.Major);
            Assert.AreEqual(3.0M, check.GPA);


        }
    }





}
