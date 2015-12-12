package empires.contracts;

import empires.models.resources.ResourceType;

public interface Resource {

    public int getQuantity();

    public ResourceType getResourceType();
}