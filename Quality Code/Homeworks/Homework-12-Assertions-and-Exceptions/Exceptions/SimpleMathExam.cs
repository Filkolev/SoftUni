using System;

public class SimpleMathExam : Exam
{
    private const int MinProblemsSolved = 0;
    private const int MaxProblemsSolved = 10;

    private int problemsSolved;

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved
    {
        get
        {
            return this.problemsSolved;
        }

        private set
        {
            if (value < MinProblemsSolved || MaxProblemsSolved < value)
            {
                string message = string.Format(
                    "The number of problems solved must be in the range [{0} ... {1}].",
                    MinProblemsSolved,
                    MaxProblemsSolved);

                throw new ArgumentOutOfRangeException(
                    "problemsSolved",
                    message);
            }

            this.problemsSolved = value;
        }
    }

    public override ExamResult Check()
    {
        switch (this.ProblemsSolved)
        {
            case 1:
            case 2:
                return new ExamResult(2, 2, 6, "Bad result: nothing done.");
            case 3:
            case 4:
                return new ExamResult(3, 2, 6, "Poor result: few problems solved.");
            case 5:
            case 6:
                return new ExamResult(4, 2, 6, "Average result: some problems solved.");
            case 7:
            case 8:
                return new ExamResult(5, 2, 6, "Good result: most problems solved.");
            case 9:
            case 10:
                return new ExamResult(6, 2, 6, "Excellent result: most or all problems solved.");
            default:
                throw new ArgumentOutOfRangeException("problemsSolved", "The number of problems solved is invalid.");
        }
    }
}
