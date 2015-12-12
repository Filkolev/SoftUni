package empires.models.buildings;

import empires.contracts.Building;
import empires.contracts.Resource;
import empires.contracts.ResourceFactory;
import empires.contracts.Unit;
import empires.contracts.UnitFactory;

public abstract class AbstractBuilding implements Building {

    private static final int PRODUCTION_START = 1;
    private int cyclesCount = 0;      

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
        if (!this.canProduceResource()) {
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
        if (!this.canProduceUnit()) {
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
    public boolean canProduceUnit() {
        boolean hasProducedUnit = this.cyclesCount > PRODUCTION_START
                && (this.cyclesCount - PRODUCTION_START) % this.unitProductionCycleLength == 0;

        return hasProducedUnit;
    }

    @Override
    public boolean canProduceResource() {
        boolean hasProducedResources = this.cyclesCount > PRODUCTION_START
                && (this.cyclesCount - PRODUCTION_START) % this.resourceProductionCycleLength == 0;

        return hasProducedResources;
    }

    @Override
    public void update() {
        this.cyclesCount++;
    }

    @Override
    public String toString() {
        int turnsUntilUnit = this.unitProductionCycleLength - ((this.cyclesCount - PRODUCTION_START) % this.unitProductionCycleLength);
        int turnsUntilResource = this.resourceProductionCycleLength - ((this.cyclesCount - PRODUCTION_START) % this.resourceProductionCycleLength);

        String result = String.format(
                "--%s: %d turns (%d turns until %s, %d turns until %s)",
                this.getClass().getSimpleName(),
                this.cyclesCount - PRODUCTION_START,
                turnsUntilUnit,
                this.unitType,
                turnsUntilResource,
                this.resourceType);

        return result;
    }
}