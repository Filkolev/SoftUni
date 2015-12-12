package empires.io;

import java.util.Scanner;
import empires.contracts.InputReader;

public class ConsoleInputReader implements InputReader {

    private final Scanner scanner = new Scanner(System.in);

    @Override
    public String readLine() {
        String line = scanner.nextLine();

        return line;
    }
}