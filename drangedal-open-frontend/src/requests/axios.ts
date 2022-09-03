// Default config options
import axios from "axios";
import { store } from "../store";


const defaultOptions = {
  baseURL: "http://localhost:5000/api/v1",
  headers: {
    'Content-Type': 'application/json',
  },
};

// Create instance
let instance = axios.create(defaultOptions);
// Set the AUTH token for any request
instance.interceptors.request.use(function (config) {
  const token = store.state.token
  if(config.headers)
    config.headers.Authorization =  token ? `Bearer ${token}` : '';
  return config;
});

export default instance
