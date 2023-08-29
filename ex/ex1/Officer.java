public abstract class Officer {
    String name;
    boolean sex;
    String address;

    public Officer(String name, Boolean sex, String address) {
        this.name = name;
        this.sex = sex;
        this.address = address;
    }

    @Override
    public String toString() {
        return "Name: " + this.name + "\n" + "Sex: " + this.sex + "\n" + "Address: " + this.address + "\n";
    }
}
