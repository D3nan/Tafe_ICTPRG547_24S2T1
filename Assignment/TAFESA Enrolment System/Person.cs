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
        public const string DEFAULT_PHONENUMBER = "0000000000";
        public static readonly Address DEFAULT_ADDRESS = new Address(0, "UNKNOWN", "UNKNOWN", 0000, "UNKNOWN");

        /// <summary>
        /// Declaring the properties
        /// </summary>
        public string PersonName { get; set; }
        public string PersonEmail { get; set; }
        public string PersonPhoneNumber { get; set; }  // Changed to string
        public Address Address { get; set; }

        /// <summary>
        /// No-arg constructor, using only default values
        /// </summary>
        public Person() : this(DEFAULT_NAME, DEFAULT_EMAIL, DEFAULT_PHONENUMBER, DEFAULT_ADDRESS) { }

        /// <summary>
        /// 2-arg constructor that takes personName and personPhoneNumber, with other properties set to default values
        /// </summary>
        /// <param name="personName"></param>
        /// <param name="personPhoneNumber"></param>
        public Person(string personName, string personPhoneNumber) : this(personName, DEFAULT_EMAIL, personPhoneNumber, DEFAULT_ADDRESS) { }

        /// <summary>
        /// Main constructor for Person that initializes all properties
        /// </summary>
        /// <param name="personName"></param>
        /// <param name="personEmail"></param>
        /// <param name="personPhoneNumber"></param>
        /// <param name="address"></param>
        public Person(string personName, string personEmail, string personPhoneNumber, Address address)
        {
            PersonName = personName;
            PersonEmail = personEmail;
            PersonPhoneNumber = personPhoneNumber;  // Now accepts string
            Address = address;
        }

        // Overrides the ToString
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The person's name is: {PersonName} ");
            sb.AppendLine($"Email: {PersonEmail} ");
            sb.AppendLine($"Phone number: {PersonPhoneNumber} ");
            sb.AppendLine($"{Address}");

            return sb.ToString();
        }
    }

}
