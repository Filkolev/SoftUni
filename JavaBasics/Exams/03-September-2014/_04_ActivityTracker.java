import java.util.Scanner;
import java.util.TreeMap;

public class _04_ActivityTracker {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner(System.in);
		
		int numberOfLogs = scanner.nextInt();
		scanner.nextLine();
		
		TreeMap<Integer, TreeMap<String, Float>> monthActivity = new TreeMap<>();
		
		for (int i = 0; i < numberOfLogs; i++) {
			String[] activity = scanner.nextLine().split(" "); 			
			String[] date = activity[0].split("/");
			
			int month = Integer.parseInt(date[1]);			
			String name = activity[1];			
			float distance = Float.parseFloat(activity[2]);				
			
			if (monthActivity.containsKey(month)) {
				if (monthActivity.get(month).containsKey(name)) {
					distance +=  monthActivity.get(month).get(name);					
				}	
				monthActivity.get(month).put(name, distance);
			} else {
				TreeMap<String, Float> users = new TreeMap<>();
				users.put(name, distance);
				monthActivity.put(month, users);
			}					
		}
		
		for (Integer month : monthActivity.keySet()) {
			System.out.print(month + ": ");
			
			TreeMap<String, Float> users = monthActivity.get(month);
			
			int count = 0;
			
			for (String name : users.keySet()) {
				if (count > 0) {
					System.out.printf(", %s(%.0f)", name, users.get(name));
				} else {
					System.out.printf("%s(%.0f)", name, users.get(name));
				}
				
				count++;		
				
			}
			
			System.out.println();
		}
	}
}
