package geometry.geometry2d;

public final class Geometry2DUtils {
    private Geometry2DUtils(){

    }

    public static double calcDistanceBetweenVertices(Vertex2D v1, Vertex2D v2) {
        double deltaX = v1.getX() - v2.getX();
        double deltaY = v1.getY() - v2.getY();

        double distance = Math.sqrt(deltaX * deltaX + deltaY * deltaY);

        return distance;
    }
}
