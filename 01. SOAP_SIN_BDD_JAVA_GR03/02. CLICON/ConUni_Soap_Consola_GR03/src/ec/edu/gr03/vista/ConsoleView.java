package ec.edu.gr03.vista;

import java.util.Scanner;

public class ConsoleView {
    private final Scanner scanner = new Scanner(System.in);

    public String askUsername() {
        System.out.print("Ingrese usuario: ");
        return scanner.nextLine();
    }

    public String askPassword() {
        System.out.print("Ingrese contraseña: ");
        return scanner.nextLine();
    }

    public int showMenu() {
        System.out.println("\n--- Menú ---");
        System.out.println("1. Convertir pulgadas a centímetros");
        System.out.println("2. Convertir centímetros a pulgadas");
        System.out.println("3. Cerrar sesión");
        System.out.print("Seleccione una opción: ");
        return scanner.nextInt();
    }

    public double askDouble(String message) {
        System.out.print(message + " ");
        return scanner.nextDouble();
    }

    public void showResult(String message) {
        System.out.println(message);
    }

    public void showMessage(String message) {
        System.out.println(message);
    }

    public void showError(String error) {
        System.out.println("Error: " + error);
    }
}

