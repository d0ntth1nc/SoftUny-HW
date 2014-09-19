import java.util.Scanner;


public class StuckNumbers {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner(System.in);
		int n = scanner.nextInt();
		int[] numbers = new int[n];
		for (int i = 0; i < numbers.length; i++) {
			numbers[i] = scanner.nextInt();
		}
		
		boolean hasStuckNumbers = false;
		for (int i = 0; i < numbers.length; i++) {
			int a = numbers[i];
			for (int j = 0; j < numbers.length; j++) {
				int b = numbers[j];
				if (a == b) {
					continue;
				}
				for (int j2 = 0; j2 < numbers.length; j2++) {
					int c = numbers[j2];
					if (c == a || c == b) {
						continue;
					}
					for (int k = 0; k < numbers.length; k++) {
						int d = numbers[k];
						if (d == a || d == b || d == c) {
							continue;
						}
						String firstNumber = "" +  numbers[i] + numbers[j];
						String secondNumber = "" + numbers[j2] + numbers[k];
						if (firstNumber.equals(secondNumber)) {
							hasStuckNumbers = true;
							System.out.printf("%d|%d==%d|%d\n", a, b, c, d);
						}
					}
				}
			}
		}
		
		if (!hasStuckNumbers) {
			System.out.println("No");
		}
	}

}