import java.util.Scanner;


public class _01_CountBeers {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scn = new Scanner(System.in);
		
		String input = scn.nextLine();
		
		int totalBeers = 0;
		
		while (!input.equals("End")) {
			String[] data = input.split(" ");
			
			if (data[1].equals("beers")) {
				totalBeers += Integer.parseInt(data[0]);
			} else {
				totalBeers += 20*Integer.parseInt(data[0]);
			}
			
			input = scn.nextLine();
		}
		
		System.out.printf("%d stacks + %d beers", totalBeers/20, totalBeers%20);
	}
}
