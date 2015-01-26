using System;

class Battery
{
    private string description;
    private double batteryLife;

    public string Description
    {
        get { return this.description; }
        set
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("description", "Battery info cannot be empty.");
            }

            this.description = value;
        }
    }

    public double BatteryLife
    {
        get { return this.batteryLife; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("batteryLife", "Battery life cannot be negative.");
            }

            this.batteryLife = value;
        }
    }

    public Battery(string description, double batteryLife)
    {
        this.Description = description;
        this.BatteryLife = batteryLife;
    }
}
