import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class _02_SumCards {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);

		List<Integer> faces = new ArrayList<Integer>();

		String[] cards = input.nextLine().split("\\s+");

		for (int i = 0; i < cards.length; i++) {
			String card = cards[i];
			if (card == "" || card == null) {
				continue;
			}
			String face = card.substring(0, card.length() - 1);	

			switch (face) {
			case "J": faces.add(12); break;
			case "Q": faces.add(13); break;
			case "K": faces.add(14); break;
			case "A": faces.add(15); break;
			default: faces.add(Integer.parseInt(face)); break;
			}
		}

		int sum = 0;

		boolean consecutive = false;

		if (faces.size() == 1) {
			System.out.println(faces.get(0));
			return;
		}
		else if (faces.size() == 2) {
			sum = faces.get(0) + faces.get(1);
			if (faces.get(0) == faces.get(1)) {
				sum *= 2;
			}
			System.out.println(sum);
			return;
		}

		else {
			for (int i = 0; i < faces.size(); i++) {	


				if (i == 0) {
					if (faces.get(i) == faces.get(i + 1)) {
						consecutive = true;
					}
				}
				else if (i == faces.size() - 1) {
					if (faces.get(i) == faces.get(i - 1)) {
						consecutive = true;
					}
				}
				else if (faces.get(i) == faces.get(i - 1) || faces.get(i) == faces.get(i + 1)) {
					consecutive = true;	
				}		


				sum += faces.get(i);			
				if (consecutive) {
					sum += faces.get(i);
				}

				consecutive = false;
			}
		}

		System.out.println(sum);
	}
}
