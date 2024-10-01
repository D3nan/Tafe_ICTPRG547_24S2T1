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
            // Testing for Student Class
            Student student1 = new Student(123);
            Student student2 = new Student(123);

            // Test override of == method and static Equal
            Console.WriteLine("student1 == student2 (expect true): " + (student1 == student2));

            // Test override of virtual Equal method
            Console.WriteLine("student1.Equals(student2) (expect true): " + student1.Equals(student2));

            // Test override of != method and static Equal
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

            Console.ReadLine();
        }
    }

}
