package models.products;

public class Computer extends ElectronicsProduct {
    public static final int DEFAULT_GUARANTEE_PERIOD = 24;

    public Computer(
            String name,
            double price,
            int quantity,
            AgeRestriction ageRestriction) {
        super(name, price, quantity, ageRestriction, DEFAULT_GUARANTEE_PERIOD);
    }

    @Override
    public double getPrice() {
        double price = super.getPrice();

        if (this.getQuantity() > 1000) {
            price *= 0.95;
        }

        return price;
    }
}
