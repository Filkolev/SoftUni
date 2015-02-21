import java.awt.*;
import java.util.LinkedList;

/**
 * A class describing the properties and behaviour of the Snake object in the game
 */
public class Snake{
	LinkedList<Point> snakeBody = new LinkedList<Point>();
	private Color snakeColor;
	private int velocityX, velocityY;

    /**
     * Creates a new Snake object with default length, position and speed
     */
	public Snake() {
		snakeColor = Color.GREEN;
		snakeBody.add(new Point(300, 100));
		snakeBody.add(new Point(280, 100));
		snakeBody.add(new Point(260, 100));
		snakeBody.add(new Point(240, 100));
		snakeBody.add(new Point(220, 100));
		snakeBody.add(new Point(200, 100));
		snakeBody.add(new Point(180, 100));
		snakeBody.add(new Point(160, 100));
		snakeBody.add(new Point(140, 100));
		snakeBody.add(new Point(120, 100));

		velocityX = 20;
		velocityY = 0;
	}

    /**
     * Draws the Snake object on the playing field
     * @param g The Graphics object
     */
	public void drawSnake(Graphics g) {
		for (Point point : this.snakeBody) {
			point.drawObject(g, snakeColor);
		}
	}

    /**
     * Moves the Snake object on the playing field based on its velocity and direction
     */
	public void tick() {
		Point newPosition = new Point((snakeBody.get(0).getX() + velocityX), (snakeBody.get(0).getY() + velocityY));

        // Check if the Snake object ended up outside the playing field or overlapped with itself
		if (newPosition.getX() > Game.WIDTH - 20) {
		 	Game.gameRunning = false;
		} else if (newPosition.getX() < 0) {
			Game.gameRunning = false;
		} else if (newPosition.getY() < 0) {
			Game.gameRunning = false;
		} else if (newPosition.getY() > Game.HEIGHT - 20) {
            Game.gameRunning = false;
		} else if (Game.apple.getPoint().equals(newPosition)) {
			snakeBody.add(Game.apple.getPoint());
            Game.apple = new Apple(this);
            Game.points += 50;
		} else if (snakeBody.contains(newPosition)) {
            Game.gameRunning = false;
			System.out.println("You ate yourself");
		}

		for (int i = snakeBody.size()-1; i > 0; i--) {
			snakeBody.set(i, new Point(snakeBody.get(i-1)));
		}

		snakeBody.set(0, newPosition);
	}

    /**
     * Gets the Snake's current horizontal velocity
     * @return The speed of the Snake along the x-axis
     */
	public int getVelocityX() {
		return velocityX;
	}

    /**
     * Sets the horizontal velocity of the Snake to a new value.
     * @param velocityX The new velocity along the x-axis
     */
	public void setVelocityX(int velocityX) {
		this.velocityX = velocityX;
	}

    /**
     * Gets the Snake's current vertical velocity
     * @return The speed of the Snake along the y-axis
     */
	public int getVelocityY() {
		return velocityY;
	}

    /**
     * Sets the vertical velocity of the Snake to a new value.
     * @param velocityY The new velocity along the y-axis
     */
	public void setVelocityY(int velocityY) {
		this.velocityY = velocityY;
	}
}
