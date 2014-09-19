import java.util.ArrayList;
import java.util.Scanner;

/*
 * Write a program that reads two lists of
 * letters l1 and l2 and combines them:
 * appends all letters c from l2 to the end of l1,
 * but only when c does not appear in l1.
 * Print the obtained combined list.
 * All lists are given as sequence of
 * letters separated by a single space,
 * each at a separate line.
 * Use ArrayList<Character> of chars to
 * keep the input and output lists.
 */
public class CombineListsOfLetters {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner(System.in);
		
		ArrayList<Character> firstList =
				new ArrayList<Character>();
		for (char c : scanner.nextLine().toCharArray()) {
			if (Character.isLetter(c)) firstList.add(c);
		}
		
		ArrayList<Character> secondList = new ArrayList<Character>();
		for (char c : scanner.nextLine().toCharArray()) {
			if (Character.isLetter(c)) secondList.add(c);
		}
		
		ArrayList<Character> output =
				new ArrayList<Character>(firstList);
		secondList.forEach(_char -> {
			if (!output.contains(_char)) {
				output.add(_char);
			}
		});
		
		for (char _char : output) {
			System.out.printf("%c ", _char);
		}
	}

}
