package geometry;

import java.util.Arrays;
import java.util.List;

public class Shape {
    protected List<Vertex> vertices;

    protected Shape (Vertex ... vertices) {
        this.vertices = Arrays.asList(vertices);
    }
}
