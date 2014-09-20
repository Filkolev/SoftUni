import java.util.Scanner;

// Write a program to calculate the count of bits 1 in the binary representation of given integer number n.

public class _07_CountOfBitsOne {
	public static void main(String[] args) {
		System.out.print("Enter an integer number to find out how many 1 bits it has in binary form: ");
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		int number = input.nextInt();
		
		int countBits = Integer.bitCount(number);
		
		System.out.printf("%nThe number %d has %d 1-bits in its binary representation.", number, countBits);
	}
}
