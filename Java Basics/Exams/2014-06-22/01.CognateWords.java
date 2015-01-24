import java.util.HashSet;
import java.util.Scanner;

public class _01_CognateWords {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner sc = new Scanner(System.in);
		
		String input = sc.nextLine().trim();
		
		String[] words = input.split("\\P{Alpha}+");
		HashSet<String> results = new HashSet<String>();		
		
		for (int i = 0; i < words.length; i++) {
			for (int j = 0; j < words.length; j++) {
				if (j == i) {
					continue;
				}
				String word = words[i] + words[j];
				
				for (int k = 0; k < words.length; k++) {
					if (words[k].equals(word)) {					
						
						String currentString = words[i] + "|" + words[j] + "=" + words[k];
						results.add(currentString);
						
					}
				}
				
			}
		}
		
		if (results.isEmpty()) {
			System.out.println("No");
		}
		else {
			for (String string : results) {
				System.out.println(string);
			}
		}
	}
}
