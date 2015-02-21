import java.awt.Color;
import java.awt.Graphics;

/**
 * A base class describing the properties and behaviour of Point objects in the game
 */
public class Point{
	private int x, y;
	private final int WIDTH = 20;
	private final int HEIGHT = 20;

    /**
     * Creates a Point object from another Point object
     * @param p The Point object used for the creation of the new Point
     */
	public Point(Point p){
		this(p.x, p.y);
	}

    /**
     * Creates a Point object with given coordinates on the playing field
     * @param x The x-coordinate of the new Point
     * @param y The y-coordinate of the new Point
     */
	public Point(int x, int y){
		this.x = x;
		this.y = y;
	}

    /**
     * Gets the x-coordinate of the current Point
     * @return An integer number representing the x-coordinate of the Point
     */
	public int getX() {
        return x;
	}

    /**
     * Changes the x-coordinate of the current Point
     * @param x The new x-coordinate of the Point
     */
	public void setX(int x) {
        this.x = x;
	}

    /**
     * Gets the y-coordinate of the current Point
     * @return An integer number representing the y-coordinate of the Point
     */
	public int getY() {
        return y;
	}

    /**
     * Changes the y-coordinate of the current Point
     * @param y The new y-coordinate of the Point
     */
	public void setY(int y) {
        this.y = y;
	}

    /**
     * Draws an object on the playing field in the specified color
     * @param g The Graphics object
     * @param color The color to be used when drawing the object
     */
	public void drawObject(Graphics g, Color color) {
		g.setColor(Color.BLACK);
		g.fillRect(x, y, WIDTH, HEIGHT);
		g.setColor(color);
		g.fillRect(x + 1, y + 1, WIDTH - 2, HEIGHT - 2);
	}

    /**
     * Returns a string representation of a Point
     * @return A string representation of a Point
     */
	public String toString() {
		return "[x=" + x + ",y=" + y + "]";
	}

    /**
     * Returns true if two Points have the same coordinates
     * @param obj The Point object to compare to
     * @return
     */
	public boolean equals(Object obj) {
        if (obj instanceof Point) {
            Point point = (Point)obj;
            return (x == point.x) && (y == point.y);
        }
        return false;
    }
}
