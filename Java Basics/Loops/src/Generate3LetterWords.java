import java.util.Scanner;

/*
 * Write a program to generate and
 * print all 3-letter words consisting of
 * given set of characters. For example if
 * we have the characters 'a' and 'b',
 * all possible words will be "aaa", "aab",
 * "aba", "abb", "baa", "bab", "bba" and "bbb".
 * The input characters are given as
 * string at the first line of the input.
 * Input characters are unique
 * (there are no repeating characters).
 */
public class Generate3LetterWords {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner(System.in);
		char[] inputChars = scanner.next("\\w+").toCharArray();
		for ( char firstChar : inputChars ) {
			for ( char secondChar : inputChars ) {
				for ( char thirdChar : inputChars ) {
					System.out.print(firstChar);
					System.out.print(secondChar);
					System.out.print(thirdChar);
					System.out.println();
				}
			}
		}
	}

}
