using System;
using System.Collections.Generic;
using System.IO;

namespace Lab1
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public BloodGroup Group { get; set; }

        public Person(string firstName, string lastName, int age,
                                            Gender gender, BloodGroup group)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Gender = gender;
            Group = group;
        }
    }

    class Program
    {
        public static void WriteToTxt(List<Person> people)
        {
            string dir = Directory.GetCurrentDirectory();
            StreamWriter streamWriter = new StreamWriter(Path.Combine(dir, "Test.txt"));
            streamWriter.WriteLine(people);
            streamWriter.Close();
        }
        static void Main(string[] args)
        {
            var people = new List<Person>();
            people.Add(new Person("Michael", "Schum", 23, Gender.Male, BloodGroup.I));
            people.Add(new Person("Alice", "Zug", 44, Gender.Female, BloodGroup.IV));
            people.Add(new Person("Jhon", "Blank", 17, Gender.Male, BloodGroup.III));
            people.Add(new Person("Sam", "Cook", 52, Gender.Male, BloodGroup.II));
            people.Add(new Person("Sharon", "Greg", 25, Gender.Male, BloodGroup.I));
            people.Add(new Person("Elison", "Smith", 34, Gender.Female, BloodGroup.III));
            people.Add(new Person("Donna", "Smith", 25, Gender.Female, BloodGroup.IV));

            foreach (var p in people)
            {
                string message = "The following matches found: " + p.FirstName + " "
                                        + p.LastName + " " + p.Age;
                if (p.Gender == Gender.Female && p.Group == BloodGroup.IV)
                {
                    Console.WriteLine(message);
                    
                }
            }
            Console.ReadKey();
        }
        
    }
}
