package models.products;

import interfaces.Buyable;

public abstract class Product implements Buyable {
    private String name;
    private double price;
    private int quantity;
    private AgeRestriction ageRestriction;

    protected Product(String name, double price, int quantity, AgeRestriction ageRestriction) {
        this.setName(name);
        this.setPrice(price);
        this.setQuantity(quantity);
        this.setAgeRestriction(ageRestriction);
    }

    public String getName() {
        return this.name;
    }

    public void setName(String name) {
        if (name.isEmpty() || name == null) {
            throw new IllegalArgumentException(
                    "The product name cannot be empty.");
        }

        if (name.length() < 2) {
            throw new IllegalArgumentException(
                    "The product name should be at least two symbols long.");
        }

        this.name = name;
    }

    @Override
    public double getPrice() {
        return this.price;
    }

    public void setPrice(double price) {
        if (price <= 0) {
            throw new IllegalArgumentException(
                    "The price of the product should be greater than zero.");
        }

        this.price = price;
    }

    public int getQuantity() {
        return this.quantity;
    }

    public void setQuantity(int quantity) {
        if (quantity < 0) {
            throw new IllegalArgumentException(
                    "The quantity of the product cannot be negative.");
        }

        this.quantity = quantity;
    }

    public AgeRestriction getAgeRestriction() {
        return this.ageRestriction;
    }

    public void setAgeRestriction(AgeRestriction ageRestriction) {
        this.ageRestriction = ageRestriction;
    }
}
