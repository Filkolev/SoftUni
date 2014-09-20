import java.util.Scanner;

public class _03_PointsInsideAFigure {
	public static void main(String[] args) {
		System.out.println("Enter the coordinates of a point to find whether it's inside or outside the figure:");
		
		@SuppressWarnings("resource")
		Scanner sc = new Scanner(System.in);
		
		double X = sc.nextDouble();
		double Y = sc.nextDouble();
		
		boolean inside = false;
		
		if (Y >= 6.0 && Y <= 8.5 && X >= 12.5 && X <= 22.5) {
			inside = true;
		} else if ((Y >= 8.5 && Y <= 13.5) && (X >= 12.5 && X <= 17.5)) {
			inside = true;
		} else if ((Y >= 8.5 && Y <= 13.5) && (X >= 20 && X <= 22.5)) {
			inside = true;
		}
		
		String result = inside ? "inside" : "outside";
		System.out.printf("%nThe point with cordinates {%f, %f} is %s the figure.", X, Y, result);
	}
}
