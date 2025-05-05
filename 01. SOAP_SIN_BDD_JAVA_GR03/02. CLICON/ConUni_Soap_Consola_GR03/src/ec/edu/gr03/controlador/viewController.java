package ec.edu.gr03.controlador;

/**
 *
 * @author Drouet
 */
public class viewController {

    public static double centimetrosAPulgadas(double centimetros) {
        ec.edu.gr03.controlador.ConversionUnidades_Service service = new ec.edu.gr03.controlador.ConversionUnidades_Service();
        ec.edu.gr03.controlador.ConversionUnidades port = service.getConversionUnidadesPort();
        return port.centimetrosAPulgadas(centimetros);
    }

    public static double pulgadasACentimetros(double pulgadas) {
        ec.edu.gr03.controlador.ConversionUnidades_Service service = new ec.edu.gr03.controlador.ConversionUnidades_Service();
        ec.edu.gr03.controlador.ConversionUnidades port = service.getConversionUnidadesPort();
        return port.pulgadasACentimetros(pulgadas);
    }

    public static boolean login(java.lang.String username, java.lang.String password) {
        ec.edu.gr03.controlador.Login_Service service = new ec.edu.gr03.controlador.Login_Service();
        ec.edu.gr03.controlador.Login port = service.getLoginPort();
        return port.login(username, password);
    }
    
}
