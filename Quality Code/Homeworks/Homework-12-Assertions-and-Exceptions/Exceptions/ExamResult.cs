using System;

public class ExamResult
{
    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comments;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Grade = grade;
        this.Comments = comments;
    }

    public int Grade
    {
        get
        {
            return this.grade;
        }

        private set
        {
            if (value < this.MinGrade || this.MaxGrade < value)
            {
                string message = string.Format(
                    "The grade should be int the range [{0} ... {1}].",
                    this.MinGrade,
                    this.MaxGrade);

                throw new ArgumentOutOfRangeException(
                    "grade",
                    message);
            }

            this.grade = value;
        }
    }

    public int MinGrade
    {
        get
        {
            return this.minGrade;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(
                    "minGrade",
                    "The minimum grade cannot be a negative number.");
            }

            this.minGrade = value;
        }
    }

    public int MaxGrade
    {
        get
        {
            return this.maxGrade;
        }

        private set
        {
            if (value <= this.MinGrade)
            {
                throw new ArgumentOutOfRangeException(
                    "maxGrade",
                    "The maximum grade should be greater than the minimum grade.");
            }

            this.maxGrade = value;
        }
    }

    public string Comments
    {
        get
        {
            return this.comments;
        }

        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(
                    "comments",
                    "The comments field cannot be empty.");
            }

            this.comments = value;
        }
    }
}
