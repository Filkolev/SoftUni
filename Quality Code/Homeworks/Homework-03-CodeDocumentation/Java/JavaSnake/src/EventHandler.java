import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

/**
 * A class responsible for handling all game-related events.
 */
public class EventHandler implements KeyListener {

    /**
     * Creates an event handler for the provided game instance
     * @param game The instance of the game
     */
	public EventHandler(Game game){
        game.addKeyListener(this);
	}

    /**
     * Checks the key pressed by the user and changes
     * the Snake object's velocity accordingly
     * @param e The key event captured
     */
	public void keyPressed(KeyEvent e) {
		int keyCode = e.getKeyCode();
		
		if (keyCode == KeyEvent.VK_W || keyCode == KeyEvent.VK_UP) {
			if(Game.snake.getVelocityY() != 20){
                Game.snake.setVelocityX(0);
                Game.snake.setVelocityY(-20);
			}
		}

		if (keyCode == KeyEvent.VK_S || keyCode == KeyEvent.VK_DOWN) {
			if(Game.snake.getVelocityY() != -20){
                Game.snake.setVelocityX(0);
                Game.snake.setVelocityY(20);
			}
		}

		if (keyCode == KeyEvent.VK_D || keyCode == KeyEvent.VK_RIGHT) {
			if(Game.snake.getVelocityX() != -20){
                Game.snake.setVelocityX(20);
                Game.snake.setVelocityY(0);
			}
		}

		if (keyCode == KeyEvent.VK_A || keyCode == KeyEvent.VK_LEFT) {
			if(Game.snake.getVelocityX() != 20){
                Game.snake.setVelocityX(-20);
                Game.snake.setVelocityY(0);
			}
		}

		// Other controls - game exit
		if (keyCode == KeyEvent.VK_ESCAPE) {
			System.exit(0);
		}
	}
	
	public void keyReleased(KeyEvent e) {
	}
	
	public void keyTyped(KeyEvent e) {
	}
}
