package geometry.geometry3d;

import geometry.Shape;
import interfaces.AreaMeasurable;
import interfaces.VolumeMeasurable;

public abstract class SpaceShape extends Shape implements AreaMeasurable, VolumeMeasurable {
    protected SpaceShape(Vertex3D ... vertices) {
        super(vertices);
    }

    @Override
    public abstract double getArea();

    @Override
    public abstract double getVolume();

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();

        sb.append(String.format("%nArea: %.2f%n", this.getArea()));
        sb.append(String.format("Volume: %.2f%n", this.getVolume()));

        return sb.toString();
    }
}
