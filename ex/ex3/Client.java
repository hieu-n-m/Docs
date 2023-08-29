import java.util.Scanner;

public class Client {
    private String name;
    private int house;
    private String electric_meter_id;
    public Client() {
    }
    public String getElectric_meter_id() {
        return electric_meter_id;
    }

    public void inputClient () {
        Scanner scn = new Scanner(System.in);
        System.out.println("Add new client:");
        System.out.print("Insert name: ");
        String name = scn.next();
        System.out.print("Insert house: ");
        int house = scn.nextInt();
        System.out.print("Insert ID: ");
        String id = scn.next();
        this.name = name;
        this.house = house;
        this.electric_meter_id = id;
    }
    @Override
    public String toString() {
        return "\n\tName: " + name + "\n\tHouse: " + house + "\n\tMeter ID: " + electric_meter_id;
    }
}
