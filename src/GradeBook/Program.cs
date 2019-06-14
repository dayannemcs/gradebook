using System; //Calls System namespace that provide a type such Console class
using System.Collections.Generic;

namespace GradeBook
{
    class Program //This class has a single member which is the Main method
    {
        //Main method serves as the entry point of a program
        static void Main(string[] args)
        {            
            var book = new Book("Dayanne gradebook");
            book.AddGrade(95.3);
            book.AddGrade(97.7);
            book.AddGrade(98.3);
            
            var stats =  book.GetStatistics();   
            
            //Print the highest grade
            Console.WriteLine($"The highest grade is {stats.High}");
            //Print the lowest grade
            Console.WriteLine($"The lowest grade is {stats.Low}");
            //printing the avg grade of the list and formatting to only one digit
            System.Console.WriteLine($"The average grade is {stats.Average:N1}");     
        }
    }
}
