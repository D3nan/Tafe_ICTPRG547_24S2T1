using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TAFESA_Enrolment_System;

namespace TAFESA_Enrolment_System.Tests
{
    [TestFixture]

    public class ProgramTests
    {
        public Student[] students;

        // Creating Address object
        Address address = new Address(123, "Rundle Street", "Adelaide", 5000, "SA");
        Address address1 = new Address(456, "Hindley Street", "Sydney", 2000, "NSW");

        [OneTimeSetUp]
        public void SetUp()
        {
            // Initialize Enrollment objects
            Enrollment mathEnrollment = new Enrollment(new DateTime(2024, 8, 10), "A", 1, new Subject());
            Enrollment scienceEnrollment = new Enrollment(new DateTime(2024, 8, 12), "B", 1, new Subject());
            Enrollment historyEnrollment = new Enrollment(new DateTime(2024, 8, 14), "C", 1, new Subject());
            Enrollment engineeringEnrollment = new Enrollment(new DateTime(2024, 8, 16), "A", 1, new Subject());

            // Initialize an array of Student objects for testing purposes with single Enrollment
            students = new Student[]
            {
            new Student(101, "Math", new DateTime(2022, 8, 10), mathEnrollment),
            new Student(110, "Science", new DateTime(2022, 8, 12), scienceEnrollment),
            new Student(103, "History", new DateTime(2022, 8, 14), historyEnrollment),
            new Student(104, "Engineering", new DateTime(2022, 8, 16), engineeringEnrollment),

            // Using 1-arg for Student (with default enrollment)
            new Student(108),
            new Student(106),

            // Using 2-arg, with default Program and custom date
            new Student(107, new DateTime(2023, 1, 1)),
            new Student(105, new DateTime(2024, 2, 1)),  

            // Using 2-arg, with custom Program and default date
            new Student(102, "Art"),
            new Student(109, "Finance"),
            };

        }

        [Test]
        public void CreateAndOutputObjects_Test()
        {
            // Creating Address object
            Console.WriteLine(address1.ToString());

            // Creating Person object
            Person person = new Person("John Doe", "john.doe@example.com", "0412123456", address);
            Console.WriteLine(person.ToString());

            // Creating Subject object
            Subject subject = new Subject("201", "Mathematics", 2500);
            Console.WriteLine(subject.ToString());

            // Creating Enrollment object
            Subject subject2 = new Subject("ICTPRG547", "Advanced Programming", 6000);
            Enrollment enrollment = new Enrollment(new DateTime(2023, 8, 20), "A", 1, subject2);
            Console.WriteLine(enrollment.ToString());

            // Creating Student object with Enrollment
            Student student = new Student(101, "Computer Science", new DateTime(2022, 8, 15), enrollment);

            // Set base class properties (Person properties)
            student.PersonName = "Denan Diep";
            student.PersonEmail = "denan.diep@tafesa.edu.au";
            student.PersonPhoneNumber = "0412123456";
            student.Address = address1;
            Console.WriteLine(student.ToString());

            // Verify each object is created
            Assert.NotNull(address1);
            Assert.NotNull(person);
            Assert.NotNull(subject);
            Assert.NotNull(enrollment);
            Assert.NotNull(student);

            // Perform some validation for each object's properties
            Assert.That(address.StreetName, Is.EqualTo("Rundle Street"));
            Assert.That(person.PersonName, Is.EqualTo("John Doe"));
            Assert.That(subject.SubjectName, Is.EqualTo("Mathematics"));
            Assert.That(enrollment.Grade, Is.EqualTo("A"));
            Assert.That(student.StudentId, Is.EqualTo(101));

            //Check output of each object
            //Console.ReadLine();
        }

        [Test]
        public void LinearSearch_StudentFound_ReturnsCorrectIndex()
        {
            // Test Linear Search for a student found
            Student target = new Student(102, "Science", new DateTime(2022, 8, 12), new Enrollment());
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
