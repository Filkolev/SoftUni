using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

class Computer : IComparable
{
    /*----- FIELDS -----*/

    private string name;
    private List<Component> components;


    /*----- PROPERTIES -----*/

    public string Name
    {
        get { return this.name; }
        set
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("name", "Name cannot be empty.");
            }

            this.name = value;
        }
    }

    public decimal Price
    {
        get
        {
            return CalcComputerPrice(this);
        }
    }

    public List<Component> Components
    {
        get { return this.components; }
        set
        {
            if (value.Count == 0)
            {
                throw new ArgumentNullException("components", "Computer should contain at least one component.");
            }

            this.components = value;
        }
    }


    /*----- CONSTRUCTORS -----*/

    public Computer(string name, List<Component> components)
    {
        this.Name = name;
        this.Components = components;
    }


    /*----- METHODS -----*/

    public int CompareTo(object obj)
    {
        Computer computer = (Computer)obj;
        return this.Price.CompareTo(computer.Price);
    }

    public static decimal CalcComputerPrice(Computer computer)
    {
        var components = computer.Components;

        decimal price = 0;

        foreach (var component in components)
        {
            price += component.Price;
        }

        return price;
    }

    public void AddComponent(Component component)
    {
        var list = this.Components;
        list.Add(component);
        this.Components = list;
    }

    public override string ToString()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("bg");

        string description = new string('-', 50) + "\r\n";
        description += "COMPUTER DESCRIPTION\r\n";
        description += new string('-', 50) + "\r\n";
        description += "Name: " + this.Name + "\r\n";
        description += "Components:\r\n";

        foreach (var component in this.Components)
        {
            description += String.Format(
                "\t{0}{2} ({1:c2})\r\n",
                component.Name, component.Price, String.IsNullOrWhiteSpace(component.Details) ? "" : ": " + component.Details);
        }

        description += String.Format("Total price: {0:c2}\r\n", this.Price);
        description += new string('-', 50) + "\r\n";

        return description;
    }
}