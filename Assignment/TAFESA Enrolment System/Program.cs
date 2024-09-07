using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TAFESA_Enrolment_System
{
    class Student
    {
        // Setting default values
        public const string DEFAULT_PROG = "Not Enrolled In Any Programs";
        public static readonly DateTime DEFAULT_DATE = DateTime.Today.Date;

        public int StudentId { get; set; }
        public string Program { get; set; }
        public DateTime DateRegistered { get; set; }

        // Constructor that accepts only studentId and assigns default values for program and dateRegistered
        public Student(int studentId) : this(studentId, DEFAULT_PROG, DEFAULT_DATE) { }

        // Constructor that accepts studentId and program, and assigns the default dateRegistered
        public Student(int studentId, string program) : this(studentId, program, DEFAULT_DATE) { }

        // Constructor that accepts studentId and dateRegistered, and assigns the default program
        public Student(int studentId, DateTime dateRegistered) : this(studentId, DEFAULT_PROG, dateRegistered) { }

        // Main constructor that initializes all properties
        public Student(int studentId, string program, DateTime dateRegistered)
        {
            StudentId = studentId;
            Program = program;
            DateRegistered = dateRegistered;
        }

        public override bool Equals(object obj)
        {
            // If null or different type, then it won't be equal
            if (obj == null || obj.GetType() != this.GetType())
                return false;

            // If it's itself, then yes they will be equal
            if (ReferenceEquals(this, obj)) return true;

            // Cast obj to Student and check if it's a valid comparison
            Student student = obj as Student;
            if (student == null)
                return false;

            // Compare relevant properties (assuming StudentId is unique)
            return this.StudentId == student.StudentId;
        }

        public static bool operator ==(Student student1, Student student2)
        { 
            return object.Equals(student1, student2); 
        }
        public static bool operator !=(Student student1, Student student2)
        {
            return !object.Equals(student1, student2);
        }

        public static bool Equals(object obj1, object obj2)

        {
            if (obj1 == obj2) return true; // Checks if references are the same
            if (obj1 == null || obj2 == null) return false; // Checks for null
            else
                return obj1.Equals(obj2); // Call the virtual Equals method
        }

        public override int GetHashCode()
        {
            int hash = 17; //Start with a prime number
            hash = hash * 31 + this.StudentId.GetHashCode();
            hash = hash * 31 + (this.Program?.GetHashCode() ?? 0); // Handle null for Program
            hash = hash * 31 + this.DateRegistered.GetHashCode();
            return hash;
        }

        // Main method to test the Student class
        static void Main(string[] args)
        {
            Student student1 = new Student(123);
            Student student2 = new Student(123);

            // Test override of == method and static Equal
            Console.WriteLine("student1 == student2: " + (student1 == student2));

            // Test override of virtual Equal method
            Console.WriteLine("student1.Equals(student2): " + student1.Equals(student2));

            // Test override of != method and static Equal
            Student student3 = new Student(124);
            Console.WriteLine("student1 != student3: " + (student1 != student3));
            Console.ReadLine();
        }

    }
}
