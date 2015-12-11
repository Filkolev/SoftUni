package org.softuni.empires.core.factories;

import org.softuni.empires.contracts.Building;
import org.softuni.empires.contracts.BuildingFactory;
import org.softuni.empires.contracts.ResourceFactory;
import org.softuni.empires.contracts.UnitFactory;
import org.softuni.empires.models.buildings.Archery;
import org.softuni.empires.models.buildings.Barracks;

public class BuildingFactoryImpl implements BuildingFactory {

    @Override
    public Building createBuilding(String buildingType, UnitFactory unitFactory, ResourceFactory resourceFactory) {
        switch(buildingType) {
            case "barracks":
                return new Barracks(unitFactory, resourceFactory);
            case "archery":
                return new Archery(unitFactory, resourceFactory);
            default:
                throw new UnsupportedOperationException("Unknown building type");
        }
    }    
}