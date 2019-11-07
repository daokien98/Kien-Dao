import java.util.ArrayList;
import java.util.Scanner;
import java.util.Collections;
import java.io.Serializable;
public class Student extends Person implements Serializable{
    private int MaSV;
    private ArrayList<Subject> MonHoc;
    private float DTB;
    public Student()
    {
        super("",0);
        this.setMa(0);
        this.setMon(new ArrayList<Subject>());
        this.setDTB(0);
    }
    public Student(int msv, int tuoi, String ten,float tb)
    {
        super(ten,tuoi);
        this.setMa(msv);
        this.setMon(new ArrayList<Subject>());
        this.setDTB(tb);
    }
    public int getMa() {
        return MaSV;
    }
    public void setMa(int msv) {
        this.MaSV = msv;
    }
    public ArrayList<Subject> getMon() {
        return MonHoc;
    }
    public void setMon(ArrayList<Subject> subject) {
        this.MonHoc = subject;
    }
    public float getDTB() {
        return DTB;
    }
    public void setDTB(float dtb) {
        this.DTB = dtb;
    }
    public void InputSubject()
    {
        Scanner sc = new Scanner(System.in);
        int kt = 1;
        while(kt!=0)
        {
            System.out.print("Mon Hoc: ");
            String str = sc.next();
            System.out.print("Diem: ");
            float diem  = sc.nextFloat();
            MonHoc.add(new Subject(str,diem));
            System.out.print("Ban co muon nhap them mon hoc?\n(1)Co (0)Khong");
            kt = sc.nextInt();
        }
    }
    public float DiemTB(ArrayList<Subject> n)
    {
        float s = 0;
        int dem = 0;
        for(Subject i : n)
        {
            s = s + i.getDiemSV();
            dem = dem+1;
        }
        return s/dem;
    }
    public void InputStudent()
    {
        Scanner sc = new Scanner(System.in);
        System.out.print("Nhap ma sinh vien: ");
        this.MaSV = sc.nextInt();
        super.InputPerson();
        InputSubject();
        this.DTB = DiemTB(MonHoc);
    }
    public void OutputStudent()
    {
        System.out.print("Ma Sinh Vien: "+this.MaSV+"\t");
        super.OutputPerson();
        for (Subject i : MonHoc)
        {
            i.OutputSubject();
            System.out.print("Diem: "+ i.getDiemSV()+"\t");
        }
        System.out.print("Diem Trung Binh: "+this.DTB+"\n");
    }
}