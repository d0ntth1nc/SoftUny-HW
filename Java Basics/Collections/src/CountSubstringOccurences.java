import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


public class CountSubstringOccurences {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner(System.in);
		String wordsLine = scanner.nextLine();
		String word = scanner.nextLine();
		Matcher m = Pattern.compile(String.format("((?=(%s)))", word),
				Pattern.CASE_INSENSITIVE).matcher(wordsLine);
		int count = 0;
		while (m.find()) {
			count++;
		};
		
		System.out.println(count);
	}

}
