using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAFESA_Enrolment_System
{
    public class Enrollment
    {
        /// <summary>
        /// Setting default values. All constructors must either have all the arguments or none.
        /// </summary>
        public static readonly DateTime DEFAULT_DATEENROLLED = DateTime.Today;
        public const string DEFAULT_GRADE = "N/A";
        public const int DEFAULT_SEMESTER = 0;
        // public static readonly Subject DEFAULT_SUBJECT = new Subject("00000", "NO SUBJECT SELECTED", 0.0);
        // Removed DEFAULT_SUBJECT to prevent enrollments pointing to this same object

        /// <summary>
        /// Declaring the properties
        /// </summary>
        public DateTime DateEnrolled { get; set; }
        public string Grade { get; set; }
        public int Semester { get; set; }
        public Subject Subject { get; set; }  // Aggregated Subject

        /// <summary>
        /// No-arg constructor, using only default values
        /// </summary>
        public Enrollment() : this(DEFAULT_DATEENROLLED, DEFAULT_GRADE, DEFAULT_SEMESTER, new Subject()) { }

        /// <summary>
        /// 1-arg constructor that takes dateEnrolled, with other properties set to default values
        /// </summary>
        /// <param name="dateEnrolled"></param>
        public Enrollment(DateTime dateEnrolled) : this(dateEnrolled, DEFAULT_GRADE, DEFAULT_SEMESTER, new Subject()) { }

        /// <summary>
        /// 2-arg constructor that takes dateEnrolled and semester, with other properties set to default values
        /// </summary>
        /// <param name="dateEnrolled"></param>
        /// <param name="semester"></param>
        public Enrollment(DateTime dateEnrolled, int semester) : this(dateEnrolled, DEFAULT_GRADE, semester, new Subject()) { }

        /// <summary>
        /// 3-arg constructor that takes dateEnrolled, grade, and semester, with default Subject
        /// </summary>
        /// <param name="dateEnrolled"></param>
        /// <param name="grade"></param>
        /// <param name="semester"></param>
        public Enrollment(DateTime dateEnrolled, string grade, int semester) : this(dateEnrolled, grade, semester, new Subject()) { }

        /// <summary>
        /// Main constructor for Enrollment that initializes all properties, including the aggregated Subject
        /// </summary>
        /// <param name="dateEnrolled"></param>
        /// <param name="grade"></param>
        /// <param name="semester"></param>
        /// <param name="subject"></param>
        public Enrollment(DateTime dateEnrolled, string grade, int semester, Subject subject)
        {
            DateEnrolled = dateEnrolled;
            Grade = grade;
            Semester = semester;
            Subject = subject;
        }

        // Overrides the ToString
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Enrollment:");
            sb.AppendLine($"{Subject}");
            sb.AppendLine($"Enrollment is for: {DateEnrolled} during semester {Semester} with grade {Grade}");
            return sb.ToString();
        }
    }

}
