package ec.edu.gr03.controlador;

import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.AfterAll;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.*;

public class LoginTest {
    
    public LoginTest() {
    }
    
    @BeforeAll
    public static void setUpClass() {
    }
    
    @AfterAll
    public static void tearDownClass() {
    }
    
    @BeforeEach
    public void setUp() {
    }
    
    @AfterEach
    public void tearDown() {
    }

    /**
     * Test of login method, of class Login.
     */
    @Test
    public void testLoginIncorrectCredentials() {
        System.out.println("login");
        String username = "123";
        String password = "123";
        Login instance = new Login();
        boolean expResult = false;
        boolean result = instance.login(username, password);
        assertEquals(expResult, result);
    }
    
    @Test
    public void testLoginCorrectCredentials() {
        System.out.println("login");
        String username = "MONSTER";
        String password = "MONSTER9";
        Login instance = new Login();
        boolean expResult = true;
        boolean result = instance.login(username, password);
        assertEquals(expResult, result);
    }
}
