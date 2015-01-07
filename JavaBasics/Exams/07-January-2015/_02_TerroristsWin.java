import java.util.Scanner;

public class _02_TerroristsWin {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scn = new Scanner(System.in);
		
		String input = scn.nextLine();
		char[] message = input.toCharArray();		
		
		while (new String(message).indexOf('|') != -1) {
			int startOfBomb = new String(message).indexOf('|');
			message[startOfBomb] = '.';
			int endOfBomb = new String(message).indexOf('|');
			message[endOfBomb] = '.';
			
			String bomb = new String(message).substring(startOfBomb + 1, endOfBomb);
			
			int sum = 0;
			for (Character ch : bomb.toCharArray()) {
				sum += ch;
			}
			
			int damage = sum % 10;
			
			int startArea = Math.max(0, startOfBomb - damage);
			int endArea = Math.min(input.length() - 1, endOfBomb + damage);
			
			for (int i = startArea; i <= endArea; i++) {
				message[i] = '.';
			}			
		}
		
		System.out.println(new String(message));
	}
}