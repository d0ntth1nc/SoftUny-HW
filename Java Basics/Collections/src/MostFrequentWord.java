import java.util.Collections;
import java.util.Scanner;
import java.util.SortedMap;
import java.util.TreeMap;


public class MostFrequentWord {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner(System.in);
		String text = scanner.nextLine();
		String[] words = text.toLowerCase().split("[^a-zA-Z]+");
		SortedMap<String, Integer> wordsSet = new TreeMap<String, Integer>();
		for (String word : words) {
			if (wordsSet.containsKey(word)) {
				int occurences = wordsSet.get(word) + 1;
				wordsSet.replace(word, occurences);
			} else {
				wordsSet.put(word, 1);
			}
		}
		
		int maxOccurencesCount = Collections.max(wordsSet.values());
		wordsSet.forEach((word, occurences) -> {
			if (occurences == maxOccurencesCount) {
				System.out.printf("%s - > %d\n", word, occurences);
			}
		});
	}

}
