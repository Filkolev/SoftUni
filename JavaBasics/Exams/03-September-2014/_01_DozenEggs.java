import java.util.Scanner;

public class _01_DozenEggs {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		int totalEggs = 0;
		
		for (int i = 0; i < 7; i++) {
			String[] dailyProduce = input.nextLine().split(" ");
			
			if (dailyProduce[1].equals("eggs")) {
				totalEggs += Integer.parseInt(dailyProduce[0]);
			} else {
				totalEggs += 12 * Integer.parseInt(dailyProduce[0]);
			}
			
		}
		
		System.out.printf("%d dozens + %d eggs", totalEggs / 12, totalEggs % 12);
	}
}
