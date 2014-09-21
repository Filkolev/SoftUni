import java.util.ArrayList;
import java.util.Scanner;


public class _02_MagicSum {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scn = new Scanner(System.in);
		
		int denominator = Integer.parseInt(scn.nextLine());
		
		String input = scn.nextLine();
		
		ArrayList<Integer> numbers = new ArrayList<>();
		
		while (!input.equals("End")) {
			numbers.add(Integer.parseInt(input));
			
			input = scn.nextLine();
			
		}
		
		int maxSum = Integer.MIN_VALUE;
		int firstNum = 0;
		int secondNum = 0;
		int thirdNum = 0;
		
		boolean found = false;
		
		for (int i = 0; i < numbers.size() - 2; i++) {
			for (int j = i + 1; j < numbers.size(); j++) {
				for (int k = j + 1; k < numbers.size(); k++) {
					int currentFirstNum = numbers.get(i);
					int currentSecondNum = numbers.get(j);
					int currentThirdNum = numbers.get(k);
					int currentSum = currentFirstNum + currentSecondNum + currentThirdNum;
					
					
					if (currentSum % denominator == 0 && currentSum > maxSum) {
						maxSum = currentSum;
						firstNum = currentFirstNum;
						secondNum = currentSecondNum;
						thirdNum = currentThirdNum;
						found = true;
					}
				}
			}
		}
		
		if (!found) {
			System.out.println("No");
		} else {
			System.out.printf("(%d + %d + %d) %% %d = 0 ", firstNum, secondNum, thirdNum, denominator);
		}
		
	}
}
