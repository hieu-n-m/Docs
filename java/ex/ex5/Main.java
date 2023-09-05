import java.time.Year;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Department department = new Department("SAMI");
        Scanner scn = new Scanner(System.in);
        enum Button {ADD, CHECK_FORMAL, GET_AVG_SCORE_BY_ID, COUNT_TOTAL_FORMAL,
            FIND_VALEDICTORIAN, PRINT_IN_SERVICE, PRINT_GOOD, FIND_BEST, PRINT_SORT_LIST, COUNT_BY_YEAR, ESC}
        while (true) {
            System.out.println("""

                    Insert function:\s
                    1.ADD\s
                    2.CHECK_FORMAL\s
                    3.GET_AVG_SCORE_BY_ID\s
                    4.COUNT_TOTAL_FORMAL\s
                    5.FIND_VALEDICTORIAN\s
                    6.PRINT_IN_SERVICE\s
                    7.PRINT_GOOD\s
                    8.FIND_BEST\s
                    9.PRINT_SORT_LIST\s
                    10.COUNT_BY_YEAR\s
                    11.ESC""");
            try {
                switch (Button.valueOf(scn.next())) {
                    case ADD -> department.addNewStudent();

                    case CHECK_FORMAL -> {
                        System.out.print("Insert ID: ");
                        Student t = department.getStudentByID(scn.next());
                        System.out.println(department.isFormal(t));
                    }
                    case GET_AVG_SCORE_BY_ID -> {
                        System.out.print("Insert ID: ");
                        Student t = department.getStudentByID(scn.next());
                        System.out.print("Insert semester: ");
                        t.getAvgScoreBySemester(scn.next());
                    }
                    case COUNT_TOTAL_FORMAL -> System.out.println(department.totalFormal());

                    case FIND_VALEDICTORIAN -> System.out.println(department.getValedictorian());

                    case PRINT_IN_SERVICE -> {
                        System.out.print("Insert location: ");
                        department.printListInServiceBy(scn.next());
                    }
                    case PRINT_GOOD -> department.printGoodStudent();

                    case FIND_BEST -> System.out.println(department.getBestStudent());

                    case PRINT_SORT_LIST -> department.sortStudentBy().forEach(System.out::println);

                    case COUNT_BY_YEAR -> {
                        System.out.print("Insert year: ");
                        System.out.println(department.countStudentByYear(Year.of(scn.nextInt())));
                    }
                    case ESC -> {
                        return;
                    }
                }
            } catch (Exception e) {
                System.out.println("Invalid value");
            }
        }
    }
}