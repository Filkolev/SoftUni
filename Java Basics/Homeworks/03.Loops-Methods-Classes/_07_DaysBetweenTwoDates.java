import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.time.temporal.ChronoUnit;
import java.util.Scanner;

/* Write a program to calculate the difference between two dates in 
 * number of days. The dates are entered at two consecutive lines 
 * in format day-month-year. Days are in range [1…31]. Months are 
 * in range [1…12]. Years are in range [1900…2100]. */

public class _07_DaysBetweenTwoDates {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in); 

		DateTimeFormatter formatter = DateTimeFormatter.ofPattern("dd-MM-yyyy"); 

		String startInput = input.nextLine();
		if (startInput.length() == 9) {
			startInput = "0" + startInput;
		}

		String endInput = input.nextLine();
		if (endInput.length() == 9) {
			endInput = "0" + endInput;
		}

		LocalDate start = LocalDate.parse(startInput, formatter);
		LocalDate end = LocalDate.parse(endInput, formatter);	
		
		long daysBetween = ChronoUnit.DAYS.between(start, end);		

		System.out.println(daysBetween);
	}
}
