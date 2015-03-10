import java.util.LinkedHashMap;
import java.util.Scanner;
import java.util.TreeMap;

public class _04_UserLogs {
    public static void main(String[] args) {
        Scanner scn = new Scanner(System.in);

        TreeMap<String, LinkedHashMap<String, Integer>> logs = new TreeMap<String, LinkedHashMap<String, Integer>>();

        String input = scn.nextLine();
        while (!input.equals("end")) {
            String[] tokens = input.split("\\s+");
            String ip = tokens[0].split("=")[1];
            String username = tokens[2].split("=")[1];

            if (!logs.containsKey(username)) {
                LinkedHashMap<String, Integer> userEntry = new LinkedHashMap<String, Integer>();
                userEntry.put(ip, 1);
                logs.put(username, userEntry);
            } else if (!logs.get(username).containsKey(ip)){
                logs.get(username).put(ip, 1);
            } else {
                int countOfMessages = logs.get(username).get(ip) + 1;
                logs.get(username).put(ip, countOfMessages);
            }

            input = scn.nextLine();
        }

        for (String username : logs.keySet()) {
            System.out.println(username + ":");

            int count = 0;
            for (String ip : logs.get(username).keySet()) {
                System.out.printf("%s => %d", ip, logs.get(username).get(ip));
                count++;

                if (count < logs.get(username).keySet().size()) {
                    System.out.printf(", ");
                } else {
                    System.out.println(".");
                }
            }
        }
    }
}
