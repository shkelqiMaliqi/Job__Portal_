/*
import jwt_decode from 'jwt-decode';

const Auth = {
  setToken: (token) => {
    localStorage.setItem('jwtToken', token);
  },
  
  getToken: () => {
    return localStorage.getItem('jwtToken');
  },
  
  removeToken: () => {
    localStorage.removeItem('jwtToken');
  },
  
  getUserFromToken: () => {
    const token = Auth.getToken();
    if (token) {
      return jwt_decode(token); // Use the correct named import
    }
    return null;
  }
};

export default Auth;
export const { setToken, getToken, removeToken, getUserFromToken } = Auth;
*/