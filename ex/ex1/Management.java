import java.util.List;
import java.util.stream.Collectors;

public class Management {
    public static void addNewOfficer(List<Officer> list, Officer officer) {
        list.add(officer);
    }

    public static void findOfficer(List<Officer> list, String name) {
        if (list == null) {
            System.out.println("List empty");
        } else {
            list.stream().filter(officer -> officer.name.equals(name)).forEach(System.out::println);
//            list.stream().filter(officer -> officer.name.equals(name)).forEach(officer -> {
//                System.out.println(officer.name + " " + officer.address);});
//            list.stream().filter(officer -> officer.name.equals(name)).findFirst();
//            List<Officer> newlist = list.stream().filter(officer -> officer.name.equals(name)).collect(Collectors.toList());
//            newlist.get(0);
        }
    }

    public static void printListOfficers(List<Officer> list) {
        if (list == null) {
            System.out.println("List empty");
        } else {
            list.stream().forEach(System.out::println);
        }
    }
}
