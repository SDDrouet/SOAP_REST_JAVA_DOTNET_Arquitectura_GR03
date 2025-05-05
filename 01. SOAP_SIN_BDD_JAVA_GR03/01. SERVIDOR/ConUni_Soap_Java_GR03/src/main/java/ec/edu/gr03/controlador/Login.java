package ec.edu.gr03.controlador;

import ec.edu.gr03.modelo.User;
import jakarta.jws.WebService;
import jakarta.jws.WebMethod;
import jakarta.jws.WebParam;

@WebService(serviceName = "Login")
public class Login {

    @WebMethod(operationName = "login")
    public boolean login(@WebParam(name = "username") String username, @WebParam(name = "password") String password) {
        User user = new User();
        
        return user.verify(username, password);      
    }
}
