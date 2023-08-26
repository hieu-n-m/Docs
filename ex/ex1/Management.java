import java.util.List;

public class Management {
    public static void addNewOfficer (List<Officer> list, Officer officer) {
        list.add(officer);
    }
    public static void findOfficer (List<Officer> list, String name) {
        list.stream().filter(officer-> officer.name.equals(name)).forEach(System.out::println);
    }
    public static void printListOfficers (List<Officer> list) {
        list.stream().forEach(System.out::println);
    }
}
