import java.math.BigInteger;
import java.util.Scanner;


public class _05_BitFlipper {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scn = new Scanner(System.in);
		
		String input = scn.nextLine();
		
		BigInteger number = new BigInteger(input);
		
		for (int i = 63; i >= 2; i--) {
			if (number.testBit(i) && number.testBit(i - 1) && number.testBit(i - 2)) {
				number = number.flipBit(i);
				number = number.flipBit(i - 1);
				number = number.flipBit(i - 2);
				i -= 2;
			} else if (!number.testBit(i) && !number.testBit(i - 1) && !number.testBit(i - 2)) {
				number = number.flipBit(i);
				number = number.flipBit(i - 1);
				number = number.flipBit(i - 2);
				i -= 2;
			}
		}
		
		System.out.println(number);
	}
}
