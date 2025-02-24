import React, { useEffect, useState } from "react";
import axios from "axios";

const API_BASE_URL = "http://localhost:5001";

const App = () => {
  const [halak, setHalak] = useState([]);
  const [tavak, setTavak] = useState([]);
  const [horgaszok, setHorgaszok] = useState([]);
  const [fogasok, setFogasok] = useState([]);

  useEffect(() => {
    fetchData("/halak", setHalak);
    fetchData("/tavak", setTavak);
    fetchData("/horgaszok", setHorgaszok);
    fetchData("/fogasok", setFogasok);
  }, []);

  const fetchData = async (endpoint, setter) => {
    try {
      const response = await axios.get(`${API_BASE_URL}${endpoint}`);
      setter(response.data);
    } catch (error) {
      console.error(`Hiba a ${endpoint} lekérésekor:`, error);
    }
  };

  return (
    <div>
      <h1>Halas Adatkezelő</h1>
      <h2>Halak</h2>
      <pre>{JSON.stringify(halak, null, 2)}</pre>
      <h2>Tavak</h2>
      <pre>{JSON.stringify(tavak, null, 2)}</pre>
      <h2>Horgászok</h2>
      <pre>{JSON.stringify(horgaszok, null, 2)}</pre>
      <h2>Fogások</h2>
      <pre>{JSON.stringify(fogasok, null, 2)}</pre>
    </div>
  );
};

export default App;
