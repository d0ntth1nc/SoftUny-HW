import java.util.Scanner;

/*
 * Write a program to generate and print all
 * symmetric numbers in given range [start…end]
 * (0 ≤ start ≤ end ≤ 999). A number is
 * symmetric if its digits are symmetric toward its middle.
 * For example, the numbers 101, 33, 989 and
 * 5 are symmetric, but 102, 34 and 997 are not symmetric
 */
public class SymmetricNumbersInRange {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner(System.in);
		int start = scanner.nextInt();
		int end = scanner.nextInt();
		
		for (int i = start; i <= end; i++) {
			if (isSymmetric(i)) {
				System.out.println(i);
			}
		}
	}
	
	private static boolean isSymmetric(int number) {
		if (number < 10) {
			return true;
		} else {
			String numberAsString = Integer.toString(number);
			boolean isSymmetric = true;
			for (int i = 0; i < numberAsString.length(); i++) {
				if (numberAsString.charAt(i) !=
						numberAsString.charAt(
								(numberAsString.length() - 1 - i))) {
					isSymmetric = false;
					break;
				}
			}
			return isSymmetric;
		}
	}
}