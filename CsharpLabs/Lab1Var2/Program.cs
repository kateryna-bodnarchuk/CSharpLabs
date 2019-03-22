using System;

namespace Lab1Var2
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public Gender Gender { get; set; }
        public BloodGroup Group { get; set; }

        public Person(string firstName, string lastName, DateTime birthDay,
                                            Gender gender, BloodGroup group)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDay = birthDay;
            Gender = gender;
            Group = group;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
