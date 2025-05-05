// ConversionUnidadesController.jsx
import axios from 'axios';

const SOAP_URL = 'http://localhost:8080/ConUni_Soap_Java_GR03/ConversionUnidades?wsdl';

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

// Función auxiliar para extraer la respuesta del XML
const extractResponseValue = (xmlString, tagName) => {
  const parser = new DOMParser();
  const xmlDoc = parser.parseFromString(xmlString, 'text/xml');
  const valueNode = xmlDoc.querySelector(tagName);
  return valueNode ? valueNode.textContent : null;
};

// Función para hacer la llamada SOAP
const callSoapService = async (action, body) => {
  const envelope = createSoapEnvelope(body);
  const response = await axios.post(SOAP_URL, envelope, {
    headers: {
      'Content-Type': 'text/xml; charset=utf-8',
      SOAPAction: `"${action}"`, // En tu WSDL estaba vacío, así que lo dejamos así
    },
  });
  return response.data;
};

// Convertir pulgadas a centímetros
export const pulgadasACentimetros = async (pulgadas) => {
  const body = `
    <con:pulgadasACentimetros>
      <pulgadas>${pulgadas}</pulgadas>
    </con:pulgadasACentimetros>
  `;
  const response = await callSoapService('', body);
  return extractResponseValue(response, 'return');
};

// Convertir centímetros a pulgadas
export const centimetrosAPulgadas = async (centimetros) => {
  const body = `
    <con:centimetrosAPulgadas>
      <centimetros>${centimetros}</centimetros>
    </con:centimetrosAPulgadas>
  `;
  const response = await callSoapService('', body);
  return extractResponseValue(response, 'return');
};
