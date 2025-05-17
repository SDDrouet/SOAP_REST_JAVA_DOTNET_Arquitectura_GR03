package ec.edu.gr03.controlador;

import jakarta.ws.rs.GET;
import jakarta.ws.rs.Path;
import jakarta.ws.rs.Produces;
import jakarta.ws.rs.QueryParam;
import jakarta.ws.rs.core.MediaType;
import jakarta.ws.rs.core.Response;

@Path("/conversion")
public class ConversionUnidades {

    @GET
    @Path("/pulgadasACentimetros")
    @Produces(MediaType.APPLICATION_JSON)
    public Response pulgadasACentimetros(@QueryParam("pulgadas") double pulgadas) {
        double resultado = pulgadas * 2.54;
        return Response.ok("{\"resultado\":" + resultado + "}").build();
    }

    @GET
    @Path("/centimetrosAPulgadas")
    @Produces(MediaType.APPLICATION_JSON)
    public Response centimetrosAPulgadas(@QueryParam("centimetros") double centimetros) {
        double resultado = centimetros / 2.54;
        return Response.ok("{\"resultado\":" + resultado + "}").build();
    }
}
