import java.util.Scanner;

/*
 * Write a program to calculate the count of
 * bits 1 in the binary representation of
 * given integer number n.
 */
public class CountOfBit1 {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner( System.in );
		int n = scanner.nextInt();
		int onesCount = 0;
		
		for ( int i = 0; i < 32; i++ ) {
			onesCount += ( ( 1 << i ) & n ) >> i;
		}
		
		System.out.println( onesCount );
	}

}
