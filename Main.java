import java.awt.Color;
import java.awt.Component;
import java.awt.Graphics;
import java.nio.channels.NonReadableChannelException;
import java.util.Date;
import javax.swing.JFrame;

public class Main {
    public final static int WINDOW_WIDTH=900;
    public final static int WINDOW_HEIGHT=800;

    public static void main(String[] args) {
        JFrame windowFrame=new JFrame();
        windowFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        windowFrame.setBounds(200,0,WINDOW_WIDTH,WINDOW_HEIGHT);
        windowFrame.setBackground(new Color(167,169,164));
        windowFrame.setVisible(true);
        DongHo clock=new DongHo();
        windowFrame.getContentPane().add(clock);
        Thread clockThread=new Thread(clock);
        clockThread.start();
    }
}