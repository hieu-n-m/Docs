import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.stream.Collectors;

public class Manager {
    HashSet<Person> clients;
    public Manager() {
        clients = new HashSet<>();
    }
    public void addClient (Person p) {
        try {
            if (clients.stream().filter(c-> c.id.equals(p.id)).findAny().isPresent()) {
                throw new Exception("ID already exists");
            }
            else {
                clients.add(p);
            }
        }
        catch (Exception e) {
            System.out.println(e.getMessage());
        }

    }
    public Person getClientById (String id) {
        if (!(clients.isEmpty())) {
            return clients.stream().filter(c -> c.id.equals(id)).findFirst().get();
        }
        else {
            return null;
        }
    }
    public void deleteClients (Person p) {
        clients.remove(p);
    }
    @Override
    public String toString () {
        String list = "";
        for (Person client : clients) {
            list += client.toString() + "\n";
        }
        return list;
    }
}
