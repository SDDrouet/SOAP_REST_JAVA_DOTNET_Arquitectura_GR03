import axios from 'axios';

const REST_URL = 'http://192.168.1.5:8080/ConUni_Rest_Java_GR03/api/auth/login';

// Función para iniciar sesión (reemplaza la implementación SOAP)
export const login = async (username, password) => {
    try {
        const response = await axios.post(
            REST_URL,
            { username, password }, // JSON body
            {
                headers: {
                    'Content-Type': 'application/json',
                },
            }
        );

        // Se espera una respuesta del tipo: { "authenticated": true/false }
        console.log('REST login response:', response.data.authenticated);
        return response.data.authenticated;
    } catch (error) {
        console.error('Error during REST login:', error.message);
        return null;
    }
};
