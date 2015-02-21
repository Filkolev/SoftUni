package models.products;

import interfaces.Expirable;

import java.time.LocalDate;

public class FoodProduct extends Product implements Expirable {
    private LocalDate expirationDate;

    public FoodProduct(
            String name,
            double price,
            int quantity,
            AgeRestriction ageRestriction,
            LocalDate expirationDate) {
        super(name, price, quantity, ageRestriction);
        this.setExpirationDate(expirationDate);
    }

    @Override
    public double getPrice() {
        double price = super.getPrice();

        if (this.isDiscounted()) {
            price *= 0.7;
        }

        return price;
    }

    @Override
    public LocalDate getExpirationDate() {
        return this.expirationDate;
    }

    public void setExpirationDate(LocalDate expirationDate) {
        this.expirationDate = expirationDate;
    }

    private boolean isDiscounted() {
        LocalDate today = LocalDate.now();
        return today.plusDays(15).isAfter(expirationDate);
    }
}
