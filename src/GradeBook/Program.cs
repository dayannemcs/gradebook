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
            EnterGrades(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"For the book named {book.Name}");
            //Print the highest grade
            Console.WriteLine($"The highest grade is {stats.High}");
            //Print the lowest grade
            Console.WriteLine($"The lowest grade is {stats.Low}");
            //printing the avg grade of the list and formatting to only one digit
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");

        }

        private static void EnterGrades(Book book)
        {
            while (true)
            {
                Console.WriteLine("Enter the grades or 'q' to quit: \n");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}
