import java.util.Scanner;
import java.util.ArrayList;

public class CouplesFrequency {
	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner sc = new Scanner(System.in);

		String[] input = sc.nextLine().split(" ");

		int[] numbers = new int[input.length];
		int totalCouples = numbers.length - 1;

		for (int i = 0; i < input.length; i++) {
			numbers[i] = Integer.parseInt(input[i]);
		}

		ArrayList<int[]> couples = new ArrayList<int[]>();
		ArrayList<int[]> frequencies = new ArrayList<int[]>();

		for (int i = 0; i < numbers.length - 1; i++) {
			int currentFirst = numbers[i];
			int currentSecond = numbers[i+1];

			int[] currentCouple = {currentFirst, currentSecond};
			couples.add(currentCouple);
		}

		while (couples.size() > 0) {
			int[] currentArray = couples.get(0);
			int currentFirst = currentArray[0];
			int currentSecond = currentArray[1];

			int count = 0;

			for (int j = 0; j < couples.size(); j++) {
				if (currentFirst == couples.get(j)[0]
						&& currentSecond == couples.get(j)[1]) {
					count++;					
					couples.remove(j);
					j--;
				}
			}

			int[] result = {currentFirst, currentSecond, count};
			frequencies.add(result);			

		}	

		for (int i = 0; i < frequencies.size(); i++) {
			 System.out.printf("%d %d -> %.2f%%", 
					 frequencies.get(i)[0],frequencies.get(i)[1], (double)frequencies.get(i)[2] / totalCouples * 100 );
			 System.out.println();
		}
	}
}
