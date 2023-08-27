public class Main {
    public static void main(String[] args) {
        Text t1 = new Text();
        System.out.println(t1.standardize());
        System.out.println(t1.countWord());

        Text t2 = new Text("      ");
        System.out.println(t2.standardize());
        System.out.println(t2.countWord());

        Text t3 = new Text("   a  aksj   aker   kk    ars  ");
        System.out.println(t3.standardize());
        System.out.println(t3.countWord());
    }
}