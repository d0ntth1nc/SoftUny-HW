import java.math.BigDecimal;
import java.io.IOException;
import java.io.UncheckedIOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.Collections;

/* Problem 9
 * Create a class Product to hold products,
 * which have name (string) and price (decimal number).
 * Read from a text file named "Input.txt" a list of products.
 * Each product will be in format name + space + price.
 * You should hold the products in objects of class Product.
 * Sort the products by price and write them in format price +
 * space + name in a file named "Output.txt".
 * Ensure you close correctly all used resources.
 */
public class ListOfProducts {

	public static void main(String[] args) {
		Path path = Paths.get("Input.txt");
		ArrayList<Product> products = new ArrayList<Product>();
		try {
			Files.lines(path).forEach((line) -> {
				String[] lineElements = line.split(" ");
				String name = lineElements[0];
				BigDecimal price = new BigDecimal(lineElements[1]);
				Product product = new Product(name, price);
				products.add(product);
			});
			
			sortAndPrint(products);
		} catch (UncheckedIOException | NumberFormatException | IOException e) {
			// TODO Auto-generated catch block
			System.out.println("Error");
		}
	}
	
	private static void sortAndPrint(ArrayList<Product> products) {
		Collections.sort(products);
		for (Product product : products) {
			System.out.printf("%s %s\n", product.getPrice().toString(), product.getName());
		}
	}
}
