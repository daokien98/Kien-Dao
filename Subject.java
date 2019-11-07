import java.io.Serializable;

public class Subject implements Serializable {
    private String TenMon;
    private float diem;

    public Subject(String tenSB, float diem) {
        this.setNameSubject(tenSB);
        this.setDiemSV(diem);
    }

    public String getNameSubject() {
        return TenMon;
    }

    public void setNameSubject(String nameSubject) {
        this.TenMon = nameSubject;
    }

    public float getDiemSV() {
        return diem;
    }

    public void setDiemSV(float d) {
        this.diem = d;
    }

    public void OutputSubject() {
        System.out.print("Mon hoc: " + this.TenMon + "\t");
    }

}