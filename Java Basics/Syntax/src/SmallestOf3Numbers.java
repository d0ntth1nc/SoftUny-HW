import java.util.Scanner;

/*
 * Write a program that finds the smallest of three numbers.
 */
public class SmallestOf3Numbers {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner( System.in );
		int firstNumber = scanner.nextInt();
		int secondNumber = scanner.nextInt();
		int thirdNumber = scanner.nextInt();
		
		int smallestNumber = Math.min( firstNumber, secondNumber );
		smallestNumber = Math.min( smallestNumber, thirdNumber );
		System.out.println( smallestNumber );
	}

}
