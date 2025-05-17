package ec.edu.gr03.controlador;

import jakarta.ws.rs.GET;
import jakarta.ws.rs.Path;
import jakarta.ws.rs.Produces;
import jakarta.ws.rs.core.MediaType;

@Path("/hello")
public class HelloWorldResource {
    
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public String sayHello() {
        return "¡Hola Mundo desde Payara con Java 21!";
    }
}