using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public struct Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public int BirthYear { get; set; }
    public int Height { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();
        string jsonFilePath = "C:/Users/T460s/Desktop/Os Lab/firstHW/thirdHW/person.json";
        if (File.Exists(jsonFilePath))
        {
            string json = File.ReadAllText(jsonFilePath);
            people = JsonSerializer.Deserialize<List<Person>>(json);

        
            Console.WriteLine("Data read from people.json:");
            foreach (var person in people)
            {
                Console.WriteLine($"First Name: {person.FirstName}");
                Console.WriteLine($"Last Name: {person.LastName}");
                Console.WriteLine($"Phone Number: {person.PhoneNumber}");
                Console.WriteLine($"Birth Year: {person.BirthYear}");
                Console.WriteLine($"Height: {person.Height}");
                Console.WriteLine();
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Enter details for person {i + 1}:");
                Person person = new Person();
                Console.Write("First Name: ");
                person.FirstName = Console.ReadLine();
                Console.Write("Last Name: ");
                person.LastName = Console.ReadLine();
                Console.Write("Phone Number: ");
                person.PhoneNumber = Console.ReadLine();
                Console.Write("Birth Year: ");
                person.BirthYear = int.Parse(Console.ReadLine());
                Console.Write("Height: ");
                person.Height = int.Parse(Console.ReadLine());
                people.Add(person);
            }


            string json = JsonSerializer.Serialize(people);
            File.WriteAllText(jsonFilePath, json);

            Console.WriteLine($"Data saved to {jsonFilePath}");
        }
    }
}
