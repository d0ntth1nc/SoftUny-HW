
import java.util.Scanner;
import java.util.SortedSet;
import java.util.TreeSet;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

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
		Pattern pattern = Pattern.compile("\\w+", Pattern.CASE_INSENSITIVE);
		Matcher matcher = pattern.matcher(text);
		
		
		SortedSet<String> uniqueWords = new TreeSet<String>();
		while (matcher.find()) {
			// The set does not allow duplicates
			uniqueWords.add(matcher.group().toLowerCase());
		}
		for(String word : uniqueWords) {
			System.out.printf("%s ", word);
		}
	}

}
