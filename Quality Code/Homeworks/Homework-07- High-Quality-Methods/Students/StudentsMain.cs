namespace Students
{
    using System;

    public class StudentsMain
    {
        public static void Main()
        {
            // I'm using American settings, that's why the month goes first when parsing to DateTime
            Student peter = new Student("Peter", "Ivanov", "Sofia", DateTime.Parse("03.17.1992"));
            Student stella = new Student("Stella", "Markova", "Vidin", DateTime.Parse("11.03.1993"));

            stella.AdditionalInfo = "gamer, high results";

            Console.WriteLine(
                "{0} older than {1} -> {2}",
                peter.FirstName,
                stella.FirstName,
                peter.IsOlderThan(stella));
        }
    }
}
