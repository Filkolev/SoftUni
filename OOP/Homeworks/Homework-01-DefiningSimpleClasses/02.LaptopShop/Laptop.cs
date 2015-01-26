using System;

class Laptop
{
    /*----- FIELDS -----*/

    private string model;
    private decimal price;


    /*----- PROPERTIES -----*/

    public string Model
    {
        get { return this.model; }
        set
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("model", "Model info cannot be empty.");
            }

            this.model = value;
        }
    }

    public string Manufacturer { get; set; }

    public string Processor { get; set; }

    public string RAM { get; set; }

    public string GPU { get; set; }

    public string HDD { get; set; }

    public string Display { get; set; }

    public Battery LaptopBattery { get; set; }

    public decimal Price
    {
        get { return this.price; }
        set
        {
            if (value < 0.0m)
            {
                throw new ArgumentOutOfRangeException("price", "Price cannot be negative.");
            }

            this.price = value;
        }
    }


    /*----- CONSTRUCTORS -----*/

    public Laptop(string model, decimal price)
    {
        this.Model = model;
        this.Price = price;
    }

    public Laptop(string model, decimal price, string manufacturer)
        : this(model, price)
    {
        this.Manufacturer = manufacturer;
    }

    public Laptop(string model, decimal price, string manufacturer, Battery laptopBattery)
        : this(model, price, manufacturer)
    {
        this.LaptopBattery = laptopBattery;
    }

    public Laptop(string model, decimal price, string manufacturer, string processor, string ram, string gpu, string hdd)
        : this(model, price, manufacturer)
    {
        this.Processor = processor;
        this.RAM = ram;
        this.GPU = gpu;
        this.HDD = hdd;
    }

    public Laptop(string model, decimal price, string manufacturer, string processor, string ram, string gpu, string hdd, Battery laptopBattery)
        : this(model, price, manufacturer, processor, ram, gpu, hdd)
    {
        this.LaptopBattery = laptopBattery;
    }

    public Laptop(string model, decimal price, string manufacturer, string processor, string ram, string gpu, string hdd, Battery laptopBattery, string display)
        : this(model, price, manufacturer, processor, ram, gpu, hdd, laptopBattery)
    {
        this.Display = display;
    }


    /*----- METHODS -----*/

    public override string ToString()
    {
        string description = new string('-', 50) + "\r\n";
        description += String.Format("{0, 35}", "LAPTOP DESCRIPTION") + "\r\n";
        description += new string('-', 50) + "\r\n";

        description += string.Format("{0, -15}", "| MODEL") + String.Format("| {0, 31}", this.Model) + " |\r\n";
        description += new string('-', 50) + "\r\n";

        if (!String.IsNullOrWhiteSpace(this.Manufacturer))
        {
            description += string.Format("{0, -15}", "| MANUFACTURER") + String.Format("| {0, 31}", this.Manufacturer) + " |\r\n";
            description += new string('-', 50) + "\r\n";
        }

        if (!String.IsNullOrWhiteSpace(this.Processor))
        {
            description += string.Format("{0, -15}", "| PROCESSOR") + String.Format("| {0, 31}", this.Processor) + " |\r\n";
            description += new string('-', 50) + "\r\n";
        }

        if (!String.IsNullOrWhiteSpace(this.RAM))
        {
            description += string.Format("{0, -15}", "| RAM") + String.Format("| {0, 31}", this.RAM) + " |\r\n";
            description += new string('-', 50) + "\r\n";
        }

        if (!String.IsNullOrWhiteSpace(this.GPU))
        {
            description += string.Format("{0, -15}", "| GPU") + String.Format("| {0, 31}", this.GPU) + " |\r\n";
            description += new string('-', 50) + "\r\n";
        }

        if (!String.IsNullOrWhiteSpace(this.HDD))
        {
            description += string.Format("{0, -15}", "| HDD") + String.Format("| {0, 31}", this.HDD) + " |\r\n";
            description += new string('-', 50) + "\r\n";
        }

        if (!String.IsNullOrWhiteSpace(this.Display))
        {
            description += string.Format("{0, -15}", "| DISPLAY") + String.Format("| {0, 31}", this.Display) + " |\r\n";
            description += new string('-', 50) + "\r\n";
        }

        if (this.LaptopBattery != null)
        {
            description += string.Format("{0, -15}", "| BATTERY") + String.Format("| {0, 31}", this.LaptopBattery.Description) + " |\r\n";
            description += new string('-', 50) + "\r\n";
            description += string.Format("{0, -15}", "| BATTERY LIFE") + String.Format("| {0, 25:f1} hours", this.LaptopBattery.BatteryLife) + " |\r\n";
            description += new string('-', 50) + "\r\n";
        }

        description += string.Format("{0, -15}", "| PRICE") + String.Format("| {0, 31:c2}", this.Price) + " |\r\n";
        description += new string('-', 50) + "\r\n\r\n";

        return description;
    }
}
