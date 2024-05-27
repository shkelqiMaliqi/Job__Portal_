import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Form, Button } from 'react-bootstrap';

const UpdateUser = ({ userId, onCancel, onUpdate }) => {
  const [userData, setUserData] = useState({
    U_Name: '',
    U_Surname: '',
    U_Email: '',
    U_Username: '',
    U_Phone: '',
    U_Password: '',
  });

  useEffect(() => {
    fetchUserData();
  }, []);

  const fetchUserData = async () => {
    try {
      const response = await axios.get(`https://localhost:7263/api/Users/${userId}`);
      if (response.data) {
        setUserData(response.data);
      } else {
        console.error('User data not found');
      }
    } catch (error) {
      console.error('Error fetching user data:', error);
    }
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setUserData({ ...userData, [name]: value });
  };

  const handleUpdate = async () => {
    try {
      const response = await axios.put(`https://localhost:7263/api/Users/${userId}`, userData);
      if (response.status === 200) {
        console.log('User updated successfully');
        onUpdate(); // Callback to handle successful update
      } else {
        console.error('Failed to update user');
      }
    } catch (error) {
      console.error('Error updating user:', error);
    }
  };

  return (
    <div className="container mt-4">
      <h2>Update User Details</h2>
      <Form>
        <Form.Group controlId='formName'>
          <Form.Label>Name:</Form.Label>
          <Form.Control type='text' name='U_Name' value={userData.U_Name} onChange={handleChange} />
        </Form.Group>

        <Form.Group controlId='formSurname'>
          <Form.Label>Surname:</Form.Label>
          <Form.Control type='text' name='U_Surname' value={userData.U_Surname} onChange={handleChange} />
        </Form.Group>

        <Form.Group controlId='formEmail'>
          <Form.Label>Email:</Form.Label>
          <Form.Control type='email' name='U_Email' value={userData.U_Email} onChange={handleChange} disabled />
        </Form.Group>

        <Form.Group controlId='formUsername'>
          <Form.Label>Username:</Form.Label>
          <Form.Control type='text' name='U_Username' value={userData.U_Username} onChange={handleChange} />
        </Form.Group>

        <Form.Group controlId='formPhone'>
          <Form.Label>Phone:</Form.Label>
          <Form.Control type='text' name='U_Phone' value={userData.U_Phone} onChange={handleChange} />
        </Form.Group>

        <Form.Group controlId='formPassword'>
          <Form.Label>Password:</Form.Label>
          <Form.Control type='password' name='U_Password' value={userData.U_Password} onChange={handleChange} />
        </Form.Group>

        <Button variant='primary' onClick={handleUpdate}>Update</Button>
      </Form>
    </div>
  );
};

export default UpdateUser;
