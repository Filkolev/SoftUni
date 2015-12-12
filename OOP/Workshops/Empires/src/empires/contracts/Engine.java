package empires.contracts;

public interface Engine {

    public void run();
    
    public void executeCommand(String commandName, String[] commandTokens);
}