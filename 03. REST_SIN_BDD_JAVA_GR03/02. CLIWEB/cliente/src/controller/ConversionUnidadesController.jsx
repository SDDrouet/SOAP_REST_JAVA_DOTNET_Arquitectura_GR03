// ConversionUnidadesController.jsx
import axios from 'axios';

const REST_BASE_URL = 'http://localhost:8080/ConUni_Rest_Java_GR03/api/conversion';

// Convertir pulgadas a centímetros
export const pulgadasACentimetros = async (pulgadas) => {
  try {
    const response = await axios.get(`${REST_BASE_URL}/pulgadasACentimetros`, {
      params: { pulgadas }
    });
    return response.data.resultado;
  } catch (error) {
    console.error('Error al convertir pulgadas a centímetros:', error);
    return null;
  }
};

// Convertir centímetros a pulgadas
export const centimetrosAPulgadas = async (centimetros) => {
  try {
    const response = await axios.get(`${REST_BASE_URL}/centimetrosAPulgadas`, {
      params: { centimetros }
    });
    return response.data.resultado;
  } catch (error) {
    console.error('Error al convertir centímetros a pulgadas:', error);
    return null;
  }
};
