import java.io.IOException;
import java.io.UncheckedIOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.Scanner;

/* Problem 8
 * Write a program to read a text file "Input.txt"
 * holding a sequence of integer numbers,
 * each at a separate line. Print the sum of
 * the numbers at the console. Ensure you close correctly the
 * file in case of exception or in case of normal execution.
 * In case of exception (e.g. the file is missing),
 * print "Error" as a result
 */
public class SumNumbersFromText {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner(System.in);
		
		System.out.println("Enter file name:");
		String pathAsString = scanner.nextLine();
		Path path = Paths.get(pathAsString);
		ArrayList<Double> ar = new ArrayList<Double>();
		
		try {
			Files.lines(path).forEach((line) -> {
				double result = Double.parseDouble(line);
				ar.add(result);
			});
			
			double sum = 0;
			for (double number : ar) {
				sum += number;
			}
			
			System.out.println(Math.round(sum));
		} catch (UncheckedIOException | NumberFormatException | IOException e) {
			// TODO Auto-generated catch block
			System.out.println("Error");
		}
	}
}
