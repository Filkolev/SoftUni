import java.util.Scanner;
import java.util.TreeMap;

public class _04_LogsAggregator {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scn = new Scanner(System.in);
		
		int numberOfLogs = Integer.parseInt(scn.nextLine());
		
		TreeMap<String, TreeMap<String, Integer>> entries = new TreeMap<>();
		
		for (int i = 0; i < numberOfLogs; i++) {
			String[] inputs = scn.nextLine().split(" ");
			
			String ip = inputs[0];
			String name = inputs[1];
			int duration = Integer.parseInt(inputs[2]);
			
			TreeMap<String, Integer> ipEntries = new TreeMap<>();
			
			if (entries.containsKey(name)) {
				if (entries.get(name).containsKey(ip)) {
					duration += entries.get(name).get(ip);
				}
				
				entries.get(name).put(ip, duration);
			} else {
				ipEntries.put(ip, duration);
				entries.put(name, ipEntries);
			}
		}
		
		for (String name : entries.keySet()) {
			System.out.print(name + ": ");
			
			int totalDuration = 0;
			
			for (String ip : entries.get(name).keySet()) {
				totalDuration += entries.get(name).get(ip);
			}
			
			System.out.print(totalDuration + " ");
			System.out.println(entries.get(name).keySet());
		}				
	}
}
