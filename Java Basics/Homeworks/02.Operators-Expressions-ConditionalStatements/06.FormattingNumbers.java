import java.util.Scanner;

/* Write a program that reads 3 numbers: an integer a (0 ≤ a ≤ 500), a 
 * floating-point b and a floating-point c and prints them in 4 virtual 
 * columns on the console. Each column should have a width of 10 characters. 
 * The number a should be printed in hexadecimal, left aligned; then the 
 * number a should be printed in binary form, padded with zeroes, then the 
 * number b should be printed with 2 digits after the decimal point, right 
 * aligned; the number c should be printed with 3 digits after the decimal 
 * point, left aligned. */

public class _06_FormattingNumbers {
	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		System.out.print("Enter an integer a (0<= a <= 500): ");		
		int a = input.nextInt();
		
		System.out.print("Enter a floating-point number b: ");		
		double b = input.nextDouble();
		
		System.out.print("Enter a floating-point number c: ");		
		double c = input.nextDouble();
		
		String unpaddedBinary = Integer.toBinaryString(a);
		
		StringBuilder sb = new StringBuilder();

		for (int toPrepend = 10 - unpaddedBinary.length(); toPrepend>0; toPrepend--) {
		    sb.append('0');
		}

		sb.append(unpaddedBinary);
		String paddedBinary = sb.toString();
		
		System.out.printf("%n|%-10X|%s|%10.2f|%-10.3f|", a, paddedBinary, b, c);
		
	}
}
