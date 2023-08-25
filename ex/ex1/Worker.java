public class Worker extends Officer{
    int degree;
    public Worker(String name, Boolean sex, String address, int degree) {
        super(name, sex, address);
        this.degree = degree;
    }
}
