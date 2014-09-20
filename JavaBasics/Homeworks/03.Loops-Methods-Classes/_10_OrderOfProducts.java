import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.math.BigDecimal;
import java.util.ArrayList;

// Correct output for the first example is 70.6, not 70.5, checked with a calculator

/* Create a class Product to hold products, which have name (string) 
 * and price (decimal number). Read from a text file named "Products.txt" 
 * a list of product with prices and keep them in a list of products. Each 
 * product will be in format name + space + price. You should hold the products 
 * in objects of class Product. Read from a text file named "Order.txt" an order 
 * of products with quantities. Each order line will be in format product + 
 * space + quantity. Calculate and print in a text file "Output.txt" the total 
 * price of the order. Ensure you close correctly all used resources. */

public class _10_OrderOfProducts {
	public static void main(String[] args) {
		try {
			
			BufferedReader orderReader = new BufferedReader(new FileReader("_10_Order.txt"));
			BufferedReader priceReader = new BufferedReader(new FileReader("_10_Products.txt"));
			
			ArrayList<Product> priceList = new ArrayList<Product>();
			
			String priceEntry = priceReader.readLine();
			
			while (priceEntry != null) {
				String[] priceSplit = priceEntry.split(" ");
				Product currentEntry = new Product(priceSplit[0], new BigDecimal(priceSplit[1]));
				priceList.add(currentEntry);
				priceEntry = priceReader.readLine();
			}
			
			String orderEntry = orderReader.readLine();
			
			BigDecimal totalPrice = new BigDecimal(0);
			
			while (orderEntry != null) {
				String[] orderSplit = orderEntry.split(" ");
				
				for (Product priceListing : priceList) {
					if (priceListing.getProductName().equals(orderSplit[1])) {
						BigDecimal quantity = new BigDecimal(orderSplit[0]);
						BigDecimal currentPrice = (priceListing.getPrice()).multiply(quantity);
						totalPrice = totalPrice.add(currentPrice);
					}
				}
				
				orderEntry = orderReader.readLine();
				
			}
			
			BufferedWriter writer = new BufferedWriter(new FileWriter("_10_output.txt"));
			writer.write(totalPrice.toPlainString());
			
			orderReader.close();
			priceReader.close();
			writer.close();
		
			
		} catch (IOException e) {
			System.out.println("Error!");
		}
	}
}
