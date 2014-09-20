import java.util.Scanner;

/* Write a program that enters an array of strings and finds in it all 
 * sequences of equal elements. The input strings are given as a single 
 * line, separated by a space. */

public class _02_SequencesOfEqualStrings {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner sc = new Scanner(System.in);
		
		System.out.println("Enter the strings on a single line separated by a space:");
		
		String input = sc.nextLine();
		
		String[] strings = input.split(" ");
		
		boolean equal = false;
		
		System.out.println("\nResult:");
		
		System.out.print(strings[0] + " ");
		
		for (int i = 1; i < strings.length; i++) {
			if (strings[i].equals(strings[i-1])) {
				equal = true;
			} else {
				equal = false;
			}
			
			if (equal) {
				System.out.print(strings[i]+ " ");
			} else {
				System.out.print("\n" + strings[i]+ " ");
			}
		}
	}
}
