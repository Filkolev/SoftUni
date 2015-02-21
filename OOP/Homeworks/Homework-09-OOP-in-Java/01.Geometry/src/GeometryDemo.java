import geometry.Shape;
import geometry.geometry2d.*;
import geometry.geometry3d.Cuboid;
import geometry.geometry3d.Sphere;
import geometry.geometry3d.SquarePyramid;
import geometry.geometry3d.Vertex3D;
import interfaces.PerimeterMeasurable;
import interfaces.VolumeMeasurable;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;
import java.util.stream.Collectors;

public class GeometryDemo {
    public static void main(String[] args) {
        Vertex2D pointA = new Vertex2D(0, 0);
        System.out.println(pointA.getX());

        Vertex2D pointB = new Vertex2D(1, 1);
        Vertex2D pointC = new Vertex2D(2, 2);
        Vertex2D pointCValid = new Vertex2D(-1, 10);

        // Triangle invalidTriangle = new Triangle(pointA, pointB, pointC);
        Triangle validTriangle = new Triangle(pointA, pointB, pointCValid);
        System.out.println(validTriangle);

        Triangle rightTriangle = new Triangle(new Vertex2D(0, 3), new Vertex2D(4, 0), new Vertex2D(0, 0));
        System.out.println(rightTriangle);

        ArrayList<Shape> shapes = new ArrayList<Shape>();
        shapes.add(validTriangle);
        shapes.add(rightTriangle);
        shapes.add(new Rectangle(new Vertex2D(0, 0), 5, 10));
        shapes.add(new Circle(new Vertex2D(0, 0), 2.5));
        shapes.add(new Cuboid(new Vertex3D(0, 0, 0), 10, 10, 10));
        shapes.add(new Sphere(new Vertex3D(0, 0, 0), 5.5));
        shapes.add(new SquarePyramid(new Vertex3D(0, 0, 0), 10, 10));

        System.out.println("All shapes:");
        for (Shape shape : shapes) {
            System.out.println(shape);
        }

        System.out.println();

        List<VolumeMeasurable> volumeOver40 = shapes
                .stream()
                .filter(shape -> shape instanceof VolumeMeasurable)
                .map(shape -> (VolumeMeasurable)shape)
                .filter(shape -> shape.getVolume() > 40)
                .collect(Collectors.toList());

        System.out.println("Volume measurable shapes with volume over 40:");
        for (VolumeMeasurable volumeMeasurable : volumeOver40) {
            System.out.println(volumeMeasurable);
        }

        System.out.println();

        Comparator<PerimeterMeasurable> compareByPerimeter =
                (PerimeterMeasurable s1, PerimeterMeasurable s2) ->
                {
                    if (s1.getPerimeter() == s2.getPerimeter()) {
                        return 0;
                    }

                    return s1.getPerimeter() < s2.getPerimeter() ? -1 : 1;
                };

        List<PlaneShape> sortedByPerimeter = shapes
                .stream()
                .filter(shape -> shape instanceof PlaneShape)
                .map(shape -> (PlaneShape)shape)
                .sorted(compareByPerimeter)
                .collect(Collectors.toList());

        System.out.println("Plane shapes sorted by perimeter:");
        for (PlaneShape planeShape : sortedByPerimeter) {
            System.out.println(planeShape);
        }

        System.out.println();
    }
}
