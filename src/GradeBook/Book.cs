using System;
using System.Collections.Generic;

namespace GradeBook
{

    public delegate void GradedAddedDelegate(object sender, EventArgs args);

    public class NameObject
    {
        public NameObject(string name)
        {
            Name = name;
        }

        public string Name 
        {
            get;
            set;
        }
    }

    public abstract class BookBase : NameObject
    {
        public BookBase(string name) : base(name)
        {
        }

        public abstract void AddGrade(double grade);
    }
    public class Book : BookBase
    {
        public Book(string name): base(name) {
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
      
        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade > 0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
                
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }

        }

        private List<double> grades;

    
    }
}