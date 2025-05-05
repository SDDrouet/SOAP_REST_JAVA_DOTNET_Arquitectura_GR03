import React, { useState } from "react";
import { View, TextInput, Button, Text, StyleSheet, Image } from "react-native";
import { login } from "../controllers/LoginController";
import { useRouter } from "expo-router";

export default function LoginScreen() {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");
  const router = useRouter();

  const handleLogin = async () => {
    try {
      const result = await login(username, password);
      if (true) {
        router.push("/views/MenuScreen");
      } else {
        setError("Credenciales incorrectas.");
      }
    } catch (err) {
      setError("Error de conexión: " + err.message);
    }
  };

  return (
    <View style={styles.container}>
      <Image source={require("@/assets/images/monster.jpg")} style={styles.image} />
      <TextInput
        placeholder="Usuario"
        value={username}
        onChangeText={setUsername}
        style={styles.input}
      />
      <TextInput
        placeholder="Contraseña"
        secureTextEntry
        value={password}
        onChangeText={setPassword}
        style={styles.input}
      />
      <View style={styles.button}>
        <Button title="Iniciar sesión" onPress={handleLogin} color="#007AFF" />
      </View>
      {error ? <Text style={styles.error}>{error}</Text> : null}
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1, justifyContent: "center", alignItems: "center", padding: 20, backgroundColor: "#f2f2f2",
  },
  image: {
    width: "100%", height: 220, marginBottom: 20, borderRadius: 8,
  },
  input: {
    width: "100%",
    height: 50,
    backgroundColor: "#fff",
    borderRadius: 10,
    paddingHorizontal: 15,
    marginBottom: 12,
    borderWidth: 1,
    borderColor: "#ccc",
  },
  button: {
    width: "100%",
    marginTop: 10,
    borderRadius: 10,
    overflow: "hidden",
    backgroundColor: "#007AFF",
  },
  error: {
    color: "red",
    marginTop: 10,
    textAlign: "center",
  },
});
