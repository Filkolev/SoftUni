import java.util.Scanner;

public class _02_Durts {
	public static void main(String[] args) {
		
		Scanner input = new Scanner(System.in);
		
		int centerX = input.nextInt();
		int centerY = input.nextInt();
		int range = input.nextInt();
		
		
		int horizontalLeftX = centerX - range; 
		int horizontalRightX = centerX + range;
		int horizontalTopY = centerY  + range / 2;
		int horizontalBottomY = centerY - range / 2;
		
		int verticalLeftX = centerX - range / 2;
		int verticalRightX = centerX + range / 2;
		int verticalTopY = centerY + range;
		int verticalBottomY = centerY - range;
		
		int count = input.nextInt();
		
		for (int i = 0; i < count; i++) {
			int currentX = input.nextInt();
			int currentY = input.nextInt();
			
			boolean insideHorizontal = CheckPoint(currentX, currentY, horizontalBottomY, horizontalTopY,horizontalLeftX,  horizontalRightX);
			boolean insideVertical = CheckPoint(currentX, currentY, verticalBottomY, verticalTopY,verticalLeftX,  verticalRightX);
			
			boolean inside = insideHorizontal || insideVertical;
			
			System.out.printf("%s%n", inside ? "yes" : "no");
		}
		
		
		
	}
	public static boolean CheckPoint(int X, int Y, int bottomBorder, int topBorder, int leftBorder, int rightBorder){
		if (X >= leftBorder && X <= rightBorder && Y >= bottomBorder && Y <= topBorder) {
			return true;
		}	
		else {
			return false;
		}
	}
}
