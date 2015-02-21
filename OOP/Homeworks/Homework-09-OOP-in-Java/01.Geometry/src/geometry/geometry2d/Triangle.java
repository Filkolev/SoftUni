package geometry.geometry2d;

public class Triangle extends PlaneShape {
    public Triangle (Vertex2D a, Vertex2D b, Vertex2D c) {
        super(a, b, c);
        checkTriangle();
    }

    public double getSideA() {
        double distanceA = Geometry2DUtils.calcDistanceBetweenVertices(
                (Vertex2D)this.vertices.get(0),
                (Vertex2D)this.vertices.get(1));

        return distanceA;
    }

    public double getSideB() {
        double distanceB = Geometry2DUtils.calcDistanceBetweenVertices(
                (Vertex2D)this.vertices.get(1),
                (Vertex2D)this.vertices.get(2));

        return distanceB;
    }

    public double getSideC() {
        double distanceC = Geometry2DUtils.calcDistanceBetweenVertices(
                (Vertex2D)this.vertices.get(2),
                (Vertex2D)this.vertices.get(0));

        return distanceC;
    }

    public void checkTriangle() {
        if (!this.isValidTriangle()) {
            throw new IllegalArgumentException(
                    "Invalid triangle. Each side of a triangle should be greater than the sum of the other two.");
        }
    }

    public boolean isValidTriangle() {
        if (this.getSideA() + this.getSideB() <= this.getSideC() ||
                this.getSideA() + this.getSideC() <= this.getSideB() ||
                this.getSideB() + this.getSideC() <= this.getSideC()) {
            return false;
        }

        return true;
    }

    @Override
    public double getArea() {
        double semiPerimeter = this.getPerimeter() / 2;
        double a = this.getSideA();
        double b = this.getSideB();
        double c = this.getSideC();

        double area = Math.sqrt(semiPerimeter * (semiPerimeter - a) * (semiPerimeter - b) * (semiPerimeter - c));

        return area;
    }

    @Override
    public double getPerimeter() {
        double perimeter = this.getSideA() + this.getSideB() + this.getSideC();

        return perimeter;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append("Triangle" + System.lineSeparator());
        sb.append("Vertices: ");

        for (int i = 0; i < 3; i++) {
            sb.append(this.vertices.get(i));

            if (i < 2) {
                sb.append(", ");
            }
        }

        sb.append(super.toString());

        return sb.toString();
    }
}
