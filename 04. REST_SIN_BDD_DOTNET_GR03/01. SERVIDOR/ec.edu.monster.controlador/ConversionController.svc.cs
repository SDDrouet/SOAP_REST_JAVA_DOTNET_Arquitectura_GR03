using System.Collections.Generic;
using System.Linq;
using _01.SERVIDOR.ec.edu.monster.modelo;
using _01.SERVIDOR.ec.edu.monster.webservice;

namespace _01.SERVIDOR.ec.edu.monster.servicio
{
    public class ConversionController : IConversionController
    {
        private static List<Usuario> usuarios = new List<Usuario>
        {
            new Usuario { id = 1, usuario = "MONSTER", password = "MONSTER9" },
            new Usuario { id = 2, usuario = "ADMIN", password = "abcd" }
        };

        private readonly ConversionServicio _servicio = new ConversionServicio();

        public Response Convertir(Request request)
        {
            double resultado = _servicio.convertirTemperatura(request.valor, request.origen, request.destino);

            return new Response
            {
                valorConvertido = resultado,
                mensaje = $"{request.valor} {request.origen} = {resultado} {request.destino}"
            };
        }

        public bool Login(Usuario user)
        {
            return _servicio.validarLogin(user.usuario, user.password);
        }

        public List<Usuario> GetUsuarios()
        {
            return _servicio.obtenerUsuarios();
        }
    }
}
