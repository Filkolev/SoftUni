package org.softuni.empires.io;

import org.softuni.empires.contracts.OutputWriter;

public class ConsoleOutputWriter implements OutputWriter {

    @Override
    public void writeLine(String output) {
        System.out.println(output);
    }
}