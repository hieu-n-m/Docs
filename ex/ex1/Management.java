import java.util.List;

public class Management {
    public static void addNewOfficer (List<Officer> list, Officer officer) {
        list.add(officer);
    }
    public static void findOfficer (List<Officer> list, String name) {
        Boolean flag = false;
        for (Officer officer : list) {
            if (officer.name.equals(name)) {
                System.out.println(officer.name + " " + officer.sex + " " + officer.address);;
                flag = true;
            }
        }
        if (flag == false) {
            System.out.println("Not found");
        }
    }
    public static void printListOfficers (List<Officer> list) {
        for (Officer officer : list) {
            System.out.println(officer.name + " " + officer.sex + " " + officer.address);
        }
    }
    public static void escapeManagement (List<Officer> list) {

    }
}
