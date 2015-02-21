package geometry.geometry3d;

import geometry.Vertex;

public class SquarePyramid extends SpaceShape {
    private double baseWidth;
    private double height;

    public SquarePyramid (Vertex3D baseCenter, double baseWidth, double height) {
        super(baseCenter);
        this.setBaseWidth(baseWidth);
        this.setHeight(height);
    }

    public double getBaseWidth() {
        return this.baseWidth;
    }

    public void setBaseWidth(double baseWidth) {
        if (baseWidth <= 0) {
            throw new IllegalArgumentException(
                    "The base width of a pyramid should be greater than zero.");
        }

        this.baseWidth = baseWidth;
    }

    public double getHeight() {
        return this.height;
    }

    public void setHeight(double height) {
        if (height <= 0) {
            throw new IllegalArgumentException(
                    "The height of a pyramid should be greater than zero.");
        }

        this.height = height;
    }

    public Vertex getBaseCenterVertex() {
        return this.vertices.get(0);
    }

    @Override
    public double getArea() {
        double baseArea = this.getBaseWidth() * this.getBaseWidth();

        double sideArea = this.getBaseWidth() * this.getSideHeight() / 2;

        double totalArea = 4 * sideArea + baseArea;

        return totalArea;
    }

    @Override
    public double getVolume() {
        double volume = 1.0 / 3 * this.getBaseWidth() * this.getHeight();

        return volume;
    }

    private double getSideHeight() {
        double height = this.getHeight();
        double base = this.getBaseWidth() / 2;

        double sideHeight = Math.sqrt(height * height + base * base);

        return sideHeight;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append("Square pyramid" + System.lineSeparator());
        sb.append(String.format("Base center: %s%n", this.getBaseCenterVertex()));
        sb.append(String.format("Base width: %.2f%n", this.getBaseWidth()));
        sb.append(String.format("Height: %.2f", this.getHeight()));
        sb.append(super.toString());

        return sb.toString();
    }
}
