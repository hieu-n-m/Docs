public abstract class Officer {
    String name;
    Boolean sex;
    String address;
    public Officer(String name, Boolean sex, String address) {
        this.name = name;
        this.sex = sex;
        this.address = address;
    }
    @Override
    public String toString() {
        return this.name + " " + this.sex + " " + this.address;
    }
}
