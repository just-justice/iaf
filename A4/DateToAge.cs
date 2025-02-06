using System;

public static class DateTimeExtensions
{
    public static int GetAge(this DateTime dateOfBirth)
    {
        DateTime today = DateTime.Today;
        int age = today.Year - dateOfBirth.Year;
        
        if (dateOfBirth.Date > today.AddYears(-age))
        {
            age--;
        }
        
        return age;
    }
}

class Program
{
    static void Main()
    {
        DateTime birthDate = new DateTime(1990, 5, 15);
        int age = birthDate.GetAge();
        Console.WriteLine($"Age: {age}"); // Output: Age: (calculated age)
    }
}
