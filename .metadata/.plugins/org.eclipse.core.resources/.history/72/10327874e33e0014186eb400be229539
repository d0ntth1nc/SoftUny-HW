import java.util.Collections;
import java.util.Scanner;
import java.util.SortedMap;
import java.util.TreeMap;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


public class MostFrequentWord {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner(System.in);
		String text = scanner.nextLine();
		Matcher matcher = Pattern.compile("\\w+")
				.matcher(text);
		SortedMap<String, Integer> words = new TreeMap<String, Integer>();
		while (matcher.find()) {
			String word = matcher.group().toLowerCase();
			if (words.containsKey(word)) {
				int occurences = words.get(word) + 1;
				words.replace(word, occurences);
			} else {
				words.put(word, 1);
			}
		}
		
		int maxOccurencesCount = Collections.max(words.values());
		words.forEach((word, occurences) -> {
			if (occurences == maxOccurencesCount) {
				System.out.printf("%s - > %d\n", word, occurences);
			}
		});
	}

}
