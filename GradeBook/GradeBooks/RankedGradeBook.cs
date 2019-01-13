using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name , bool isWeighted) : base(name, isWeighted)
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
            var numberOfGradesBelowThreshold = 0;
            foreach (var student in Students)
            {
                if (averageGrade > student.AverageGrade)
                    numberOfGradesBelowThreshold++;
            }
            if (numberOfGradesBelowThreshold >= threshold * 4)
                return 'A';
            else if (numberOfGradesBelowThreshold >= threshold * 3)
                return 'B';
            else if (numberOfGradesBelowThreshold >= threshold * 2)
                return 'C';
            else if (numberOfGradesBelowThreshold >= threshold)
                return 'D';
            else
                return 'F';
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
