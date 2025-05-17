package ec.edu.gr03.controlador;

import ec.edu.gr03.modelo.User;
import ec.edu.gr03.vista.ConsoleView;

public class AppController {
    private final viewController viewController1 = new viewController();
    private final ConsoleView view = new ConsoleView();
    private final User session = new User();
    
    public void start() {
        boolean authenticated = false;

        while (!authenticated) {
            String username = view.askUsername();
            String password = view.askPassword();
            authenticated = viewController1.login(username, password);
            if (authenticated) {
                session.setUsername(username);
            } else {
                view.showError("Credenciales incorrectas. Intente de nuevo.");
            }
        }

        boolean running = true;
        while (running) {
            int choice = view.showMenu();
            switch (choice) {
                case 1:
                    double pulgadas = view.askDouble("Ingrese pulgadas:");
                    double cm = viewController1.pulgadasACentimetros(pulgadas);
                    view.showResult("Resultado: " + cm + " cm");
                    break;
                case 2:
                    double centimetros = view.askDouble("Ingrese centímetros:");
                    double inch = viewController1.centimetrosAPulgadas(centimetros);
                    view.showResult("Resultado: " + inch + " pulgadas");
                    break;
                case 3:
                    running = false;
                    view.showMessage("Sesión cerrada. ¡Hasta luego!");
                    break;
                default:
                    view.showError("Opción inválida.");
            }
        }
    }
}
