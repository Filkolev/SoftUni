package org.softuni.empires.io;

import java.util.Scanner;
import org.softuni.empires.contracts.InputReader;

public class ConsoleInputReader implements InputReader {

    private final Scanner scanner = new Scanner(System.in);

    @Override
    public String readLine() {
        String line = scanner.nextLine();

        return line;
    }
}