import java.util.Scanner;


public class _03_DrawFigure {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scn = new Scanner(System.in);
		
		int size = scn.nextInt();
		int outerDots = 0;
		int stars = size;
		
		for (int i = 0; i < size / 2 + 1; i++) {
			for (int j = 0; j < outerDots; j++) {
				System.out.print(".");
			}
			for (int j = 0; j < stars; j++) {
				System.out.print("*");
			}
			for (int j = 0; j < outerDots; j++) {
				System.out.print(".");
			}
			System.out.println();
			
			outerDots++;
			stars -= 2;
		}
		
		outerDots -= 2;
		stars += 4;
		
		for (int i = 0; i < size / 2; i++) {
			for (int j = 0; j < outerDots; j++) {
				System.out.print(".");
			}
			for (int j = 0; j < stars; j++) {
				System.out.print("*");
			}
			for (int j = 0; j < outerDots; j++) {
				System.out.print(".");
			}
			System.out.println();
			
			outerDots--;
			stars += 2;
		}
	}
}
