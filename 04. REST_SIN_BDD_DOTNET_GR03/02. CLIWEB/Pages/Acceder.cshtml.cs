using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using _02._CLICON.ec.edu.monster.controlador;
using _02._CLICON.ec.edu.monster.modelo;
using System.Threading.Tasks;

namespace _02._CLIWEB.Pages
{
    public class AccederModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {
            if (TempData.ContainsKey("ErrorLogin"))
            {
                ErrorMessage = TempData["ErrorLogin"]?.ToString();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                TempData["ErrorLogin"] = "Debe ingresar usuario y contraseña.";
                return RedirectToPage();
            }

            var controlador = new ConversionControlador();
            var usuario = new Usuario
            {
                usuario = Username,
                password = Password
            };

            bool loginCorrecto = await controlador.LoginAsync(usuario);

            if (loginCorrecto)
            {
                return RedirectToPage("Convertir");
            }
            else
            {
                TempData["ErrorLogin"] = "Usuario o contraseña incorrectos. Intente nuevamente.";
                return RedirectToPage();
            }
        }
    }
}
