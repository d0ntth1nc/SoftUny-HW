import java.awt.Color;
import java.awt.Graphics;
import java.util.LinkedList;

public class Snake {
    private LinkedList<Point> snakeBody = new LinkedList<>();
    private Color snakeColor;
    private int velocityX = 0, velocityY = 0;

    public Snake() {
        snakeColor = Color.GREEN;
        snakeBody.add(new Point(300, 100)); 
        snakeBody.add(new Point(280, 100)); 
        snakeBody.add(new Point(260, 100)); 
        snakeBody.add(new Point(240, 100)); 
        snakeBody.add(new Point(220, 100)); 
        snakeBody.add(new Point(200, 100)); 
        snakeBody.add(new Point(180, 100));
        snakeBody.add(new Point(160, 100));
        snakeBody.add(new Point(140, 100));
        snakeBody.add(new Point(120, 100));

        velocityX = 20;
        velocityY = 0;
    }
    
    public LinkedList<Point> getBody() {
        return this.snakeBody;
    }

    public void draw(Graphics g) {		
        for (Point point : this.snakeBody) {
            point.draw(g, snakeColor);
        }
    }

    public void move() {
        Point newPosition =
            new Point((snakeBody.get(0).getX() + velocityX),
                (snakeBody.get(0).getY() + velocityY));

        if (newPosition.getX() > GameWindow.WIDTH - 20) {
            GameWindow.gameRunning = false;
        } else if (newPosition.getX() < 0) {
            GameWindow.gameRunning = false;
        } else if (newPosition.getY() < 0) {
            GameWindow.gameRunning = false;
        } else if (newPosition.getY() > GameWindow.HEIGHT - 20) {
            GameWindow.gameRunning = false;
        } else if (GameWindow.food.getPoint().equals(newPosition)) {
            snakeBody.add(GameWindow.food.getPoint());
            GameWindow.food = new Food(this);
            GameWindow.score += 50;
        } else if (snakeBody.contains(newPosition)) {
            GameWindow.gameRunning = false;
            System.out.println("You ate yourself");
        }	

        for (int i = snakeBody.size() - 1; i > 0; i--) {
            snakeBody.set(i, new Point(snakeBody.get(i - 1)));
        }	
        snakeBody.set(0, newPosition);
    }

    public int getVelX() {
        return velocityX;
    }

    public void setVelX(int velX) {
        this.velocityX = velX;
    }

    public int getVelY() {
        return velocityY;
    }

    public void setVelY(int velY) {
        this.velocityY = velY;
    }
}