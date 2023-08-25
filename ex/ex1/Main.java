import java.util.ArrayList;
import java.util.List;

public class Main {
    public static void main(String[] args) {
        List<Officer> officers = new ArrayList<>();
        Management.addNewOfficer(officers, new Staff("A", true, "abc", "abc"));
        Management.addNewOfficer(officers, new Engineer("B", false, "abc", "abc"));
        Management.addNewOfficer(officers, new Worker("C", false, "abc", 1));
        Management.findOfficer(officers, "C");
        Management.findOfficer(officers, "d");
        Management.printListOfficers(officers);
        Management.escapeManagement(officers);
    }
}