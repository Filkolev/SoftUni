import java.awt.*;
import java.util.LinkedList;

public class Snake{
	LinkedList<Point> snakeBody = new LinkedList<Point>();
	private Color snakeColor;
	private int velocityX, velocityY;
	
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
	
	public void drawSnake(Graphics g) {
		for (Point point : this.snakeBody) {
			point.drawObject(g, snakeColor);
		}
	}
	
	public void tick() {
		Point newPosition = new Point((snakeBody.get(0).getX() + velocityX), (snakeBody.get(0).getY() + velocityY));
		
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

	public int getVelocityX() {
		return velocityX;
	}

	public void setVelocityX(int velocityX) {
		this.velocityX = velocityX;
	}

	public int getVelocityY() {
		return velocityY;
	}

	public void setVelocityY(int velocityY) {
		this.velocityY = velocityY;
	}
}
