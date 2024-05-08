import React, { useState } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom'; // Assuming you're using React Router


import LoggedIn from './LoggedIn';

const Profile = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const [loggedIn, setLoggedIn] = useState(false);
  const [userData, setUserData] = useState(null);

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.post('https://localhost:7263/api/Users/login', {
        U_Email: email,
        U_Password: password,
      });
      console.log('Login successful!');
      console.log('User:', response.data);

      setLoggedIn(true);
      setUserData(response.data);
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
      console.log('Logged out successfully');
    } catch (error) {
      console.error('Logout error:', error);
    }
  };

  return (
    <div className="profile-container">
      {!loggedIn ? (
        <>
          <h2 className='login_intro'>Login</h2>
          {error && <p className="error">{error}</p>}
          <form onSubmit={handleSubmit}>
            <div>
              <label className='login_labels'>Email</label>
              <input 
                type="text"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                className="input-field"
              />
            </div>
            <div>
              <label className='login_labels'>Password</label>
              <input
                type="password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                className="input-field"
              />
            </div>
            <button type="submit" className="login-button">Sign In</button>
          </form>
          <p className="register-link">Don't have an account? <Link className='register_link' to="/register">Sign Up</Link></p>
        </>
      ) : (
        <LoggedIn user={userData} onLogout={handleLogout} />
      )}
    </div>
  );
};

export default Profile;
