import java.util.Arrays;
import java.util.Scanner;

// Write a program to enter a number n and n integer numbers and sort 
// and print them. Keep the numbers in array of integers: int[].

public class _01_SortArrayOfNumbers {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner(System.in);
		
		System.out.print("How many numbers do you want to enter: ");
		int numberOfInputs = scanner.nextInt();
		
		int[] numbers = new int[numberOfInputs];
		
		for (int i = 0; i < numberOfInputs; i++) {			
			numbers[i] = scanner.nextInt();
		}
		
		Arrays.sort(numbers);
		
		System.out.println("\nHere are the numbers in ascending order:");
		for (int num : numbers) {
			System.out.print(num + " ");
		}
	}
}
