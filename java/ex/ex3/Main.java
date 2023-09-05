import java.util.*;
import java.util.stream.IntStream;

public class Main {
    public static void main(String[] args) {
        List<Receipt> receiptList = new ArrayList<>();
        Scanner scn = new Scanner(System.in);
        enum Button {ADD, EDIT, PAY, ESC}
        while (true) {
            System.out.print("\n" +
                    "Insert function (1.ADD 2.PRINT 3.PAY 4.ESC): ");
            try {
                switch (Button.valueOf(scn.next())) {
                    case ADD -> {
                        Client c = new Client();
                        c.inputClient();
                        Receipt r = new Receipt(c);
                        r.inputReceipt();
                        receiptList.add(r);
                    }
                    case EDIT -> {
                        System.out.print("Insert ID: ");
                        String id = scn.next();
                        try {
                            int index = IntStream.range(0, receiptList.size())
                                    .filter(i -> receiptList.get(i).client.getElectric_meter_id().equals(id))
                                    .findFirst()
                                    .orElse(-1);
                            if (index != -1) {
                                receiptList.get(index).client.inputClient();
                            }
                        } catch (Exception e) {
                            System.out.println("Invalid value");
                        }
                    }
                    case PAY -> {
                        System.out.print("Insert ID: ");
                        String id = scn.next();
                        try {
                            receiptList.stream()
                                    .filter(r -> r.client.getElectric_meter_id().equals(id))
                                    .findFirst().ifPresent(t -> System.out.println(t.getPay()));
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