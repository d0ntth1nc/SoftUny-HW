import java.awt.Canvas;
import java.awt.Dimension;
import java.awt.Graphics;

@SuppressWarnings("serial")
public class GameWindow extends Canvas implements Runnable {
    public static final int WIDTH = 600;
    public static final int HEIGHT = 600;
    public static final Dimension GAME_FIELD_SIZE = new Dimension(WIDTH, HEIGHT);
    
    public static Snake snake;
    public static Food food;
    public static int score;
    public static boolean gameRunning = false;
    
    private Graphics globalGraphics;
    private Thread runThread;
    
    public GameWindow() {	
        snake = new Snake();
        food = new Food(snake);
    }
    
    @Override
    public void paint(Graphics g) {
        this.setPreferredSize(GAME_FIELD_SIZE);
        this.globalGraphics = g.create();
        score = 0;

        if (this.runThread == null) {
            this.runThread = new Thread(this);
            this.runThread.start();
            gameRunning = true;
        }
    }

    @Override
    public void run() {
        while (gameRunning) {
            snake.move();
            render(this.globalGraphics);
            try {
                Thread.sleep(100);
            } catch (Exception e) {
                // TODO: Implement exception handling!
            }
        }
    }

    public void render(Graphics g) {
        g.clearRect(0, 0, WIDTH, HEIGHT + 25);
        g.drawRect(0, 0, WIDTH, HEIGHT);
        
        snake.draw(g);
        food.draw(g);
        g.drawString("score= " + score, 10, HEIGHT + 25);	
    }
}

