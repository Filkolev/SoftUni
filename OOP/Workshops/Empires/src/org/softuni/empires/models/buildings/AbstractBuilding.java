package org.softuni.empires.models.buildings;

import org.softuni.empires.contracts.Building;
import org.softuni.empires.contracts.Resource;
import org.softuni.empires.contracts.ResourceFactory;
import org.softuni.empires.contracts.Unit;
import org.softuni.empires.contracts.UnitFactory;

public abstract class AbstractBuilding implements Building {

    private int cyclesCount = -1;

    private String resourceType;
    private int resourceQuantiy;
    private int resourceProductionCycleLength;
    private final ResourceFactory resourceFactory;

    private String unitType;
    private int unitProductionCycleLength;
    private final UnitFactory unitFactory;

    protected AbstractBuilding(
            String unitType,
            int unitProductionCycleLength,
            UnitFactory unitFactory,
            String resourceType,
            int resourceQuantity,
            int resourceProductionCycleLength,
            ResourceFactory resourceFactory) {
        this.setUnitType(unitType);
        this.setUnitProductionCycleLength(unitProductionCycleLength);
        this.unitFactory = unitFactory;
        this.setResourceType(resourceType);
        this.setResourceQuantity(resourceQuantity);
        this.setResourceProductionCycleLength(resourceProductionCycleLength);
        this.resourceFactory = resourceFactory;
    }

    @Override
    public Resource produceResource() {
        if (!this.hasProducedResources()) {
            throw new UnsupportedOperationException("Building cannot produce a resource at this time.");
        }

        Resource resource = this.resourceFactory.createResource(this.resourceType, this.resourceQuantiy);

        return resource;
    }

    private void setResourceType(String resource) {
        if (resource == null || resource.isEmpty()) {
            throw new IllegalArgumentException("Resource cannot be empty.");
        }

        this.resourceType = resource;
    }

    private void setResourceQuantity(int quantity) {
        if (quantity < 0) {
            throw new IllegalArgumentException();
        }

        this.resourceQuantiy = quantity;
    }

    private void setResourceProductionCycleLength(int cycleLength) {
        if (cycleLength <= 0) {
            throw new IllegalArgumentException("cycleLength should be positive.");
        }

        this.resourceProductionCycleLength = cycleLength;
    }

    @Override
    public Unit produceUnit() {
        if (!this.hasProducedUnit()) {
            throw new UnsupportedOperationException("Building cannot produce a unit at this time.");
        }

        Unit unit = this.unitFactory.createUnit(this.unitType);

        return unit;
    }

    private void setUnitType(String unitType) {
        if (unitType == null || unitType.isEmpty()) {
            throw new IllegalArgumentException();
        }

        this.unitType = unitType;
    }

    private void setUnitProductionCycleLength(int cycleLength) {
        if (cycleLength <= 0) {
            throw new IllegalArgumentException("cycleLength should be positive.");
        }

        this.unitProductionCycleLength = cycleLength;
    }

    @Override
    public boolean hasProducedUnit() {
        boolean hasProducedUnit = this.cyclesCount > 0
                && this.cyclesCount % this.unitProductionCycleLength == 0;

        return hasProducedUnit;
    }

    @Override
    public boolean hasProducedResources() {
        boolean hasProducedResources = this.cyclesCount > 0
                && this.cyclesCount % this.resourceProductionCycleLength == 0;

        return hasProducedResources;
    }

    @Override
    public void update() {
        this.cyclesCount++;
    }

    @Override
    public String toString() {
        int turnsUntilUnit = this.unitProductionCycleLength - (this.cyclesCount % this.unitProductionCycleLength);
        int turnsUntilResource = this.resourceProductionCycleLength - (this.cyclesCount % this.resourceProductionCycleLength);

        String result = String.format(
                "--%s: %d turns (%d turns until %s, %d turns until %s)",
                this.getClass().getSimpleName(),
                this.cyclesCount,
                turnsUntilUnit,
                this.unitType,
                turnsUntilResource,
                this.resourceType);

        return result;
    }
}
