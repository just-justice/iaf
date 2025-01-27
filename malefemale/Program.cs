// Write a function that takes in a List<Person> and Prints out two List<Person> for Male and Female.

// static void Distinguish(List<Person> personList)
// {
// 	// Divide personList into two list malePerson, femalePerson
// 	// Print the contents of each list
// }

// Person { int Id, string Name, string Gender  }

// Gender can be Male or Female

class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }

}

class FORCED
{
   static void maleOrFemale(List<Person> list)
    {
    List<Person> male = new List<Person>();
    List<Person> female = new List<Person>();

    
        foreach ( var i in list)
        {
            if (i.Gender == "Male")
            {male.Add(i);
            }

            else if (i.Gender == "Female")
            {
                female.Add(i);
            }
        }
    

    Console.WriteLine("List of Males: ");
    foreach(var males in male)
    {
        Console.WriteLine("id:" + males.Id + "  Name: " + males.Name + "    Gender: " + males.Gender);
    }

    Console.WriteLine("List of Females: ");
    foreach (var females in female)
    {
        Console.WriteLine("id:" + females.Id + "    Name: " + females.Name + "  Gender: " + females.Gender);
    }

    }
static void Main()
{
    List<Person> malefemale = new List<Person>{
        new Person { Id = 1, Name = "Eliza", Gender = "Female" },
        new Person { Id = 2, Name = "SomeMaleName", Gender = "Male" },
        new Person { Id = 3, Name = "Rebecca", Gender = "Female" },
        new Person { Id = 4, Name = "Magnus", Gender = "Male" },
        new Person { Id = 5, Name = "Traxex", Gender = "Female" },
        new Person { Id = 6, Name = "El Machio", Gender = "Male" },
     };

    maleOrFemale(malefemale);
}
}

