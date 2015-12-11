package org.softuni.empires;

import org.softuni.empires.contracts.BuildingFactory;
import org.softuni.empires.contracts.Engine;
import org.softuni.empires.contracts.InputReader;
import org.softuni.empires.contracts.OutputWriter;
import org.softuni.empires.contracts.ResourceFactory;
import org.softuni.empires.contracts.UnitFactory;
import org.softuni.empires.core.EmpiresEngine;
import org.softuni.empires.core.factories.BuildingFactoryImpl;
import org.softuni.empires.core.factories.ResourceFactoryImpl;
import org.softuni.empires.core.factories.UnitFactoryImpl;
import org.softuni.empires.io.ConsoleInputReader;
import org.softuni.empires.io.ConsoleOutputWriter;

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