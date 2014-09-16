import java.util.Scanner;

/*
 * Write a program that enters a positive integer number num and
 * converts and prints it in hexadecimal form.
 * You may use some built-in method from
 * the standard Java libraries.
 */
public class DecimalToHexadecimal {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner( System.in );
		int num = scanner.nextInt();
		String numHex = Integer.toHexString( num );
		System.out.println( numHex.toUpperCase() );
	}

}
