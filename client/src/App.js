import "./App.css";
import { useState, useEffect } from "react";
import axios from "./axios";
import { Link } from "react-router-dom";

function App() {
  const [topics, setTopics] = useState([]);
  const [input, setInput] = useState("");

  const fetch = () => {
    axios.get("/topics").then((res) => {
      setTopics(res.data);
    });
  };

  const post = () => {
    axios.post("/topics", { name: input }).then(() => {
      fetch();
    });
  };

  useEffect(() => {
    fetch();
  }, []);

  return (
    <div className="App">
      <h1>puntossensibless</h1>
      {topics.map((item) => (
        <p key={item.createdOn}>
          <Link to={`/${item.name}`}>{item.name}</Link>
        </p>
      ))}
      <div>
        <input value={input} onChange={(e) => setInput(e.target.value)} />
        <button onClick={post}>+</button>
      </div>
    </div>
  );
}

export default App;
