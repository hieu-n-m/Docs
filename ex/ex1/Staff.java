public class Staff extends Officer {
    String task;

    public Staff(String name, boolean sex, String address, String task) {
        super(name, sex, address);
        this.task = task;
    }
}
