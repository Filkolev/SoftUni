import java.awt.Canvas;
import java.awt.Dimension;
import java.awt.Graphics;

@SuppressWarnings("serial")
/**
 * A class describing the properties and behaviour of the Game object
 */
public class Game extends Canvas implements Runnable {
	public static Snake snake;
	public static Apple apple;
	static int points;
	
	private Graphics globalGraphics;
	private Thread runThread;
	public static final int WIDTH = 600;
	public static final int HEIGHT = 600;
	private final Dimension GameDimensions = new Dimension(WIDTH, HEIGHT);
	
	static boolean gameRunning = false;

    /**
     * Creates a new Game instance with a Snake and an Apple object
     */
    public Game(){
        snake = new Snake();
        apple = new Apple(snake);
    }

    /**
     * Creates the playing field and starts the game in a new thread
     * @param g The Graphics object
     */
	public void paint(Graphics g){
		this.setPreferredSize(GameDimensions);
		globalGraphics = g.create();
		points = 0;
		
		if(runThread == null){
			runThread = new Thread(this);
			runThread.start();
			gameRunning = true;
		}
	}

    /**
     * Main loop of the game
     */
	public void run(){
		while(gameRunning){
			snake.tick();
			render(globalGraphics);

			try {
				Thread.sleep(100);
			} catch (Exception e) {
				// TODO
			}
		}
	}

    /**
     * Draws all objects on the playing field
     * @param g The Graphics object
     */
	public void render(Graphics g){
		g.clearRect(0, 0, WIDTH, HEIGHT +25);
		g.drawRect(0, 0, WIDTH, HEIGHT);
		snake.drawSnake(g);
		apple.drawApple(g);
		g.drawString("score= " + points, 10, HEIGHT + 25);
	}
}

