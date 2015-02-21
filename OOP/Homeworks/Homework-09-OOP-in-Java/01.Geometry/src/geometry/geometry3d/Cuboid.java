package geometry.geometry3d;

import geometry.Vertex;

public class Cuboid extends SpaceShape {
    private double width;
    private double height;
    private double depth;

    public Cuboid(Vertex3D topLeftFront, double width, double height, double depth) {
        super(topLeftFront);
        this.setWidth(width);
        this.setHeight(height);
        this.setDepth(depth);
    }

    public double getWidth() {
        return this.width;
    }

    public void setWidth(double width) {
        if (width <= 0) {
            throw new IllegalArgumentException(
                    "The width of a cuboid should be greater than zero.");
        }

        this.width = width;
    }

    public double getHeight() {
        return this.height;
    }

    public void setHeight(double height) {
        if (height <= 0) {
            throw new IllegalArgumentException(
                    "The height of a cuboid should be greater than zero.");
        }

        this.height = height;
    }

    public double getDepth() {
        return this.depth;
    }

    public void setDepth(double depth) {
        if (depth <= 0) {
            throw new IllegalArgumentException(
                    "The depth of a cuboid should be greater than zero.");
        }

        this.depth = depth;
    }

    @Override
    public double getArea() {
        double frontArea = this.getWidth() * this.getHeight();
        double sideArea = this.getWidth() * this.getDepth();
        double topArea = this.getHeight() * this.getDepth();

        double area = 2 * (frontArea + sideArea + topArea);

        return area;
    }

    public Vertex getTopLeftFrontVertex() {
        return this.vertices.get(0);
    }

    @Override
    public double getVolume() {
        double volume = this.getWidth() * this.getHeight() * this.getDepth();

        return volume;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();

        sb.append("Cuboid" + System.lineSeparator());
        sb.append(String.format(
                "Top-left-front vertex: %s%n",
                this.getTopLeftFrontVertex()));

        sb.append("Width: " + this.getWidth() + System.lineSeparator());
        sb.append("Height: " + this.getHeight() + System.lineSeparator());
        sb.append("Depth: " + this.getDepth());
        sb.append(super.toString());

        return sb.toString();
    }
}
