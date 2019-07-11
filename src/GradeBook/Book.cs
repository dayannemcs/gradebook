using System;
using System.Collections.Generic;

namespace GradeBook
{

    public delegate void GradedAddedDelegate(object sender, EventArgs args);

    /* A class is a type. It is a data structure that combines state (fields) and actions (methods and other functions member)
    into a single unit.*/
    public class Book
    {
        //Declaring a constructor to initialize a member of the new object
        public Book(string name) {
            grades = new List<double>();
            Name = name;
        }
        
        public event GradedAddedDelegate GradeAdded;

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

            switch (result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    result.Letter = 'd';
                    break;                
                default:
                    result.Letter = 'F';
                    break;
            }
            
            return result;
        }
      
        public bool AddGrade(double grade)
        {
            if (grade <= 100 && grade > 0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
                return true;
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }

        }

        private List<double> grades;

        public string Name {
            get {
                return name;
                }
            set {
                if (!String.IsNullOrEmpty(value))
                {
                    name = value;
                }
            }
        }
        public string name;
    }
}