import java.util.Scanner;

public class VideoDurations {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		
		Scanner input = new Scanner(System.in);
		
		int hours  = 0;
		int minutes = 0;
		
		String video = input.next();
		
		while (!video.equals("End")) {
			String[] currentVideo = video.split(":");
			hours += Integer.parseInt(currentVideo[0]);
			minutes += Integer.parseInt(currentVideo[1]);
			video = input.next();
		}
		
		hours += minutes/60;
		minutes = minutes % 60;
		
		String minutesToPrint = String.format("%02d", minutes);
		
		System.out.println(hours + ":" + minutesToPrint);	
	}
}
