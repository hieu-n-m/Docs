import java.util.HashMap;
import java.util.Map;

public class HotelRoom {
    static Map<String, Integer> room_category = new HashMap<>() {{
        put("A", 500);
        put("B", 300);
        put("C", 100);
    }};
    int day;
    String category;
    @Override
    public String toString () {
        return category + ":" + day;
    }
    public HotelRoom (int day, String category) {
        this.day = day;
        this.category = category;
    }
    public int getPrice () {
        return this.day * room_category.get(category);
    }
}
