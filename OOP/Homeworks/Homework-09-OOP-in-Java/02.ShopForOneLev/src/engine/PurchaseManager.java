package engine;

import interfaces.Expirable;
import models.Customer;
import models.products.AgeRestriction;
import models.products.Product;

import java.security.InvalidParameterException;
import java.time.LocalDate;

public final class PurchaseManager {
    private PurchaseManager(){

    }

    public static void processPurchase(Product product, Customer customer) {
        validatePurchase(product, customer);

        customer.setBalance(customer.getBalance() - product.getPrice());
        product.setQuantity(product.getQuantity() - 1);
    }

    private static void validatePurchase(Product product, Customer customer) {
        if (!isProductAvailable(product)) {
            throw new InvalidParameterException(
                    "The product is out of stock!");
        }

        if (hasProductExpired(product)) {
            throw new InvalidParameterException("The product has expired!");
        }

        if (!hasEnoughMoney(product, customer)) {
            throw new InvalidParameterException(
                    "You do not have enough money to buy this product!");
        }

        if (isRestricted(product, customer)) {
            throw new IllegalArgumentException(
                    "You are too young to buy this product!");
        }
    }

    private static boolean isProductAvailable(Product product) {
        if (product.getQuantity() <= 0) {
            return false;
        }

        return true;
    }

    private static boolean hasProductExpired(Product product) {
        if (product instanceof Expirable) {
            Expirable productAsExpirable = (Expirable)product;

            if (productAsExpirable.getExpirationDate().isBefore(LocalDate.now())) {
                return true;
            }
        }

        return false;
    }

    private static boolean hasEnoughMoney(Product product, Customer customer) {
        if (customer.getBalance() < product.getPrice()) {
            return false;
        }

        return true;
    }

    private static boolean isRestricted(Product product, Customer customer) {
        if (product.getAgeRestriction() == AgeRestriction.NONE) {
            return false;
        }

        if (product.getAgeRestriction() == AgeRestriction.TEENAGER &&
                customer.getAge() < 13) {
            return true;
        }

        if (product.getAgeRestriction() == AgeRestriction.ADULT &&
                customer.getAge() < 18) {
            return true;
        }

        return false;
    }
}
