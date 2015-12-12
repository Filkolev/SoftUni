package empires.contracts;

public interface ResourceFactory {

    public Resource createResource(String resourceType, int quantity);
}