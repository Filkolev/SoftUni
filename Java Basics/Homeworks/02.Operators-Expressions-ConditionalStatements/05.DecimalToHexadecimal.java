import java.util.Scanner;

/* Write a program that enters a positive integer number num and converts and 
 * prints it in hexadecimal form. You may use some built-in method from the 
 * standard Java libraries. */

public class _05_DecimalToHexadecimal {
	public static void main(String[] args) {
		System.out.print("Enter an integer number in decimal format: ");
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		int decimal = input.nextInt();
		
		System.out.printf("%nThe number in hexadecimal format is %X.", decimal);
	}
}
