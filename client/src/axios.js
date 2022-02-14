import axios from "axios";

const instance = axios.create();

if (process.env.NODE_ENV === "production") {
  const BASE_URL = process.env.REACT_APP_BASE_URL;
  instance.defaults.baseURL = BASE_URL;
}

export default instance;
