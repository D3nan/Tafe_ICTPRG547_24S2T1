using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAFESA_Enrolment_System;

namespace TAFESA_Enrolment_System.Tests
{
    [TestFixture]
    public class ProgramTests
    {

        public Student[] students;

        [OneTimeSetUp]
        public void SetUp()
        {
            // Initialize an array of Student objects for testing purposes
            students = new Student[]
            {
                new Student(101, "Math", new DateTime(2022, 8, 10)),
                new Student(110, "Science", new DateTime(2022, 8, 12)),
                new Student(103, "History", new DateTime(2022, 8, 14)),
                new Student(104, "Engineering", new DateTime(2022, 8, 16)),
    
                // Using 1-arg for Student
                new Student(108),
                new Student(106),
    
                // Using 2-arg, with default (null) Program
                new Student(107, new DateTime(2023, 1, 1)), 
                new Student(105, new DateTime(2024, 2, 1)),  
    
                // Using 2-arg, with default (null) Datetime
                new Student(102, "Art"),
                new Student(109, "Finance"), 
            };
        }

        [Test]
        public void LinearSearch_StudentFound_ReturnsCorrectIndex()
        {
            // Test Linear Search for a student found
            Student target = new Student(102, "Science", new DateTime(2022, 8, 12)); // Searching for StudentId 102
            int index = Utility.LinearSeachArray(students, target);
            Assert.AreEqual(1, index);
        }

        [Test]
        public void LinearSearch_StudentNotFound_ReturnsMinusOne()
        {
            // Test Linear Search for a student not found
            Student targetStudent = new Student(999); // Non-existent StudentId
            int index = Utility.LinearSeachArray(students, targetStudent);
            Assert.AreEqual(-1, index, "Non-existent student should return -1.");
        }

        [Test]
        public void BinarySearch_StudentFound_ReturnsCorrectIndex()
        {
            // Sort students array first before using Binary Search
            Array.Sort(students); // Sort by StudentId in ascending order
            Student targetStudent = new Student(103); // Searching for StudentId 103
            int index = Utility.BinarySearchArray(students, targetStudent);
            Assert.AreEqual(2, index, "Student should be found at index 2.");
        }

        [Test]
        public void BinarySearch_StudentNotFound_ReturnsMinusOne()
        {
            // Test Binary Search for a student not found
            Array.Sort(students); // Sort by StudentId in ascending order
            Student targetStudent = new Student(999); // Non-existent StudentId
            int index = Utility.BinarySearchArray(students, targetStudent);
            Assert.AreEqual(-1, index, "Non-existent student should return -1.");
        }

        [Test]
        public void Sort_AscendingOrder_SuccessfulSort()
        {
            // Sort students in ascending order of StudentId
            Utility.BubbleSort(students);
            Assert.That(students[0].StudentId, Is.EqualTo(101));
            Assert.That(students[1].StudentId, Is.EqualTo(102));
            Assert.That(students[2].StudentId, Is.EqualTo(103));
            Assert.That(students[3].StudentId, Is.EqualTo(104));
        }

        [Test]
        public void Sort_DescendingOrder_SuccessfulSort()
        {
            // Sort students in descending order of StudentId
            Utility.SelectionSortDescending(students);
            Assert.That(students[0].StudentId, Is.EqualTo(110));
            Assert.That(students[1].StudentId, Is.EqualTo(109));
            Assert.That(students[2].StudentId, Is.EqualTo(108));
            Assert.That(students[3].StudentId, Is.EqualTo(107));
        }
    }
}
