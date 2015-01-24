import java.util.Scanner;

/* Write a program to count the number of words in given 
 * sentence. Use any non-letter character as word separator. */

public class _05_CountAllWords {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scn = new Scanner(System.in);
		
		System.out.println("Enter the text:");
		String input = scn.nextLine();		
		String[] words = input.split("[^a-zA-Z]+");
		
		System.out.print("\nThere are ");
		// Check if sentence started with non-letter (we'll get "" in words[0], don't count it as a word)
		if (words[0].equals("")) {
			System.out.println(words.length - 1 + " words in the text.");
		} else {
			System.out.println(words.length + " words in the text.");
		}		
	}
}
