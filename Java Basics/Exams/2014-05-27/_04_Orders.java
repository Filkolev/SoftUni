import java.util.LinkedHashMap;
import java.util.Scanner;
import java.util.TreeMap;


public class _04_Orders {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scn = new Scanner(System.in);
		
		int numberOfOrders = Integer.parseInt(scn.nextLine());
		
		LinkedHashMap<String, TreeMap<String, Integer>> entries = new LinkedHashMap<String, TreeMap<String,Integer>>();
		
		for (int i = 0; i < numberOfOrders; i++) {
			String[] data = scn.nextLine().split(" ");
			
			String name = data[0];
			int orderAmount = Integer.parseInt(data[1]);
			String product = data[2];
			
			if (entries.containsKey(product)) {
				if (entries.get(product).containsKey(name)) {
					orderAmount += entries.get(product).get(name);
				}
				
				entries.get(product).put(name, orderAmount);
			} else {
				TreeMap<String, Integer> newEntry = new TreeMap<>();
				newEntry.put(name, orderAmount);
				entries.put(product, newEntry);
			}
		}
		
		for (String product : entries.keySet()) {
			System.out.print(product + ": ");
			boolean firstEntry = true;
			for (String name : entries.get(product).keySet()) {
				if (!firstEntry) {
					System.out.print(", ");
				}
				System.out.print(name + " " + entries.get(product).get(name));
				firstEntry = false;
			}
			
			System.out.println();
		}
		
	}
}
