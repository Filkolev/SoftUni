import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;

public class _01_Pyramid {
	 public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scn = new Scanner(System.in);
		
		int numberOfLines = Integer.parseInt(scn.nextLine());
		
		ArrayList<Integer> result = new ArrayList<>();
		int previousNum = Integer.MIN_VALUE;
		
		for (int i = 0; i < numberOfLines; i++) {
			String[] nums = scn.nextLine().split("[^-\\d]+");
			ArrayList<Integer> numbers = new ArrayList<>();
			
			for (String num : nums) {
				if (!num.isEmpty()) {
					numbers.add(Integer.parseInt(num));
				}
			}
			
			Collections.sort(numbers);
			
			boolean found = false;
			for (Integer num : numbers) {				
				if (num > previousNum) {
					previousNum = num;
					result.add(num);
					found = true;
					break;
				}				
			}
			
			if (!found) {
				previousNum++;
			}
		}
		
		for (int i = 0; i < result.size() ; i++) {
			System.out.print(result.get(i));
			if (i < result.size() - 1) {
				System.out.print(", ");
			}
		}
	}
}