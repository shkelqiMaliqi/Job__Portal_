import React from 'react';
import axios from 'axios';
import { Button } from 'react-bootstrap';

const DeleteUser = ({ userId, onDelete }) => {
  const handleDelete = async () => {
    try {
      const response = await axios.delete(`https://localhost:7263/api/Users/${userId}`);
      if (response.data) {
        console.log('User deleted successfully');
        onDelete(); 
      } else {
        console.error('Failed to delete user');
      }
    } catch (error) {
      console.error('Error deleting user:', error);
    }
  };

  return (
    <div className="container mt-4">
      <h2>Delete User</h2>
      <p>Are you sure you want to delete your account?</p>
      <Button variant='danger' onClick={handleDelete}>Delete</Button>
    </div>
  );
};

export default DeleteUser;
