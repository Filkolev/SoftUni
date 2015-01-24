import java.math.BigDecimal;

public  class Product implements Comparable<Product>{
	
	private String productName;
	private BigDecimal price;

	public Product(String productName, BigDecimal price) {
		this.productName = productName;
		this.price = price;
	};

	public String getProductName() {
		return productName;
	}
	public void setProductName(String productName) {
		this.productName = productName;
	}
	public BigDecimal getPrice() {
		return price;
	}
	public void setPrice(BigDecimal price) {
		this.price = price;
	}

	@Override
	public int compareTo(Product p1) {		
		return this.getPrice().compareTo(p1.getPrice());
	}
}
