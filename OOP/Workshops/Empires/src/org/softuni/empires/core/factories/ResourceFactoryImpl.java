package org.softuni.empires.core.factories;

import org.softuni.empires.contracts.Resource;
import org.softuni.empires.contracts.ResourceFactory;
import org.softuni.empires.models.resources.ResourceImpl;
import org.softuni.empires.models.resources.ResourceType;

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