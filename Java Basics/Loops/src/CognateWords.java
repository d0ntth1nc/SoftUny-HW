import java.util.HashSet;
import java.util.Scanner;

/* Problem 12
 * Write a program to find in the input string all unique sets of
 * 3 �words� {a, b, c}, such that a|b = c.
 * Assume that "a|b" means to concatenate the �word� b after a.
 * We call these �words� {a, b, c} cognate words.
 * For example in the input string "java..?|basics/*-+=javabasics"
 * we have one cognate: java|basics=javabasics.
 * Notes: All �words� must be case sensitive! Don't repeat the cognate words in the output.
 */
public class CognateWords {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner(System.in);
		String inputString = scanner.nextLine();
		String[] words = inputString.split("[^a-zA-Z]+");

		boolean hasCognateWords = false;
		HashSet<String> foundWords = new HashSet<String>();
		for (int i = 0; i < words.length; i++) {
			for (int j = i + 1; j < words.length; j++) {
				for (int j2 = 0; j2 < words.length; j2++) {
					if (j2 == i || j2 == j) continue;
					String a = words[i];
					String b = words[j];
					String c = words[j2];
					if (!foundWords.contains(c)) {
						if ((a + b).equals(c)) {
							hasCognateWords = true;
							System.out.printf("%s|%s=%s\n", a, b, c);
							foundWords.add(c);
						} else if (b.concat(a).equals(c)) {
							hasCognateWords = true;
							System.out.printf("%s|%s=%s\n", b, a, c);
							foundWords.add(c);
						}
					}
				}
			}
		}
		
		if (!hasCognateWords) {
			System.out.println("No");
		}
	}
}