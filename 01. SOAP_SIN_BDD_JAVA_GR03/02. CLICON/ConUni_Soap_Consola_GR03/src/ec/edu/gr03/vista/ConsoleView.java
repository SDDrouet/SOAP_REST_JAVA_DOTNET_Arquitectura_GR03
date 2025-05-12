package ec.edu.gr03.vista;

import java.util.Scanner;
import java.io.Console;

public class ConsoleView {
    private final Scanner scanner = new Scanner(System.in);

    public String askUsername() {
        System.out.print("Ingrese usuario: ");
        return scanner.nextLine();
    }

    public String askPassword() {
        Console console = System.console();
        if (console != null) {
            char[] passwordChars = console.readPassword("Ingrese contraseña: ");
            return new String(passwordChars);
        } else {
            // Fallback si se ejecuta desde un IDE que no soporta Console
            System.out.println("Advertencia: no se puede ocultar la contraseña en esta consola.");
            Scanner scanner = new Scanner(System.in);
            System.out.print("Ingrese contraseña: ");
            return scanner.nextLine();
        }
    }

    public int showMenu() {
        int option = 0;
        boolean valid = false;

        while (!valid) {
            System.out.println("\n--- Menú ---");
            System.out.println("1. Convertir pulgadas a centímetros");
            System.out.println("2. Convertir centímetros a pulgadas");
            System.out.println("3. Cerrar sesión");
            System.out.print("Seleccione una opción: ");

            if (scanner.hasNextInt()) {
                option = scanner.nextInt();
                if (option >= 1 && option <= 3) {
                    valid = true;
                } else {
                    System.out.println("Error: opción fuera de rango. Intente de nuevo.");
                }
            } else {
                System.out.println("Error: debe ingresar un número entero.");
                scanner.next(); // limpiar entrada inválida
            }
        }

        return option;
    }

    public double askDouble(String message) {
        double number = 0;
        boolean valid = false;

        while (!valid) {
            System.out.print(message + " ");
            if (scanner.hasNextDouble()) {
                number = scanner.nextDouble();
                valid = true;
            } else {
                System.out.println("Error: Solo se permiten números. Intenta de nuevo.");
                scanner.next(); // Limpia la entrada inválida
            }
        }

        return number;
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

