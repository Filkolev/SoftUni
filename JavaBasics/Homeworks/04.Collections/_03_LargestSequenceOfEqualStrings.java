import java.util.Scanner;

/* Write a program that enters an array of strings and finds 
 * in it the largest sequence of equal elements. If several 
 * sequences have the same longest length, print the leftmost 
 * of them. The input strings are given as a single line, separated 
 * by a space. */

public class _03_LargestSequenceOfEqualStrings {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner sc = new Scanner(System.in);
		
		System.out.println("Enter the input strings on a single line separated by a space:");
		
		String input = sc.nextLine();
		
		String[] strings = input.split(" ");
		
		int maxLength = 1;
		String maxString = strings[0];
		String currentSequence = strings[0];
		int currentLength = 1;
		
		for (int i = 1; i < strings.length; i++) {
			String currentString = strings[i];
			
			if (i != strings.length - 1 && currentString.equals(currentSequence)) {
				currentLength++;				
			} else {
				if (currentString.equals(currentSequence)) {
					currentLength++;
				}
				if (currentLength > maxLength) {
					maxLength = currentLength;
					maxString = currentSequence;
				}
				
				currentLength = 1;
				currentSequence = currentString;
			}				
		}
		
		System.out.println("\nThe longest sequence of equal strings is:");
		for (int i = 0; i < maxLength; i++) {
			System.out.print(maxString + " ");
		}
	}
}
