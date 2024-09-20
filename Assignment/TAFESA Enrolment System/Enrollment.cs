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

        /// <summary>
        /// Declaring the properties
        /// </summary>
        public DateTime DateEnrolled { get; set; }
        public string Grade { get; set; }
        public int Semester { get; set; }

        /// <summary>
        /// No arg constructor, using only default values
        /// </summary>
        public Enrollment() : this(DEFAULT_DATEENROLLED, DEFAULT_GRADE, DEFAULT_SEMESTER) { }

        /// <summary>
        /// 1-arg constructor that takes dateEnrolled, with other properties set to default values
        /// </summary>
        /// <param name="dateEnrolled"></param>
        public Enrollment(DateTime dateEnrolled) : this(dateEnrolled, DEFAULT_GRADE, DEFAULT_SEMESTER) { }

        /// <summary>
        /// 2-arg constructor that takes dateEnrolled and semester, with other properties set to default values
        /// </summary>
        /// <param name="dateEnrolled"></param>
        /// <param name="semester"></param>
        public Enrollment(DateTime dateEnrolled, int semester) : this(dateEnrolled, DEFAULT_GRADE, semester) { }

        /// <summary>
        /// Main constructor for Enrollment that initializes all properties
        /// </summary>
        /// <param name="dateEnrolled"></param>
        /// <param name="grade"></param>
        /// <param name="semester"></param>
        public Enrollment(DateTime dateEnrolled, string grade, int semester)
        {
            DateEnrolled = dateEnrolled;
            Grade = grade;
            Semester = semester;
        }
    }
}
