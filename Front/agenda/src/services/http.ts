import axios, { AxiosInstance } from "axios";

const api: AxiosInstance = axios.create({
  baseURL: "https://localhost:7208",
  headers: {
    'Content-type': 'application/json'
  }
});

export default api;