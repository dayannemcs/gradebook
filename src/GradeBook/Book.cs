using System;
using System.Collections.Generic;

namespace GradeBook
{
    /* A class is a type. It is a data structure that combines state (fields) and actions (methods and other functions member)
    into a single unit.*/
    public class Book
    {
        //Declaring a constructor to initialize a member of the new object
        public Book(string name) {
            grades = new List<double>();
            Name = name;
        }
        // returns a classe Statistics
        public Statistics GetStatistics()
        {
            //Instanciando a classe Statistics
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            
 
            foreach (var grade in grades)
            { 
                result.High = Math.Max(result.High, grade);
                result.Low = Math.Min(result.Low, grade);               
                result.Average += grade; //adding the elements of the list and storing the result of the adding
            }
            //calculating the average 
            result.Average /= grades.Count;
            
            return result;
        }
      
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        private List<double> grades;
        public string Name;
    }
}