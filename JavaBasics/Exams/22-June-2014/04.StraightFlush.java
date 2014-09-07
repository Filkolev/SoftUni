import java.util.Arrays;
import java.util.Scanner;

public class _04_StraightFlush {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);

		String[] cards = input.nextLine().split("\\W+");
		int[] faces = new int[cards.length];
		String[] suits = new String[cards.length]; 

		for (int i = 0; i < cards.length; i++) {
			String face = cards[i].substring(0, 1);
			String suit = "";
			if (face.equals("1")) {
				face = cards[i].substring(0, 2);
				suit = cards[i].substring(2, 3);			

			}
			else {
				suit = cards[i].substring(1, 2);
			}

			suits[i] = suit;

			switch (face) {
			case "J": faces[i] = 11; break;
			case "Q": faces[i] = 12; break;
			case "K": faces[i] = 13; break;
			case "A": faces[i] = 14; break;
			default: faces[i] = Integer.parseInt(face); break;
			}
		}
		
		boolean found = false;
		
		for (int card1 = 0; card1 < suits.length - 4; card1++) {
			for (int card2 = card1 + 1; card2 < suits.length; card2++) {
				for (int card3 = card2 + 1; card3 < suits.length; card3++) {
					for (int card4 = card3 + 1; card4 < suits.length; card4++) {
						for (int card5 = card4 + 1; card5 < suits.length; card5++) {
							if (CheckSuits(suits, card1, card2, card3, card4, card5)) {
								int[] sorted = {faces[card1], faces[card2], faces[card3], faces[card4], faces[card5]};								
								Arrays.sort(sorted);
								
								if (CheckFaces(sorted)) {
									found = true;
									
									PrintFlush(sorted, suits[card1]);
								}
							}
						}
					}
				}
			}
		}
		
		if (!found) {
			System.out.println("No Straight Flushes");
		}
	}
	
	public static boolean CheckSuits(String[] suits, int i1, int i2, int i3, int i4, int i5) {
		if (suits[i1].equals(suits[i2])
				&& suits[i2].equals(suits[i3])
				&& suits[i3].equals(suits[i4])
				&& suits[i4].equals(suits[i5])) {
			return true;
		}
		
		return false;
	}
	
	public static boolean CheckFaces(int[] sorted) {
		
		
		boolean consecutive = true;
		
		for (int i = 0; i < sorted.length - 1; i++) {
			if (sorted[i] + 1 != sorted[i+1]) {
				consecutive = false;
				break;
			}
		}
		
		return consecutive;
	}
	
	public static void PrintFlush(int[] sorted, String suit) {
		StringBuilder sb = new StringBuilder();
		sb.append("[");
		
		for (int i = 0; i < sorted.length; i++) {
			switch (sorted[i]) {
			case 11: sb.append("J"); break;
			case 12: sb.append("Q"); break;
			case 13: sb.append("K"); break;
			case 14: sb.append("A"); break;
			default: sb.append(sorted[i]); break;
			}
			
			sb.append(suit);
			
			if (i != sorted.length - 1) {
				sb.append(", ");
			}
		}
		
		sb.append("]");
		
		System.out.println(sb);
		
	}
}
