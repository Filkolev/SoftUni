import java.util.Scanner;

public class _03_FireTheArrows {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scn = new Scanner(System.in);
		
		int rows = Integer.parseInt(scn.nextLine());		
		
		char[][] matrix = new char[rows][];
		
		for (int i = 0; i < rows; i++) {
			String row = scn.nextLine();
			
			matrix[i] = new char[row.length()];
			for (int j = 0; j < row.length(); j++) {
				matrix[i][j]= row.charAt(j); 
			}
		}
		
		boolean over = false;		
		
		while (!over) {
			int moves = 0;
			for (int row = 0; row < rows; row++) {
				for (int col = 0; col < matrix[row].length; col++) {
					
					switch (matrix[row][col]) {
					case '^':
						if (row > 0 && col < matrix[row - 1].length) {
							if (matrix[row - 1][col] == 'o') {
								matrix[row - 1][col] = '^';
								matrix[row][col] = 'o';
								moves++;
							}
						}
						break;
					case 'v':
						if (row < rows - 1 && col < matrix[row + 1].length) {
							if (matrix[row + 1][col] == 'o') {
								matrix[row + 1][col] = 'v';
								matrix[row][col] = 'o';
								moves++;								
							}
						}
						break;
						
					case '<':
						if (col > 0) {
							if (matrix[row][col - 1] == 'o') {
								matrix[row][col - 1]  = '<';
								matrix[row][col] = 'o';
								moves++;
							}
						}
						break;
						
					case '>':
						if (col < matrix[row].length - 1) {
							if (matrix[row][col + 1] == 'o') {
								matrix[row][col + 1]  = '>';
								matrix[row][col] = 'o';
								moves++;									
							}
						}
						break;					
					}
				}
			}
			
			if (moves == 0) {
				over = true;
			}
		}
		
		for (int i = 0; i < rows; i++) {
			for (int j = 0; j < matrix[i].length; j++) {
				System.out.print((char)matrix[i][j]);
			}
			System.out.println();
		}		
	}
}