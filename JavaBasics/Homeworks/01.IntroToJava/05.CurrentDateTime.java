// Create a simple Java program CurrentDateTime.java to print the current date and time.

import java.time.LocalDateTime;
import java.time.ZoneId;

public class _05_CurrentDateTime {
	
	public static void main(String[] args) {
		
	 LocalDateTime today = LocalDateTime.now(ZoneId.of("Europe/Sofia"));
	 
	 System.out.printf(
			 "Today is %s, %s %s, %s. The local time is %s:%s.", 
			 today.getDayOfWeek(), today.getMonth(), today.getDayOfMonth(), today.getYear(), today.getHour(), today.getMinute());
	
	}
	
}
