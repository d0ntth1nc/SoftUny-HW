import java.util.Scanner;

/*
 * Write a program that enters the sides of a rectangle 
 * (two integers a and b) and calculates and prints 
 * the rectangle's area
 */
public class RectangleArea {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner( System.in );
		int a = scanner.nextInt();
		int b = scanner.nextInt();
		int area = a * b;
		System.out.println(area);
		
	}

}
