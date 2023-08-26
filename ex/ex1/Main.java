import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        List<Officer> officers = new ArrayList<>();
        Scanner scn = new Scanner(System.in);
        enum Button {ADD, FIND, PRINTALL, ESC}
        while (true) {
            System.out.print("\n" +
                    "Insert function (1.ADD 2.FIND 3.PRINTALL 4.ESC): ");
            switch (Button.valueOf(scn.next())) {
                case ADD -> {
                    System.out.println("Add new officer:");
                    System.out.print("Insert name: ");
                    String name = scn.next();
                    System.out.print("Are you male? - ");
                    Boolean sex = scn.nextBoolean();
                    System.out.print("Insert address: ");
                    String address = scn.next();
                    enum Position {WORKER, ENGINEER, STAFF}
                    System.out.print("Insert position (WORKER/ENGINEER/STAFF): ");
                    switch (Position.valueOf(scn.next())) {
                        case WORKER -> {
                            System.out.print("Insert degree (1-10): ");
                            int degree = scn.nextInt();
                            try {
                                if ((degree < 1) || (degree > 10)) {
                                    throw new Exception("Degree must be from 1 to 10");
                                }
                            } catch (Exception e) {
                                System.out.println(e);
                            }
                            Management.addNewOfficer(officers, new Worker(name, sex, address, degree));
                        }
                        case ENGINEER -> {
                            System.out.print("Insert major: ");
                            Management.addNewOfficer(officers, new Engineer(name, sex, address, scn.next()));
                        }
                        case STAFF -> {
                            System.out.print("Insert task: ");
                            Management.addNewOfficer(officers, new Staff(name, sex, address, scn.next()));
                        }
                    }
                }
                case FIND -> {
                    System.out.print("Insert name: ");
                    Management.findOfficer(officers, scn.next());
                }
                case PRINTALL -> {
                    Management.printListOfficers(officers);
                }
                case ESC -> {
                    return;
                }
            }
        }
    }
}