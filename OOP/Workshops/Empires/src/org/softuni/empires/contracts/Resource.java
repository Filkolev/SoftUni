package org.softuni.empires.contracts;

import org.softuni.empires.models.resources.ResourceType;

public interface Resource {

    public int getQuantity();

    public ResourceType getResourceType();
}