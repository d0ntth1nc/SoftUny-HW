import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

public class KeyHandler implements KeyListener {
    public KeyHandler(GameWindow game){
        game.addKeyListener(this);
    }
    
    @Override
    public void keyPressed(KeyEvent e) {
        int keyCode = e.getKeyCode();
		
        if (keyCode == KeyEvent.VK_W || keyCode == KeyEvent.VK_UP) {
            if (GameWindow.snake.getVelY() != 20) {
                GameWindow.snake.setVelX(0);
                GameWindow.snake.setVelY(-20);
            }
        }
        if (keyCode == KeyEvent.VK_S || keyCode == KeyEvent.VK_DOWN) {
            if (GameWindow.snake.getVelY() != -20) {
                GameWindow.snake.setVelX(0);
                GameWindow.snake.setVelY(20);
            }
        }
        if (keyCode == KeyEvent.VK_D || keyCode == KeyEvent.VK_RIGHT) {
            if (GameWindow.snake.getVelX() != -20) {
                GameWindow.snake.setVelX(20);
                GameWindow.snake.setVelY(0);
            }
        }
        if (keyCode == KeyEvent.VK_A || keyCode == KeyEvent.VK_LEFT) {
            if (GameWindow.snake.getVelX() != 20) {
                GameWindow.snake.setVelX(-20);
                GameWindow.snake.setVelY(0);
            }
        }
        
        //Other controls
        if (keyCode == KeyEvent.VK_ESCAPE) {
            System.exit(0);
        }
    }

    public void keyReleased(KeyEvent e) {
    }

    public void keyTyped(KeyEvent e) {	
    }
}
