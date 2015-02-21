package geometry.geometry3d;

import geometry.Vertex;

public class Vertex3D extends Vertex {
    private double x;
    private double y;
    private double z;

    public Vertex3D(double x, double y, double z) {
        this.setX(x);
        this.setY(y);
        this.setZ(z);
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

    public double getZ() {
        return this.z;
    }

    public void setZ(double z) {
        this.z = z;
    }

    @Override
    public String toString() {
        return String.format("(X: %.2f, Y: %.2f, Z: %.2f)", this.getX(), this.getY(), this.getZ());
    }
}
