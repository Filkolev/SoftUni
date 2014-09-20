import java.util.Scanner;

/* Write a program to count how many sequences of two equal bits ("00" or "11") 
 * can be found in the binary representation of given integer number n (with overlapping). */

public class _08_CountEqualBitPairs {
	public static void main(String[] args) {
		System.out.print("Enter an integer: ");
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		int number = input.nextInt();
		int mask = 3;
		int countPairs = 0;
		
		while (number > 2) {
			if ((number & mask) == 3 || (number & mask) == 0) {
				countPairs++;
			}
			
			number >>= 1;
		}
		
		System.out.printf("%nThe number has %d equal bit pairs (00 or 11).", countPairs);
	}
}
