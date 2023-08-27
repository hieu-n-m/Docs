import java.time.Year;
import java.util.Date;
import java.util.LinkedHashMap;
import java.util.Scanner;

public class InServiceStudent extends Student{
    String location;
    public InServiceStudent () {
        super();
    }

    public InServiceStudent(String id, String name, Date dob, Year year, float entryScore, LinkedHashMap<String, Float> score, String location) {
        super(id, name, dob, year, entryScore, score);
        this.location = location;
    }
    public void inputInfor() {
        super.inputInfo();
        Scanner scn = new Scanner(System.in);
        System.out.print("Insert location: ");
        this.location = scn.next();
    }
}
