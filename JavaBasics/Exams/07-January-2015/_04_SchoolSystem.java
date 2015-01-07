import java.util.ArrayList;
import java.util.Scanner;
import java.util.TreeMap;

public class _04_SchoolSystem {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scn = new Scanner(System.in);
		
		int count = Integer.parseInt(scn.nextLine());
		
		TreeMap<String, TreeMap<String, ArrayList<Double>>> grades = new TreeMap<>();
		
		for (int i = 0; i < count; i++) {
			String[] data = scn.nextLine().split(" ");			
			String name = data[0] + " " + data[1];
			String subject = data[2];
			Double grade = Double.parseDouble(data[3]);
			
			if (!grades.containsKey(name)) {
				TreeMap<String, ArrayList<Double>> currentGrade = new TreeMap<>();
				ArrayList<Double> subjectGrades = new ArrayList<Double>();
				subjectGrades.add(grade);
				currentGrade.put(subject, subjectGrades);
				grades.put(name, currentGrade);
			} else if (!grades.get(name).containsKey(subject)) {				
				ArrayList<Double> subjectGrades = new ArrayList<Double>();
				subjectGrades.add(grade);				
				grades.get(name).put(subject, subjectGrades);
			} else {
				grades.get(name).get(subject).add(grade);
			}
		}
		
		for (String name : grades.keySet()) {
			System.out.print(name + ": [");
			
			int countPrinted = 0;
			
			for (String subject : grades.get(name).keySet()) {
				int countOfMarks = grades.get(name).get(subject).size();
				
				double sum = 0;
				for (int i = 0; i < countOfMarks; i++) {
					sum += grades.get(name).get(subject).get(i);
				}
				
				double avg = sum / countOfMarks;
				
				System.out.printf("%s - %.2f", subject, avg);
				
				if (countPrinted < grades.get(name).keySet().size() - 1) {
					System.out.print(", ");
				} else {
					System.out.println("]");	
				}
				
				countPrinted++;				
			}
		}		
	}
}