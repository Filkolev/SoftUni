import java.util.Scanner;

public class _01_StuckNumbers {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		boolean found = false;
		input.nextLine();
		
		String[] numbers = input.nextLine().split("\\s+");
		
		for (int i1 = 0; i1 < numbers.length; i1++) {
			for (int i2 = 0; i2 < numbers.length; i2++) {
				if (i1 != i2) {
					for (int i3 = 0; i3 < numbers.length; i3++) {
						if (i3 != i2 && i3 != i1) {
							for (int i4 = 0; i4 < numbers.length; i4++) {
								if (i4 != i3 && i4 != i2 && i4 != i1) {
									String left = numbers[i1] + numbers[i2];
									String right = numbers[i3] + numbers[i4];
									
									if (left.equals(right)) {
										found = true;
										
										System.out.printf("%s|%s==%s|%s%n", numbers[i1], numbers[i2], numbers[i3], numbers[i4]);
									}
								}
							}
						}
					}
				}
			}
		}
		
		if (!found) {
			System.out.println("No");
		}
	}
}
