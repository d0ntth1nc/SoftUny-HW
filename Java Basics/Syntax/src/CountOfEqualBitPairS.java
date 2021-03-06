import java.util.Scanner;

/*
 * Write a program to count how many sequences of
 * two equal bits ("00" or "11") can be found in
 * the binary representation of
 * given integer number n (with overlapping).
 */
public class CountOfEqualBitPairS {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner( System.in );
		int n = scanner.nextInt();
		int sequencesCount = 0;
		
		for (int p = 0; p < 32 - Integer.numberOfLeadingZeros( n ) - 1; p++ ) {
			int currentBit = ( ( (1 << p ) & n ) >> p );
			int nextBit = ( ( ( 1 << p + 1 ) & n ) >> p + 1 );
			if ( currentBit == nextBit ) {
				sequencesCount++;
			}
		}
		
		System.out.println( sequencesCount );
	}

}
