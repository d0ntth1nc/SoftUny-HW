import java.util.Scanner;

/*
 * Write a program that enters an array of 
 * strings and finds in it all sequences of equal elements.
 * The input strings are given as a single line, separated by a space.
 * Note: the count of the input strings is not explicitly specified,
 * so you might need to read the first input line as a string and split it by a space
 */
public class SequencesOfEqualStrings {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner(System.in);
		String line = scanner.nextLine();
		String[] elements = line.split(" ");
		
		for (int i = 0; i < elements.length; i++) {
			if (i < elements.length - 1) {
				if (elements[i].equals(elements[i + 1])) {
					System.out.printf("%s ", elements[i]);
				} else {
					System.out.println(elements[i]);
				}
			}
			 else {
				System.out.println(elements[i]);
			}
		}
		
	}

}
