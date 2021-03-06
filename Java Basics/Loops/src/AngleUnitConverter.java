import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.Scanner;

/* Problem 5
 * 
 * Write a method to convert from degrees to radians.
 * Write a method to convert from radians to degrees.
 * You are given a number n and n queries for conversion.
 * Each conversion query will consist of a number + space + measure.
 * Measures are "deg" and "rad". Convert all radians to
 * degrees and all degrees to radians. Print the results as n lines,
 * each holding a number + space + measure.
 * Format all numbers with 6 digit after the decimal point
 */
public class AngleUnitConverter {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner(System.in);
		int n = scanner.nextInt();
		ArrayList<String> results = new ArrayList<String>();
		
		scanner.nextLine();
		for (int i = 0; i < n; i++) {
			String input = scanner.nextLine();
			String[] inputElements = input.split(" ");
			double number = Double.parseDouble(inputElements[0]);
			String measure = inputElements[1];
			double result;
			if (measure.equals("deg")) {
				result = degToRad(number);
				measure = "rad";
			} else {
				result = radToDeg(number);
				measure = "deg";
			}
			DecimalFormat df = new DecimalFormat();
			df.setMinimumFractionDigits(6);
			df.setMaximumFractionDigits(6);
			results.add((df.format(result)) + " " + measure);
		}
		
		for(String result : results) {
			System.out.println(result);
		}
	}
	
	private static double degToRad(double deg) {
		return deg * (Math.PI / 180);
	}
	
	private static double radToDeg(double rad) {
		return rad * (180 / Math.PI);
	}
}
