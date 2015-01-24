import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class _03_Biggest3PrimeNumbers {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);

		String initialInput = input.nextLine();
		String[] temp = initialInput.split("[( )]+");
		List<Integer> numbers = new ArrayList<Integer>(); 

		for (String entry : temp) {

			if (entry.length() > 0) {
				int currentNumber = Integer.parseInt(entry);
				if (uniqueEntry(numbers, currentNumber) && prime(currentNumber)) {
					numbers.add(currentNumber);
				}				
			}
		}

		int maxSum = 0;

		if (numbers.size() < 3) {
			System.out.println("No");
			return;
		} else {
			for (int i1 = 0; i1 < numbers.size(); i1++) {			
				for (int i2 = i1 + 1; i2 < numbers.size(); i2++) {					
					for (int i3 = i2 + 1; i3 < numbers.size(); i3++) {

						int sum = numbers.get(i1) + numbers.get(i2) + numbers.get(i3);
						if (sum > maxSum) {
							maxSum = sum;
						}
					}
				}
			}
		}
		
		System.out.println(maxSum);

	}

	public static boolean uniqueEntry(List<Integer> numbers, Integer currentNum) {

		for (int i = 0; i < numbers.size(); i++) {
			if (currentNum == numbers.get(i)) {
				return false;
			}
		}

		return true;
	}
	
	private static boolean prime(Integer number) {
		if (number < 2) {
			return false;
		}
		
				
		for (int i = 2; i <= Math.sqrt(number); i++) {
			if (number % i == 0) {
				return false;
			}
		}
		
		return true;
	}
}
