using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("TAFESA_Enrolment_SystemTests")]
namespace TAFESA_Enrolment_System
{
    class Program
    {
        static void Main(string[] args)
        {
            // Existing tests for Student, Subject, Enrollment, Address, and Person classes
            //TestClasses();

            // New tests for SingleLinkedList<Student>
            //TestSingleLinkedList();

            // Testing Binary Search Tree
            //BinaryTest();

            // Testing Binary Search Tree
            DebugArray();

            Console.ReadLine();
        }

        static void DebugArray()
        {
            // Create an array of students for testing
            Student[] students = new Student[]
            {
                new Student(101),
                new Student(110),
                new Student(103),
                new Student(104),
                new Student(108),
                new Student(106),
            };

            // Sort students array first before using Binary Search
            Array.Sort(students);

            // Test Binary Search on a valid array
            Student targetStudent = new Student(103); // Searching for StudentId 103
            int index = Utility.BinarySearchArray(students, targetStudent);
            Console.WriteLine($"Student 103 should be at index 1: {index}"); // Expected output

            // Test Binary Search with null array
            try
            {
                int nullIndex = Utility.BinarySearchArray(null, targetStudent);
                Console.WriteLine($"Student 103 should be at index 1: {index}");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Caught expected null exception: {ex.Message}");
            }

            // Test Binary Search on empty array
            Student[] empty_students = new Student[] {};

            // Test Binary Search with null array
            try
            {
                int emptyIndex = Utility.BinarySearchArray(empty_students, targetStudent);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Caught expected exception:{ex.Message}");
            }
        }

        static void TestClasses()
        {
            // Testing for Student Class
            Student student1 = new Student(123);
            Student student2 = new Student(123);

            Console.WriteLine("student1 == student2 (expect true): " + (student1 == student2));
            Console.WriteLine("student1.Equals(student2) (expect true): " + student1.Equals(student2));

            Student student3 = new Student(124);
            Console.WriteLine("student1 != student3 (expect true): " + (student1 != student3));

            // Testing for Subject Class
            Subject sub1 = new Subject("00000", "NO SUBJECT SELECTED", 0.0);
            Subject sub2 = new Subject();

            Console.WriteLine("sub1 == sub2 (expect false): " + (sub1 == sub2));
            Console.WriteLine("sub1.Equals(sub2) (expect false): " + sub1.Equals(sub2));

            // Testing for Enrollment Class
            Enrollment enrollment1 = new Enrollment(DateTime.Today, "N/A", 0);
            Enrollment enrollment2 = new Enrollment();

            Console.WriteLine("enrollment1 == enrollment2 (expect false): " + (enrollment1 == enrollment2));
            Console.WriteLine("enrollment1.Equals(enrollment2) (expect false): " + enrollment1.Equals(enrollment2));

            // Testing for Address Class
            Address address1 = new Address(0000, "N/A", "N/A", 0000, "N/A");
            Address address2 = new Address();

            Console.WriteLine("address1 == address2 (expect false): " + (address1 == address2));
            Console.WriteLine("address1.Equals(address2) (expect false): " + address1.Equals(address2));

            // Testing for Person Class
            Person person1 = new Person("NO NAME PROVIDED", "N/A", "0000000000", new Address());
            Person person2 = new Person();

            Console.WriteLine("person1 == person2 (expect false): " + (person1 == person2));
            Console.WriteLine("person1.Equals(person2) (expect false): " + person1.Equals(person2));
        }

        static void TestSingleLinkedList()
        {
            var studentList = new SingleLinkedList<Student>();

            // a) Add a Student instance to the head of the linked list
            var studentA = new Student(111);
            var studentB = new Student(112);
            var studentC = new Student(113);
            var studentD = new Student(114);
            var studentE = new Student(115);
            var studentF = new Student(116);
            var studentG = new Student(117);
            var studentH = new Student(118);
            studentList.AddFirst(studentA);
            studentList.AddLast(studentB);
            studentList.AddLast(studentC);
            studentList.AddLast(studentD);
            studentList.AddLast(studentE);
            

            PrintList(studentList); // Print the list after the operation

            studentList.AddFirst(studentF);
            Console.WriteLine("Added Student116 To head Current List:");
            PrintList(studentList); // Print the list after the operation

            studentList.AddLast(studentG);
            Console.WriteLine("Added Student117 To Tail Current List:");
            PrintList(studentList); // Print the list after the operation
        }

        // Helper method to print the contents of the linked list
        static void PrintList(SingleLinkedList<Student> studentList)
        {
            Console.WriteLine("Current List:");
            var current = studentList.Head;
            while (current != null)
            {
                Console.WriteLine($"StudentId: {current.Value.StudentId}");
                current = current.Next; // Assuming the linked list has a Next property
            }
            Console.WriteLine();
        }

        static void BinaryTest()
        {
            // Initialize the tree
            BinaryTree bst = new BinaryTree();
            bst.Add(4); // root Node
            bst.Add(2); // add to LHS since 2 < 4
            bst.Add(6); // add to RHS since 6 > 4
            bst.Add(1); // add to LHS of 2 since 1 < 2
            bst.Add(5); // add to LHS of 6 since 5 < 6
            bst.Add(3); // add to RHS of 2 since 3 > 2
            bst.Add(7); // add to RHS of 6 since 7 > 6

            Console.WriteLine("PreOrder Traversal:");
            bst.TraversePreOrder(bst.Root);

            Console.WriteLine("\nInOrder Traversal:");
            bst.TraverseInOrder(bst.Root);

            Console.WriteLine("\nPostOrder Traversal:");
            bst.TraversePostOrder(bst.Root);

        }
    }
}
