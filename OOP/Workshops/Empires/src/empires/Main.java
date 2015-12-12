package empires;

import empires.contracts.BuildingFactory;
import empires.contracts.Engine;
import empires.contracts.InputReader;
import empires.contracts.OutputWriter;
import empires.contracts.ResourceFactory;
import empires.contracts.UnitFactory;
import empires.core.EmpiresEngine;
import empires.core.factories.BuildingFactoryImpl;
import empires.core.factories.ResourceFactoryImpl;
import empires.core.factories.UnitFactoryImpl;
import empires.io.ConsoleInputReader;
import empires.io.ConsoleOutputWriter;

public class Main {

    public static void main(String[] args) {
        InputReader reader = new ConsoleInputReader();
        OutputWriter writer = new ConsoleOutputWriter();
        ResourceFactory resourceFactory = new ResourceFactoryImpl();
        UnitFactory unitFactory = new UnitFactoryImpl();
        BuildingFactory buildingFactory = new BuildingFactoryImpl();

        Engine engine = new EmpiresEngine(reader, writer, resourceFactory, unitFactory, buildingFactory);
        engine.run();
    }
}