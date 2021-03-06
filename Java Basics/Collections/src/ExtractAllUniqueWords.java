
import java.util.Arrays;
import java.util.Scanner;
import java.util.TreeSet;

/*
 * At the first line at the console you are given a piece of text.
 * Extract all words from it and print them in
 * alphabetical order. Consider each non-letter character as
 * word separator. Take the repeating words only once.
 * Ignore the character casing.
 * Print the result words in a single line, separated by spaces.
 */
public class ExtractAllUniqueWords {

	public static void main(String[] args) {
		
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner(System.in);
		String text = scanner.nextLine();
		String[] words = text.toLowerCase().split("[^a-zA-Z]+");
		TreeSet<String> uniqueWords = new TreeSet<String>(Arrays.asList(words));
		uniqueWords.forEach(word -> {
			System.out.printf("%s ", word);
		});
	}

}
