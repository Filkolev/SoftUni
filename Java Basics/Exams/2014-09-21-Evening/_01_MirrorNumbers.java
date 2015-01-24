import java.util.Scanner;


public class _01_MirrorNumbers {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scn = new Scanner(System.in);
		
		scn.nextLine();
		
		String[] numbers = scn.nextLine().split(" ");
		boolean found = false;
		
		for (int i = 0; i < numbers.length - 1; i++) {
			for (int j = i + 1; j < numbers.length; j++) {
				if (numbers[i].equals(new StringBuffer(numbers[j]).reverse().toString())) {
					found = true;
					System.out.println(numbers[i]+ "<!>" + numbers[j] );
				}
			}
		}
		
		if (!found) {
			System.out.println("No");
		}
	}
}
