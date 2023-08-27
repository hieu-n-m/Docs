public class Main {
    public static void main(String[] args) {
        Department department = new Department("SAMI");
        department.addNewStudent();
        department.studentList.stream().map(department::isFormal).forEach(System.out::println);
    }
}