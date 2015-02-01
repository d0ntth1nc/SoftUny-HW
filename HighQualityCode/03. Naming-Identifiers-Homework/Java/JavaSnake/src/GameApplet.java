import java.applet.Applet;
import java.awt.Dimension;
import java.awt.Graphics;

@SuppressWarnings("serial")
public class GameApplet extends Applet {
    private GameWindow game;
    private KeyHandler keyHandler;

    @Override
    public void init() {
        this.game = new GameWindow();
        this.game.setPreferredSize(new Dimension(800, 650));
        this.game.setVisible(true);
        this.game.setFocusable(true);
        this.add(this.game);
        this.setVisible(true);
        this.setSize(new Dimension(800, 650));
        this.keyHandler = new KeyHandler(this.game);
    }
    
    public KeyHandler getKeyHandler() {
        return this.keyHandler;
    }

    public void setSize(Graphics g) {
        this.setSize(new Dimension(800, 650));
    }
}
