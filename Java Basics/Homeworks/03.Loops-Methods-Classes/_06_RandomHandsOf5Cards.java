import java.util.HashSet;
import java.util.Random;
import java.util.Scanner;

// Write a program to generate n random hands of 5 different cards form a standard suit of 52 cards.

public class _06_RandomHandsOf5Cards {
	public static void main(String[] args) {
		Random rand = new Random();
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		String[] faces = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
		String[] suits = {"\u2660", "\u2665", "\u2666", "\u2663"};
		
		System.out.print("How many hands would you like to get: ");
		int numberOfHands = input.nextInt();
		
		System.out.println("\nHere you go:");
		
		for (int i = 0; i < numberOfHands; i++) {
			HashSet<String> hand = new HashSet<String>();			
			
			while (hand.size() < 5) {
				String face = faces[rand.nextInt(13)];
				String suit = suits[rand.nextInt(4)];
				
				hand.add(face + suit);			
			}
			
			for (String card : hand) {
				System.out.print(card + " ");
			}
			System.out.println();
		}		
	}
}
