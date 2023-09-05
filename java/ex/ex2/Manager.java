import java.util.HashSet;

public class Manager {
    HashSet<Person> clients;
    public Manager() {
        clients = new HashSet<>();
    }
    public void addClient (Person p) {
        try {
            if (clients.stream().anyMatch(c-> c.id.equals(p.id))) {
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
            return clients.stream().filter(c -> c.id.equals(id)).findFirst().orElse(null);
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
        StringBuilder list = new StringBuilder();
        for (Person client : clients) {
            list.append(client.toString()).append("\n");
        }
        return list.toString();
    }
}
