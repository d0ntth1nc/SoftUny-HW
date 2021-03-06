import java.util.Locale;
import java.util.Scanner;

/*
 * Write a program that reads 3 numbers:
 * an integer a (0 ≤ a ≤ 500), a floating-point b and
 * a floating-point c and prints them in
 * 4 virtual columns on the console.
 * Each column should have a width of
 * 10 characters. The number a should be printed in
 * hexadecimal, left aligned;
 * then the number a should be printed in
 * binary form, padded with zeroes,
 * hen the number b should be printed with
 * 2 digits after the decimal point,
 * right aligned; the number c should be
 * printed with 3 digits after the decimal point,
 * left aligned.
 */
public class FormattingNumbers {

	public static void main(String[] args) {
		Locale.setDefault(Locale.ROOT);
		
		final int COLUMN_WIDTH = 10;
		
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner(System.in);
		
		short a = scanner.nextShort();
		float b = scanner.nextFloat();
		float c = scanner.nextFloat();
		
		StringBuilder sb = new StringBuilder();
		sb.append( '|' );
		
		String aAsHex = Integer.toHexString( ( int ) a );
		sb.append( padRight( aAsHex, COLUMN_WIDTH ) );
		sb.append( '|' );
		
		String aAsBinary = Integer.toBinaryString( a );
		sb.append( String.format( "%010d", Integer.parseInt( aAsBinary ) ) );
		sb.append( '|' );
		
		String bAsString = String.format( "%.2f", b );
		sb.append( padLeft( bAsString, COLUMN_WIDTH ) );
		sb.append( '|' );
		
		String cAsString = String.format( "%.3f", c );
		sb.append( padRight( cAsString, COLUMN_WIDTH ) );
		sb.append( '|' );
		
		System.out.println( sb.toString() );
	}
	
	public static String padRight( String s, int n ) {
		return String.format( "%1$-" + n + "s", s );
	}

	public static String padLeft( String s, int n ) {
		return String.format( "%1$" + n + "s", s );
	}
}

