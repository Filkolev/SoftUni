import java.util.Scanner;

public class _02_LettersChangeNumbers {
    public static void main(String[] args) {
        Scanner scn = new Scanner(System.in);

        String[] input = scn.nextLine().split("\\s+");

        double result = 0;

        for (String str : input) {
            if (str.isEmpty()) {
                continue;
            }

            int firstLetterPosition = str.charAt(0);
            int secondLetterPosition = str.charAt(str.length() - 1);

            double number = Integer.parseInt(str.substring(1, str.length() - 1));

            if (Character.isLowerCase(firstLetterPosition)) {
                firstLetterPosition -= 'a' - 1;
                number *= firstLetterPosition;
            } else {
                firstLetterPosition -= 'A' - 1;
                number /= firstLetterPosition;
            }

            if (Character.isLowerCase(secondLetterPosition)) {
                secondLetterPosition -= 'a' - 1;
                number += secondLetterPosition;
            } else {
                secondLetterPosition -= 'A' - 1;
                number -= secondLetterPosition;
            }

            result += number;
        }

        System.out.printf("%.2f", result);
    }
}
