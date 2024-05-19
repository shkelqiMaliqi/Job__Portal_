import React, { useState, useEffect } from 'react';
import axios from 'axios';
import LoggedIn from './LoggedIn';

const Profile = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const [loggedIn, setLoggedIn] = useState(false);
  const [userData, setUserData] = useState(null);

  useEffect(() => {
    const isLoggedIn = localStorage.getItem('isLoggedIn');
    if (isLoggedIn) {
      const userData = JSON.parse(localStorage.getItem('userData'));
      if (userData) {
        setLoggedIn(true);
        setUserData(userData);
      }
    }
  }, []);

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.post('https://localhost:7263/api/Users/login', {
        U_Email: email,
        U_Password: password,
      });
      setLoggedIn(true);
      setUserData(response.data);
      localStorage.setItem('isLoggedIn', true);
      localStorage.setItem('userData', JSON.stringify(response.data));
      const userResponse = await axios.get(`https://localhost:7263/api/Users/${response.data.UserId}`);
      setUserData(userResponse.data);
    } catch (error) {
      console.error('Login error:', error);
      setError('Invalid email or password');
    }
  };

  const handleLogout = async () => {
    try {
      await axios.post('https://localhost:7263/api/Users/logout');
      setLoggedIn(false);
      setUserData(null);
      localStorage.removeItem('isLoggedIn');
      localStorage.removeItem('userData');
    } catch (error) {
      console.error('Logout error:', error);
    }
  };

  return (
    <div className="profile-container">
      {!loggedIn ? (
        <form className="login-form" onSubmit={handleSubmit}>
          <h2>Login</h2>
          {error && <p className="error-message">{error}</p>}
          <div className="form-group">
            <label>Email:</label>
            <input
              type="text"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
            />
          </div>
          <div className="form-group">
            <label>Password:</label>
            <input
              type="password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
            />
          </div>
          <button type="submit">Login</button>
          <p className="text-center text-muted mt-5 mb-0">
            Don't have an account? <a href="/register" className="fw-bold text-body"><u>Register here</u></a>
          </p>
        </form>
      ) : (
        <LoggedIn user={userData} onLogout={handleLogout} />
      )}
    </div>
  );
};

export default Profile;
