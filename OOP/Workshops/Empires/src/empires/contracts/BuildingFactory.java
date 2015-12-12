package empires.contracts;

public interface BuildingFactory {

    public Building createBuilding(String buildingType, UnitFactory unitFactory, ResourceFactory resourceFactory);
}