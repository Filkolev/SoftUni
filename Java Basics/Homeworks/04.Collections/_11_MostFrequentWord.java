import java.util.Scanner;
import java.util.TreeMap;

/* Write a program to find the most frequent word in a text 
 * and print it, as well as how many times it appears in 
 * format "word -> count". Consider any non-letter character 
 * as a word separator. Ignore the character casing. If several 
 * words have the same maximal frequency, print all of them in 
 * alphabetical order.  */

public class _11_MostFrequentWord {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scn  = new Scanner(System.in);
		
		System.out.println("Enter the text: ");
		String input = scn.nextLine();
		
		String[] words = input.split("[^a-zA-Z]+");		
		
		TreeMap<String, Integer> frequencies = new TreeMap<>();
		
		int occurences = 0;
		
		for (int i = 0; i < words.length; i++) {
			
			String currentWord = words[i].toLowerCase();
			
			if (currentWord.equals("")) {
				continue;
			}
			
			int count = 0;
			
			for (String string : words) {
				if (currentWord.equals(string.toLowerCase())) {
					count++;
				}
			}
			
			if (count > occurences) {
				occurences = count;
			}
			
			frequencies.put(currentWord, count);			
		}
		
		for (String word : frequencies.keySet()) {
			if (frequencies.get(word) == occurences) {
				System.out.println(word + " -> " + occurences + " times");
			}
		}
	}
}
