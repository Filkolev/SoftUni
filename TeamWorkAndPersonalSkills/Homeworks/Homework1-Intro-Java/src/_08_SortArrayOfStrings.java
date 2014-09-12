import java.util.Arrays;
import java.util.Scanner;

public class _08_SortArrayOfStrings {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		System.out.print("How many strings would you like to enter: ");		
		
		int numberOfInputs = Integer.parseInt(input.nextLine());		
		
		String[] arrayToSort = new String[numberOfInputs]; 
		
		for (int i = 0; i < numberOfInputs; i++) {
			arrayToSort[i] = input.nextLine();
		}
		
		Arrays.sort(arrayToSort);
		
		System.out.println();
		System.out.println("Result:");
		
		for (int i = 0; i < arrayToSort.length; i++) {
			System.out.println(arrayToSort[i]);
		}
	}
}
