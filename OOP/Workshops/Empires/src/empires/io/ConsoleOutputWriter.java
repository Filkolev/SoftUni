package empires.io;

import empires.contracts.OutputWriter;

public class ConsoleOutputWriter implements OutputWriter {

    @Override
    public void writeLine(String output) {
        System.out.println(output);
    }
}