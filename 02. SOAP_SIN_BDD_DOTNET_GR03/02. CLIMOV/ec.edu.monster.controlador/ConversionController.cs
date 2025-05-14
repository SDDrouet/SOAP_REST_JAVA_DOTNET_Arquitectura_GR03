using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using _02._CLIMOV.ec.edu.monster.modelo;

namespace _02._CLIMOV.ec.edu.monster.controlador
{
    public class ConversionController
    {
        private const string SOAP_URL = "http://192.168.1.15:8092/ec.edu.monster.controlador/ConversionControlador.svc";
        private const string SOAP_ACTION = "http://tempuri.org/IConversionControlador/convertir";

        public static async Task<Response> ConvertirAsync(Request req)
        {
            var soapEnvelope = $@"
<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tem=""http://tempuri.org/"" xmlns:_01=""http://schemas.datacontract.org/2004/07/_01.SERVIDOR.ec.edu.monster.modelo"">
   <soapenv:Header/>
   <soapenv:Body>
      <tem:convertir>
         <tem:_request>
            <_01:destino>{req.destino}</_01:destino>
            <_01:origen>{req.origen}</_01:origen>
            <_01:valor>{req.valor}</_01:valor>
         </tem:_request>
      </tem:convertir>
   </soapenv:Body>
</soapenv:Envelope>";

            var httpClient = new HttpClient();
            var content = new StringContent(soapEnvelope, Encoding.UTF8, "text/xml");
            content.Headers.Add("SOAPAction", SOAP_ACTION);

            var response = await httpClient.PostAsync(SOAP_URL, content);
            var result = await response.Content.ReadAsStringAsync();

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(result);

            var valorConvertido = double.Parse(xmlDoc.GetElementsByTagName("valorConvertido")[0].InnerText);
            var mensaje = xmlDoc.GetElementsByTagName("mensaje")[0].InnerText;

            return new Response { valorConvertido = valorConvertido, mensaje = mensaje };
        }
    }
}
