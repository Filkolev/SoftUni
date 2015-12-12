package empires.core.factories;

import empires.contracts.Resource;
import empires.contracts.ResourceFactory;
import empires.models.resources.ResourceImpl;
import empires.models.resources.ResourceType;

public class ResourceFactoryImpl implements ResourceFactory {

    @Override
    public Resource createResource(String resourceType, int quantity) {
        this.validateQuantity(quantity);
        ResourceType type = ResourceType.fromString(resourceType);

        return new ResourceImpl(type, quantity);
    }

    private void validateQuantity(int quantity) {
        if (quantity < 0) {
            throw new IllegalArgumentException("Quantity cannot be negative.");
        }
    }
}