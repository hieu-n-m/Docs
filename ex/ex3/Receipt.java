import java.util.Scanner;

public class Receipt {
    Client client;
    int new_electric_meter_index;
    int old_electric_meter_index;

    public Receipt(Client client) {
        this.client = client;
    }
    public int getPay() {
        return (new_electric_meter_index - old_electric_meter_index) * 5;
    }
    public void inputReceipt() {
        Scanner scn = new Scanner(System.in);
        System.out.print("Insert new electric meter index: ");
        this.new_electric_meter_index = scn.nextInt();
        System.out.print("Insert old electric meter index: ");
        this.old_electric_meter_index = scn.nextInt();
    }

    @Override
    public String toString () {
        return "\nClient: " + client + "\nIndex: " + old_electric_meter_index + " - " + new_electric_meter_index;
    }
}
