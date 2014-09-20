import java.util.Scanner;

/* Write a program to check whether a point is inside or outside the house below. 
 * The point is given as a pair of floating-point numbers, separated by a space. 
 * Your program should print "Inside" or "Outside". */

public class _09_PointsInsideHouse {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		double bottom = 8.5;
		double top = 13.5;
		
		double leftRectangleLeftBorder = 12.5;
		double leftRectangleRightBorder = 17.5;
		
		double rightRectangleLeftBorder = 20.0;
		double rightRectangleRightBorder = 22.5;
		
		System.out.println("Enter the X and Y coordinates of the point: ");
		double X = input.nextDouble();
		double Y = input.nextDouble();
		
		// For the triangle (say ABC) and the point P: if the area of ABC = area APB + areaBPC + areaCPA => point is inside;
		boolean inside = pointInRectangle(X, Y, top, bottom, leftRectangleLeftBorder, leftRectangleRightBorder) 
				|| pointInRectangle(X, Y, top, bottom, rightRectangleLeftBorder, rightRectangleRightBorder)
				|| insideTriangle(X, Y);
		
		String result = inside ? "Inside!" : "Outside!";
		
		System.out.println();
		System.out.println(result);
	}
	
	public static boolean pointInRectangle(double X, double Y, double top, double bottom, double left, double right) {
		if (X >= left && X <= right && Y >= bottom && Y <= top) {
			return true;
		}
		
		return false;
	}
	
	public static boolean insideTriangle(double X, double Y) {
		double areaABC = getTriangleArea(12.5, 8.5, 22.5, 8.5, 17.5, 3.5);
		double areaAPB = getTriangleArea(12.5, 8.5, X, Y, 22.5, 8.5);
		double areaBPC = getTriangleArea(22.5, 8.5, X, Y, 17.5, 3.5);
		double areaCPA = getTriangleArea(17.5, 3.5, X, Y, 12.5, 8.5);
		
		if (areaABC == areaAPB + areaBPC + areaCPA) {
			return true;
		} else {
			return false;
		}
	}
	
	public static double getTriangleArea(double Ax, double Ay, double Bx, double By, double Cx, double Cy) {
		double area = 0;
		area += Ax*(By - Cy);
        area += Bx*(Cy - Ay);
        area += Cx*(Ay - By);
        area /= 2.0;
        area = Math.abs(area);
        
        return area;
	}
}
