import java.math.BigInteger;
import java.util.Scanner;


public class _02_SimpleLoops {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scn = new Scanner(System.in);
		
		BigInteger tribo1 = new BigInteger(scn.nextLine());
		BigInteger tribo2 = new BigInteger(scn.nextLine());
		BigInteger tribo3 = new BigInteger(scn.nextLine());
		
		int n = Integer.parseInt(scn.nextLine());
		
		System.out.println(getTriboN(tribo1, tribo2, tribo3, n));
	}
	
	public static BigInteger getTriboN(BigInteger tribo1, BigInteger tribo2, BigInteger tribo3, int n) {
		if (n == 1) {
			return tribo1;
		}
		if (n == 2) {
			return tribo2;
		}
		if (n == 3) {
			return tribo3;
		}
		
		BigInteger triboN = tribo1.add(tribo2).add(tribo3);
		
		for (int i = 4; i < n; i++) {
			tribo1 = tribo2;
			tribo2 = tribo3;
			tribo3 = triboN;
			triboN = tribo1.add(tribo2).add(tribo3);
		}
		
		return triboN;
	}
}
