import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/* Write a program to extract all email addresses from given text. The text comes at the 
 * first input line. Print the emails in the output, each at a separate line. Emails are 
 * considered to be in format <user>@<host>, where:
<user> is a sequence of letters and digits, where '.', '-' and '_' can appear between them. 
Examples of valid users: "stephan", "mike03", "s.johnson", "st_steward", "softuni-bulgaria", 
"12345". Examples of invalid users: ''--123", ".....", "nakov_-", "_steve", ".info".
<host> is a sequence of at least two words, separated by dots '.'. Each word is sequence of 
letters and can have hyphens '-' between the letters. Examples of hosts: "softuni.bg", 
"software-university.com", "intoprogramming.info", "mail.softuni.org". Examples of invalid hosts: 
"helloworld", ".unknown.soft.", "invalid-host-", "invalid-".
Example of valid emails: info@softuni-bulgaria.org, kiki@hotmail.co.uk, no-reply@github.com, 
s.peterson@mail.uu.net, info-bg@software-university.software.academy. */

public class _08_ExtractEmails {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scn = new Scanner(System.in);
		
		System.out.print("Enter the text: ");
		String text = scn.nextLine();
		
		// You can try testing the text in the file EmailTest.txt, there are invalid emails in the end 
		// which should not be captured. There should be 9 matches total.
		// You can also check out the explanation file to understand what this regex does.
		String emailMatcher = "((?<=\\s)|^)([a-z0-9][a-z0-9\\-._]*[a-z0-9])@([a-z0-9][a-z0-9\\-]*[a-z0-9]\\.)+[a-z0-9]+";
		
		Pattern pattern = Pattern.compile(emailMatcher);
		Matcher matcher = pattern.matcher(text);

		System.out.println("\nThe text contains the following emails:");
		while(matcher.find()) {
		    System.out.println(matcher.group());
		}
	}
}
