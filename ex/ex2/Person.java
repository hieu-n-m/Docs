import java.util.List;
import java.util.stream.Collectors;

public class Person {
    String name;
    int age;
    String id;
    List<HotelRoom> room;
    public Person(String name, int age, String id, List<HotelRoom> room) {
        this.name = name;
        this.age = age;
        this.id = id;
        this.room = room;
    }
    public int getBill () {
        return room.stream().map(HotelRoom::getPrice).mapToInt(Integer::intValue).sum();
    }
    public String toString () {
        return "\nName: " + name
                + "\nAge: " + age
                + "\nID: " + id
                + "\nRoom: " + room;
    }
}
