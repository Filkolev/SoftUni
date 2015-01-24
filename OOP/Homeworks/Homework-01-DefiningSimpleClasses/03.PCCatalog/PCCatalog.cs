using System;
using System.Collections.Generic;
using System.Text;

class PCCatalog
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;

        List<Component> components = new List<Component>();
        components.Add(new Component("Motherboard", 90));
        components.Add(new Component("CPU", 120.45m));
        components.Add(new Component("RAM", 45.50m, "8 GB"));
        // components.Add(new Component(" ", 12));   // Empty name => Exception
        // components.Add(new Component("HDD", -1.1m));  // Negative price => Exception

        Computer pc = new Computer("HP", components);
        Console.WriteLine(pc);
        pc.AddComponent(new Component("added later", 1)); // Using method that allows addition of components
        Console.WriteLine(pc);

        // List<Component> emptyComponentsList = new List<Component>();
        // Computer pcWithoutComponents = new Computer("Ooops", emptyComponentsList); // Empty components list on creation => Exception

        List<Computer> catalog = new List<Computer>();
        catalog.Add(pc);

        List<Component> componentsList4 = new List<Component>();
        componentsList4.Add(new Component("GPU", 1125.5m));
        componentsList4.Add(new Component("CPU", 900));

        catalog.Add(new Computer("Expensive", componentsList4));

        List<Component> componentsList2 = new List<Component>();
        componentsList2.Add(new Component("DVD", 15.99m));
        componentsList2.Add(new Component("GPU", 255.1m));

        catalog.Add(new Computer("Cheap", componentsList2));

        List<Component> componentsList3 = new List<Component>();
        componentsList3.Add(new Component("RAM", 52.19m));
        componentsList3.Add(new Component("SSD", 550));

        catalog.Add(new Computer("Average", componentsList3));

        catalog.Sort(); // Icomparable interface implemented on Computer class

        foreach (var computer in catalog)
        {
            Console.WriteLine(computer);
        }
    }
}
