import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        List<Receipt> receiptList = new ArrayList<>();
        Scanner scn = new Scanner(System.in);
        enum Button {ADD, PRINT, PAY, ESC}
        while (true) {
            System.out.print("\n" +
                    "Insert function (1.ADD 2.PRINT 3.PAY 4.ESC): ");
            try {
                switch (Button.valueOf(scn.next())) {
                    case ADD -> {
                        System.out.println("Add new client:");
                        System.out.print("Insert name: ");
                        String name = scn.next();
                        System.out.print("Insert house: ");
                        int house = scn.nextInt();
                        System.out.print("Insert ID: ");
                        String id = scn.next();
                        System.out.print("Insert new electric meter index: ");
                        int newidx = scn.nextInt();
                        System.out.print("Insert old electric meter index: ");
                        int oldidx = scn.nextInt();
                        receiptList.add(new Receipt(new Client(name, house, id), newidx, oldidx));
                    }
                    case PRINT -> {
                        receiptList.forEach(System.out::println);
                    }
                    case PAY -> {
                        System.out.print("Insert ID: ");
                        String id = scn.next();
                        try {
                            System.out.println(receiptList.stream()
                                    .filter(r->r.client.electric_meter_id.equals(id))
                                    .findFirst().get()
                                    .getPay());
                        }
                        catch (Exception e) {
                            System.out.println("Not found");
                        }

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