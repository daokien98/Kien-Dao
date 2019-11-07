import java.io.Serializable;
import java.util.Scanner;
import java.io.Serializable;

public class Person implements Serializable {
    private String ten;
    private int tuoi;

    public Person(String namePerson, int agePerson) {
        this.setName(namePerson);
        this.setAge(agePerson);
    }

    public int getAge() {
        return tuoi;
    }

    public void setAge(int Tuoi) {
        this.tuoi = Tuoi;
    }

    public String getName() {
        return ten;
    }

    public void setName(String Ten) {
        this.ten = Ten;
    }

    public void InputPerson() {
        Scanner sc = new Scanner(System.in);
        System.out.print("Nhap Ten: ");
        this.ten = sc.next();
        System.out.print("Nhap Tuoi: ");
        this.tuoi = sc.nextInt();
    }

    public void OutputPerson() {
        System.out.print("Ten: " + this.ten + "\t");
        System.out.print("Tuoi: " + this.tuoi + "\t");
    }
}