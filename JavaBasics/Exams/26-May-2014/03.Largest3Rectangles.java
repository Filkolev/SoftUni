import java.util.ArrayList;
import java.util.Scanner;

public class Largest3Rectangles {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner sc = new Scanner(System.in);
		
		String input = sc.nextLine();		
		input = input.replaceAll("\\s+","");
		
		String[] splitInput = input.split("\\[|\\]|x");
		
		ArrayList<Integer> numbers = new ArrayList<Integer>();
		
		for (int i = 0; i < splitInput.length; i++) {
			String currentMember = splitInput[i];
			
			if (currentMember.length() > 0) {
				int num = Integer.parseInt(splitInput[i]);
				numbers.add(num);
			}
		}
		
		long maxProduct = 0;
		for (int i = 0; i < numbers.size() - 5; i += 2) {
			long currentProduct = numbers.get(i) * numbers.get(i + 1);
			currentProduct += (numbers.get(i + 2)* numbers.get(i + 3));
			currentProduct += numbers.get(i+4)*numbers.get(i+5);
			
			if (currentProduct > maxProduct) {
				maxProduct = currentProduct;
			}
		}
		
		System.out.println(maxProduct);
	}
}
