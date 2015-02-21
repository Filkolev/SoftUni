package models.products;

public class Appliance extends ElectronicsProduct {
    public static final int DEFAULT_GUARANTEE_PERIOD = 6;

    public Appliance(
            String name,
            double price,
            int quantity,
            AgeRestriction ageRestriction) {
        super(name, price, quantity, ageRestriction, DEFAULT_GUARANTEE_PERIOD);
    }

    @Override
    public double getPrice() {
        double price = super.getPrice();

        if (this.getQuantity() < 50) {
            price *= 1.05;
        }

        return price;
    }
}
