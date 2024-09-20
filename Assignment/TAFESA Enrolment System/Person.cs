using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAFESA_Enrolment_System
{
    public class Person
    {
        /// <summary>
        /// Setting default values. All constructors must either have all the arguments or none.
        /// </summary>
        public const string DEFAULT_NAME = "NO NAME PROVIDED";
        public const string DEFAULT_EMAIL = "N/A";
        public const int DEFAULT_PHONENUMBER = 0000000000;

        /// <summary>
        /// Declaring the properties
        /// </summary>
        public string PersonName { get; set; }
        public string PersonEmail { get; set; }
        public int PersonPhoneNumber { get; set; }

        /// <summary>
        /// No arg constructor, using only default values
        /// </summary>

        public Person() : this(DEFAULT_NAME, DEFAULT_EMAIL, DEFAULT_PHONENUMBER) { }

        /// <summary>
        /// 2-arg constructor that takes personName and personPhoneNumber, with other properties set to default values
        /// </summary>
        /// <param name="personName"></param>
        /// <param name="personPhoneNumber"></param>
        public Person(string personName, int personPhoneNumber) : this(personName, DEFAULT_EMAIL, personPhoneNumber) { }

        /// <summary>
        /// 2-arg constructor that takes personName and personEmail, with other properties set to default values
        /// </summary>
        /// <param name="dateEnrolled"></param>
        /// <param name="semester"></param>
        public Person(string personName, string personEmail) : this(personName, personEmail, DEFAULT_PHONENUMBER) { }

        /// <summary>
        /// Main constructor for Subject that initialises all properties
        /// </summary>
        /// <param name="subjectCode"></param>
        /// <param name="subjectName"></param>
        /// <param name="cost"></param>
        public Person(string personName, string personEmail, int personPhoneNumber)
        {
            PersonName = personName;
            PersonEmail = personEmail;
            PersonPhoneNumber = personPhoneNumber;
        }
    }
}
