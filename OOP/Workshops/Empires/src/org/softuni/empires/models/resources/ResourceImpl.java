package org.softuni.empires.models.resources;

import org.softuni.empires.contracts.Resource;

public class ResourceImpl implements Resource {
    private final ResourceType resourceType;
    private int quantity;
    
    public ResourceImpl(ResourceType resourceType, int quantity) {
        this.resourceType = resourceType;
        this.setQuantity(quantity);
    }
    
    @Override
    public int getQuantity() {
        return this.quantity;
    }
    
    private void setQuantity(int quantity) {
        if (quantity < 0) {
            throw new IllegalArgumentException("Quantity cannot be negative.");
        }
        
        this.quantity = quantity;
    }

    @Override
    public ResourceType getResourceType() {
        return this.resourceType;
    }
}