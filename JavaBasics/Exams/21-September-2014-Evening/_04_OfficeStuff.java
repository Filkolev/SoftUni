import java.util.LinkedHashMap;
import java.util.Scanner;
import java.util.TreeMap;


public class _04_OfficeStuff {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scn = new Scanner(System.in);
		
		int numberOfInputs = Integer.parseInt(scn.nextLine());
		
		TreeMap<String, LinkedHashMap<String, Integer>> entries = new TreeMap<>();
		
		for (int i = 0; i < numberOfInputs; i++) {
			String[] data = scn.nextLine().split("[ |\\-]+");
			String companyName = data[1];
			String product = data[3];
			int amount = Integer.parseInt(data[2]);
			
			if (entries.containsKey(companyName)) {
				if (entries.get(companyName).containsKey(product)) {
					amount += entries.get(companyName).get(product);
				}
				
				entries.get(companyName).put(product, amount);
			} else {
				LinkedHashMap<String, Integer> newEntry = new LinkedHashMap<>();
				newEntry.put(product, amount);
				entries.put(companyName, newEntry);
			}
			
		}
		
		for (String company : entries.keySet()) {
			System.out.print(company + ": ");
			
			boolean first = true;
			
			for (String nut : entries.get(company).keySet()) {
				if (!first) {
					System.out.print(", ");
				}
				
				first = false;
				
				System.out.print(nut + "-" + entries.get(company).get(nut));
				
			}
			System.out.println();
		}
	}
}
