import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileReader;
import java.io.FileWriter;
import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Collections;

/* Create a class Product to hold products, which have name (string) 
 * and price (decimal number). Read from a text file named "Input.txt" 
 * a list of products. Each product will be in format name + space + price. 
 * You should hold the products in objects of class Product. Sort the 
 * products by price and write them in format price + space + name in a 
 * file named "Output.txt". Ensure you close correctly all used resources.  */

public class _09_ListOfProducts {
	public static void main(String[] args) {
		try {
			BufferedReader reader = new BufferedReader(new FileReader("_09_input.txt"));
			String line = reader.readLine();
			
			ArrayList<Product> productList = new ArrayList<Product>();
			
			while (line != null) {
				String[] splitLine = line.split(" ");
				String name = splitLine[0];
				BigDecimal price = new BigDecimal(splitLine[1]);
				Product currentProduct = new Product(name, price);	
				productList.add(currentProduct);
				line = reader.readLine();
			}
			
			Collections.sort(productList);
			
			BufferedWriter writer = new BufferedWriter(new FileWriter("_09_output.txt"));
			
			for (Product product : productList) {
				writer.write(product.getPrice() + " " + product.getProductName() + "\n");
			}
			
			reader.close();
			writer.close();
			
		} catch (Exception ex) {
			System.out.println("Error!");
		}
	}	
}
