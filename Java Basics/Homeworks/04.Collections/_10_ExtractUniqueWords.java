import java.util.Scanner;
import java.util.TreeSet;

/* At the first line at the console you are given a piece 
 * of text. Extract all words from it and print them in 
 * alphabetical order. Consider each non-letter character 
 * as word separator. Take the repeating words only once. 
 * Ignore the character casing. Print the result words in 
 * a single line, separated by spaces. */

public class _10_ExtractUniqueWords {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scn = new Scanner(System.in);
		
		System.out.println("Enter the text: ");
		String input = scn.nextLine();

		String[] words = input.split("[^a-zA-Z]+");

		TreeSet<String> uniqueWords = new TreeSet<>();

		for (String word : words) {
			if (!word.equals("")) {
				uniqueWords.add(word.toLowerCase());
			}
		}

		for (String string : uniqueWords) {
			System.out.print(string + " ");
		}
	}
}
