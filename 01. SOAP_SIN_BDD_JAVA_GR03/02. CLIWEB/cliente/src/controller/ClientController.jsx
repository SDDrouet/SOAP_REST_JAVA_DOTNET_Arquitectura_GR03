import axios from 'axios';

const SOAP_URL = 'http://localhost:8080/ConUni_Soap_Java_GR03/Login?wsdl';

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

// Función para iniciar sesión
export const login = async (username, password) => {
    const body = 
        `<con:login>
            <username>${username}</username>
            <password>${password}</password>
        </con:login>`;
    const response = await callSoapService('', body);
    const loginResponse = extractResponse(response, 'login');
    return loginResponse ? loginResponse.textContent : null;
};

// Función auxiliar para extraer la respuesta del XML
const extractResponse = (xmlString, action) => {
    const parser = new DOMParser();
    const xmlDoc = parser.parseFromString(xmlString, 'text/xml');
    return xmlDoc.querySelector(`${action}Response`);
};

const extractResponseValue = (xmlString, tagName) => {
    const parser = new DOMParser();
    const xmlDoc = parser.parseFromString(xmlString, 'text/xml');
    const valueNode = xmlDoc.querySelector(tagName);
    return valueNode ? valueNode.textContent : null;
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


