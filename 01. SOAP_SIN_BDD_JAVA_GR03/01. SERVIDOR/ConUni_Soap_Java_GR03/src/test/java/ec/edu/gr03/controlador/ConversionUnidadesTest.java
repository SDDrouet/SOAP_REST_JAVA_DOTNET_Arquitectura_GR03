/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/UnitTests/JUnit5TestClass.java to edit this template
 */
package ec.edu.gr03.controlador;

import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.AfterAll;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.*;

/**
 *
 * @author Drouet
 */
public class ConversionUnidadesTest {
    
    public ConversionUnidadesTest() {
    }
    
    @BeforeAll
    public static void setUpClass() {
    }
    
    @AfterAll
    public static void tearDownClass() {
    }
    
    @BeforeEach
    public void setUp() {
    }
    
    @AfterEach
    public void tearDown() {
    }

    /**
     * Test of pulgadasACentimetros method, of class ConversionUnidades.
     */
    @Test
    public void testPulgadasACentimetros() {
        System.out.println("pulgadasACentimetros");
        double pulgadas = 3;
        ConversionUnidades instance = new ConversionUnidades();
        double expResult = 7.62;
        double result = instance.pulgadasACentimetros(pulgadas);
        assertEquals(expResult, result, 0);
    }

    /**
     * Test of centimetrosAPulgadas method, of class ConversionUnidades.
     */
    @Test
    public void testCentimetrosAPulgadas() {
        System.out.println("centimetrosAPulgadas");
        double centimetros = 7.62;
        ConversionUnidades instance = new ConversionUnidades();
        double expResult = 3;
        double result = instance.centimetrosAPulgadas(centimetros);
        assertEquals(expResult, result, 0);
    }
    
}
