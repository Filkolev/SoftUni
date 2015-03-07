using System;

public class CSharpExam : Exam
{
    private const int MinScore = 0;
    private const int MaxScore = 100;

    private int score;

    public CSharpExam(int score)
    {
        this.Score = score;
    }

    public int Score
    {
        get
        {
            return this.score;
        }

        private set
        {
            if (value < MinScore || MaxScore < value)
            {
                string message = string.Format(
                    "The score should be in the range [{0} ... {1}].",
                    MinScore,
                    MaxScore);

                throw new ArgumentOutOfRangeException(
                    "score",
                    message);
            }

            this.score = value;
        }
    }

    public override ExamResult Check()
    {
        return new ExamResult(this.Score, MinScore, MaxScore, "Exam results calculated by score.");
    }
}
