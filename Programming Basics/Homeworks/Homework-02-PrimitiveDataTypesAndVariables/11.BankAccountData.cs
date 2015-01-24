using System;

/* A bank account has a holder name (first name, middle name and last name), available amount of money (balance), 
 bank name, IBAN, 3 credit card numbers associated with the account. Declare the variables needed to keep the 
 information for a single bank account using the appropriate data types and descriptive names. */

class BankAccountData
{
    static void Main()
    {
        string holderFirstName;
        string holderMiddleName;
        string holderLastName;        
        decimal accountBalance; 
        string bankName;        
        string IBAN;   
        string ccNumber1;
        string ccNumber2;
        string ccNumber3;

        holderFirstName = "George";
        holderMiddleName = "W.";
        holderLastName = "Bush";
        accountBalance = 20000000m;
        bankName = "Wells Fargo Bank";
        IBAN = "CH93 0076 2011 6238 5295 7";
        ccNumber1 = "1234567890123456";
        ccNumber2 = "2345678901234567";
        ccNumber3 = "3456789012345678";
           
        Console.WriteLine(
            new string('-', 40) + "\nBANK ACCOUNT DETAILS\n" + new string('-', 40) + "\nAccount Holder: {2}, {0} {1}\nAccount Balance: {3:c}\nBank Name: {4}\nIBAN: {5}\nCredit Card Numbers: {6}, {7}, {8}",
            holderFirstName, holderMiddleName, holderLastName, accountBalance, bankName, IBAN, ccNumber1, ccNumber2, ccNumber3);
    }
}
