package ec.edu.gr03.modelo;

public class User {
    private final String username = "MONSTER";
    private final String password = "MONSTER9";

    public User() {
    }

    public String getUsername() {
        return username;
    }

    public String getPassword() {
        return password;
    }
    
    public boolean verify(String username, String password) {
        return this.username.equals(username) && this.password.equals(password);
    }
}
