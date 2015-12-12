package empires.models.buildings;

import empires.contracts.ResourceFactory;
import empires.contracts.UnitFactory;

public class Archery extends AbstractBuilding {

    private static final String ARCHERY_UNIT_TYPE = "Archer";
    private static final int ARCHERY_UNIT_PRODUCTION_CYCLE = 3;
    
    private static final String ARCHERY_RESOURCE_TYPE = "Gold";
    private static final int ARCHERY_RESOURCE_QUANTITY = 5;
    private static final int ARCHERY_RESOURCE_PRODUCTION_CYCLE = 2;
    
    public Archery(UnitFactory unitFactory, ResourceFactory resourceFactory) {
        super(
                ARCHERY_UNIT_TYPE, 
                ARCHERY_UNIT_PRODUCTION_CYCLE, 
                unitFactory, 
                ARCHERY_RESOURCE_TYPE, 
                ARCHERY_RESOURCE_QUANTITY, 
                ARCHERY_RESOURCE_PRODUCTION_CYCLE, 
                resourceFactory);
    }    
}