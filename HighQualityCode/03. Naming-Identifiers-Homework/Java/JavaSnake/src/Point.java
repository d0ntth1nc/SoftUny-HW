import java.awt.Color;
import java.awt.Graphics;

public class Point {
    private final int WIDTH = 20;
    private final int HEIGHT = 20;
    
    private int x, y;
    
    public Point(Point p) {
        this(p.x, p.y);
    }

    public Point(int x, int y) {
        this.x = x;
        this.y = y;
    }	

    public int getX() {
        return x;
    }
    
    public void setX(int x) {
        this.x = x;
    }
    
    public int getY() {
        return y;
    }
    
    public void setY(int y) {
        this.y = y;
    }

    public void draw(Graphics g, Color color) {
        g.setColor(Color.BLACK);
        g.fillRect(this.x, this.y, WIDTH, HEIGHT);
        g.setColor(color);
        g.fillRect(this.x + 1, this.y + 1, WIDTH - 2, HEIGHT - 2);		
    }

    @Override
    public String toString() {
            return "[x=" + this.x + ",y=" + this.y + "]";
    }

    @Override
    public boolean equals(Object obj) {
        if (obj instanceof Point) {
            Point point = (Point)obj;
            return (this.x == point.getX()) && (this.y == point.getY());
        }
        return false;
    }
}
