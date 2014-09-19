import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/*
 * Write a program to find how many times a
 * word appears in given text. The text is
 * given at the first input line.
 * The target word is given at the second input line.
 * The output is an integer number.
 * Please ignore the character casing.
 * Consider that any non-letter character is a word separator
 */
public class CountSpecifiedWord {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner(System.in);
		String text = scanner.nextLine();
		String word = scanner.nextLine();
		String pattern = String.format("\\b%s\\b", word);
		Pattern p = Pattern.compile(pattern, Pattern.CASE_INSENSITIVE);
		Matcher matcher = p.matcher(text);
		int count = 0;
		while (matcher.find()) {
		      count++;
		}
		System.out.println(count);
	}

}
