import axios from 'axios';
import { XMLParser } from 'fast-xml-parser';

const SOAP_URL = 'http://192.168.1.30:8080/ConUni_Soap_Java_GR03/Login?wsdl';

// Función auxiliar para envolver el cuerpo XML en un envelope SOAP
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

const extractResponse = (xmlString, action) => {
    const parser = new XMLParser({
      ignoreAttributes: false,
      ignoreDeclaration: true,
      removeNSPrefix: true // ⚠️ Esto elimina el prefijo como soapenv:, con:, etc.
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
  

// Función para realizar la llamada SOAP
const callSoapService = async (action, body) => {
  const envelope = createSoapEnvelope(body);
  const response = await axios.post(
    SOAP_URL,
    envelope,
    {
      headers: {
        'Content-Type': 'text/xml; charset=utf-8',
        SOAPAction: `"${action}"`,
      },
    }
  );
  return response.data;
};

// Función para iniciar sesión
export const login = async (username, password) => {
  const body = `
    <con:login>
      <username>${username}</username>
      <password>${password}</password>
    </con:login>
  `;
  const response = await callSoapService('', body);
  const loginResponse = extractResponse(response, 'login');
  return loginResponse;
};
