import java.util.Scanner;

public class _01_Timespan {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scn = new Scanner(System.in);
		
		String[] start = scn.nextLine().split(":");
		int startHour = Integer.parseInt(start[0]);
		int startMinute = Integer.parseInt(start[1]);
		int startSecond = Integer.parseInt(start[2]);
		
		String[] end = scn.nextLine().split(":");
		int endHour = Integer.parseInt(end[0]);
		int endMinute = Integer.parseInt(end[1]);
		int endSecond = Integer.parseInt(end[2]);
		
		if (startSecond < endSecond) {
			startSecond += 60;
			startMinute--;
		}
		
		String toPrintSecond = "";
		int resultSecond = startSecond - endSecond;
		if (resultSecond < 10) {
			toPrintSecond = "0" + resultSecond;
		} else {
			toPrintSecond = "" + resultSecond;
		}
		
		String toPrintMinute = "";
		if (startMinute < endMinute) {
			startMinute += 60;
			startHour--;
		}
		
		int resultMinute = startMinute - endMinute;
		if (resultMinute < 10) {
			toPrintMinute = "0" + resultMinute;
		} else {
			toPrintMinute = "" + resultMinute;
		}
		
		int resultHour = startHour - endHour;
		
		System.out.printf("%d:%s:%s", resultHour, toPrintMinute, toPrintSecond);
	}
}
