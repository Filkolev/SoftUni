import java.util.Scanner;

// Write a program that finds the smallest of three numbers.

public class _04_TheSmallestOfThreeNumbers {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		System.out.println("Enter three numbers a, b and c to find the smallest of them.");
		
		System.out.print("a = ");
		double a = input.nextDouble();
				
		System.out.print("b = ");
		double b = input.nextDouble();
		
		double minNumber = Math.min(a, b);
		
		System.out.print("c = ");
		double c = input.nextDouble();
		minNumber = Math.min(minNumber, c);		
		
		String str = String.valueOf(minNumber);		
		
		System.out.printf("%nThe smallest of the three numbers is %s.", str);
	}	
}
