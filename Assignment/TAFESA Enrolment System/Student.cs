using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TAFESA_Enrolment_System
{
    public class Student : Person, IComparable<Student>
    {
        // Default values
        public const string DEFAULT_PROG = "Not Enrolled In Any Programs";
        public static readonly DateTime DEFAULT_DATE = DateTime.Today.Date;
        // public static readonly Enrollment DEFAULT_ENROLLMENT = new Enrollment(DEFAULT_DATE);
        // Removed DEFAULT_ENROLLMENT to avoid pointing to this same object

        // Properties
        public int StudentId { get; set; }
        public string Program { get; set; }
        public DateTime DateRegistered { get; set; }
        public Enrollment Enrollment { get; set; } // Single Enrollment object

        // Constructor that accepts only studentId and assigns default values for program, dateRegistered, and a default enrollment
        public Student(int studentId) : this(studentId, DEFAULT_PROG, DEFAULT_DATE, new Enrollment()) { }

        // Constructor that accepts studentId and program, and assigns the default dateRegistered and a default enrollment
        public Student(int studentId, string program) : this(studentId, program, DEFAULT_DATE, new Enrollment()) { }

        // Constructor that accepts studentId and dateRegistered, and assigns the default program and a default enrollment
        public Student(int studentId, DateTime dateRegistered) : this(studentId, DEFAULT_PROG, dateRegistered, new Enrollment()) { }

        // Main constructor for Student that initializes all properties
        public Student(int studentId, string program, DateTime dateRegistered, Enrollment enrollment)
            : base(DEFAULT_NAME, DEFAULT_EMAIL, DEFAULT_PHONENUMBER, new Address())  // Base class (Person) initialization
        {
            StudentId = studentId;
            Program = program;
            DateRegistered = dateRegistered;
            Enrollment = enrollment;
        }

        // Overrides the ToString method to provide string representation of the student including the enrollment
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Student ID: {StudentId}");
            sb.AppendLine(base.ToString()); // This will include name, email, phone, and address
            sb.AppendLine($"Program: {Program}");
            sb.AppendLine($"Date Registered: {DateRegistered.ToShortDateString()}");
            sb.AppendLine($"Enrollment:");
            sb.AppendLine($" - Subject: {Enrollment.Subject.SubjectName}");
            sb.AppendLine($" - Subject Code: {Enrollment.Subject.SubjectCode}");
            sb.AppendLine($" - Subject Cost: {Enrollment.Subject.Cost}");
            sb.AppendLine($" - Date Enrolled: {Enrollment.DateEnrolled.ToShortDateString()}");
            sb.AppendLine($" - Semester: {Enrollment.Semester}");
            sb.AppendLine($" - Grade: {Enrollment.Grade}");

            return sb.ToString();
        }

        // Overrides the Equals method for Student comparison based on StudentId
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            if (ReferenceEquals(this, obj)) return true;

            Student student = obj as Student;
            return student != null && this.StudentId == student.StudentId;
        }

        // Override the == (equals) operator
        public static bool operator ==(Student student1, Student student2)
        {
            return object.Equals(student1, student2);
        }

        // Override the != (not equals) operator
        public static bool operator !=(Student student1, Student student2)
        {
            return !object.Equals(student1, student2);
        }

        // Overriding GetHashCode method using StudentId, Program, and DateRegistered
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 31 + this.StudentId.GetHashCode();
            hash = hash * 31 + (this.Program?.GetHashCode() ?? 0);
            hash = hash * 31 + this.DateRegistered.GetHashCode();
            return hash;
        }

        // Implement IComparable interface to compare students by StudentId
        public int CompareTo(Student other)
        {
            return this.StudentId.CompareTo(other.StudentId);
        }

        // Implement IComparable interface to compare with an object
        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentException("Object is null");
            if (!(obj is Student)) throw new ArgumentException("Expected Student");
            return CompareTo((Student)obj);
        }

        // Override comparison operators >, <, >=, <= for Student objects
        public static bool operator >(Student student1, Student student2) => student1.CompareTo(student2) > 0;
        public static bool operator <(Student student1, Student student2) => student1.CompareTo(student2) < 0;
        public static bool operator >=(Student student1, Student student2) => student1.CompareTo(student2) >= 0;
        public static bool operator <=(Student student1, Student student2) => student1.CompareTo(student2) <= 0;
    }
}

