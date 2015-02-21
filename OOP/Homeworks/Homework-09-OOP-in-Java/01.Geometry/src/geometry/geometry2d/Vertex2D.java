package geometry.geometry2d;

import geometry.Vertex;

public class Vertex2D extends Vertex {
    private double x;
    private double y;

    public Vertex2D (double x, double y) {
        this.setX(x);
        this.setY(y);
    }

    public double getX() {
        return this.x;
    }

    public void setX(double x) {
        this.x = x;
    }

    public double getY() {
        return this.y;
    }

    public void setY(double y) {
        this.y = y;
    }

    @Override
    public String toString() {
        return String.format("(X: %.2f, Y: %.2f)", this.getX(), this.getY());
    }
}