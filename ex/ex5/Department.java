import java.time.Year;
import java.util.*;
import java.util.function.Predicate;
import java.util.stream.Collectors;

public class Department {
    String name;
    List<Student> studentList;

    public Department(String name) {
        this.name = name;
        this.studentList = new ArrayList<>();
    }

    public Department(String name, List<Student> studentList) {
        this.name = name;
        this.studentList = studentList;
    }
    public void addNewStudent () {
        try {
            Scanner scn = new Scanner(System.in);
            do {
                System.out.print("In-service Student? - ");
                Student t = null;
                if (scn.nextBoolean()) {
                    t = new Student();
                }
                else {
                    t = new InServiceStudent();
                }
                t.inputInfo();
                studentList.add(t);
                System.out.print("Continue? - ");
            } while (scn.nextBoolean());
        } catch (Exception e) {
            System.out.println("Invalid value");
        }
    }
    public boolean isFormal(Student t) {
        return !(t instanceof InServiceStudent);
    }
    public long totalFormal() {
        return studentList.stream().filter(this::isFormal).count();
    }
    public Student getValedictorian() {
        if (studentList.isEmpty()) {
            return null;
        }
        return studentList.stream().max(new Comparator<Student>() {
            @Override
            public int compare(Student o1, Student o2) {
                return Float.compare(o1.entryScore, o2.entryScore);
            }
        }).get();
    }
    public void printListInService () {
        if (studentList.isEmpty()) {
            System.out.println("List Empty");
        }
        else {
            studentList.stream().filter(Predicate.not(this::isFormal)).forEach(System.out::println);
        }
    }
    public void printGoodStudent () {
        if (studentList.isEmpty()) {
            System.out.println("List Empty");
        }
        else if (studentList.stream().anyMatch(Predicate.not(s -> s.score.isEmpty()))) {
            studentList.stream()
                    .filter(Predicate.not(s -> s.score.isEmpty()))
                    .filter(s -> (float) s.getSemesterScore().toArray()[s.getSemesterScore().size() - 1] >= 8)
                    .forEach(System.out::println);
        }
        else {
            System.out.println("Not record any table yet");
        }
    }

    public Student getBestStudent() {
        if (studentList.isEmpty()) {
            System.out.println("List Empty");
            return null;
        }
        else if (studentList.stream().anyMatch(Predicate.not(s -> s.score.isEmpty()))) {
            return studentList.stream()
                    .filter(Predicate.not(s -> s.score.isEmpty()))
                    .max(new Comparator<Student>() {
                        @Override
                        public int compare(Student s1, Student s2) {
                            float s1Max = s1.getSemesterScore().stream().max(Float::compareTo).get();
                            float s2Max = s2.getSemesterScore().stream().max(Float::compareTo).get();
                            return Float.compare(s1Max, s2Max);
                        }
                    }).get();
        }
        else {
            return null;
        }
    }
    public Collection<Student> sortStudentBy() {
        if (studentList.isEmpty()) {
            System.out.println("List Empty");
            return null;
        }
        else {
            Comparator<Student> comparator = Comparator.comparing(s -> s.year);
            comparator = comparator.thenComparing(Comparator.comparing(s -> s.entryScore));
            return studentList.stream().sorted(comparator).collect(Collectors.toList());
        }
    }
    public long countStudentByYear (Year y) {
        if (studentList.isEmpty()) {
            System.out.println("List Empty");
            return -1;
        }
        else {
            return studentList.stream().filter(s->s.year.equals(y)).count();
        }
    }
}
