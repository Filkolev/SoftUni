package empires.models.buildings;

import empires.contracts.ResourceFactory;
import empires.contracts.UnitFactory;

public class Barracks extends AbstractBuilding {

    private static final String BARRACKS_UNIT_TYPE = "Swordsman";
    private static final int BARRACKS_UNIT_PRODUCTION_CYCLE = 4;
    
    private static final String BARRACKS_RESOURCE_TYPE = "Steel";  
    private static final int BARRACKS_RESOURCE_QUANTITY = 10;
    private static final int BARRACKS_RESOURCE_PRODUCTION_CYCLE = 3;

    public Barracks(UnitFactory unitFactory, ResourceFactory resourceFactory) {
        super(
                BARRACKS_UNIT_TYPE, 
                BARRACKS_UNIT_PRODUCTION_CYCLE, 
                unitFactory, 
                BARRACKS_RESOURCE_TYPE, 
                BARRACKS_RESOURCE_QUANTITY, 
                BARRACKS_RESOURCE_PRODUCTION_CYCLE, 
                resourceFactory);
    }       
}