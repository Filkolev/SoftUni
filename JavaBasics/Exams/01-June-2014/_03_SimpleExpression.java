import java.math.BigDecimal;
import java.util.Scanner;

public class _03_SimpleExpression {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		String initial = input.nextLine().replace(" ", "");
		
		String[] numbers = initial.split("(-)|(\\+)");
		String[] operations = initial.split("[.\\d]+");		
		
		int startIndex = 0;
		if (operations[0] == "") {
			startIndex++;
		}
		
		BigDecimal sum = new BigDecimal(0);

		char currentOperation = '+';
		
		
		for (int j = 0; j < numbers.length; j++) {
			BigDecimal num = new BigDecimal(numbers[j]);
			
			if (currentOperation == '+') {
				sum = sum.add(num);
				
			}
			else {
				sum = sum.subtract(num);
			}
			
			startIndex++;
			
			if (startIndex <= operations.length - 1) {
				currentOperation = operations[startIndex].charAt(0);
			}
			
		}

		
		System.out.println(sum);
				
	}
}
