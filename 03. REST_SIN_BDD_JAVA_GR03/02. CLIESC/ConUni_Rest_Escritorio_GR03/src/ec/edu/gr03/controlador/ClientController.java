package ec.edu.gr03.controlador;

import ec.edu.gr03.modelo.AuthRes;
import ec.edu.gr03.modelo.Resultado;
import ec.edu.gr03.modelo.User;

public class ClientController {

    public static double centimetrosAPulgadas(double centimetros) {
        ConversionUnidadesClient conversionUnidadesClient = new ConversionUnidadesClient();
        Resultado res = conversionUnidadesClient.centimetrosAPulgadas(Resultado.class, centimetros);
        return res.getResultado();
    }

    public static double pulgadasACentimetros(double pulgadas) {
        ConversionUnidadesClient conversionUnidadesClient = new ConversionUnidadesClient();
        Resultado res = conversionUnidadesClient.pulgadasACentimetros(Resultado.class, pulgadas);
        return res.getResultado();
    }

public static boolean login(String username, String password) {
    LoginClient loginClient = new LoginClient();
    try {
        User user = new User(username, password);
        AuthRes authRes = loginClient.login(user, AuthRes.class);
        return authRes.isAuthenticated();
    } catch (jakarta.ws.rs.ClientErrorException e) {
        System.out.println("Error al intentar iniciar sesión:");
        System.out.println("Código de estado HTTP: " + e.getResponse().getStatus());
        System.out.println("Mensaje: " + e.getMessage());

        // Si el servidor envía un cuerpo con más detalles, puedes imprimirlo así:
        try {
            String errorBody = e.getResponse().readEntity(String.class);
            System.out.println("Detalles del error: " + errorBody);
        } catch (Exception ex) {
            System.out.println("No se pudo leer el cuerpo del error.");
        }

        return false;
    } finally {
        loginClient.close();
    }
}
}
