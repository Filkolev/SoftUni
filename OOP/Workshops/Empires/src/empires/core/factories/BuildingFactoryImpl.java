package empires.core.factories;

import empires.contracts.Building;
import empires.contracts.BuildingFactory;
import empires.contracts.ResourceFactory;
import empires.contracts.UnitFactory;
import empires.models.buildings.Archery;
import empires.models.buildings.Barracks;

public class BuildingFactoryImpl implements BuildingFactory {

    @Override
    public Building createBuilding(String buildingType, UnitFactory unitFactory, ResourceFactory resourceFactory) {
        switch (buildingType) {
            case "barracks":
                return new Barracks(unitFactory, resourceFactory);
            case "archery":
                return new Archery(unitFactory, resourceFactory);
            default:
                throw new UnsupportedOperationException("Unknown building type");
        }
    }
}