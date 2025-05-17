package ec.edu.gr03.controlador;

import ec.edu.gr03.modelo.User;
import jakarta.ws.rs.Consumes;
import jakarta.ws.rs.POST;
import jakarta.ws.rs.Path;
import jakarta.ws.rs.Produces;
import jakarta.ws.rs.core.MediaType;
import jakarta.ws.rs.core.Response;

@Path("/auth")
public class Login {

    public static class LoginRequest {
        public String username;
        public String password;
    }

    @POST
    @Path("/login")
    @Consumes(MediaType.APPLICATION_JSON)
    @Produces(MediaType.APPLICATION_JSON)
    public Response login(LoginRequest request) {
        User user = new User();
        boolean isValid = user.verify(request.username, request.password);
        return Response.ok("{\"authenticated\":" + isValid + "}").build();
    }
}
