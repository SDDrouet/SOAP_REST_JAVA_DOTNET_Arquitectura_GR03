/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/WebServices/JerseyClient.java to edit this template
 */
package ec.edu.gr03.controlador;

import jakarta.ws.rs.ClientErrorException;
import jakarta.ws.rs.client.Client;
import jakarta.ws.rs.client.WebTarget;

/**
 * Jersey REST client generated for REST resource:ConversionUnidades
 * [/conversion]<br>
 * USAGE:
 * <pre>
 *        ConversionUnidadesClient client = new ConversionUnidadesClient();
 *        Object response = client.XXX(...);
 *        // do whatever with response
 *        client.close();
 * </pre>
 *
 * @author Drouet
 */
public class ConversionUnidadesClient {

    private WebTarget webTarget;
    private Client client;
    private static final String BASE_URI = "http://localhost:8080/ConUni_Rest_Java_GR03/api";

    public ConversionUnidadesClient() {
        client = jakarta.ws.rs.client.ClientBuilder.newClient();
        webTarget = client.target(BASE_URI).path("conversion");
    }

    public <T> T pulgadasACentimetros(Class<T> responseType, double pulgadas) throws ClientErrorException {
        WebTarget resource = webTarget;
        resource = resource.queryParam("pulgadas", pulgadas);
        resource = resource.path("pulgadasACentimetros");
        return resource.request(jakarta.ws.rs.core.MediaType.APPLICATION_JSON).get(responseType);
    }

    public <T> T centimetrosAPulgadas(Class<T> responseType, double centimetros) throws ClientErrorException {
        WebTarget resource = webTarget;
        resource = resource.queryParam("centimetros", centimetros);
        resource = resource.path("centimetrosAPulgadas");
        return resource.request(jakarta.ws.rs.core.MediaType.APPLICATION_JSON).get(responseType);
    }

    public void close() {
        client.close();
    }
    
}
