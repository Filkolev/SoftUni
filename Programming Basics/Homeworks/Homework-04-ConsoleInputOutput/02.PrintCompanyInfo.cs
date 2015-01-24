using System;

/* A company has name, address, phone number, fax number, web site and manager. The manager 
 has first name, last name, age and a phone number. Write a program that reads the information
 about a company and its manager and prints it back on the console. */

class PrintCompanyInfo
{
    static void Main()
    {
        Console.Write("Please enter the company's name: ");
        string companyName = Console.ReadLine();

        Console.Write("Please enter the company's address: ");
        string companyAddress = Console.ReadLine();

        Console.Write("Please enter the company's phone number: ");
        string companyPhone = Console.ReadLine();

        Console.Write("Please enter the company's fax number: ");
        string companyFax = Console.ReadLine();

        Console.Write("Please enter the company's web site: ");
        string companySite = Console.ReadLine();

        Console.Write("Please enter the first name of the company's manager: ");
        string managerFirstName = Console.ReadLine();

        Console.Write("Please enter the last name of the company's manager: ");
        string managerLastname = Console.ReadLine();

        Console.Write("Please enter the age of the company's manager: ");
        int managerAge = int.Parse(Console.ReadLine());

        Console.Write("Please enter the phone number of the company's manager: ");
        string managerPhone = Console.ReadLine();

        Console.WriteLine("\n"+new string('*',45));
        Console.WriteLine(
            "{0}\nAddress: {1}\nTel. {2}\nFax: {3}\nWeb site: {4}\nManager: {5} {6} (age: {7}, tel. {8})",
           companyName.ToUpper(), companyAddress, companyPhone, companyFax, companySite,managerFirstName, managerLastname, managerAge, managerPhone);

    }
}
