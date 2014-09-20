import java.math.BigDecimal;
import java.util.Scanner;


public class _01_SimpleCalculation {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scn = new Scanner(System.in);
		
		BigDecimal x = new BigDecimal(scn.nextLine());
		BigDecimal y = new BigDecimal(scn.nextLine());
		BigDecimal zero = new BigDecimal("0");
		
		if (x.compareTo(zero) == 0 && y.compareTo(zero) == 0) {
			System.out.println(0);
		} else if (x.compareTo(zero) == 0 && y.compareTo(zero) != 0) {
			System.out.println(5);
		} else if (x.compareTo(zero) != 0 && y.compareTo(zero) == 0) {
			System.out.println(6);
		} else if (x.compareTo(zero) == 1 && y.compareTo(zero) == 1) {
			System.out.println(1);
		} else if (x.compareTo(zero) == -1 && y.compareTo(zero) == 1) {
			System.out.println(2);
		} else if (x.compareTo(zero) == -1 && y.compareTo(zero) == -1) {
			System.out.println(3);
		} else if (x.compareTo(zero) == 1 && y.compareTo(zero) == -1) {
			System.out.println(4);
		}
	}
}
