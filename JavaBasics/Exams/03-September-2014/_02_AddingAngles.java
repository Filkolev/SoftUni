import java.util.Scanner;

public class _02_AddingAngles {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		int countOfAngles = input.nextInt();
				
		int[] angles = new int[countOfAngles];
		
		for (int i = 0; i < countOfAngles; i++) {
			angles[i] = input.nextInt();
		}
		
		boolean found = false;
		
		for (int i1 = 0; i1 < angles.length - 2; i1++) {
			for (int i2 = i1 + 1; i2 < angles.length; i2++) {
				for (int i3 = i2 + 1; i3 < angles.length; i3++) {
					int sum = angles[i1] + angles[i2] + angles[i3];
					if (sum % 360 == 0) {
						found = true;
						
						System.out.printf("%d + %d + %d = %d degrees%n", angles[i1], angles[i2], angles[i3], sum);
					}					
				}
			}
		}
		
		if (!found) {
			System.out.println("No");
		}
	}
}
