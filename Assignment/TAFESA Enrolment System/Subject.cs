using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAFESA_Enrolment_System
{
    public class Subject
    {
        /// <summary>
        /// Setting default values. All constructors must either have all the arguments or none.
        /// </summary>
        public const string DEFAULT_SUBJECTCODE = "00000";
        public const string DEFAULT_SUBJECTNAME = "NO SUBJECT SELECTED";
        public const double DEFAULT_COST = 0.0;

        /// <summary>
        /// Declaring the properties
        /// </summary>
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public double Cost { get; set; }

        /// <summary>
        /// No arg constructor, using only default values
        /// </summary>
        
        public Subject() : this(DEFAULT_SUBJECTCODE, DEFAULT_SUBJECTNAME, DEFAULT_COST) { }

        /// <summary>
        /// Main constructor for Subject that initialises all properties
        /// </summary>
        /// <param name="subjectCode"></param>
        /// <param name="subjectName"></param>
        /// <param name="cost"></param>
        public Subject(string subjectCode, string subjectName, double cost)
        {
            SubjectCode = subjectCode;
            SubjectName = subjectName;
            Cost = cost;
        }

        // Overrides the ToString
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The subject is: {SubjectName}, with code: {SubjectCode} and costs ${Cost}");

            return sb.ToString();
        }
    }
}
