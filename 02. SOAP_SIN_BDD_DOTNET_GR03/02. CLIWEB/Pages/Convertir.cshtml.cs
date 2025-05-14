using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceReference1;
using _02._CLICON.ec.edu.monster.controlador;

namespace _02._CLIWEB.Pages
{
    public class ConvertirModel : PageModel
    {
        private readonly ConversionControlador _conversionControlador;

        public ConvertirModel()
        {
            _conversionControlador = new ConversionControlador();
        }

        [BindProperty]
        public Request RequestData { get; set; }

        public Response ResponseData { get; set; }

        public string ResultadoMensaje { get; set; } = string.Empty;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ResultadoMensaje = " Formulario no válido. Revisa los campos.";
                return Page();
            }

            if (string.IsNullOrWhiteSpace(RequestData.origen) ||
                string.IsNullOrWhiteSpace(RequestData.destino) ||
                string.IsNullOrWhiteSpace(RequestData.valor.ToString()))
            {
                ResultadoMensaje = " Todos los campos son obligatorios.";
                return Page();
            }

            if (RequestData.origen == RequestData.destino)
            {
                ResultadoMensaje = $"No se requiere conversión:\n\n" +
                                   $"{RequestData.valor} {RequestData.origen} = {RequestData.valor} {RequestData.destino}";
                ResponseData = null; 
                return Page();
            }


            if (RequestData.valor.ToString().Length > 5)
            {
                ResultadoMensaje = "El número debe tener máximo 5 dígitos.";
                return Page();
            }

            try
            {
                ResponseData = await _conversionControlador.convertirAsync(RequestData);

                ResultadoMensaje = $"Resultado:\n\n" +
                    $" {RequestData.valor} {RequestData.origen} son {ResponseData.valorConvertido} {RequestData.destino}";
            }
            catch (Exception ex)
            {
                ResultadoMensaje = $"No se pudo conectar al servicio. Detalles: {ex.Message}";
            }

            return Page();
        }
    }
}
