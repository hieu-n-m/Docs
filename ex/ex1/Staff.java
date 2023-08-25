public class Staff extends Officer {
    String task;
    public Staff(String name, Boolean sex, String address, String task) {
        super(name, sex, address);
        this.task = task;
    }
}
