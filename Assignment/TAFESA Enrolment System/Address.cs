using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAFESA_Enrolment_System
{
    public class Address
    {
        /// <summary>
        /// Setting default values. All constructors must either have all the arguments or none.
        /// </summary>
        public const int DEFAULT_STREET_NUM = 0000;
        public const string DEFAULT_STREET_NAME = "N/A";
        public const string DEFAULT_SUBURB = "N/A";
        public const int DEFAULT_POSTCODE = 0000;
        public const string DEFAULT_STATE = "N/A";

        /// <summary>
        /// Declaring the properties
        /// </summary>
        public int StreetNum { get; set; }
        public string StreetName { get; set; }
        public string Suburb { get; set; }
        public int PostCode { get; set; }
        public string State { get; set; }

        /// <summary>
        /// No arg constructor, using only default values
        /// </summary>

        public Address() : this(DEFAULT_STREET_NUM, DEFAULT_STREET_NAME, DEFAULT_SUBURB, DEFAULT_POSTCODE, DEFAULT_STATE) { }

        /// <summary>
        /// 2-arg constructor that takes streetNum and streetName, with other properties set to default values
        /// </summary>
        /// <param name="streetNum"></param>
        /// <param name="streetName"></param>
        public Address(int streetNum, string streetName) : this(streetNum, streetName, DEFAULT_SUBURB, DEFAULT_POSTCODE, DEFAULT_STATE) { }

        /// <summary>
        /// 3-arg constructor that takes suburb, postcode and state, with other properties set to default values
        /// </summary>
        /// <param name="suburb"></param>
        /// <param name="postcode"></param>
        /// <param name="state"></param>
        public Address(string suburb, int postcode, string state) : this(DEFAULT_STREET_NUM, DEFAULT_STREET_NAME, suburb, postcode, state) { }

        /// <summary>
        /// 3-arg constructor that takes streetNum, streetName and suburb with other properties set to default values
        /// </summary>
        /// <param name="streetNum"></param>
        /// <param name="streetName"></param>
        /// <param name="suburb"></param>
        public Address(int streetNum, string streetName, string suburb) : this(streetNum, streetName, suburb, DEFAULT_POSTCODE, DEFAULT_STATE) { }

        /// <summary>
        /// 3-arg constructor that takes streetNum, streetName and postcode with other properties set to default values
        /// </summary>
        /// <param name="streetNum"></param>
        /// <param name="streetName"></param>
        /// <param name="postcode"></param>
        public Address(int streetNum, string streetName, int postcode) : this(streetNum, streetName, DEFAULT_SUBURB, postcode, DEFAULT_STATE) { }

        /// <summary>
        /// Main constructor for Subject that initialises all properties
        /// </summary>
        /// <param name="streetNum"></param>
        /// <param name="streetName"></param>
        /// <param name="suburb"></param>
        /// <param name="postcode"></param>
        /// <param name="state"></param>
        public Address(int streetNum, string streetName, string suburb, int postcode, string state)
        {
            StreetNum = streetNum;
            StreetName = streetName;
            Suburb = suburb;
            PostCode = postcode;
            State = state;
        }

        // Overrides the ToString
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Address: {StreetNum} {StreetName}, {Suburb}, {PostCode}, {State}");

            return sb.ToString();
        }
    }
}
