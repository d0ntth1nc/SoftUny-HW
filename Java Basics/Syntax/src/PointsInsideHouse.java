import java.awt.geom.Point2D;
import java.awt.geom.Point2D.Float;
import java.util.Arrays;
import java.util.Locale;
import java.util.Scanner;

/* Problem 9
 * Write a program to check whether a point is
 * inside or outside the house below.
 * The point is given as a pair of floating-point numbers, 
 * separated by a space. Your program should print "Inside" or "Outside".
 */
public class PointsInsideHouse {
	private static Float[] roofPoints = {
		new Point2D.Float( 12.5F, 8.5F ),
		new Point2D.Float( 17.5F, 3.5F ),
		new Point2D.Float( 22.5F, 8.5F )
	};
	
	private static Float[] bodyPoints = {
		new Point2D.Float( 12.5F, 8.5F ),
		new Point2D.Float( 17.5F, 8.5F ),
		new Point2D.Float( 17.0F, 13.5F ),
		new Point2D.Float( 12.5F, 13.5F ),
		
		new Point2D.Float( 20.0F, 8.5F ),
		new Point2D.Float( 22.5F, 8.5F ),
		new Point2D.Float( 22.5F, 13.5F ),
		new Point2D.Float( 20.0F, 13.5F ),
	};
	
	public static void main(String[] args) {
		Locale.setDefault( Locale.ROOT );
		
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner( System.in );
		float xPos = scanner.nextFloat();
		float yPos = scanner.nextFloat();
		Float inputPoint = new Point2D.Float( xPos, yPos );
		
		String msg = isInsideHouse( inputPoint ) ? "Inside" : "Outside";
		System.out.println( msg );
	}
	
	public static Float[] getRoofPoints() {
		return Arrays.copyOf( roofPoints, roofPoints.length );
	}
	
	public static Float[] getBodyPoints() {
		return Arrays.copyOf( bodyPoints, bodyPoints.length );
	}
	
	public static boolean isInsideHouse( Float inputPoint ) {
		boolean isInsideRoof = isInsideFigure( inputPoint, roofPoints );
		boolean isInsideFirstBodyElement =
				isInsideFigure( inputPoint,
						Arrays.copyOfRange( bodyPoints, 0, 4 ) );
		boolean isInsideSecondBodyElement =
				isInsideFigure( inputPoint,
						Arrays.copyOfRange( bodyPoints, 4, 4 ) );
		return isInsideRoof || isInsideFirstBodyElement ||
				isInsideSecondBodyElement;
	}
	
	private static boolean isInsideFigure( Float inputPoint, Float[] figurePoints ) {
		boolean isInsideFigure = true;
		
		for ( int i = 0, next = 1; i < figurePoints.length - 1; i++, next++) {
			if ( next >= figurePoints.length - 1 ) {
				next = 0;
			}
			if ( !isRightOrColinear( figurePoints[ i ], figurePoints[ next ],
					inputPoint )) {
				isInsideFigure = false;
				break;
			}
		}
		
		return isInsideFigure;
	}
	
	public static boolean isRightOrColinear( Point2D.Float a,
			Point2D.Float b, Point2D.Float c ) {
		return ( ( b.x - a.x ) * ( c.y - a.y ) -
				( b.y - a.y ) * ( c.x - a.x ) ) >= 0;
	}
}
