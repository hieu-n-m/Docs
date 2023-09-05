public class Engineer extends Officer {
    String major;

    public Engineer(String name, boolean sex, String address, String major) {
        super(name, sex, address);
        this.major = major;
    }
}
