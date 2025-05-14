using _01.SERVIDOR.ec.edu.monster.modelo;
using _01.SERVIDOR.ec.edu.monster.servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _01.SERVIDOR.ec.edu.monster.controlador
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ConversionControlador" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ConversionControlador.svc o ConversionControlador.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ConversionControlador : IConversionControlador
    {
        public Response convertir(Request _request)
        {
            Response _response = new Response();
            ConversionServicio _servicio = new ConversionServicio();
            try
            {
                if ((_request.origen.Equals("C") || _request.origen.Equals("F") || _request.origen.Equals("K")) && (_request.destino.Equals("C") || _request.destino.Equals("F") || _request.destino.Equals("K")))
                {
                    if (_request.valor >= 0 || _request.valor < 0)
                    {
                        _response.valorConvertido = _servicio.convertirTemperatura(_request.valor, _request.origen, _request.destino);
                        _response.mensaje = _request.valor.ToString() + " " + _request.origen + " son " + _response.valorConvertido + " " + _request.destino;
                    }
                    else
                    {
                        _response.mensaje = "El valor debe ser mayor a 0";
                    }
                }
                else
                {
                    _response.mensaje = "Los valores de origen y destino deben ser C, F o K";
                }
            }catch(Exception ex)
            {
                _response.mensaje = "Error: Ingrese valores numéricos" + ex.Message;
            }

            return _response;
        }

    }
}
