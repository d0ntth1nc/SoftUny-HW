import java.math.BigDecimal;

/*
 * For problem 9 - List of products and
 * problem 10 - Order of products
 * 
 */
public class Product implements Comparable<Product> {
	private String name;
	private BigDecimal price;
	
	public Product(String name, BigDecimal price) {
		this.name = name;
		this.price = price;
	}
	
	public String getName() {
		return this.name;
	}
	
	public BigDecimal getPrice() {
		return this.price;
	}

	@Override
	public int compareTo(Product o) {
		return this.price.compareTo(o.price);
	}
}
