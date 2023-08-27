public class Client {
    String name;
    int house;
    String electric_meter_id;

    public Client(String name, int house, String electric_meter_id) {
        this.name = name;
        this.house = house;
        this.electric_meter_id = electric_meter_id;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setHouse(int house) {
        this.house = house;
    }

    public void setElectric_meter_id(String electric_meter_id) {
        this.electric_meter_id = electric_meter_id;
    }
    @Override
    public String toString() {
        return "\n\tName: " + name + "\n\tHouse: " + house + "\n\tMeter ID: " + electric_meter_id;
    }
}
