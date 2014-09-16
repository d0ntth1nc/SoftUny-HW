import java.util.Scanner;

/*
 * Write a program to find how many times given
 * string appears in given text as substring.
 * The text is given at the first input line.
 * The search string is given at the second input line.
 * The output is an integer number.
 * Please ignore the character casing
 */
public class SubstringOccurences {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner(System.in);
		String text = scanner.nextLine();
		String ptnString = scanner.nextLine();
		ptnString = ptnString.toLowerCase();
		int count = 0;
		for (int i = 0; i <= text.length() - ptnString.length(); i++) {
			String currentSubString = text.substring(i, i + ptnString.length());
			if (currentSubString.toLowerCase().equals(ptnString)) {
				count++;
			}
			
		}
		System.out.println(count);
	}

}
