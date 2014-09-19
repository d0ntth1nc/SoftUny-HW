import java.util.ArrayList;
import java.util.Scanner;

/*
 * Write a program to find all increasing sequences inside an array of integers.
 * The integers are given in a single line, separated by a space.
 * Print the sequences in the order of their appearance in the input array,
 * each at a single line. Separate the sequence elements by a space.
 * Find also the longest increasing sequence and print it at the last line.
 * If several sequences have the same longest length, print the leftmost of them.
 */
public class LongestIncreasingSequence {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner(System.in);
		String integersString = scanner.nextLine();
		String[] numbers = integersString.split(" ");
		ArrayList<String> longestIncreasingSequence =
				new ArrayList<String>();
		ArrayList<String> currentSequence = new ArrayList<String>();
		
		longestIncreasingSequence.add(numbers[0]);
		currentSequence.add(numbers[0]);
		System.out.printf("%s ", numbers[0]);
		
		for (int i = 1; i < numbers.length; i++) {
			int currentNum = Integer.parseInt(numbers[i]);
			int prevNum = Integer.parseInt(numbers[i - 1]);
			if (currentNum <= prevNum) {
				currentSequence.clear();
				System.out.println();
			}
			currentSequence.add(numbers[i]);
			System.out.printf("%s ", numbers[i]);
			
			if (currentSequence.size() > longestIncreasingSequence.size()) {
				longestIncreasingSequence = new ArrayList<String>(currentSequence);
			}
		}
		
		System.out.printf("\nLongest: ");
		for (String s : longestIncreasingSequence) {
			System.out.printf("%s ", s);
		}
	}

}