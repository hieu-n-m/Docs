import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Manager manager = new Manager();
        Scanner scn = new Scanner(System.in);
        enum Button {ADD, FIND, PAY, ESC}
        while (true) {
            System.out.print("\n" +
                    "Insert function (1.ADD 2.FIND 3.PAY 4.ESC): ");
            try {
                switch (Button.valueOf(scn.next())) {
                    case ADD -> {
                        System.out.println("Add new client:");
                        System.out.print("Insert name: ");
                        String name = scn.next();
                        System.out.print("Insert age: ");
                        int age = scn.nextInt();
                        System.out.print("Insert ID: ");
                        String id = scn.next();
                        enum HIRE {ADDROOM, ESC}
                        List<HotelRoom> room = new ArrayList<>();
                        addroom: while (true) {
                            System.out.print("\n" +
                                    "Add more room (1.ADDROOM 2.ESC): ");
                            try {
                                switch (HIRE.valueOf(scn.next())) {
                                    case ADDROOM -> {
                                        System.out.print("Insert number of days: ");
                                        int days = scn.nextInt();
                                        try {
                                            if (days < 0) {
                                                throw new ArithmeticException("Non negative");
                                            }
                                        }
                                        catch (ArithmeticException e) {
                                            System.out.println(e.getMessage());
                                        }
                                        System.out.print("Insert room class (A/B/C): ");
                                        String roomclass = scn.next();
                                        try {
                                            if (!HotelRoom.room_category.containsKey(roomclass)) {
                                                throw new Exception("Room class invalid");
                                            }
                                            else {
                                                room.add(new HotelRoom(days, roomclass));
                                            }
                                        }
                                        catch (Exception e) {
                                            System.out.println(e.getMessage());
                                        }
                                    }
                                    case ESC -> {
                                        break addroom;
                                    }
                                }
                            } catch (Exception e) {
                                System.out.println("Invalid value");
                            }
                        }
                        manager.addClient(new Person(name, age, id, room));

                    }
                    case FIND -> {
                        System.out.print("Insert ID: ");
                        String id = scn.next();
                        Person found = manager.getClientById(id);
                        System.out.println(found);
                        manager.deleteClients(found);
                    }
                    case PAY -> {
                        System.out.print("Insert ID: ");
                        String id = scn.next();
                        Person found = manager.getClientById(id);
                        System.out.println(found.getBill());
                    }
                    case ESC -> {
                        return;
                    }
                }
            } catch (Exception e) {
                System.out.println("Invalid value");
            }
        }
    }
}