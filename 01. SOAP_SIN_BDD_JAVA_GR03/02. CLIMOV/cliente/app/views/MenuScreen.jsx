import React, { useState } from "react";
import { View, TextInput, Button, Text, StyleSheet, Image } from "react-native";
import { pulgadasACentimetros, centimetrosAPulgadas } from "../controllers/ConversionUnidadesController";
import { useRouter } from "expo-router";

export default function MenuScreen() {
  const [input, setInput] = useState("");
  const [resultado, setResultado] = useState("");
  const router = useRouter();

  const convertirPC = async () => {
    const res = await pulgadasACentimetros(input);
    setResultado(`${input} pulgadas = ${res} cm`);
  };

  const convertirCP = async () => {
    const res = await centimetrosAPulgadas(input);
    setResultado(`${input} cm = ${res} pulgadas`);
  };

  const logout = () => {
    router.replace("/views/LoginScreen");
  };

  return (
    <View style={styles.container}>
      <Image source={require("@/assets/images/monster.jpg")} style={styles.image} />
      <TextInput
        placeholder="Ingrese valor"
        keyboardType="numeric"
        value={input}
        onChangeText={setInput}
        style={styles.input}
      />
      <View style={styles.button}>
        <Button title="Pulgadas a Centímetros" onPress={convertirPC} color="#34C759" />
      </View>
      <View style={styles.button}>
        <Button title="Centímetros a Pulgadas" onPress={convertirCP} color="#FF9500" />
      </View>
      {resultado ? <Text style={styles.result}>{resultado}</Text> : null}
      <View style={[styles.button, { marginTop: 20 }]}>
        <Button title="Cerrar sesión" color="#FF3B30" onPress={logout} />
      </View>
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
    marginVertical: 5,
  },
  result: {
    marginTop: 20,
    fontSize: 16,
    fontWeight: "bold",
    color: "#333",
  },
});
