
import java.util.Scanner;

/* Write a program that enters 3 points in the plane (as integer x and y coordinates), 
 * calculates and prints the area of the triangle composed by these 3 points. Round the 
 * result to a whole number. In case the three points do not form a triangle, print "0" 
 * as result. */

public class _02_TriangleArea {
	public static void main(String[] args) {
        System.out.print("Enter the coordinates of three points in the coordinate plane ");
        System.out.println("to find the area of the triangle they form.");
        System.out.println("You will get an answer 0 if the points do not form a triangle.");
        
        @SuppressWarnings("resource")
		Scanner sc = new Scanner(System.in);
        
        int Ax = sc.nextInt();
        int Ay = Integer.parseInt(sc.nextLine().trim());
        
        int Bx = sc.nextInt();
        int By = Integer.parseInt(sc.nextLine().trim());
        
        int Cx = sc.nextInt();
        int Cy = Integer.parseInt(sc.nextLine().trim());
        
        // Calculate it in steps to make the code more manageable
        double area = 0;
        area += Ax*(By - Cy);
        area += Bx*(Cy - Ay);
        area += Cx*(Ay - By);
        area /= 2.0;
        area = Math.abs(area);
        
        if (area != 0) {
        	System.out.printf("%nThe area of the triangle is %d.", (int)area);
		} else {
			System.out.printf("%nResult: 0.%nThese three points do not form a triangle; they are collinear.");
		}
        
	}
}
