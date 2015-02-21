package geometry.geometry2d;

import geometry.Vertex;

public class Circle extends PlaneShape {
    private double radius;

    public Circle (Vertex2D center, double radius) {
        super(center);
        this.setRadius(radius);
    }

    public double getRadius() {
        return this.radius;
    }

    public void setRadius(double radius) {
        if (radius <= 0) {
            throw new IllegalArgumentException(
                    "The radius of a circle should be greater than zero.");
        }

        this.radius = radius;
    }

    public Vertex getCenter() {
        return this.vertices.get(0);
    }

    @Override
    public double getArea() {
        double area = Math.PI * this.getRadius() * this.getRadius();

        return area;
    }

    @Override
    public double getPerimeter() {
        double perimeter = 2 * Math.PI * this.getRadius();

        return perimeter;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append("Circle" + System.lineSeparator());
        sb.append(String.format("Center: %s%n", this.getCenter()));
        sb.append(String.format("Radius: %.2f", this.getRadius()));
        sb.append(super.toString());

        return sb.toString();
    }
}
