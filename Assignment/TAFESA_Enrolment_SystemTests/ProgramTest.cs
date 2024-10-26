using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using TAFESA_Enrolment_System;

namespace TAFESA_Enrolment_System.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        public Student[] students;
        public Student[] empty_students; //For debugging purposes
        public SingleLinkedList<Student> studentList;

        public DoublyLinkedList<Student> studentDoublyList; // New Doubly Linked List
        public BinaryTree bst;

        // Creating Address object
        Address address = new Address(123, "Rundle Street", "Adelaide", 5000, "SA");
        Address address1 = new Address(456, "Hindley Street", "Sydney", 2000, "NSW");

        [OneTimeSetUp]
        public void SetUp()
        {
            // Initialize the linked lists
            studentList = new SingleLinkedList<Student>
            {
                new Student(111),
                new Student(112),
                new Student(113),
                new Student(114),
                new Student(115)
            };

            studentDoublyList = new DoublyLinkedList<Student>(); // Initialize the Doubly Linked List
            bst = new BinaryTree(); // Initialize the Doubly Linked List

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
                new Student(108),
                new Student(106),
                new Student(107, new DateTime(2023, 1, 1)),
                new Student(105, new DateTime(2024, 2, 1)),
                new Student(102, "Art"),
                new Student(109, "Finance"),
            };

            // Empty array for debugging purposes only
            empty_students = new Student[] { };
        }

        // Previous tests for sorting and searching

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

        // Single Linked List Tests

        [Test]
        public void AddToHead_Test()
        {
            Student student116 = new Student(116);
            studentList.AddFirst(student116);

            // Assert that the head is correct
            Assert.AreEqual(studentList.Head.Value, student116, "Student should be at the head of the list.");

            // Enumerate through the list to check the values
            var currentNode = studentList.Head; // Start at the head
            int count = 0;

            while (currentNode != null) // Traverse the list
            {
                count++;
                // Check if the current node is the one we added
                if (count == 1) // Only one student should be in the list
                {
                    Assert.AreEqual(currentNode.Value, student116, "First student should be the one we added.");
                }
                currentNode = currentNode.Next; // Move to the next node
            }

            // Assert that the count is 6
            Assert.AreEqual(count, 6, "Count should be 6 after adding one student.");
        }

        [Test]
        public void AddToTail_Test()
        {
            Student student117 = new Student(117);
            studentList.AddLast(student117);

            // Assert that the tail is correct
            Assert.AreEqual(studentList.Tail.Value, student117, "Student should be at the tail of the list.");

            // Enumerate through the list to check the values
            var currentNode = studentList.Head; // Start at the head
            int count = 0;

            while (currentNode != null) // Traverse the list
            {
                //Console.WriteLine($"Student ID: {currentNode.Value.StudentId}");
                count++;
                // Check if the current node is the last one added
                if (currentNode == studentList.Tail)
                {
                    Assert.AreEqual(currentNode.Value, student117, "Last student should be the one we added.");
                }
                currentNode = currentNode.Next; // Move to the next node
            }

            // Assert that the count is now the expected value (6 + 1 = 7)
            Assert.AreEqual(count, 7, "List count should be 6 after adding one student.");
            PrintStudentList(studentList);
        }

        [Test]
        public void FindStudentInList_Test()
        {
            Student target = new Student(118);
            Student target2 = new Student(119);
            studentList.AddFirst(target);

            bool found = studentList.Contains(target);
            Assert.IsTrue(found, "Student 118 should be found in the list.");
            bool found2 = studentList.Contains(target2);
            Assert.IsFalse(found2, "Student 119 should not be found in the list.");
            PrintStudentList(studentList);

        }

        [Test]
        public void RemoveStudentFromHead_Test()
        {
            Student studentToRemove = new Student(120);
            studentList.AddFirst(studentToRemove);
            PrintStudentList(studentList);
            studentList.RemoveFirst();
            PrintStudentList(studentList);

            Assert.AreNotEqual(studentList.Head?.Value, studentToRemove, "Student should no longer be at the head.");
            Assert.AreEqual(studentList.Count, 8, "Count remains after adding then removing.");

        }

        [Test]
        public void RemoveStudentFromTail_Test()
        {
            Student studentToRemove = new Student(117); //Existing student on list
            studentList.RemoveLast();

            Assert.AreNotEqual(studentList.Tail?.Value, studentToRemove, "Student should no longer be at the tail.");
            Assert.AreEqual(studentList.Count, 7, "Count remains after adding then removing.");
            PrintStudentList(studentList);
        }

        // Doubly Linked List Tests

        [Test]
        public void AddToDoublyHead_Test()
        {
            Student student1 = new Student(1);
            studentDoublyList.AddFirst(student1);

            Assert.AreEqual(studentDoublyList.Head.Value, student1, "Student should be at the head of the doubly list.");
            Assert.AreEqual(studentDoublyList.Tail.Value, student1, "Student should also be at the tail of the doubly list since it's the only student.");
        }

        [Test]
        public void AddToDoublyTail_Test()
        {
            Student student2 = new Student(2);
            studentDoublyList.AddLast(student2);

            Assert.AreEqual(studentDoublyList.Tail.Value, student2, "Student should be at the tail of the doubly list.");
            Assert.AreEqual(studentDoublyList.Head.Value, studentDoublyList.Head.Value, "Head should remain the same after adding to the tail.");
        }

        [Test]
        public void FindStudentInDoublyList_Test()
        {
            //PrintDoubleList(studentDoublyList);
            Student target = new Student(5);
            studentDoublyList.Add(target);
            //PrintDoubleList(studentDoublyList);

            bool found = studentDoublyList.Contains(target);
            Assert.IsTrue(found, "Student 5 should be found in the doubly list. List now has 3 items");
        }

        [Test]
        public void RemoveDoublyHead_Test()
        {
            Student studentToRemove = new Student(3);
            studentDoublyList.AddFirst(studentToRemove);
            studentDoublyList.RemoveFirst();

            Assert.AreEqual(studentDoublyList.Count, 3, "Count should still be 3 after adding/removing the first student.");
            PrintDoubleList(studentDoublyList);
        }


        [Test]
        public void RemoveDoublyTail_Test()
        {
            //Student studentToRemove = new Student(4);
            //studentDoublyList.AddLast(studentToRemove);
            studentDoublyList.RemoveLast();
            PrintDoubleList(studentDoublyList);

            Assert.AreEqual(studentDoublyList.Count, 2, "Count should be 2 after removing the last student.");
        }

        private void PrintStudentList(SingleLinkedList<Student> list)
        {
            var currentNode = list.Head;
            Console.WriteLine("Current List:");

            while (currentNode != null)
            {
                Console.Write($"Student ID: {currentNode.Value.StudentId} ");
                currentNode = currentNode.Next;
            }

            Console.WriteLine(); // For a new line after printing all students
        }

        private void PrintDoubleList(DoublyLinkedList<Student> list)
        {
            var currentNode = list.Head;
            Console.WriteLine("Current List:");

            while (currentNode != null)
            {
                Console.Write($"Student ID: {currentNode.Value.StudentId} ");
                currentNode = currentNode.Next;
            }

            Console.WriteLine(); // For a new line after printing all students
        }

    }
}
