using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException();

            List<double> grades = Students.SelectMany(x => x.Grades).ToList();
            //grades.Add(averageGrade);

            grades = grades.OrderByDescending(x => x).ToList();

            double percentile = grades.IndexOf(averageGrade) / (double)grades.Count * 100;

            if (percentile < 20)
                return 'A';
            else if (percentile < 40)
                return 'B';
            else if (percentile < 60)
                return 'C';
            else if (percentile < 80)
                return 'D';
            else
                return 'F';
        }
    }
}
