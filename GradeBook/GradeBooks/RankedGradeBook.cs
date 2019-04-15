using System;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            this.Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (this.Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            double rank = 0;
            foreach (var student in this.Students)
            {
                if (student.AverageGrade >= averageGrade)
                {
                    rank += 1;
                }
            }

            double percentile = rank / this.Students.Count;

            if (percentile <= 0.2)
            {
                return 'A';
            }
            else if(percentile <= 0.4)
            {
                return 'B';
            }
            else if(percentile <= 0.6)
            {
                return 'C';
            }
            else if(percentile <= 0.8)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }
    }
}