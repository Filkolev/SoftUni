import java.util.Arrays;
import java.util.LinkedList;
import java.util.List;
import java.util.Random;
import java.util.Scanner;

public class Hangman {
	public static void main(String[] args) {
		// Add difficulty levels - three separate lists of words; user will choose after each game;
		List<String> secretWords = new LinkedList<String>(Arrays.asList("PURIFICATION", "SUBROUTINE", "ELEPHANT", "EPITOME"));
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		Random selector = new Random();

		boolean gameWon = false;
		boolean dead = false;

		while (secretWords.size() > 0) {
			// start loop here
			int index = selector.nextInt(secretWords.size());
			int livesLeft = 10;


			String currentWord = secretWords.get(index);
			secretWords.remove(index);

			char[] toGuess = currentWord.toCharArray();
			char[] guessed = new char[currentWord.length()];
			// add wrong letters array; show it on the console

			// add text boxes
			for (int i = 0; i < guessed.length; i++) {
				guessed[i] = '*';
			}
			
			System.out.println("Enter letters from the English alphabet in order to guess the word! If you enter more than one letter, only the first one will matter. Entering symbols or digits may get you killed!");
			System.out.printf("%s%n", new String(guessed));
			
			System.out.print("Letter: ");
			
			// to fix - count repeated letters in the word, don't count letters that were already guessed before
			int totalLettersFound = 0;
			
			while (!dead || !gameWon) {
				char guessLetter = input.next().toUpperCase().charAt(0);
				boolean letterFound = false;
				

				for (int i = 0; i < guessed.length; i++) {
					if (guessLetter == toGuess[i]) {
						guessed[i] = guessLetter;
						letterFound = true;
						totalLettersFound++;						
					}			
				}

				PrintWord(guessed);
				if (!letterFound) {
//					System.out.println("Sorry! This letter isn't in the word!");
					livesLeft--;	
					// add drawing
				}

				if (livesLeft < 0) {
					dead = true;
					break;
				}
				else if (totalLettersFound == currentWord.length()) {
					gameWon = true;
					break;
				}
			}
			
			// Add game over and new game prompt
			// show word if dead
			// clear old word, missed letters
		}

	}
	
	public static void PrintWord(char[] guessed) {
		System.out.println(new String(guessed));
	}
}
