import java.math.BigDecimal;
import java.util.Arrays;
import java.util.Scanner;


public class _02_ThreeLargestNumbers {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scn = new Scanner(System.in);
		
		Integer numberOfInputs = Integer.parseInt(scn.nextLine());
		
		BigDecimal[] numbers = new BigDecimal[numberOfInputs];
		
		for (int i = 0; i < numbers.length; i++) {
			numbers[i]= new BigDecimal(scn.nextLine()); 
		}
		
		Arrays.sort(numbers);
		
		for (int i = 0; i < Math.min(3, numberOfInputs); i++) {
			System.out.println(numbers[numberOfInputs - 1 - i].toPlainString());
		}
	}
}
