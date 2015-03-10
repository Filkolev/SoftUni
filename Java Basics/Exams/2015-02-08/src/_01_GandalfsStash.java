import java.util.Scanner;

public class _01_GandalfsStash {
    public static void main(String[] args) {
        Scanner scn = new Scanner(System.in);

        int moodPoints = Integer.parseInt(scn.nextLine());

        String[] food = scn.nextLine().split("[^a-zA-Z]+");

        for (String meal : food) {
            if (meal.equalsIgnoreCase("cram")) {
                moodPoints += 2;
            } else if (meal.equalsIgnoreCase("lembas")) {
                moodPoints += 3;
            } else if (meal.equalsIgnoreCase("apple")) {
                moodPoints++;
            } else if (meal.equalsIgnoreCase("melon")) {
                moodPoints++;
            } else if (meal.equalsIgnoreCase("honeycake")) {
                moodPoints += 5;
            } else if (meal.equalsIgnoreCase("mushrooms")) {
                moodPoints -= 10;
            } else {
                moodPoints--;
            }
        }

        System.out.println(moodPoints);

        if (moodPoints < -5) {
            System.out.println("Angry");
        } else if (moodPoints < 0) {
            System.out.println("Sad");
        } else if (moodPoints < 15) {
            System.out.println("Happy");
        } else {
            System.out.println("Special JavaScript mood");
        }
    }
}
