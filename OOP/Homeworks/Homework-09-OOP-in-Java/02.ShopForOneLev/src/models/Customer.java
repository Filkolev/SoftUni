package models;

public class Customer {
    private String name;
    private int age;
    private double balance;

    public Customer(String name, int age, double balance) {
        this.setName(name);
        this.setAge(age);
        this.setBalance(balance);
    }

    public String getName() {
        return this.name;
    }

    public void setName(String name) {
        if (name.isEmpty() || name == null) {
            throw new IllegalArgumentException(
                    "The customer's name cannot be empty.");
        }

        if (name.length() < 2) {
            throw new IllegalArgumentException(
                    "The customer's name should be at least two symbols long.");
        }

        this.name = name;
    }

    public int getAge() {
        return this.age;
    }

    public void setAge(int age) {
        if (age < 0 || 100 < age) {
            throw new IllegalArgumentException(
                    "Age should be in the range [0 ... 100].");
        }

        this.age = age;
    }

    public double getBalance() {
        return this.balance;
    }

    public void setBalance(double balance) {
        if (balance < 0) {
            throw new IllegalArgumentException(
                    "The customer's balance cannot be negative.");
        }

        this.balance = balance;
    }
}
