import java.util.Scanner;

public class _03_LegoBlocks {
    public static void main(String[] args) {
        Scanner scn = new Scanner(System.in);

        int numberOfRows = Integer.parseInt(scn.nextLine());

        String[][] leftMatrix = new String[numberOfRows][];
        String[][] rightMatrix = new String[numberOfRows][];
        int[] rowLengths = new int[numberOfRows];

        int countOfCells = 0;

        for (int i = 0; i < numberOfRows; i++) {
            leftMatrix[i] = scn.nextLine().trim().split("\\s+");
            countOfCells += leftMatrix[i].length;
            rowLengths[i] += leftMatrix[i].length;
        }

        for (int i = 0; i < numberOfRows; i++) {
            rightMatrix[i] = scn.nextLine().trim().split("\\s+");
            countOfCells += rightMatrix[i].length;
            rowLengths[i] += rightMatrix[i].length;
        }

        for (int i = 1; i < numberOfRows; i++) {
            if (rowLengths[i] != rowLengths[i -1]) {
                System.out.printf("The total number of cells is: %d", countOfCells);
                return;
            }
        }

        for (int i = 0; i < numberOfRows; i++) {
            StringBuilder rowToPrint = new StringBuilder("[");

            for (int j = 0; j < leftMatrix[i].length; j++) {
                rowToPrint.append(leftMatrix[i][j]);
                rowToPrint.append(", ");
            }


            for (int j = rightMatrix[i].length - 1; j >= 0; j--) {
                rowToPrint.append(rightMatrix[i][j]);

                if (j > 0) {
                    rowToPrint.append(", ");
                }
            }

            rowToPrint.append("]");

            System.out.println(rowToPrint);
        }
    }
}
