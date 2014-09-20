import java.util.Scanner;

/* Write a program to find how many times a word appears in 
 * given text. The text is given at the first input line. 
 * The target word is given at the second input line. The 
 * output is an integer number. Please ignore the character 
 * casing. Consider that any non-letter character is a word 
 * separator. */

public class _06_CountSpecifiedWord {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scn = new Scanner(System.in);
		
		System.out.print("Enter the text: ");
		String input = scn.nextLine();
		System.out.print("Enter the lookup word: ");
		String lookupWord = scn.nextLine().trim().toLowerCase();
		
		String[] words = input.split("[^a-zA-Z]+");
		
		int count = 0;
		
		for (String word : words) {
			if (lookupWord.equals(word.toLowerCase())) {
				count++;
			}
		}
		
		System.out.println("\nNumber of occurences of the word \"" + lookupWord + "\": " + count);
		
	}
}
