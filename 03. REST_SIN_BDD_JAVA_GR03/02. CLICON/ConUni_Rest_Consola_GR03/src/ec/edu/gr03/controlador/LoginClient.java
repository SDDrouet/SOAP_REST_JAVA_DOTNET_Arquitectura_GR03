package ec.edu.gr03.controlador;

import jakarta.ws.rs.ClientErrorException;
import jakarta.ws.rs.client.Client;
import jakarta.ws.rs.client.ClientBuilder;
import jakarta.ws.rs.client.Entity;
import jakarta.ws.rs.client.WebTarget;
import jakarta.ws.rs.core.MediaType;

public class LoginClient {

    private static final String BASE_URI = "http://localhost:8080/ConUni_Rest_Java_GR03/api";
    private final WebTarget webTarget;
    private final Client client;

    public LoginClient() {
        client = ClientBuilder.newClient();
        webTarget = client.target(BASE_URI).path("auth");
    }

    /**
     * Envía las credenciales de usuario al endpoint /auth/login y recibe una respuesta de tipo T.
     *
     * @param <T> Tipo de la clase esperada como respuesta (por ejemplo AuthRes.class)
     * @param requestEntity Objeto que se enviará en el cuerpo (ej: instancia de User)
     * @param responseType Clase de respuesta esperada
     * @return instancia del tipo de respuesta esperada
     * @throws ClientErrorException si ocurre un error HTTP
     */
    public <T> T login(Object requestEntity, Class<T> responseType) throws ClientErrorException {
        return webTarget
                .path("login")
                .request(MediaType.APPLICATION_JSON)
                .post(Entity.entity(requestEntity, MediaType.APPLICATION_JSON), responseType);
    }

    public void close() {
        client.close();
    }
}
