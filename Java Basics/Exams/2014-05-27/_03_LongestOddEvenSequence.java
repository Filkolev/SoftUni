import java.util.ArrayList;
import java.util.Scanner;

public class _03_LongestOddEvenSequence {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scn = new Scanner(System.in);
		
		String input = scn.nextLine();
		
		String[] splitInput = input.split("[( )]+");
		ArrayList<Integer> numbers = new ArrayList<>();
		
		for (String entry : splitInput) {
			if (entry.equals("")) {
				continue;
			}
			
			numbers.add(Integer.parseInt(entry));
		}
		
		int maxSequence = 0;
		
		boolean previousIsEven = false;		
		int currentSequence = 1;
		
		if (numbers.get(0) % 2 == 0) {
			previousIsEven = true;
		}
		
		for (int i = 1; i < numbers.size(); i++) {
			
			boolean currentIsEven = numbers.get(i) % 2 == 0;
			if (numbers.get(i) == 0 && previousIsEven) {
				currentIsEven = false;
			}
			
			if ((previousIsEven && !currentIsEven)
					|| (!previousIsEven && currentIsEven)) {
				currentSequence++;				
				
			} else {
				if (currentSequence > maxSequence) {
					maxSequence = currentSequence;
				}
				currentSequence = 1;				
			}
			
			previousIsEven = currentIsEven;
			
			if (i == numbers.size() - 1) {
				if (currentSequence > maxSequence) {
					maxSequence = currentSequence;
				}
			}
		}
		
		System.out.println(maxSequence);
	}
}
