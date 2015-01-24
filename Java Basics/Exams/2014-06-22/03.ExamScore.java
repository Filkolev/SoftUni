import java.util.Scanner;
import java.util.TreeMap;


public class _03_ExamScore {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scn = new Scanner(System.in);

		scn.nextLine();
		scn.nextLine();
		scn.nextLine();

		TreeMap<Integer, TreeMap<String, Double>> entries = new TreeMap<>(); 

		while (true) {
			String inputLine = scn.nextLine();
			if (inputLine.startsWith("-")) {
				break;
			}

			String[] tokens = inputLine.split("[ |]+");

			String name = tokens[1] + " " + tokens[2];
			int score = Integer.parseInt(tokens[3]);
			Double grade = Double.parseDouble(tokens[4]);
			TreeMap<String, Double> newEntry = new TreeMap<>();
          newEntry.put(name, grade);

			if (entries.containsKey(score)) {				
				entries.get(score).put(name, grade);
			} else {
				
				entries.put(score, newEntry);
			}
		}
		
		for (Integer entry : entries.keySet()) {
			System.out.print(entry + " -> ");
			System.out.print(entries.get(entry).keySet());
			
			Double averageDouble = 0.0;
			int numberOfGrades = entries.get(entry).size();
			
			double totalGrade = 0.0;
			
			for (String name : entries.get(entry).keySet()) {
				totalGrade += entries.get(entry).get(name);
			}
			
			averageDouble = totalGrade / numberOfGrades;
			System.out.printf("; avg=%.2f", averageDouble);
			
			System.out.println();
		}
	}
}
