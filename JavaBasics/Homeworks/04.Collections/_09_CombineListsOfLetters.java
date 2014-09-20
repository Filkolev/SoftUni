import java.util.ArrayList;
import java.util.Scanner;

/* Write a program that reads two lists of letters l1 and l2 and 
 * combines them: appends all letters c from l2 to the end of l1, 
 * but only when c does not appear in l1. Print the obtained combined 
 * list. All lists are given as sequence of letters separated by a single 
 * space, each at a separate line. Use ArrayList<Character> of chars to 
 * keep the input and output lists. */

public class _09_CombineListsOfLetters {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scn = new Scanner(System.in);
		
		System.out.print("Enter the first sequence of letters: ");
		String[] firstSequence = scn.nextLine().split(" ");
		System.out.print("Enter the second sequence of letters: ");
		String[] secondSequence = scn.nextLine().split(" ");
		
		ArrayList<Character> firstList = new ArrayList<>();
		ArrayList<Character> secondList = new ArrayList<>();
		
		for (String charAsString : firstSequence) {
			firstList.add(charAsString.charAt(0));
		}
		
		for (String charAsString : secondSequence) {
			secondList.add(charAsString.charAt(0));
		}
		
		secondList.removeAll(firstList);
		firstList.addAll(secondList);
		
		System.out.println("\nThe result of combining the two lists is:");
		for (Character letter : firstList) {
			System.out.print(letter + " ");
		}
		
	}
}
