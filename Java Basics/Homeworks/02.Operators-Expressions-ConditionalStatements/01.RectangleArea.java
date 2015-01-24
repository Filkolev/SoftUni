import java.util.Scanner;

// Write a program that enters the sides of a rectangle (two integers a and b) and calculates and 
// prints the rectangle's area.

public class _01_RectangleArea {
	public static void main(String[] args) {
		System.out.print("To find the area of a rectangle, please enter the lengths of its sides, ");
		System.out.println("a and b, separated by a single space. Use integer numbers.");
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		int a = input.nextInt();
		int b = input.nextInt();
		
		long area = a*b;
		
		System.out.printf("\nA rectangle with sides a=%d units and b=%d units has area of %d units.", a, b, area);
	}
}
