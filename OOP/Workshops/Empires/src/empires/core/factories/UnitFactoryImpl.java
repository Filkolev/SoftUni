package empires.core.factories;

import empires.contracts.Unit;
import empires.contracts.UnitFactory;
import empires.models.units.Archer;
import empires.models.units.Swordsman;

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