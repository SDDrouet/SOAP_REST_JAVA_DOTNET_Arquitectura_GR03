package ec.edu.gr03.controlador;

import jakarta.jws.WebService;
import jakarta.jws.WebMethod;
import jakarta.jws.WebParam;

@WebService(serviceName = "ConversionUnidades")
public class ConversionUnidades {

    @WebMethod(operationName = "pulgadasACentimetros") 
    public double pulgadasACentimetros(@WebParam(name = "pulgadas") double pulgadas) { 
    return pulgadas*2.54; 
    } 

    @WebMethod(operationName = "centimetrosAPulgadas") 
    public double centimetrosAPulgadas(@WebParam(name = "centimetros") double centimetros) { 
    return centimetros/2.54; 
    } 
} 