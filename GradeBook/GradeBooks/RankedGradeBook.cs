using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }
            var threshold = (int)Math.Round(Students.Count * 0.2);
            var Count = 0;
            foreach (var student in Students)
            {
                if (averageGrade > student.AverageGrade)
                    Count++;
            }
            if (Count >= threshold * 4)
                return 'A';
            else if (Count >= threshold * 3)
                return 'B';
            else if (Count >= threshold * 2)
                return 'C';
            else if (Count >= threshold)
                return 'D';
            else
                return 'F';
        }
    }
}
