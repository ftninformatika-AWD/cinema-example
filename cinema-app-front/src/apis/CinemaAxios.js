import axios from 'axios';

const CinemaAxios = axios.create({
  baseURL: 'http://localhost:5172/api',
  /* other custom settings */
});

export default CinemaAxios;
