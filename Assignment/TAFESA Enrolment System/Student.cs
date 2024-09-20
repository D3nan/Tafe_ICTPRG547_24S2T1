using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAFESA_Enrolment_System
{
    public class Student : IComparable<Student>
    {
        /// <summary>
        /// Setting default values
        /// </summary>
        public const string DEFAULT_PROG = "Not Enrolled In Any Programs";
        public static readonly DateTime DEFAULT_DATE = DateTime.Today.Date;

        /// <summary>
        /// Declaring the properties
        /// </summary>
        public int StudentId { get; set; }
        public string Program { get; set; }
        public DateTime DateRegistered { get; set; }

        /// <summary>
        /// Constructor that accepts only studentId and assigns default values for program and dateRegistered
        /// </summary>
        /// <param name="studentId"></param>
        public Student(int studentId) : this(studentId, DEFAULT_PROG, DEFAULT_DATE) { }

        /// <summary>
        /// Constructor that accepts studentId and program, and assigns the default dateRegistered
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="program"></param>

        public Student(int studentId, string program) : this(studentId, program, DEFAULT_DATE) { }

        /// <summary>
        /// Constructor that accepts studentId and dateRegistered, and assigns the default program
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="dateRegistered"></param>

        public Student(int studentId, DateTime dateRegistered) : this(studentId, DEFAULT_PROG, dateRegistered) { }

        /// <summary>
        /// Main constructor for Student that initialises all properties
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="program"></param>
        /// <param name="dateRegistered"></param>
        public Student(int studentId, string program, DateTime dateRegistered)
        {
            StudentId = studentId;
            Program = program;
            DateRegistered = dateRegistered;
        }
        /// <summary>
        /// Overrides the virtual Equals method
        /// It will no longer use only the objects reference to determine if objects are equal
        /// Instead, it will compare the actual studentID value
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>boolean</returns>
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
        /// <summary>
        /// Override the == (equals) operations method
        /// </summary>
        /// <param name="student1"></param>
        /// <param name="student2"></param>
        /// <returns>boolean</returns>
        public static bool operator ==(Student student1, Student student2)
        {
            return object.Equals(student1, student2);
        }
        /// <summary>
        /// Override the != (not equals) operations method
        /// </summary>
        /// <param name="student1"></param>
        /// <param name="student2"></param>
        /// <returns>boolean</returns>
        public static bool operator !=(Student student1, Student student2)
        {
            return !object.Equals(student1, student2);
        }
        /// <summary>
        /// Override the statis Equals method
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <returns>boolean</returns>
        public static bool Equals(object obj1, object obj2)

        {
            if (obj1 == obj2) return true; // Checks if references are the same
            if (obj1 == null || obj2 == null) return false; // Checks for null
            else
                return obj1.Equals(obj2); // Call the virtual Equals method
        }
        /// <summary>
        /// Overriding GetHashCode value by using prime numbers and all the Student class properties
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hash = 17; //Start with a prime number
            hash = hash * 31 + this.StudentId.GetHashCode();
            hash = hash * 31 + (this.Program?.GetHashCode() ?? 0); // Handle null for Program
            hash = hash * 31 + this.DateRegistered.GetHashCode();
            return hash;
        }
        /// <summary>
        /// Overriding IComparable interface
        /// Compares Students by StudentId
        /// </summary>
        /// <param name="other"></param>
        /// <returns>int</returns>
         public int CompareTo(Student other)
        {
            //if (other == null) return 1; // A Student is always greater than null
            //if (ReferenceEquals(this, other)) return 0;

            //// If other is not of type Student, we could return a specific value or throw an exception
            //if (other.GetType() != this.GetType())
            //{
            //    throw new ArgumentException("Object is not a Student");
            //}
    
            return this.StudentId.CompareTo(other.StudentId); // Compare based on StudentId
        }
        /// <summary>
        /// Overriding IComparable interface. Comparing the object, then passing that object
        /// to the other CompareTo to compare against StudentId
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentException("obj");
            if (!(obj is Student)) throw new ArgumentException("Expected student");
            return CompareTo((Student)obj); // Compare based on StudentId
        }

        /// <summary>
        /// Override the > operator
        /// </summary>
        /// <param name="student1"></param>
        /// <param name="student2"></param>
        /// <returns>boolean</returns>
        public static bool operator >(Student student1, Student student2)
        {
            return student1.CompareTo(student2) > 0;
        }

        /// <summary>
        /// Override the < operator
        /// </summary>
        /// <param name="student1"></param>
        /// <param name="student2"></param>
        /// <returns>boolean</returns>
        public static bool operator <(Student student1, Student student2)
        {
            return student1.CompareTo(student2) < 0;
        }

        /// <summary>
        /// Override the >= operator
        /// </summary>
        /// <param name="student1"></param>
        /// <param name="student2"></param>
        /// <returns>boolean</returns>
        public static bool operator >=(Student student1, Student student2)
        {
            return student1.CompareTo(student2) >= 0;
        }

        /// <summary>
        /// Override the <= operator
        /// </summary>
        /// <param name="student1"></param>
        /// <param name="student2"></param>
        /// <returns>boolean</returns>
        public static bool operator <=(Student student1, Student student2)
        {
            return student1.CompareTo(student2) <= 0;
        }
    }
}
