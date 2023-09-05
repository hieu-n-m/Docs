import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.Year;
import java.util.*;

public class Student {
    String id;
    String name;
    Date dob;
    Year year;
    float entryScore;
    LinkedHashMap<String, Float> score;

    public Student() {
    }

    public Student(String id, String name, Date dob, Year year, float entryScore, LinkedHashMap<String, Float> score) {
        this.id = id;
        this.name = name;
        this.dob = dob;
        this.year = year;
        this.entryScore = entryScore;
        this.score = score;
    }
    public Student(Student s) {
        this(s.id, s.name, s.dob, s.year, s.entryScore, s.score);
    }
    public void inputInfo () {
        System.out.println("Add new student:");
        Scanner scn = new Scanner(System.in);
        System.out.print("Insert id: ");
        String id = scn.next();
        System.out.print("Insert name: ");
        String name = scn.next();
        System.out.print("Insert date of birth (dd/MM/yyyy): ");
        Date day = null;
        try {
            DateFormat df = new SimpleDateFormat("dd/MM/yyyy");
            day = df.parse(scn.next());
        }
        catch (ParseException e) {
            System.out.println(e.getMessage());
        }
        System.out.print("Insert start year: ");
        Year year = Year.of(scn.nextInt());
        System.out.print("Insert entry score: ");
        float entryScore = scn.nextFloat();
        LinkedHashMap<String, Float> list = new LinkedHashMap<>();
        try {
            getScoreLoop: while (true) {
                System.out.println("Choose function:\n1.Add new result\n2.ESC");
                switch (scn.nextInt()) {
                    case 1:
                        System.out.print("Add new semester: ");
                        String semester = scn.next();
                        System.out.print("Average score: ");
                        Float avgScore = scn.nextFloat();
                        list.put(semester, avgScore);
                        break;
                    case 2:
                        break getScoreLoop;
                }
            }
        }
        catch (Exception e) {
            System.out.println(e.getMessage());
        }
        this.id = id;
        this.name = name;
        this.dob = day;
        this.year = year;
        this.entryScore = entryScore;
        this.score = list;
    }

    public Collection<Float> getSemesterScore () {
        if (score.isEmpty()) {
            return null;
        }
        return score.values();
    }
    public void getAvgScoreBySemester (String semester) {
        try {
            if (!(this.score.isEmpty()) && this.score.containsKey(semester)) {
                System.out.println(this.score.get(semester));
            }
            else {
                throw new Exception("Invalid value");
            }
        }
        catch (Exception e) {
            System.out.println(e.getMessage());
        }

    }

    @Override
    public String toString () {
        return "\nName: " + name
                + "\nDate of birth: " + new SimpleDateFormat("dd/MM/yyyy").format(dob)
                + "\nID: " + id;
    }
}
