import java.awt.Color;
import java.awt.Graphics;
import java.util.Random;

public class Food {
    private Point point;
    private Color color;
	
    public Food(Snake s) {
        this.point = createRandomPosition(s);
        this.color = Color.RED;		
    }
    
    public Point getPoint() {
        return this.point;
    }
    
    public void draw(Graphics g) {
        this.point.draw(g, this.color);
    }
    
    private Point createRandomPosition(Snake snake) {
        Random randomGenerator = new Random();
        int x = randomGenerator.nextInt(30) * 20; 
        int y = randomGenerator.nextInt(30) * 20;
        for (Point snakePoint : snake.getBody()) {
            if (x == snakePoint.getX() || y == snakePoint.getY()) {
                return createRandomPosition(snake);				
            }
        }
        return new Point(x, y);
    }
}
