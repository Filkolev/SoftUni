import java.util.Scanner;

/* Write a program to find how many times given string appears 
 * in given text as substring. The text is given at the first 
 * input line. The search string is given at the second input 
 * line. The output is an integer number. Please ignore the character 
 * casing. */

public class _07_CountSubstringOccurences {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scn = new Scanner(System.in);
		
		System.out.print("Enter the text: ");
		String text = scn.nextLine().toLowerCase();
		System.out.print("Enter the lookup phrase: ");
		String lookupSubString = scn.nextLine().toLowerCase();		

		// Not sure how to use regex with overlapping for this problem, so I went with a loop
		int count = 0;
		
		for (int i = 0; i < text.length() - lookupSubString.length() + 1; i++) {
			String currentSubString = text.substring(i, i + lookupSubString.length());
			
			if (lookupSubString.equals(currentSubString)) {
				count++;
			}
		}
		
		System.out.println(count);
	}
}
