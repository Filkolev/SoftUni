import java.applet.Applet;
import java.awt.Dimension;
import java.awt.Graphics;

@SuppressWarnings("serial")
/**
 * The GameApplet class initializes the game and the playing field
 */
public class GameApplet extends Applet {
	private Game game;
	EventHandler eventHandler;

    /**
     * Initializes the game instance and sets the playing field dimensions.
     */
	public void init(){
		game = new Game();
		game.setPreferredSize(new Dimension(800, 650));
		game.setVisible(true);
		game.setFocusable(true);
		this.add(game);
		this.setVisible(true);
		this.setSize(new Dimension(800, 650));
		eventHandler = new EventHandler(game);
	}

    /**
     * Sets the dimensions of the playing field to the default values - 800x650
     * @param g The Graphics object
     */
	public void paint(Graphics g){
        this.setSize(new Dimension(800, 650));
	}
}
