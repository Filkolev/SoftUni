using System;

class EmployeeData_v2

    /* Here I played around asking for user input and some data validation.  */
{
    static void Main()
    {        
        string firstName;
        string lastName;
        byte age;
        char gender;
        int employeeNumberUnchecked; // Will use this to check the employee number for validity
        string employeeNumber;
       
        Console.WriteLine("Please enter the employee's first name:");
        firstName = Console.ReadLine();

        Console.WriteLine("\nPlease enter the employee's last name:");
        lastName = Console.ReadLine();

        /* Whenever there are restriction on the data entered
        I use TryParse and if the input cannot be converted to the
        desired type or if it's not within the accepted range
        I tell the user that the input is not valid and ask them to 
        re-enter the data. This is repeated until valid input is provided */
        Console.WriteLine("\nPlease enter the employee's age:");

        bool uncheckedAge = byte.TryParse(Console.ReadLine(), out age);

        while (uncheckedAge == false || age < 0 || age > 100)
        {
            Console.WriteLine("\nThe age must be a number between 0 and 100. Please re-enter:");
            uncheckedAge = byte.TryParse(Console.ReadLine(), out age);
        }
        

        Console.WriteLine("\nPlease enter the employee's gender (m or f):");
        string uncheckedGender = Console.ReadLine();
        
        while (uncheckedGender != "m" && uncheckedGender != "f")
        {
            Console.WriteLine("\nThe gender can only be \"m\" of \"f\". Please re-enter:");
            uncheckedGender = Console.ReadLine();
        }
       
        gender = char.Parse(uncheckedGender);

        Console.WriteLine("\nPlease enter the employee's unique number:");
        bool uncheckedEmployeeNumber = int.TryParse(Console.ReadLine(), out employeeNumberUnchecked);

       
        while (uncheckedEmployeeNumber == false || employeeNumberUnchecked < 27560000 || employeeNumberUnchecked > 27569999)
        {
            Console.WriteLine("\nThe employee number must be between 27 560 000 and 27 569 999 (no spaces). Please re-enter:");
            uncheckedEmployeeNumber = int.TryParse(Console.ReadLine(), out employeeNumberUnchecked);
        }

        employeeNumber = employeeNumberUnchecked.ToString();
        
        Console.WriteLine("\n" + new string('-', 40));
        Console.WriteLine("EMPLOYEE DATA FOR: " + lastName.ToUpper() + ", " + firstName.ToUpper());
        Console.WriteLine(new string('-', 40));



        Console.WriteLine("First name: {0}\nLast name: {1}\nAge: {2}\nGender: {3}\nUnique Employee Number: {4}",
            firstName, lastName, age, gender, employeeNumber);
        Console.WriteLine(new string('-', 40));
    }
}
