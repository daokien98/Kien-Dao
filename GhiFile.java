import java.io.*;
import java.util.ArrayList;
public class GhiFile {
    public void SaveFileStudent(ArrayList<Student> student, String FileName)
    {
        try
        {
            ObjectOutputStream oos = new ObjectOutputStream(new FileOutputStream(FileName));
            oos.writeObject(student);
            oos.close();
            System.out.println("Ghi File thanh cong..!");
        }
        catch(IOException ex)
        {
            ex.printStackTrace();
        }
    }
    public ArrayList FileSV(String FileName)
    {
        try
        {
            ObjectInputStream ois = new ObjectInputStream(new FileInputStream(FileName));
            ArrayList<Student> student = null;
            student = (ArrayList<Student>) ois.readObject();
            System.out.println("Load File thanh cong!");
            return student;
        }
        catch (IOException ex)
        {
            System.out.println("Khong co file");
            return null;
        }
        catch (ClassNotFoundException ex)
        {
            System.out.println("Khong tim thay class");
            return null;
        }
    }
}