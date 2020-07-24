import axios from 'axios';

const api = axios.create({
  // baseURL: 'https://centraldeerrowebapi20200718183730.azurewebsites.net/v1/',
  baseURL: 'http://localhost:49926/v1/',
});

export default api;
