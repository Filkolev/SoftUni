import engine.PurchaseManager;
import interfaces.Expirable;
import models.Customer;
import models.products.*;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

public class ShopDemo {
    public static void main(String[] args) {
        FoodProduct cigars = new FoodProduct(
                "420 Blaze it fgt",
                6.90,
                1,
                AgeRestriction.ADULT,
                LocalDate.now().plusDays(1));

        Customer pecata = new Customer("Pecata", 17, 30.00);
        Customer gopeto = new Customer("Gopeto", 18, 0.44);
        Customer pesho = new Customer("Pesho", 21, 50);

        try {
            PurchaseManager.processPurchase(cigars, pecata);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }

        try {
            PurchaseManager.processPurchase(cigars, gopeto);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }

        try {
            PurchaseManager.processPurchase(cigars, pesho);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }

        try {
            PurchaseManager.processPurchase(cigars, pesho);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }

        FoodProduct expired = new FoodProduct(
                "expired",
                0.1,
                20,
                AgeRestriction.NONE,
                LocalDate.now().minusDays(2));

        try {
            PurchaseManager.processPurchase(expired, pesho);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }

        System.out.println();

        ArrayList<Product> products = new ArrayList<>();
        products.add(cigars);
        products.add(expired);
        products.add(new Computer("Lenovo", 1200, 120, AgeRestriction.TEENAGER));
        products.add(new Appliance("Mouse", 19.99, 2500, AgeRestriction.NONE));
        products.add(new FoodProduct("soon", 10, 10, AgeRestriction.NONE, LocalDate.now().plusDays(18)));
        products.add(new Computer("Asus", 2000, 1100, AgeRestriction.ADULT));

        // Checks all products, including expired ones
        System.out.println("The product which expires first is:");
        String expiresFirst = products
                .stream()
                .filter(product -> product instanceof Expirable)
                .map(product -> (Expirable) product)
                .sorted((p1, p2) -> p1.getExpirationDate().compareTo(p2.getExpirationDate()))
                .findFirst()
                .map(product -> ((Product) product).getName())
                .get();

        System.out.println(expiresFirst);
        System.out.println();

        System.out.println("Adult products: ");
        List<Product> adultProducts = products
                .stream()
                .filter(product -> product.getAgeRestriction() == AgeRestriction.ADULT)
                .sorted((p1, p2) -> Double.compare(p1.getPrice(), p2.getPrice()))
                .collect(Collectors.toList());

        for (Product adultProduct : adultProducts) {
            System.out.println(adultProduct.getName() + " - " + adultProduct.getPrice());
        }
    }
}
