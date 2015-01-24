import java.util.Scanner;

public class _04_MagicCarNumbers {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scn = new Scanner(System.in);
		
		int magicWeight = scn.nextInt();
		char[] letters = { 'A', 'B', 'C', 'E', 'H', 'K', 'M', 'P', 'T', 'X' };		

		int countOfMagic = 0;
		
		for (int i = 0; i < 10; i++) {
			for (int j = 0; j < 10; j++) {		
				
				for (int ch1 = 0; ch1 < letters.length; ch1++) {
					for (int ch2 = 0; ch2 < letters.length; ch2++) {						
						
						if (i == j) {
							if (getWeight("" + i + i + i + i + letters[ch1] + letters[ch2]) == magicWeight) {
								countOfMagic++;
								
							}
						} else {
							if (getWeight("" + i + j + j + j + letters[ch1] + letters[ch2]) == magicWeight) {
								countOfMagic++;
								
							}
							if (getWeight("" + i + i + i + j + letters[ch1] + letters[ch2]) == magicWeight) {
								countOfMagic++;
								
							}
							if (getWeight("" + i + i + j + j + letters[ch1] + letters[ch2]) == magicWeight) {
								countOfMagic++;
								
							}
							if (getWeight("" + i + j + i + j + letters[ch1] + letters[ch2]) == magicWeight) {
								countOfMagic++;
								
							}
							if (getWeight("" + i + j + j + i + letters[ch1] + letters[ch2]) == magicWeight) {
								countOfMagic++;
								
							}
						}
						
						
					}
				}
			}
		}
		
		System.out.println(countOfMagic);		
		
	}
	
	public static int getWeight(String carNumber) {
		int weight = 40;		
		
		for (int i = 0; i < carNumber.length(); i++) {
			char symbol = carNumber.charAt(i);
			
			if (symbol >= '0' && symbol <= '9') {
				weight += symbol - '0';
			} else {
				weight += 10*(symbol - 'A' + 1);
			}
		}
		
		return weight;
	}
}
