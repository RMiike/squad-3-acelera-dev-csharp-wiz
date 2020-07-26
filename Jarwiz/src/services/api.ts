import axios from 'axios';

const api = axios.create({
  // baseURL: 'https://centraldeerrowebapi20200718183730.azurewebsites.net/v1/',

  baseURL: 'https://aceleradev-wiz-codenation.azurewebsites.net/v1/',

});

export default api;
