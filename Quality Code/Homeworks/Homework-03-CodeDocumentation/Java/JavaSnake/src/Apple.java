import java.awt.Color;
import java.awt.Graphics;
import java.util.Random;

/**
 * A class describing the properties and behaviour of the Apple objects in the game.
 */
public class Apple {
	public static Random rnd;
	private Point appleObject;
	private Color snakeColor;

    /**
     * Creates a new Apple object in the game.
     * @param s the Snake object used to check whether the Apple's position is valid
     */
	public Apple(Snake s) {
		appleObject = createApple(s);
		snakeColor = Color.RED;
	}

    /**
     * Creates a new Point on the playing field. If the Point is within the Snake object
     * the process is repeated.
     * @param s The Snake object used to check whether the new Point's position is valid for an Apple object
     * @return A new Point object which will be used to create an Apple object.
     */
	private Point createApple(Snake s) {
		rnd = new Random();

        // Gets a random integer between 0 and 600 - the width of the playing field
		int x = rnd.nextInt(30) * 20;

        // Gets a random integer between 0 and 600 - the height of the playing field
		int y = rnd.nextInt(30) * 20;

        // Check if the new Point overlaps the Snake object
		for (Point snakePoint : s.snakeBody) {
			if (x == snakePoint.getX() || y == snakePoint.getY()) {
				return createApple(s);
			}
		}

		return new Point(x, y);
	}

    /**
     * Draws the Apple object on the playing field
     * @param g
     */
	public void drawApple(Graphics g){
        appleObject.drawObject(g, snakeColor);
	}

    /**
     * Returns the Apple object
     * @return An Apple object
     */
	public Point getPoint(){
        return appleObject;
	}
}
