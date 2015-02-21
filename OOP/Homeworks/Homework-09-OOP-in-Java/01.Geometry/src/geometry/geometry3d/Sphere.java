package geometry.geometry3d;

import geometry.Vertex;

public class Sphere extends SpaceShape {
    private double radius;

    public Sphere(Vertex3D center, double radius) {
        super(center);
        this.setRadius(radius);
    }

    public double getRadius() {
        return this.radius;
    }

    public void setRadius(double radius) {
        if (radius <= 0) {
            throw new IllegalArgumentException(
                    "The radius of a sphere should be greater than zero.");
        }

        this.radius = radius;
    }

    public Vertex getCenterVertex() {
        return this.vertices.get(0);
    }

    @Override
    public double getArea() {
        double area = 4 * Math.PI * this.getRadius() * this.getRadius();

        return area;
    }

    @Override
    public double getVolume() {
        double volume = 4.0 / 3 * Math.PI * this.getRadius() * this.getRadius() * this.getRadius();

        return volume;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append("Sphere" + System.lineSeparator());
        sb.append(String.format("Center: %s%n", this.getCenterVertex()));
        sb.append(String.format("Radius: %.2f", this.getRadius()));
        sb.append(super.toString());

        return sb.toString();
    }
}
