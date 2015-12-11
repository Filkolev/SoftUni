package org.softuni.empires.core;

import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.List;
import org.softuni.empires.contracts.Building;
import org.softuni.empires.contracts.BuildingFactory;
import org.softuni.empires.contracts.Engine;
import org.softuni.empires.contracts.InputReader;
import org.softuni.empires.contracts.OutputWriter;
import org.softuni.empires.contracts.Resource;
import org.softuni.empires.contracts.ResourceFactory;
import org.softuni.empires.contracts.Unit;
import org.softuni.empires.contracts.UnitFactory;
import org.softuni.empires.contracts.Updateable;
import org.softuni.empires.models.resources.ResourceType;

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
        
        for (ResourceType resourceType : ResourceType.values()) {
            this.resources.put(ResourceType.toString(resourceType), 0);
        }
    }

    @Override
    public void Run() {
        while (true) {
            String[] inputTokens = this.reader.ReadLine().split(" ");
            String commandName = inputTokens[0];

            switch (commandName) {
                case "armistice":
                    return;
                case "build":
                    this.ExecuteBuildCommand(inputTokens);
                    break;
                case "empire-status":
                    this.ExecuteEmpireReportCommand();
                    break;
            }

            this.update();
        }
    }

    private void ExecuteBuildCommand(String[] inputTokens) {
        String buildingType = inputTokens[1];
        Building building = this.buildingFactory.createBuilding(buildingType, this.unitFactory, this.resourceFactory);

        this.buildings.add(building);
        this.updateableEntities.add(building);
    }

    private void ExecuteEmpireReportCommand() {
        StringBuilder output = new StringBuilder();

        output.append("Resources:\n");
        this.resources.keySet().stream().forEach((resourceName) -> {
            output.append(String.format("--%s: %d%n", resourceName, this.resources.get(resourceName)));
        });

        output.append("Buildings:\n");
        this.buildings.stream().forEach((building) -> {
            output.append(String.format("%s%n", building.toString()));
        });

        output.append("Units:\n");
        if (this.units.isEmpty()) {
            output.append("N/A");
        } else {
            this.units.keySet().stream().forEach((unitType) -> {
                output.append(String.format("--%s: %d%n", unitType, this.units.get(unitType)));
            });
        }

        this.writer.WriteLine(output.toString().trim());
    }

    @Override
    public void update() {
        this.updateableEntities.stream().forEach(Updateable::update);

        for (Building building : buildings) {
            if (building.hasProducedUnit()) {
                addUnit(building);
            }

            if (building.hasProducedResources()) {
                addResource(building);
            }
        }
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
}
