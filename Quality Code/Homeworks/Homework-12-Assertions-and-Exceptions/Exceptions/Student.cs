using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    private string firstName;
    private string lastName;
    private IList<Exam> exams;

    public Student(string firstName, string lastName, IList<Exam> exams)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public Student(string firstName, string lastName)
        : this(firstName, lastName, new List<Exam>())
    {
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
        }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(
                    "firstName",
                    "First name cannot be null or empty.");
            }

            this.firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(
                    "lastName",
                    "Last name cannot be null or empty.");
            }

            this.lastName = value;
        }
    }

    public IList<Exam> Exams
    {
        get
        {
            return this.exams;
        }

        private set
        {
            if (value == null)
            {
                throw new ArgumentNullException("exams", "The exams cannot be null.");
            }

            this.exams = value;
        }
    }

    public double CalcAverageExamResultInPercents()
    {
        if (this.Exams.Count == 0)
        {
            throw new InvalidOperationException("Cannot calculate average on missing exams");
        }

        double[] examScores = new double[this.Exams.Count];

        IList<ExamResult> examResults = this.CheckExams();
        for (int i = 0; i < examResults.Count; i++)
        {
            int gradeRange = examResults[i].MaxGrade - examResults[i].MinGrade;
            double normalizedGrade = examResults[i].Grade - examResults[i].MinGrade;

            examScores[i] = normalizedGrade / gradeRange;
        }

        return examScores.Average();
    }

    private IList<ExamResult> CheckExams()
    {
        if (this.Exams.Count == 0)
        {
            throw new InvalidOperationException("The student has no exams.");
        }

        IList<ExamResult> results = new List<ExamResult>();

        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }
}
