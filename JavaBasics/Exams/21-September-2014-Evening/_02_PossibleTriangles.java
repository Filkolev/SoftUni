import java.util.Arrays;
import java.util.Scanner;


public class _02_PossibleTriangles {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scn = new Scanner(System.in);
		
		String input = scn.nextLine();
		
		boolean found = false;
		
		while (!input.equals("End")) {
			String[] splitInput = input.split(" ");
			double[] numbers = new double[splitInput.length];
			
			for (int i = 0; i < splitInput.length; i++) {
				numbers[i] = Double.parseDouble(splitInput[i]); 
			}
			
			Arrays.sort(numbers);
			
			if (numbers[0] + numbers[1] > numbers[2]) {
				found = true;
				System.out.printf("%.2f+%.2f>%.2f%n", numbers[0], numbers[1], numbers[2]);
			}
			
			input = scn.nextLine();
		}
		
		if (!found) {
			System.out.println("No");
		}
		
	}
}
