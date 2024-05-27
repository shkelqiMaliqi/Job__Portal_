import React, { useState, useEffect } from 'react';
import { Button, Form } from 'react-bootstrap';
import axios from 'axios';
import { Link } from 'react-router-dom';

const Profile = ({ user, onLogout }) => {
  const [editMode, setEditMode] = useState(false);
  const [userData, setUserData] = useState({ ...user });

  useEffect(() => {
    fetchUserData(); // Fetch user data on component mount
  }, []);

  const fetchUserData = async () => {
    try {
      const response = await axios.get(`https://localhost:7263/api/users/${user.U_Id}`);
      setUserData(response.data);
    } catch (error) {
      console.error('Error fetching user data:', error);
    }
  };

  const handleEdit = () => {
    setEditMode(true);
  };

  const handleCancel = () => {
    setEditMode(false);
    fetchUserData(); 
  };

  const handleUpdate = async () => {
    try {
      await axios.put(`https://localhost:7263/api/users/${userData.U_Id}`, userData);
      setEditMode(false);
      
    } catch (error) {
      console.error('Error updating user data:', error);
    }
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setUserData({ ...userData, [name]: value });
  };

  return (
    <div className='container mt-4'>
      <div className='d-flex justify-content-between align-items-center mb-4'>
        <h2>Profile</h2>
        <Button variant='danger' onClick={onLogout}>Logout</Button>
      </div>

      {editMode ? (
        <Form>
          <Form.Group className='mb-3'>
            <Form.Label>Name</Form.Label>
            <Form.Control
              type='text'
              name='U_Name'
              value={userData.U_Name}
              onChange={handleChange}
            />
          </Form.Group>
          <Form.Group className='mb-3'>
            <Form.Label>Surname</Form.Label>
            <Form.Control
              type='text'
              name='U_Surname'
              value={userData.U_Surname}
              onChange={handleChange}
            />
          </Form.Group>
          <Form.Group className='mb-3'>
            <Form.Label>Email</Form.Label>
            <Form.Control
              type='email'
              name='U_Email'
              value={userData.U_Email}
              onChange={handleChange}
            />
          </Form.Group>
          <Form.Group className='mb-3'>
            <Form.Label>Username</Form.Label>
            <Form.Control
              type='text'
              name='U_Username'
              value={userData.U_Username}
              onChange={handleChange}
            />
          </Form.Group>
          <Form.Group className='mb-3'>
            <Form.Label>Phone</Form.Label>
            <Form.Control
              type='text'
              name='U_Phone'
              value={userData.U_Phone}
              onChange={handleChange}
            />
          </Form.Group>

          <Button variant='primary' onClick={handleUpdate}>
            Save Changes
          </Button>{' '}
          <Button variant='secondary' onClick={handleCancel}>
            Cancel
          </Button>
        </Form>
      ) : (
        <div>
          <div className='container_profile mb-7'>
            <h3>Welcome, {userData.U_Name}!</h3>
            <p>Email: {userData.U_Email}</p>
            <p>Username: {userData.U_Username}</p>
            <p>Phone: {userData.U_Phone}</p>
          </div>
          <Button variant='primary' onClick={handleEdit}>
            Edit Profile
          </Button>{' '}
          <Link to='/cv' className='btn_cv'>
            Create CV
          </Link>
        </div>
      )}
    </div>
  );
};

export default Profile;
