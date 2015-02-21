package models.products;

public abstract class ElectronicsProduct extends Product {
    private int guaranteePeriod;

    protected ElectronicsProduct(
            String name,
            double price,
            int quantity,
            AgeRestriction ageRestriction,
            int guaranteePeriod) {
        super(name, price, quantity, ageRestriction);
        this.setGuaranteePeriod(guaranteePeriod);
    }

    public int getGuaranteePeriod() {
        return this.guaranteePeriod;
    }

    public void setGuaranteePeriod(int guaranteePeriod) {
        if (guaranteePeriod < 0) {
            throw new IllegalArgumentException(
                    "The guarantee period cannot be negative.");
        }

        this.guaranteePeriod = guaranteePeriod;
    }
}
