import java.util.Scanner;

/* Write a program to generate and print all 3-letter words consisting 
 * of given set of characters. For example if we have the characters 'a' 
 * and 'b', all possible words will be "aaa", "aab", "aba", "abb", "baa", 
 * "bab", "bba" and "bbb". The input characters are given as string at 
 * the first line of the input. Input characters are unique (there are 
 * no repeating characters). */

public class _02_GenerateThreeLetterWords {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		System.out.print("Enter a set of characters to find all possible combinations of 3 of them: ");
		String inputString = input.nextLine().trim().toLowerCase();
		
		char[] letters = inputString.toCharArray();
		
		System.out.println("\nResult:");
		for (int ch1 = 0; ch1 < letters.length; ch1++) {
			for (int ch2 = 0; ch2 < letters.length; ch2++) {
				for (int ch3 = 0; ch3 < letters.length; ch3++) {
					System.out.print("" + letters[ch1] + letters[ch2] + letters[ch3] + " ");
				}
			}
		}		
	}
}
