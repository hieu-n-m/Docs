public class Receipt {
    Client client;
    int new_electric_meter_index;
    int old_electric_meter_index;
    private int pay;

    public Receipt(Client client, int new_electric_meter_index, int old_electric_meter_index) {
        this.client = client;
        this.new_electric_meter_index = new_electric_meter_index;
        this.old_electric_meter_index = old_electric_meter_index;
    }
    public int getPay() {
        this.pay = (new_electric_meter_index - old_electric_meter_index) * 5;
        return this.pay;
    }

    @Override
    public String toString () {
        return "\nClient: " + client + "\nIndex: " + old_electric_meter_index + " - " + new_electric_meter_index;
    }
}
