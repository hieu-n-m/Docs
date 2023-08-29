public class Worker extends Officer {
    int degree;

    public Worker(String name, boolean sex, String address, int degree) {
        super(name, sex, address);
        this.degree = degree;
    }
    @Override
    public String toString() {
        return super.toString() + " " + this.degree;
    }
}
