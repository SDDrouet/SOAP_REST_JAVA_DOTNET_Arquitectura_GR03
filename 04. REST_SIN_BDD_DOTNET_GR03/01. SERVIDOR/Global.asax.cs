using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace uniconv_restful_dotnet
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            // Permite que un origen específico (por ejemplo, http://localhost:3000) haga solicitudes
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "http://localhost:3000");

            // Verifica si la solicitud es un preflight CORS (solicitud OPTIONS)
            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                // Agrega los encabezados para los métodos permitidos y los encabezados en la respuesta CORS
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Authorization, Accept");

                // Establece el tiempo máximo para el cacheo de la respuesta preflight
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");  // 20 días

                // Termina la respuesta para completar la solicitud OPTIONS
                HttpContext.Current.Response.End();
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}