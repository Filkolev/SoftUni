// Write a program SumTwoNumbers.java that enters two integers from the console, 
// calculates and prints their sum. Search in Internet to learn how to read numbers from the console.

import java.util.Scanner;

public class _06_SumTwoNumbers {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		System.out.print("Enter two numbers to find their sum: ");
		int firstNum = input.nextInt();
		int secondNum = input.nextInt();
		
		int sum = firstNum + secondNum;
		
		System.out.println("The sum of the two numbers is " + sum + ".");
	}
}
