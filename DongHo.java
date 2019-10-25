import java.awt.BasicStroke;
import java.awt.Color;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.util.Calendar;
import java.util.Date;
import java.util.concurrent.Callable;
import javax.swing.JPanel;
import java.util.Scanner;

public class DongHo extends JPanel implements Runnable   {

    private int X, Y;
    private Graphics g;
    private  int Xgio, Ygio, Xphut, Yphut, Xgiay, Ygiay;


    public DongHo() {
        X=Main.WINDOW_WIDTH/2;
        Y=Main.WINDOW_HEIGHT/2;
        Xgio=Ygio=Xphut=Yphut=Xgiay=Ygiay=0;
    }
    private void KhungDongHo(Graphics g)
    {
        g.setColor(new Color(8, 27, 60));
        g.fillOval(X -300, Y-300,600,600);
        g.setColor(new Color(227, 228, 226));
        g.fillOval(X-270, Y-270, 540, 540);
    }

    private void KimDongHo(Graphics g)
    {
        ((Graphics2D) g).setStroke(new BasicStroke(20));
        int gio, phut, giay;
        Calendar calendar=Calendar.getInstance();
        giay=calendar.get(calendar.SECOND);
        phut=calendar.get(calendar.MINUTE);
        gio=calendar.get(calendar.HOUR);

        Xgiay = (int)(Math.cos(giay * 3.14f / 30 - 3.14f / 2) * 190 + X);
        Ygiay = (int)(Math.sin(giay * 3.14f / 30 - 3.14f / 2) * 190 + Y);

        Xphut = (int)(Math.cos(phut * 3.14f / 30 - 3.14f / 2) * 140 + X);
        Yphut = (int)(Math.sin(phut * 3.14f / 30 - 3.14f / 2) * 140 + Y);

        Xgio = (int)(Math.cos((gio * 30 + phut / 2) * 3.14f / 180 - 3.14f / 2) * 90 + X);
        Ygio = (int)(Math.sin((gio * 30 + phut / 2) * 3.14f / 180 - 3.14f / 2) * 90 + Y);

        g.setColor(Color.YELLOW);
        ((Graphics2D) g).setStroke(new BasicStroke(18));
        g.drawLine(X, Y , Xgio, Ygio);// kim gio

        g.setColor(Color.BLUE);
        ((Graphics2D) g).setStroke(new BasicStroke(12));
        g.drawLine(X, Y , Xphut, Yphut);// kim phut

        g.setColor(Color.black);
        ((Graphics2D) g).setStroke(new BasicStroke(2));
        g.drawLine(X, Y, Xgiay, Ygiay);// kim giay

        g.setColor(new Color(37,44,60));
        g.fillOval(X -15, Y-15,28,28);
    }

    public void SoGio(Graphics g)
    {
        g.setFont(new Font("Arial",Font.BOLD,45));
        g.setColor(new Color(41, 228, 14));
        g.drawString("1", X + 105, Y-170);
        g.drawString("2", X + 180, Y - 95);
        g.drawString("3", X+200, Y + 15);
        g.drawString("4", X + 175, Y+ 120);
        g.drawString("5", X + 100, Y+ 190);
        g.drawString("6", X - 10, Y+ 220);
        g.drawString("7", X - 120, Y+ 190);
        g.drawString("8", X - 190, Y+ 120);
        g.drawString("9", X- 220, Y + 15);
        g.drawString("10", X - 220, Y- 90);
        g.drawString("11", X - 140, Y- 170);
        g.drawString("12", X- 20, Y- 200);

    }


    @Override
    public void paint(Graphics g) {
        KhungDongHo(g);
        SoGio(g);
        KimDongHo(g);
    }
    public void run() {
        while(true) {
            repaint();
        }
    }

}