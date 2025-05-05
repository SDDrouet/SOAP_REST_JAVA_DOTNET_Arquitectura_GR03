// src/views/Menu.jsx
import { useState } from 'react';
import { centimetrosAPulgadas, pulgadasACentimetros } from '../controller/ConversionUnidadesController';
import { useNavigate } from 'react-router-dom';

function Menu() {
  const [tipo, setTipo] = useState('cm-pulg');
  const [valor, setValor] = useState('');
  const [resultado, setResultado] = useState('');
  const navigate = useNavigate();

  const calcular = async () => {
    try {
      const num = parseFloat(valor);
      if (isNaN(num)) return setResultado('Debe ingresar un número válido.');
      if (tipo === 'cm-pulg') {
        const res = await centimetrosAPulgadas(num);
        setResultado(`${num} cm = ${res} pulgadas`);
      } else {
        const res = await pulgadasACentimetros(num);
        setResultado(`${num} pulgadas = ${res} cm`);
      }
    } catch (error) {
      setResultado('Error al convertir');
      console.error(error);
    }
  };

  const cerrarSesion = () => {
    navigate('/');
  };

  return (
    <div className="login-wrapper">
      <div className="container">
      <h2>Conversión de Unidades</h2>
      <select value={tipo} onChange={(e) => setTipo(e.target.value)} style={{ marginBottom: '10px', width: '100%' }}>
        <option value="cm-pulg">Centímetros a Pulgadas</option>
        <option value="pulg-cm">Pulgadas a Centímetros</option>
      </select>
      <input
        type="text"
        placeholder="Ingrese valor"
        value={valor}
        onChange={(e) => setValor(e.target.value)}
        style={{ display: 'block', marginBottom: '10px', width: '100%' }}
      />
      <button onClick={calcular} style={{ marginRight: '10px', marginBottom: '10px', width: '100%' }}>
        Calcular
      </button>
      <button onClick={cerrarSesion}>Cerrar sesión</button>
      {resultado && <p style={{ marginTop: '20px' }}>{resultado}</p>}
      </div>
      
      <img src="/monster.jpg" alt="monster" className="login-image" />
    </div>
    
  );
}

export default Menu;
