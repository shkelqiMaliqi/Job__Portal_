import React from 'react';
import axios from 'axios';

const LoggedIn = ({ user, onLogout }) => {
  const handleLogout = async () => {
    try {
      await axios.post('https://localhost:7263/api/Users/logout');
     
      onLogout();
    } catch (error) {
      console.error('Logout error:', error);
    }
  };

  return (
    <div className='loggedIn_div'>
      <h2 className='loggedIn_intro'>Welcome back, {user.U_Email} !</h2>
      <button className='logout_button' onClick={handleLogout}>Logout</button>
    </div>
  );
};

export default LoggedIn;
