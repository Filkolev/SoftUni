package org.softuni.empires.core.factories;

import org.softuni.empires.contracts.Unit;
import org.softuni.empires.contracts.UnitFactory;
import org.softuni.empires.models.units.Archer;
import org.softuni.empires.models.units.Swordsman;

public class UnitFactoryImpl implements UnitFactory {

    @Override
    public Unit createUnit(String unitType) {
        switch (unitType) {
            case "Archer":
                return new Archer();
            case "Swordsman":
                return new Swordsman();
            default:
                throw new UnsupportedOperationException("Unsupported unit type.");
        }
    }
}