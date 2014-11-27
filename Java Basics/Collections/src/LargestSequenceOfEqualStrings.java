import java.util.ArrayList;
import java.util.Scanner;

/*
 * Write a program that enters an array of strings and
 * finds in it the largest sequence of equal elements.
 * If several sequences have the same longest length,
 * print the leftmost of them. The input strings are given as
 * a single line, separated by a space. 
 */
public class LargestSequenceOfEqualStrings {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner(System.in);
		String line = scanner.nextLine();
		String[] elements = line.split(" ");
		ArrayList<String> largestSequence = new ArrayList<String>();
		ArrayList<String> currentSequence = new ArrayList<String>();
		largestSequence.add(elements[0]);
		currentSequence.add(elements[0]);
		for (int i = 1; i < elements.length; i++) {
			if (!elements[i].equals(elements[i - 1])) {
				currentSequence.clear();
			}
			currentSequence.add(elements[i]);
			
			if (currentSequence.size() > largestSequence.size()) {
				largestSequence = new ArrayList<String>(currentSequence);
			}
		}
		
		for (String element : largestSequence) {
			System.out.printf("%s ", element);
		}
	}

}
