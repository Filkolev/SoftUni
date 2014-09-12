import java.util.Scanner;

public class _06_SumTwoNumbers {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		int firstNum = input.nextInt();
		int secondNum = input.nextInt();
		
		int sum = firstNum + secondNum;
		
		System.out.println("The sum of the two numbers is " + sum + ".");
	}
}
