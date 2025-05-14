using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._CLICON.ec.edu.monster.controlador
{
    internal class ConversionControlador
    {
        public ConversionControlador()
        {
        }
        public async Task<Response> convertirAsync(Request _request)
        {
            try
            {
                ConversionControladorClient _conversionControladorClient = new ConversionControladorClient();
                Response _reponse = _conversionControladorClient.convertirAsync(_request).Result;
                return _reponse;
            }
            catch (Exception ex)
            {
                // Handle the exception here
                Console.WriteLine("Ocurrio un error: " + ex.Message);
                throw; // Rethrow the exception
            }
        }
    }
}
