import java.util.Scanner;


public class _03_WeirdStrings {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scn = new Scanner(System.in);
		
		String input = scn.nextLine().replaceAll("[ |\\/()]+", "");
		
		String[] words = input.split("[^a-zA-Z]+");
		int[] weights = new int[words.length];
		
		for (int i = 0; i < weights.length; i++) {
			weights[i] = getWeight(words[i].toLowerCase()); 
		}
		
		int maxSum = 0;
		String firstWord = "";
		String secondWord = "";
		
		for (int i = 0; i < weights.length - 1; i++) {
			
				int currentSum = weights[i] + weights[i + 1];
				if (currentSum >= maxSum) {
					maxSum = currentSum;
					firstWord = words[i];
					secondWord = words[i + 1];
				
			}
		}
		
		System.out.println(firstWord);
		System.out.println(secondWord);
		
		
	}
	
	public static int getWeight(String word) {
		int sum = 0;
		for (int i = 0; i < word.length(); i++) {
			sum += (word.charAt(i) - 'a' + 1);
		}
		
		return sum;
	}
}
