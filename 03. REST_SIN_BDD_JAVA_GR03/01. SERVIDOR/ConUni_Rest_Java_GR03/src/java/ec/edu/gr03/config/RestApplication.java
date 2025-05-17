package ec.edu.gr03.config;

import jakarta.ws.rs.ApplicationPath;
import jakarta.ws.rs.core.Application;

/**
 *
 * @author Drouet
 */
@ApplicationPath("/api")
public class RestApplication extends Application {
    // La clase vacía es suficiente para configurar la ruta base de la API
}
