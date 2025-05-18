using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using _01.SERVIDOR.ec.edu.monster.modelo;

namespace _01.SERVIDOR.ec.edu.monster.webservice
{
    [ServiceContract]
    public interface IConversionController
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/convertir", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Response Convertir(Request request);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/login", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool Login(Usuario user);

        [OperationContract]
        [WebGet(UriTemplate = "/usuarios", ResponseFormat = WebMessageFormat.Json)]
        List<Usuario> GetUsuarios();
    }
}
