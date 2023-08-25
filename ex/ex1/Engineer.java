public class Engineer extends Officer{
    String major;
    public Engineer(String name, Boolean sex, String address, String major) {
        super(name, sex, address);
        this.major = major;
    }
}
