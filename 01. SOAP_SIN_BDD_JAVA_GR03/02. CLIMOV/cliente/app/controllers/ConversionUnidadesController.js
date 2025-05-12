import axios from 'axios';
import { XMLParser } from 'fast-xml-parser';

const SOAP_URL = 'http://10.40.13.34:8080/ConUni_Soap_Java_GR03/ConversionUnidades?wsdl';

// Función auxiliar para crear el envelope SOAP
const createSoapEnvelope = (body) => `
  <soapenv:Envelope 
    xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" 
    xmlns:con="http://controlador.gr03.edu.ec/">
    <soapenv:Header/>
    <soapenv:Body>
      ${body}
    </soapenv:Body>
  </soapenv:Envelope>
`;

// Convertir pulgadas a centímetros
export const pulgadasACentimetros = async (pulgadas) => {
    const body = `
      <con:pulgadasACentimetros>
        <pulgadas>${pulgadas}</pulgadas>
      </con:pulgadasACentimetros>
    `;
    const response = await callSoapService('', body);
    return extractResponseValue(response, 'pulgadasACentimetros');
};


const extractResponseValue = (xmlString, action) => {
    const parser = new XMLParser({
      ignoreAttributes: false,
      ignoreDeclaration: true,
      removeNSPrefix: true
    });
    const jsonObj = parser.parse(xmlString);
  
    // Después de eliminar los prefijos, accedemos directamente
    const body = jsonObj.Envelope?.Body;
    if (!body) return null;
  
    // Buscar la respuesta (ej. loginResponse)
    const responseKey = Object.keys(body).find(key => key.includes(`${action}Response`));
    const returnValue = body[responseKey]?.return;
  
    return returnValue ?? null;
  };

// Función para hacer la llamada SOAP
const callSoapService = async (action, body) => {
  const envelope = createSoapEnvelope(body);
  const response = await axios.post(SOAP_URL, envelope, {
    headers: {
      'Content-Type': 'text/xml; charset=utf-8',
      SOAPAction: `"${action}"`, // Puede quedar vacío
    },
  });
  return response.data;
};


// Convertir centímetros a pulgadas
export const centimetrosAPulgadas = async (centimetros) => {
  const body = `
    <con:centimetrosAPulgadas>
      <centimetros>${centimetros}</centimetros>
    </con:centimetrosAPulgadas>
  `;
  const response = await callSoapService('', body);
  return extractResponseValue(response, 'centimetrosAPulgadas');
};
