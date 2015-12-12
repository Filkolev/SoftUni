package empires.core;

import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.List;

import empires.contracts.Building;
import empires.contracts.BuildingFactory;
import empires.contracts.Engine;
import empires.contracts.InputReader;
import empires.contracts.OutputWriter;
import empires.contracts.Resource;
import empires.contracts.ResourceFactory;
import empires.contracts.Unit;
import empires.contracts.UnitFactory;
import empires.contracts.Updateable;
import empires.models.resources.ResourceType;

public class EmpiresEngine implements Engine, Updateable {

    private final InputReader reader;
    private final OutputWriter writer;
    private final ResourceFactory resourceFactory;
    private final UnitFactory unitFactory;
    private final BuildingFactory buildingFactory;

    private final List<Building> buildings = new ArrayList<>();
    private final List<Updateable> updateableEntities = new ArrayList<>();
    private final LinkedHashMap<String, Integer> units = new LinkedHashMap<>();
    private final LinkedHashMap<String, Integer> resources = new LinkedHashMap<>();

    private boolean isRunning = true;

    public EmpiresEngine(
            InputReader reader,
            OutputWriter writer,
            ResourceFactory resourceFactory,
            UnitFactory unitFactory,
            BuildingFactory buildingFactory) {
        this.reader = reader;
        this.writer = writer;
        this.resourceFactory = resourceFactory;
        this.unitFactory = unitFactory;
        this.buildingFactory = buildingFactory;

        this.initResources();
    }

    protected List<Building> getBuildings() {
        return this.buildings;
    }
    
    protected List<Updateable> getUpdateableEntities() {
        return this.updateableEntities;
    }
    
    protected LinkedHashMap<String, Integer> getUnits() {
        return this.units;
    }
    
    protected LinkedHashMap<String, Integer> getResources() {
        return this.resources;
    }

    @Override
    public void run() {
        while (this.isRunning) {
            String[] inputTokens = this.reader.readLine().split(" ");
            String commandName = inputTokens[0];

            this.executeCommand(commandName, inputTokens);
            this.update();
        }
    }

    @Override
    public void executeCommand(String commandName, String[] inputTokens) {
        switch (commandName) {
            case "armistice":
                this.isRunning = false;
                break;
            case "build":
                this.executeBuildCommand(inputTokens);
                break;
            case "empire-status":
                this.executeEmpireReportCommand();
                break;
        }
    }
    
    @Override
    public void update() {
        this.updateableEntities.stream().forEach(Updateable::update);

        for (Building building : buildings) {
            if (building.canProduceUnit()) {
                this.addUnit(building);
            }

            if (building.canProduceResource()) {
                this.addResource(building);
            }
        }
    }

    private void executeBuildCommand(String[] inputTokens) {
        String buildingType = inputTokens[1];
        Building building = this.buildingFactory.createBuilding(buildingType, this.unitFactory, this.resourceFactory);

        this.buildings.add(building);
        this.updateableEntities.add(building);
    }

    private void executeEmpireReportCommand() {
        StringBuilder output = new StringBuilder();

        output.append("Treasury:\n");
        this.resources.keySet().stream().forEach((resourceName) -> {
            output.append(String.format("--%s: %d%n", resourceName, this.resources.get(resourceName)));
        });

        output.append("Buildings:\n");
        if (this.buildings.isEmpty()) {
            output.append("N/A\n");
        } else {
            this.buildings.stream().forEach((building) -> {
                output.append(String.format("%s%n", building.toString()));
            });
        }

        output.append("Units:\n");
        if (this.units.isEmpty()) {
            output.append("N/A");
        } else {
            this.units.keySet().stream().forEach((unitType) -> {
                output.append(String.format("--%s: %d%n", unitType, this.units.get(unitType)));
            });
        }

        this.writer.writeLine(output.toString().trim());
    }    

    private void addResource(Building building) {
        Resource resource = building.produceResource();
        String resourceName = ResourceType.toString(resource.getResourceType());

        this.resources.put(
                resourceName,
                this.resources.get(resourceName) + resource.getQuantity());
    }

    private void addUnit(Building building) {
        Unit unit = building.produceUnit();
        String unitType = unit.getClass().getSimpleName();

        this.units.putIfAbsent(unitType, 0);
        this.units.put(unitType, this.units.get(unitType) + 1);
    }

    private void initResources() {
        for (ResourceType resourceType : ResourceType.values()) {
            this.resources.put(ResourceType.toString(resourceType), 0);
        }
    }
}
