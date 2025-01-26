//  Create a list of integers, add numbers to it, and print only the even numbers.
 List<int> numbers = new List<int>(){4,55,2,3,56,86,12,3};

        Console.WriteLine("Even numbers:");

        foreach (int number in numbers)
        {
            if (number % 2 == 0)
            {
                Console.WriteLine(number);
            }
        }

//   Write a program to find the maximum and minimum values in a list of integers. 
   List<int> minmaxlist = new List<int>{32, 44, 21, 0, 99};
   int max = minmaxlist[0], min = minmaxlist[0];

   foreach(int i in minmaxlist)
   {
    if(i > max)
        {max = i;
        }
    else{}

    if(i<min)
        {min = i;
        }
     else{}       
   }
 Console.WriteLine("Maximum value: " + max);
 Console.WriteLine("Minimum value: " + min);

// Implement a function that accepts a list of strings and returns a new list with duplicates removed.
List<string> listDuplicatesYes = new List<string> { "mercury", "venus", "earth", "mars", "sun", "sun", "mars" };
List<string> listDuplicatesNo = new List<string>();

foreach(string element in listDuplicatesYes)
{
    if(!listDuplicatesNo.Contains(element))
        {
            listDuplicatesNo.Add(element);
        }
}

for(int i = 0; i < listDuplicatesNo.Count; i++)
{
    Console.WriteLine(listDuplicatesNo[i]);
}
