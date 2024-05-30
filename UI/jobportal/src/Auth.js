import { decode as jwt_decode } from 'jwt-decode';


export const setToken = (token) => {
  localStorage.setItem('jwtToken', token);
};

export const getToken = () => {
  return localStorage.getItem('jwtToken');
};

export const removeToken = () => {
  localStorage.removeItem('jwtToken');
};

export const getUserFromToken = () => {
  const token = getToken();
  if (token) {
    return jwt_decode(token);
  }
  return null;
};
