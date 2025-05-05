import { useState } from 'react';
import { login } from '../controller/ClientController';
import { useNavigate } from 'react-router-dom';

function Login() {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState('');
  const navigate = useNavigate();

  const handleLogin = async (e) => {
    e.preventDefault();
    setLoading(true);
    try {
      const result = await login(username, password);
      if (result === 'true') {
        navigate('/menu');
      } else {
        setError('Usuario o contraseña incorrectos');
      }
    } catch (error) {
      setError('Error al iniciar sesión');
      console.error(error);
    }
    setLoading(false);
  };

  return (
    <div className="login-wrapper">
      {/* Contenedor del formulario */}
      <div className="container">
        <h2>Conversión de Unidades</h2>
        <h2>Inicio de Sesión</h2>
        <form onSubmit={handleLogin}>
          <input
            type="text"
            placeholder="Usuario"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
            required
          />
          <input
            type="password"
            placeholder="Contraseña"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
          />
          <button type="submit" disabled={loading}>
            {loading ? 'Cargando...' : 'Iniciar sesión'}
          </button>
        </form>
        {error && <p style={{ color: 'red' }}>{error}</p>}
      </div>

      {/* Imagen decorativa */}
      <img src="/monster.jpg" alt="monster" className="login-image" />
    </div>
  );
}

export default Login;
