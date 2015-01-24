using System;


class PersonsTest
{
    static void Main()
    {
        Person gosho = new Person("Gosho", 29);
        Person pesho = new Person("Pesho", 33, "pesho@mail.bg");

        Console.WriteLine(gosho);
        Console.WriteLine(pesho);
        Console.WriteLine(pesho.Name);
        pesho.IntroducePerson();

        /*----- INVALID LINES OF CODE -----*/

        //Person withBadName = new Person("few", 12); // throws exception because name is not valid
        //Person withBadAge = new Person("Hey", "not age"); // compile-time error - no overload for the Person constructor takes two strings; age is mandatory
        //Person withOutOfRangeAge = new Person("Hello", 122); // throws ArgumentOutOfRangeException because age is not in the accepted interval [1 ... 100]
        //Person withBadEmail = new Person("Hey", 100, "asdf"); // throws exception because email is not valid
        //Person withEmptyEmail = new Person("Baba Ilyitsa", 1, ""); // email is set, but doesn't match a valid pattern
        //Person withEmptyName = new Person("", 22); // throws exception because name is empty
    }
}