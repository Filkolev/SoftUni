import java.util.LinkedHashMap;
import java.util.Scanner;

/* We are given a sequence of N playing cards from a standard 
 * deck. The input consists of several cards (face + suit), 
 * separated by a space. Write a program to calculate and print 
 * at the console the frequency of each card face in format 
 * "card_face -> frequency". The frequency is calculated by the 
 * formula appearances / N and is expressed in percentages with 
 * exactly 2 digits after the decimal point. The card faces with 
 * their frequency should be printed in the order of the card face's 
 * first appearance in the input. The same card can appear multiple 
 * times in the input, but it's face should be listed only once in the output. */

public class _12_CardFrequencies {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scn = new Scanner(System.in);
		
		System.out.println("Enter the cards:");
		String input = scn.nextLine();
		
		// I assume there are no empty strings after splitting
		String[] cards = input.split(" ");
		int totalCards = cards.length;
		
		LinkedHashMap<String, Integer> occurences = new LinkedHashMap<>();
		
		for (String card : cards) {
			String face = card.substring(0, card.length() - 1);
			
			if (occurences.containsKey(face)) {
				occurences.put(face, occurences.get(face) + 1);
			} else {
				occurences.put(face, 1);
			}
		}
		
		System.out.println("\nResult:");
		
		for (String face : occurences.keySet()) {
			double percentage = (double)occurences.get(face) / totalCards * 100;
			System.out.printf("%s -> %.2f%%%n",face, percentage);
		}
	}
}
