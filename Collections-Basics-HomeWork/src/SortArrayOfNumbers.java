import java.util.Arrays;
import java.util.Scanner;

/*
 * Write a program to enter a number n and n integer numbers and
 * sort and print them. Keep the numbers in array of integers: int[]
 */
public class SortArrayOfNumbers {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner(System.in);
		int n = scanner.nextInt();
		int[] numbers = new int[n];
		
		for (int i = 0; i < numbers.length; i++) {
			numbers[i] = scanner.nextInt();
		}
		
		Arrays.sort(numbers);
		for (int number : numbers) {
			System.out.printf("%d ", number);
		}
	}

}
