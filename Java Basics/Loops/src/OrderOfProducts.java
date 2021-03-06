import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.io.UncheckedIOException;
import java.math.BigDecimal;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.HashMap;

/* Problem 10
 * Create a class Product to hold products,
 * which have name (string) and price (decimal number).
 * Read from a text file named "Products.txt" a
 * list of product with prices and keep them in a
 * list of products. Each product will be in format name +
 * space + price. You should hold the products in
 * objects of class Product. Read from a text file named
 * "Order.txt" an order of products with quantities.
 * Each order line will be in format product + space + quantity.
 * Calculate and print in a text file "Output.txt" the total price of the order.
 * Ensure you close correctly all used resources.
 */
public class OrderOfProducts {

	public static void main(String[] args) {
		Path productsPath = Paths.get("Products.txt");
		Path ordersPath = Paths.get("Order.txt");
		HashMap<String, Product> products = new HashMap<String, Product>();
		ArrayList<String> orders = new ArrayList<String>();
		try {
			Files.lines(productsPath).forEach((line) -> {
				String[] lineElements = line.split(" ");
				String name = lineElements[0];
				BigDecimal price = new BigDecimal(lineElements[1]);
				Product product = new Product(name, price);
				products.put(name,  product);
			});
			Files.lines(ordersPath).forEach((line) -> {
				orders.add(line);
			});
			
			BigDecimal totalPrice = calculateTotalPrice(products, orders);
			printToFile(totalPrice.toString());
		} catch (UncheckedIOException | NumberFormatException | IOException e) {
			System.out.println("Error");
		}
	}

	private static void printToFile(String string) {
		FileWriter fileWriter = null;
        try {
            File newTextFile = new File("Output.txt");
            fileWriter = new FileWriter(newTextFile);
            fileWriter.write(string);
            fileWriter.close();
        } catch (IOException ex) {
        	System.out.println("Error");
        } finally {
            try {
                fileWriter.close();
            } catch (IOException ex) {
            	System.out.println("Error");
            }
        }
	}

	private static BigDecimal calculateTotalPrice(
			HashMap<String, Product> products, ArrayList<String> orders) {
		
		BigDecimal totalPrice = BigDecimal.ZERO;
		for (String order : orders) {
			String[] orderParams = order.split(" ");
			int quantity = Integer.parseInt(orderParams[0]);
			String name = orderParams[1];
			BigDecimal productPrice = products.get(name).getPrice();
			BigDecimal result = productPrice.multiply(new BigDecimal(quantity));
			totalPrice = totalPrice.add(result);
		}
		return totalPrice;
	}
	
}
