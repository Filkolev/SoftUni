package geometry.geometry2d;

import geometry.Vertex;

public class Rectangle extends PlaneShape {
    private double width;
    private double height;

    public Rectangle(Vertex2D topLeft, double width, double height) {
        super(topLeft);
        this.setWidth(width);
        this.setHeight(height);
    }

    public double getWidth() {
        return this.width;
    }

    public void setWidth(double width) {
        if (width <= 0) {
            throw new IllegalArgumentException(
                    "The width of a rectangle should be greater than zero.");
        }

        this.width = width;
    }

    public double getHeight() {
        return this.height;
    }

    public void setHeight(double height) {
        if (height <= 0) {
            throw new IllegalArgumentException(
                    "The height of a rectangle should be greater than zero.");
        }

        this.height = height;
    }

    public Vertex getTopLeftVertex() {
        return this.vertices.get(0);
    }

    @Override
    public double getArea() {
        double area = this.getWidth() * this.getHeight();

        return area;
    }

    @Override
    public double getPerimeter() {
        double perimeter = 2 * (this.getWidth() + this.getHeight());

        return perimeter;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append("Rectangle" + System.lineSeparator());
        sb.append(String.format("Top-left vertex: %s%n", this.getTopLeftVertex()));
        sb.append(String.format("Width: %.2f%n", this.getWidth()));
        sb.append(String.format("Height: %.2f", this.getHeight()));
        sb.append(super.toString());

        return sb.toString();
    }
}
