import java.util.Arrays;
import java.util.Scanner;

public class PythagoreanNumbers {

	public static void main(String[] args) {
	
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		int countOfNumbers = Integer.parseInt(input.next());
		
		int[] numbers = new int[countOfNumbers];
		
		for (int i = 0; i < countOfNumbers; i++) {
			numbers[i] = Integer.parseInt(input.next());
		}
		
		Arrays.sort(numbers);
		
		boolean resultsFount = false;
		
		for (int i = 0; i < countOfNumbers; i++) {
			for (int j = i; j < countOfNumbers; j++) {
				for (int j2 = j; j2 < numbers.length; j2++) {
					if (numbers[i]*numbers[i] + numbers[j]*numbers[j] == numbers[j2]*numbers[j2] ) {
						resultsFount = true;
						
						System.out.println(numbers[i] + "*" + numbers[i] + " + " + numbers[j] + "*" + numbers[j] + " = " + numbers[j2] + "*" + numbers[j2]);
					}
				}
			}
		}
		
		if (!resultsFount) {
			System.out.println("No");
		}
	}
}
