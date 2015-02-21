package geometry.geometry2d;

import geometry.Shape;
import interfaces.AreaMeasurable;
import interfaces.PerimeterMeasurable;

public abstract class PlaneShape extends Shape implements AreaMeasurable, PerimeterMeasurable {
    protected PlaneShape(Vertex2D ... vertices) {
        super(vertices);
    }

    @Override
    public abstract double getArea();

    @Override
    public abstract double getPerimeter();

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();

        sb.append(String.format("\nArea: %.2f", this.getArea()));
        sb.append(String.format("\nPerimeter: %.2f", this.getPerimeter()));
        sb.append(System.lineSeparator());

        return sb.toString();
    }
}
